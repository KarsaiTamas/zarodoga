using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_For_Honor
{
    class Palya_Elem
    {
        private long y, x;
        public long Y { get => y; set => y = value; }
        public long X { get => x; set => x = value; }
        public int[,] palyaresz;


        public Palya_Elem(long y, long x ,int[,]palyaresz)
        {
            this.y = y;
            this.x = x;
            this.palyaresz = palyaresz;
        }
        public string palya() {
            string v = "";
            for (int i = 0; i < palyaresz.GetLength(0); i++)
            {
                for (int j = 0; j < palyaresz.GetLength(1); j++)
                {
                    v += " "+palyaresz[i,j];
                }
            }
            return v;
        }
    }
}
