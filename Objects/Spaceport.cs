using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolution.Objects
{
    internal class Spaceport
    {
        public required string Region { get; set; }
        public required string Country { get; set; }
        public float Latitude { get; set; }     //not neccesery a higher precision

        public string? BestConditions { get; set; }
    }
}
