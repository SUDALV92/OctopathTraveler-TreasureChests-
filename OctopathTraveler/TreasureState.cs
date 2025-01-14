﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class TreasureState
    {
        private string collected;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public TreasureState(uint address)
        {
            StringBuilder sb = new StringBuilder();
            uint readValue = 0;
            uint i = 0;
            do
            {
                readValue = SaveData.Instance().ReadNumber(address + i, 1);
                if (readValue != 5)
                {
                    sb.Append(readValue);
                    sb.Append(' ');
                }
                i++;
            }
            while (readValue != 5);

            var result = sb.ToString().TrimEnd();
            Collected = result;
            Name = address.ToString();
            //sorry i'm too lazy to make proper read of txt doctionary, because i only know two location names.
            switch (address)
            {
                case 1261893: Name = "Lizardmen's Den"; break;
                default:
                    break;
            }
        }

        public String Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Collected
        {
            get => collected;
            set
            {
                collected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Collected)));
            }
        }
    }
}
