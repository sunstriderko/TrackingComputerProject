using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TrackingComputerLibrary.Machines
{
    public class CardReader : IMachine
    {

        private string _accessCardName;
        public string Type { get; } = "CardReader";
        public string Name
        {
            get
            {
                return _accessCardName;
            }
            set
            {
                _accessCardName = value;
                GetCurrentStatus();
            }
        }
        public string Id { get; } = Guid.NewGuid().ToString();
        public string AccessCardNumber { get; set; }

        public CardReader(string mName, string mAccessCardNumber)
        {
            if(ValidationCheck(mAccessCardNumber))
            {
                Name = mName;
                AccessCardNumber = ReverseBytesAndPad(mAccessCardNumber);          
            }
            else
            {
                Console.WriteLine("Card number is invalid!");
            }
        }
        public bool ValidationCheck(string model)
        {
            bool validation = false;

            if (model.Length % 2 == 0 && model.Length <= 16)
            {
                validation = model.All("0123456789abcdefABCDEF".Contains);
            }

            else
            {
                validation = false;
            }

            return validation;
        }

        public string ReverseBytesAndPad(string model)
        {
            string current = "";
            string result = "";
            int j = 0;

            for (int i = model.Length - 2; i >= 0; i -= 2, j += 2)
            {
                current = $"{model[i]}{model[i+1]}";
                result = result.Insert(j,current);
            }

            for (int i = 0; i < 16 - result.Length; )
            {
                result = result.Insert(0, "0");
            }

            return result;
        }


        public event EventHandler StateChanged;

        protected virtual void GetCurrentStatus()
        {
            if (StateChanged != null) StateChanged(this, EventArgs.Empty);
            Console.WriteLine($"Current status of {Name} is: {_accessCardName}");
        }
    }
}
