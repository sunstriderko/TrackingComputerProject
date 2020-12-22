using System;
using System.Collections.Generic;
using System.Text;
using TrackingComputerLibrary.Machines;

namespace TrackingComputerLibrary
{
    public class Building
    {
        public string Name { get; set; }

        public List<IMachine> MachinesInBuilding { get; set; }

        public Building(string mName)
        {
            Name = mName;
        }
    }
}
