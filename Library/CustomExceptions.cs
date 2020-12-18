using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PaymentServiceException : Exception
    {
        private readonly string _innerData;
        public PaymentServiceException(string innerData) : this("Smth wrong with service transactions", innerData) { }
        public PaymentServiceException(string message, string innerData) : base(message) { _innerData = innerData; }
    }

    public class LimitExceededException : PaymentServiceException
    {
        private readonly string _innerData;
        public LimitExceededException(string innerData) : this("Smth wrong with service transactions", innerData) { }
        public LimitExceededException(string message, string innerData) : base(message) { _innerData = innerData; }
    }
    public class InsufficientFundsException : PaymentServiceException
    {
        private readonly string _innerData;
        public InsufficientFundsException(string innerData) : this("Smth wrong with service transactions", innerData) { }
        public InsufficientFundsException(string message, string innerData) : base(message) { _innerData = innerData; }
    }
}
