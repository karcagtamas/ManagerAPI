using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagerAPI.Services.Services
{
    /// <inheritdoc />
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;
        private readonly IUtilsService _utilsService;

        /// <summary>
        /// Injector Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="utilsService">Utils Service</param>
        public LoggerService(ILogger<LoggerService> logger, IUtilsService utilsService)
        {
            this._logger = logger;
            this._utilsService = utilsService;
        }

        /// <inheritdoc />
        public string AddUserToMessage(string message, User user)
        {
            return $"Invalid action for user {user.UserName} ({user.Id}): {message}";
        }

        /// <inheritdoc />
        public void LogError(Exception e)
        {
            this._logger.LogError(e.Message);
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, int id, object entity)
        {
            this.LogInformation(user, service, action, id.ToString(), entity);
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, int id)
        {
            this.LogInformation(user, service, action, id, null);
        }

        /// <inheritdoc />
        public ErrorResponse ExceptionToResponse(Exception e, params Exception[] list)
        {
            foreach (var error in list)
            {
                this.LogError(error);
            }

            this.LogError(e);
            return new ErrorResponse(e);
        }

        /// <inheritdoc />
        public MessageException LogInvalidThings(User user, string service, string thing, string message)
        {
            string end = $"Invalid {thing}";
            this._logger.LogError($"{this._utilsService.UserDisplay(user)}: {service} - {end}");
            return new MessageException(message);
        }

        /// <inheritdoc />
        public MessageException LogAnonymousInvalidThings(string service, string thing, string message)
        {
            string end = $"Invalid {thing}";
            this._logger.LogError($"Anonymous: {service} - {end}");
            return new MessageException(message);
        }


        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, string id)
        {
            this.LogInformation(user, service, action, id, null);
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, string id, object entity)
        {
            this._logger.LogInformation(
                $"{this._utilsService.UserDisplay(user)}: {service} - {action.ToUpper()} - with id: {id}");
            if (entity != null)
            {
                this._logger.LogInformation(entity.ToString());
            }
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, List<string> ids, object entity)
        {
            this.LogInformation(user, service, action, string.Join(", ", ids), entity);
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, List<string> ids)
        {
            this.LogInformation(user, service, action, ids, null);
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, List<int> ids, object entity)
        {
            this.LogInformation(user, service, action, ids.Select(x => x.ToString()).ToList(), entity);
        }

        /// <inheritdoc />
        public void LogInformation(User user, string service, string action, List<int> ids)
        {
            this.LogInformation(user, service, action, ids, null);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, int id)
        {
            this.LogAnonymousInformation(service, action, id, null);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, int id, object entity)
        {
            this.LogAnonymousInformation(service, action, id.ToString(), entity);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, string id)
        {
            this.LogAnonymousInformation(service, action, id, null);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, string id, object entity)
        {
            this._logger.LogInformation($"Anonymous: {service} - {action.ToUpper()} - with id: {id}");
            if (entity != null)
            {
                this._logger.LogInformation(entity.ToString());
            }
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, List<string> ids)
        {
            this.LogAnonymousInformation(service, action, ids, null);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, List<string> ids, object entity)
        {
            this.LogAnonymousInformation(service, action, string.Join(", ", ids), entity);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, List<int> ids)
        {
            this.LogAnonymousInformation(service, action, ids, null);
        }

        /// <inheritdoc />
        public void LogAnonymousInformation(string service, string action, List<int> ids, object entity)
        {
            this.LogAnonymousInformation(service, action, ids.Select(x => x.ToString()).ToList(), entity);
        }
    }
}