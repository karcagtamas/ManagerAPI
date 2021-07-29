namespace ManagerAPI.Domain.Enums
{
    /// <summary>
    /// System notification types
    /// </summary>
    public enum SystemNotificationType
    {
        /// <summary>
        /// Login
        /// </summary>
        Login = 1,

        /// <summary>
        /// Registration
        /// </summary>
        Registration = 2,

        /// <summary>
        /// Logout
        /// </summary>
        Logout = 3,

        /// <summary>
        /// Profile updated
        /// </summary>
        MyProfileUpdated = 4,

        /// <summary>
        /// Message arrived
        /// </summary>
        MessageArrived = 5,

        /// <summary>
        /// Task added
        /// </summary>
        AddTask = 6,

        /// <summary>
        /// Task deleted
        /// </summary>
        DeleteTask = 7,

        /// <summary>
        /// Task updated
        /// </summary>
        UpdateTask = 8,

        /// <summary>
        /// Password changed
        /// </summary>
        PasswordChanged = 39,

        /// <summary>
        /// Profile image changed
        /// </summary>
        ProfileImageChanged = 40,

        /// <summary>
        /// Username changed
        /// </summary>
        UsernameChanged = 41,

        /// <summary>
        /// Profile disabled
        /// </summary>
        ProfileDisabled = 42,

        /// <summary>
        /// Friend request received
        /// </summary>
        FriendRequestReceived = 43,

        /// <summary>
        /// Friend request sent
        /// </summary>
        FriendRequestSent = 44,

        /// <summary>
        /// Friend request accepted
        /// </summary>
        FriendRequestAccepted = 45,

        /// <summary>
        /// Friend request declined
        /// </summary>
        FriendRequestDeclined = 46,

        /// <summary>
        /// New friend added
        /// </summary>
        YouHasANewFriend = 47,

        /// <summary>
        /// Friend removed
        /// </summary>
        FriendRemoved = 48,

        /// <summary>
        /// News added
        /// </summary>
        AddNews = 49,

        /// <summary>
        /// News updated
        /// </summary>
        UpdateNews = 50,

        /// <summary>
        /// News deleted
        /// </summary>
        DeleteNews = 51,

        /// <summary>
        /// Messaged added
        /// </summary>
        AddMessage = 61,

        /// <summary>
        /// Message deleted
        /// </summary>
        DeleteMessage = 62,

        /// <summary>
        /// Messaged updated
        /// </summary>
        UpdateMessage = 63,

        /// <summary>
        /// Gender added
        /// </summary>
        AddGender = 64,

        /// <summary>
        /// Gender deleted
        /// </summary>
        DeleteGender = 65,

        /// <summary>
        /// Gender updated
        /// </summary>
        UpdateGender = 66
    }
}