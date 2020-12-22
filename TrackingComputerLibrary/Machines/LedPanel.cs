using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingComputerLibrary.Machines
{
    public class LedPanel :IMachine
    {
        private string _message;
        public string Type { get; } = "LedPanel";
        public string Name { get; set; }
        public string Message 
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                GetCurrentStatus();
            }
        }
        public string Id { get; } = Guid.NewGuid().ToString();

        public LedPanel(string mName, string mMessage)
        {
            Name = mName;
            Message = mMessage;
        }

        public event EventHandler StateChanged;

        protected virtual void GetCurrentStatus()
        {
            if (StateChanged != null) StateChanged(this, EventArgs.Empty);
            Console.WriteLine($"Current status of {Name} is: {_message}");
        }
    }
}
