using ManagerAPI.Domain.Entities;
using ManagerAPI.Shared.Models;
using System;
using System.Collections.Generic;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Logger Service
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Log error to the console
        /// </summary>
        /// <param name="e">Exception for logging</param>
        /// <returns>Error Response from Exception</returns>
        void LogError(Exception e);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Entity Id</param>
        void LogInformation(User user, string service, string action, int id);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Entity Id</param>
        /// <param name="entity">Connected entity object</param>
        void LogInformation(User user, string service, string action, int id, object entity);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Id of element</param>
        void LogInformation(User user, string service, string action, string id);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Id of element</param>
        /// <param name="entity">Connected entity object</param>
        void LogInformation(User user, string service, string action, string id, object entity);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Ids of elements</param>
        void LogInformation(User user, string service, string action, List<string> ids);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Ids of elements</param>
        /// <param name="entity">Connected entity object</param>
        void LogInformation(User user, string service, string action, List<string> ids, object entity);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Ids of elements</param>
        void LogInformation(User user, string service, string action, List<int> ids);

        /// <summary>
        /// Log executed events
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Ids of elements</param>
        /// <param name="entity">Connected entity object</param>
        void LogInformation(User user, string service, string action, List<int> ids, object entity);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Ids of elements</param>
        void LogAnonymousInformation(string service, string action, int id);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Id of element</param>
        /// <param name="entity">Entity</param>
        void LogAnonymousInformation(string service, string action, int id, object entity);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Id of element</param>
        void LogAnonymousInformation(string service, string action, string id);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="id">Id of element</param>
        /// <param name="entity">Entity</param>
        void LogAnonymousInformation(string service, string action, string id, object entity);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Id list of elements</param>
        void LogAnonymousInformation(string service, string action, List<string> ids);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Id list of elements</param>
        /// <param name="entity">Entity</param>
        void LogAnonymousInformation(string service, string action, List<string> ids, object entity);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Id list of elements</param>
        void LogAnonymousInformation(string service, string action, List<int> ids);

        /// <summary>
        /// Log executed events as anonymous
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="action">Executed action</param>
        /// <param name="ids">Id list of elements</param>
        /// <param name="entity">Entity</param>
        void LogAnonymousInformation(string service, string action, List<int> ids, object entity);

        /// <summary>
        /// Log invalid things.
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="service">Service's name</param>
        /// <param name="thing">Thing</param>
        /// <param name="message">Log message</param>
        /// <returns>Invalid message</returns>
        MessageException LogInvalidThings(User user, string service, string thing, string message);

        /// <summary>
        /// Log invalid things.
        /// </summary>
        /// <param name="service">Service's name</param>
        /// <param name="thing">Thing</param>
        /// <param name="message">Log message</param>
        /// <returns>Invalid message</returns>
        MessageException LogAnonymousInvalidThings(string service, string thing, string message);

        /// <summary>
        /// Join user to the given message
        /// </summary>
        /// <param name="message">Source message</param>
        /// <param name="user">User for join</param>
        /// <returns>Joined message</returns>
        string AddUserToMessage(string message, User user);

        /// <summary>
        /// Exception to Error response.
        /// To API sending.
        /// </summary>
        /// <param name="e">Error</param>
        /// <param name="list">Other exception list</param>
        /// <returns>API Error response</returns>
        ErrorResponse ExceptionToResponse(Exception e, params Exception[] list);
    }
}