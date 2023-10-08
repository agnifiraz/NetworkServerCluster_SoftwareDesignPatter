/***
 * FileName: Route.cs
 * Purpose: this is the class of handle the routes for server. 
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/

using System;

namespace Assi3
{
     class Route
    {
        private Route Next;
        private string Path;

        public Route(string path, Route next = null)
        {
            this.Path = path;
            this.Next = next;
        }

        public virtual int Handle(int value)
        {
            return 404;
        }
      
        public int CheckHandle(Request request)
        {
            string path = this.Path.ToLower().Trim();
            string route = request.Route.ToLower().Trim();

            if (path == route)
            {
                return this.Handle(request.Payload);
            }
            else if (this.Next != null)
            {
                return this.Next.CheckHandle(request);
            }
            else
            {
                return 404;
            }
        }

    }
}
