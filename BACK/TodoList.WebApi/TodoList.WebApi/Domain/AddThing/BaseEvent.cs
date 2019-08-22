﻿using System;
using CQRSlite.Events;

namespace TodoList.WebApi.Domain.AddThing {
    public abstract class BaseEvent : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}