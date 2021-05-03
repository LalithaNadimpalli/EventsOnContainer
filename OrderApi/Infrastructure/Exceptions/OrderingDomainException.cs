﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Infrastructure.Exceptions
{
    public class OrderingDomainException : Exception
    {
        public OrderingDomainException() { }

        public OrderingDomainException(string message) : base(message) { }
        public OrderingDomainException(string message, Exception exception) : base(message, exception) { }
    }
}