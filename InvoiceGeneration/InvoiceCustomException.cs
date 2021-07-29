﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGeneration
{
    public class InvoiceCustomException:Exception
    {
        public string message;
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME,INVALID_RIDE_COUNT
        }
        public ExceptionType exceptionType;
        public InvoiceCustomException(ExceptionType type, string message) : base(message)
        {
            this.exceptionType = type;
        }
    }
}
