/***
 * FileName: Request.cs
 * Purpose: this is a concrete class with fake network request class
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/
using System;

namespace Assi3
{
    class Request : Command
    {
        public string Route;
        public int Payload;
        public Request(string route, int payload)
        {
            this.Route = route;
            this.Payload = payload;
        }

        public int Execute(Route route)
        {
            return route.CheckHandle(this);
        }

    }
}
