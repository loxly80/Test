using System;
using System.Collections.Generic;
using System.Text;

namespace Kostky_IT1B
{
    public class Kostka
    {
        private int hodnota;

        public int Hodnota { get => hodnota; set => hodnota = value; }

        public Kostka()
        {
            Hod();
        }

        public void Hod()
        {
            Random random = new Random();
            hodnota = random.Next(1, 7);            
        }
    }
}
