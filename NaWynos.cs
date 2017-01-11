using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukiernia
{
    class NaWynos:Zamowienie
    {
        public override bool PoprawnyCzas()
        {
            if (czasDostawy.Hour+2 > DateTime.Today.Hour)
            {
                return true;
            }
            else
                return false;
        }
    }
}
