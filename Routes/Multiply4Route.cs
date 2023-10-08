/***
 * FileName: Multiply4Route.cs
 * Purpose: this is a concrete class of route
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/

using System;

namespace Assi3
{
    class Multiply4Route : Route
    {
        public Multiply4Route(string path, Route next = null) : base(path, next) {}
       
        public override int Handle(int payload)
        {
            return payload * 4;
        }
    }
}
