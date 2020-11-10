using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ResponseMessage<T>
    {
        public string Message { get; set; }

        public T Response { get; set;  }
    }
}
