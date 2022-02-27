using AutoMapper;
using KarcagS.Common.Tools.Entities;
using KarcagS.Common.Tools.Repository;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAPI.Services.Repositories;

/// <inheritdoc />
public class NotificationRepository<T, TKey, TNotification> : MapperRepository<T, TKey>, INotificationRepository<T, TKey> where T : class, IEntity<TKey> where TNotification : Enum
{
    /// <summary>
    /// Notification Service
    /// </summary>
    protected readonly INotificationService NotificationService;
    private readonly NotificationArguments arguments;

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="context">Context</param>
    /// <param name="loggerService">Logger</param>
    /// <param name="utilsService">Utils</param>
    /// <param name="mapper">Mapper</param>
    /// <param name="notificationService">Notification Service</param>
    /// <param name="entity">Entity</param>
    /// <param name="arguments">Arguments</param>
    public NotificationRepository(DatabaseContext context, ILoggerService loggerService, IUtilsService utilsService, IMapper mapper, INotificationService notificationService, string entity, NotificationArguments arguments) : base(context, loggerService, utilsService, mapper, entity)
    {
        this.NotificationService = notificationService;
        this.arguments = arguments;
    }

    /// <inheritdoc />
    public override void Create(T entity)
    {
        base.Create(entity);
        try
        {
            var user = this.Utils.GetCurrentUser<User, string>();


            // Notification generate
            var args = DetermineArguments(arguments.CreateArguments, entity.GetType(), entity, user);

            NotificationService.AddNotificationByType(typeof(TNotification),
                Enum.Parse(typeof(TNotification), GetNotificationAction("add"), true), user,
                args.ToArray());
        }
        catch (Exception)
        {
        }
    }

    private string GetNotificationAction(string action)
    {
        return string.Join("",
            this.GetEvent(action).Split(" ").Select(x => char.ToUpper(x[0]) + x.Substring(1).ToLower()));
    }

    private static List<string> DetermineArguments(List<string> nameList, Type firstType, T entity, User user)
    {
        var args = new List<string>();

        foreach (string i in nameList)
        {
            string[] propList = i.Split(".");
            var lastType = firstType;
            object? lastEntity = entity;

            foreach (string propElement in propList)
            {
                // Special event for updater
                if (propElement == "CurrentUser")
                {
                    lastType = user.GetType();
                    lastEntity = user;
                }
                else
                {
                    // Get inner entity from entity
                    var prop = lastType.GetProperty(propElement);
                    if (prop != null)
                    {
                        lastEntity = prop.GetValue(lastEntity);

                        if (lastEntity != null)
                        {
                            lastType = lastEntity.GetType();
                        }
                    }
                }
            }

            // Last entity is primitive (writeable)
            if (lastEntity != null && lastType != null)
            {
                if (lastType == typeof(string))
                {
                    args.Add((string)lastEntity);
                }
                else if (lastType == typeof(DateTime))
                {
                    args.Add(((DateTime)lastEntity).ToLongDateString());
                }
                else if (lastType == typeof(int))
                {
                    args.Add(((int)lastEntity).ToString());
                }
                else if (lastType == typeof(decimal))
                {
                    args.Add(((decimal)lastEntity).ToString(CultureInfo.CurrentCulture));
                }
                else if (lastType == typeof(double))
                {
                    args.Add(((double)lastEntity).ToString(CultureInfo.CurrentCulture));
                }
                else
                {
                    args.Add("");
                }
            }
            else
            {
                args.Add("");
            }
        }

        return args;
    }


}
