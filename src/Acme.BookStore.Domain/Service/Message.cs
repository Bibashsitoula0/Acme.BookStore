using System;
using System.Collections.Generic;
using System.Text;


namespace Acme.BookStore.MessageHandler
{
    public static class Message
    {
        public static Dto.Response<T> SucessWithData<T>(string message, T data)
        {
            var response = new Dto.Response<T>
            {
                Message = message,
                Status = "Sucess",
                Data = data
            };

            return response;
        }
        public static Dto.Response<T> Error<T>(string message, T data)
        {

            return new Dto.Response<T>
            {
                Message = message,
                Status = "Error"
            };
        }


        public static Dto.Response<T> Sucess<T>(string message, T data)
        {
            var response = new Dto.Response<T>
            {
                Message = message,
                Status = "Sucess",
            };

            return response;
        }
    }
}
