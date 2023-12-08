using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Dto
{

    public class Response
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }

    }
    public class Response<T>
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public T Data { get; set; }
    }

   
}
