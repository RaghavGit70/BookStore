﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertconfiguration;

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertconfiguration)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration;

        }
        public string GetName()
        {
            return _newBookAlertconfiguration.CurrentValue.BookName;
        }
    }
}