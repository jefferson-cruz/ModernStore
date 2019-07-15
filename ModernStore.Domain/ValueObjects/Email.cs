﻿using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.ValueObjects
{
    public class Email :Notifiable
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address);
        }

        public string Address { get; private set; }
    }
}
