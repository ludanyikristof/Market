using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class IDandSupershop
    {
        public int id;
        public double point;

        public IDandSupershop(int id, double point)
        {
            this.id = id;
            this.point = point;
        }
        public void Supershop()
        {
            foreach(IDandSupershop c in Shop.idandsupershop)
            {
                if(id == c.id)
                {

                }
            }
        }
    }

}
