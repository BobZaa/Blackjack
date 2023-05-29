using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hand
    {
        public Hand() { 
        private List<Kort> kort = new List<Kort>();

        public void LäggTillKort(Kort k)
        {
            kort.Add(k);
        }

        public int BeräknaVärde()
        {
            int värde = 0;
            int essar = 0;

            foreach (Kort k in kort)
            {
                värde += k.Värde;
                if (k.Valör == "Ess")
                {
                    essar++;
                }
            }

            while (värde > 21 && essar > 0)
            {
                värde -= 10;
                essar--;
            }

            return värde;
        }
    }
}
