/***
 * FileName: Server.cs
 * Purpose: Concrete class of AbstractServer
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/

using System;
using System.Collections.Generic;

namespace Assi3
{
    class Server : AbstractServer
    {
        
        public Route mainRoute;
        private Request thisRequest;

        public Server()
        {
            Route a = new MultiplyRoute("/mul");
            Route b = new Multiply4Route("/mul/4", a);
            Route c = new AddRoute("/add",b);
            mainRoute = c;

        }
        public bool Accept(Query query)
        {
            return query.Visit(this);
        }


        public bool IsBusy()
        {
            if (this.thisRequest != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public void HandleRequest(Request r)
        {
            this.thisRequest = r;
        }

       
        //print the neccessary thing for server.
        public void RouteProcess()
        {
            if (this.thisRequest == null)
            {
                Console.WriteLine("No work to do.");

            }
            else
            {
                int num = this.thisRequest.Execute(this.mainRoute);
                Console.WriteLine("Path:\t" + this.thisRequest.Route);
                Console.WriteLine("Input:\t" + this.thisRequest.Payload.ToString());
                Console.WriteLine("Result:\t" + num.ToString());
                this.thisRequest = (Request)null;
            }
        }

    }

}
