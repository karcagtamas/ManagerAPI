﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Client.Models;
using EventManager.Client.Models.Notifications;

namespace EventManager.Client.Services.Interfaces {
    public interface INotificationService {
        Task<List<NotificationDto>> GetMyNotifications ();
        Task<bool> SetUnReadsToRead (int[] ids);
        Task<int?> GetCountOfUnReadNotifications ();
    }
}