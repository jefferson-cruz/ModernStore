﻿using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}