/***
 * FileName: AddRoute.cs
 * Purpose: this is a concrete class of route
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/

using System;

namespace Assi3
{
    class AddRoute : Route
    {
        public AddRoute(string path, Route next = null) : base(path, next) {}

        public override int Handle(int payload)
        {
            return payload + 8;
        }
    }
}
