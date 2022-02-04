using FrameworkPart.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.Contexts
{
    internal class DataSeed
    {
        internal Category[] Categories
        {
            get
            {
                return new Category[]
                {
                    new Category{ Id = -1, Name = "Electronics" },
                    new Category{ Id = -2, Name = "Vehicles" },
                    new Category{ Id = -3, Name = "Accessories" }
                };
            }
        }
    }
}
