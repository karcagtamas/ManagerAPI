using AutoMapper;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Services.Services.Interfaces;

namespace ManagerAPI.Services.Services;

/// <inheritdoc />
public class GenderService : NotificationRepository<Gender, int, SystemNotificationType>, IGenderService
{
    /// <summary>
    /// Injector Constructor
    /// </summary>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="notificationService">Notification Service</param>
    /// <param name="context">Database Context</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="loggerService">Logger Service</param>
    public GenderService(IUtilsService utilsService, INotificationService notificationService,
        DatabaseContext context, IMapper mapper, ILoggerService loggerService) : base(context, loggerService,
        utilsService, mapper, notificationService, "Gender",
        new NotificationArguments
        {
            DeleteArguments = new List<string> { "Name" },
            CreateArguments = new List<string> { "Name" },
            UpdateArguments = new List<string> { "Name" }
        })
    {
    }
}
