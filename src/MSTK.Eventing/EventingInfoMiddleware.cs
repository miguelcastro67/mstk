﻿using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MSTK.Eventing
{
    public class EventingInfoMiddleware
    {
        private readonly RequestDelegate _Next;
        
        public EventingInfoMiddleware(RequestDelegate next)
        {
            this._Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do some request logic here.
            
            string uri = context.Request.Path;
            string verb = context.Request.Method;            

            await this._Next.Invoke(context).ConfigureAwait(false);

            // Do some response logic here.

            if (uri.IndexOf("/ping") == -1)
            {
                Console.WriteLine("{0}", DateTime.Now);
                Console.WriteLine("Call made to eventing service: {0}", uri);
            }
        }
    }
}
