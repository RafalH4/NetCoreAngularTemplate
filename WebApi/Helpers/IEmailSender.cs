﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public interface IEmailSender
    {
        public void SendConfirmationEmain(string firstName, string secondName, string email, Guid id);
    }
}
