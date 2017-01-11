using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukiernia
{
    abstract class Zamowienie
    {
        protected DateTime czasDostawy;
        public virtual bool PoprawnyCzas()
        {
            if(czasDostawy>DateTime.Today)
            {
                return true;
            }
            else
                return false;
        }
        public void UstawCzasDostawy(DateTime Czas)
        {
            this.czasDostawy = Czas;
        }
        public DateTime zwracamCzas()
        {
            return czasDostawy;
        }
    }
  
}
