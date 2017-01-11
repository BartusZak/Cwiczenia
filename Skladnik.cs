using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukiernia
{
    class Skladnik:IComparable<Skladnik>
    {
        private string nazwaSkladnika;
        private string Ilosc;
        private double cenaSkladnika;
        public Skladnik() { }
        public Skladnik(string nazwaSkladnika,string Ilosc,double cenaSkladnika)
        {
            this.nazwaSkladnika = nazwaSkladnika;
            this.Ilosc = Ilosc;
            this.cenaSkladnika = cenaSkladnika;
        }
        public override string ToString()
        {
            return "Nazwa: " + nazwaSkladnika + ",Ilość :" + Ilosc + ", Cena: " + cenaSkladnika+"\n";
        }
        public double zwracamCene()
        {
            return cenaSkladnika;
        }
        public int CompareTo(Skladnik other)
        {
            if (this.nazwaSkladnika == other.nazwaSkladnika)
            {
                return this.nazwaSkladnika.CompareTo(other.nazwaSkladnika);
            }
            else
                return other.nazwaSkladnika.CompareTo(this.nazwaSkladnika);
        }
    }
}
