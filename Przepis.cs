using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukiernia
{
    class Przepis
    {
        private string Nazwa;
        private double Suma = 0;
        private List<Skladnik> Skladniki;
        private int czasPrzygotowania;
        public Przepis() { Skladniki = new List<Skladnik>(); }
        public void DodajSkladnik(string nazwaSkladnika,string Ilosc,double cenaSkladnika)
        {
            Suma += cenaSkladnika;
            Skladniki.Add(new Skladnik(nazwaSkladnika, Ilosc, cenaSkladnika));
        }
        public void UstawNazweICzas(string Nazwa,int czasPrzygotowania)
        {
            this.Nazwa = Nazwa;
            this.czasPrzygotowania = czasPrzygotowania;
        }
        public override string ToString()
        {
            string Text = "";
            if(Skladniki.Count>=0)
            {
                Skladniki.Sort();
                foreach(var element in Skladniki)
                {
                    Text+=element.ToString();
                }
                return Text+"\n"+"Suma: "+Suma;
            }
            else
            {
                return "";
            }
        }
        public bool CzyCzas()
        {
            if (czasPrzygotowania > 0 && czasPrzygotowania<300)
            {
                return true;
            }
            else
                return false;
        }
        public int IleSkladnikow()
        {
            return Skladniki.Count;
        }

    }
}
