using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingComputerLibrary.Machines
{
    public class Door : IMachine
    {
        private State _status;
        public string Type { get; } = "Door";
        public string Name { get; set; }
        public string Id { get; } = Guid.NewGuid().ToString();

        public State Status { 
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                GetCurrentStatus();
            }
        }

        public Door(string mName, State mStatus)
        {
            Name = mName;
            Status = mStatus;
        }

        public event EventHandler StateChanged;

        protected virtual void GetCurrentStatus()
        {
            if (StateChanged != null) StateChanged(this, EventArgs.Empty);
            Console.WriteLine($"Current status of {Name} is: {_status}");
        }
    }

    public enum State
    {
        Locked,
        Open,
        OpenForTooLong,
        OpenForcibly,
    }
}
