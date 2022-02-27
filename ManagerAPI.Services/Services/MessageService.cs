using AutoMapper;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace ManagerAPI.Services.Services
{
    /// <summary>
    /// Message Service
    /// </summary>
    public class MessageService : NotificationRepository<Message, int, SystemNotificationType>, IMessageService
    {
        /// <summary>
        /// Injector Constructor
        /// </summary>
        /// <param name="utilsService">Utils Service</param>
        /// <param name="notificationService">Notification Service</param>
        /// <param name="context">Database Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="loggerService">Logger Service</param>
        public MessageService(IUtilsService utilsService, INotificationService notificationService,
            DatabaseContext context, IMapper mapper, ILoggerService loggerService) : base(context, loggerService,
            utilsService, mapper, notificationService, "Message",
            new NotificationArguments
            {
                DeleteArguments = new List<string>(),
                UpdateArguments = new List<string>(),
                CreateArguments = new List<string>()
            })
        {
        }

        /// <inheritdoc />
        public List<MessageDto> GetMessages(string friendId)
        {
            var user = this.Utils.GetCurrentUser<User, string>();

            var list = this.Mapper.Map<List<MessageDto>>(user.SentMessages.Where(x => x.Receiver.Id == friendId)
                .Union(user.ReceivedMessages.Where(x => x.Sender.Id == friendId)).OrderBy(x => x.Date).ToList()).Select(
                x =>
                {
                    x.IsMine = x.Sender == user.UserName;
                    return x;
                }).ToList();

            return list;
        }

        /// <inheritdoc />
        public void SendMessage(MessageModel model)
        {
            var user = this.Utils.GetCurrentUser<User, string>();
            var partner = Context.Set<User>().Find(model.PartnerId);

            if (partner == null)
            {
                throw new ServerException("Invalid message partner");
            }

            var message = new Message { SenderId = user.Id, ReceiverId = model.PartnerId, Text = model.Message };

            Create(message);
            Persist();

            this.NotificationService.AddSystemNotificationByType(SystemNotificationType.MessageArrived, partner,
                user.UserName);
        }
    }
}