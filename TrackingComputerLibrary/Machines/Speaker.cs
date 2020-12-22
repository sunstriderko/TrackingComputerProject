using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingComputerLibrary.Machines
{
    public class Speaker : IMachine
    {
        public SoundType _sound;
        public string Type { get;} = "Speaker";
        public string Name { get; set; }
        public string Id { get; } = Guid.NewGuid().ToString();
        public float Volume { get; set; }
        public SoundType Sound
        {
            get
            {
                return _sound;
            }

            set
            {
                _sound = value;
                GetCurrentStatus();
            }
        }           

        public Speaker(string mName, float mVolume, SoundType mSound)
        {
            Name = mName;
            Volume = mVolume;
            Sound = mSound;
        }

        public event EventHandler StateChanged;

        protected virtual void GetCurrentStatus()
        {
            if (StateChanged != null) StateChanged(this, EventArgs.Empty);
            Console.WriteLine($"Current status of {Name} is: {_sound}");
        }

    }
    public enum SoundType
    {
        None,
        Music,
        Alarm,
    }
}
