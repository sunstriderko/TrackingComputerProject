using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingComputerLibrary
{
    public interface IMachine
    {
        public string Type { get; }

        public string Id { get; }  

        public string Name { get; set; }

    }
}
