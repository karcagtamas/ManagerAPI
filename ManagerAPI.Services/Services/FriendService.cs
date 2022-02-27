using AutoMapper;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Enums;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace ManagerAPI.Services.Services;

/// <inheritdoc />
public class FriendService : IFriendService
{
    // Injects
    private readonly IUtilsService _utilsService;
    private readonly IMapper _mapper;
    private readonly DatabaseContext _context;
    private readonly INotificationService _notificationService;
    private readonly ILoggerService _loggerService;
    private readonly UserManager<User> _userManager;

    /// <summary>
    /// Injector Constructor
    /// </summary>
    /// <param name="utilsService">Utils Service</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="context">Database Context</param>
    /// <param name="notificationService">Notification Service</param>
    /// <param name="loggerService">Logger Service</param>
    /// <param name="userManager">User manager</param>
    public FriendService(IUtilsService utilsService, IMapper mapper, DatabaseContext context,
        INotificationService notificationService, ILoggerService loggerService, UserManager<User> userManager)
    {
        this._utilsService = utilsService;
        this._mapper = mapper;
        this._context = context;
        this._notificationService = notificationService;
        this._loggerService = loggerService;
        this._userManager = userManager;
    }

    /// <inheritdoc />
    public List<FriendRequestListDto> GetMyFriendRequests()
    {
        var user = this._utilsService.GetCurrentUser<User, string>();

        var list = this._mapper.Map<List<FriendRequestListDto>>(user.ReceivedFriendRequest.Where(x => x.Response == null)
            .OrderByDescending(x => x.SentDate).ToList());

        return list;
    }

    /// <inheritdoc />
    public List<FriendListDto> GetMyFriends()
    {
        var user = this._utilsService.GetCurrentUser<User, string>();

        var list = this._mapper.Map<List<FriendListDto>>(user.FriendListLeft.OrderBy(x => x.Friend.UserName).ToList());

        return list;
    }

    /// <inheritdoc />
    public void RemoveFriend(string friendId)
    {
        var user = this._utilsService.GetCurrentUser<User, string>();
        var friend = this._context.AppUsers.Find(friendId);

        var friends = this._context.Friends.Where(x =>
                x.User.Id == user.Id && x.Friend.Id == friendId || x.User.Id == friendId && x.Friend.Id == user.Id)
            .ToList();

        if (friends.Count == 0)
        {
            throw new ServerException("Invalid friend");
        }

        this._context.Friends.RemoveRange(friends);
        this._context.SaveChanges();

        this._notificationService.AddSystemNotificationByType(SystemNotificationType.FriendRemoved, user,
            friend?.UserName ?? string.Empty);
        this._notificationService.AddSystemNotificationByType(SystemNotificationType.FriendRemoved, friend,
            user.UserName);
    }

    /// <inheritdoc />
    public void SendFriendRequest(FriendRequestModel model)
    {
        var user = this._utilsService.GetCurrentUser<User, string>();

        if (user.UserName == model.DestinationUserName)
        {
            throw new ServerException("The target and the sender user is the same");
        }

        var destination = this._context.AppUsers.FirstOrDefault(x => x.UserName == model.DestinationUserName);

        if (destination == null)
        {
            throw new ServerException("The target does not exist");
        }

        if (this.HasFriendAlready(user, destination.Id))
        {
            throw new ServerException("The target is your friend already");
        }

        if (this.HasOpenFriendRequestAlready(user, destination.Id))
        {
            throw new ServerException("You have a request with this target");
        }

        var request = new FriendRequest
        {
            Message = model.Message,
            SenderId = user.Id,
            DestinationId = destination.Id
        };


        this._context.FriendRequests.Add(request);
        this._context.SaveChanges();

        this._notificationService.AddSystemNotificationByType(SystemNotificationType.FriendRequestSent, user,
            destination.UserName);
        this._notificationService.AddSystemNotificationByType(SystemNotificationType.FriendRequestReceived, destination,
            user.UserName);
    }

    /// <inheritdoc />
    public void SendFriendRequestResponse(FriendRequestResponseModel model)
    {
        var user = this._utilsService.GetCurrentUser<User, string>();

        var request = this._context.FriendRequests.Find(model.RequestId);

        if (request == null)
        {
            throw new ServerException("Missing request");
        }

        request.Response = model.Response;
        request.ResponseDate = DateTime.Now;
        this._context.FriendRequests.Update(request);
        this._context.SaveChanges();
        this._notificationService.AddSystemNotificationByType(
            model.Response
                ? SystemNotificationType.FriendRequestAccepted
                : SystemNotificationType.FriendRequestDeclined, request.Sender, user.UserName);

        if (model.Response)
        {
            var friend1 = new Friends { RequestId = model.RequestId, UserId = user.Id, FriendId = request.Sender.Id };
            this._context.Friends.Add(friend1);

            var friend2 = new Friends { RequestId = model.RequestId, UserId = request.Sender.Id, FriendId = user.Id };
            this._context.Friends.Add(friend2);

            this._context.SaveChanges();

            this._notificationService.AddSystemNotificationByType(SystemNotificationType.YouHasANewFriend, user,
                request.Sender.UserName);
            this._notificationService.AddSystemNotificationByType(SystemNotificationType.YouHasANewFriend,
                request.Sender, user.UserName);
        }
    }

    /// <summary>
    /// Check the user already has a friend with the given Id
    /// </summary>
    /// <param name="user">User</param>
    /// <param name="friendId">Friend's Id</param>
    /// <returns>User has this friend or not</returns>
    private bool HasFriendAlready(User user, string friendId)
    {
        return user.FriendListLeft.Any(x => x.FriendId == friendId);
    }

    /// <summary>
    /// Check the user already has opened friend request
    /// </summary>
    /// <param name="user">User</param>
    /// <param name="friendId">Friend's Id</param>
    /// <returns>User has friend request or not</returns>
    private bool HasOpenFriendRequestAlready(User user, string friendId)
    {
        return user.SentFriendRequest
                   .FirstOrDefault(x => x.DestinationId == friendId && x.Response == null) != null ||
               user.ReceivedFriendRequest
                   .FirstOrDefault(x => x.SenderId == friendId && x.Response == null) != null;
    }

    /// <inheritdoc />
    public async Task<FriendDataDto> GetFriendData(string friendId)
    {
        var user = this._utilsService.GetCurrentUser<User, string>();

        var friend = await this._context.AppUsers.FindAsync(friendId);

        if (friend == null)
        {
            throw new ServerException("Missing friend");
        }

        var friendDto = this._mapper.Map<FriendDataDto>(friend);
        var list = (await this._userManager.GetRolesAsync(user)).ToList();
        friendDto.Roles = this._context.AppRoles.OrderByDescending(x => x.AccessLevel).Where(x => list.Contains(x.Name))
            .Select(x => x.Name).ToList();
        return friendDto;
    }
}
