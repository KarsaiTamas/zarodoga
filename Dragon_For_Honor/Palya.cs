using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Dragon_For_Honor
{
    class Palya
    {
        public List<Palya_Elem> terkep = new List<Palya_Elem>();
        public Palya() {
            terkep.Add(new Palya_Elem(0, 0, Palya_Feltoltes(20, 20,0)));
        }
        public int[,] Palya_Feltoltes(int hossz, int magassag,int palyadarab) {
            int[,] vissza = new int[magassag, hossz];

            for (int i = 0; i < vissza.GetLength(0); i++)
            {
                for (int j = 0; j < vissza.GetLength(1); j++)
                {
                    if (j == 2 && i==2)
                    {
                        vissza[i, j] = 1;
                    }
                    else
                    {
                        vissza[i, j] = palyadarab;
                    }
                }
            }
            return vissza;
        }
        public void Palya_Szerkeszt(int hasznalt, int[,]uj_palya)
        {
            terkep[hasznalt].palyaresz = uj_palya; 
        }

        public int[,] Palya_keszlet(int sorszam)
        {
            return Palya_1();
        }

        public int[,] Palya_1()
        {
            Random r = new Random();
            int[,] vissza = new int[20, 20];
            int rnd2 = r.Next(1, 3);
            int rndi=r.Next(2,17);
            int rndj = r.Next(2, 17);

            for (int i = 0; i < vissza.GetLength(0); i++)
            {
                for (int j = 0; j < vissza.GetLength(1); j++)
                {
                    
                    vissza[i, j] = 1;
                    if (rnd2 == 1)
                    {
                        if (i==rndi && j > 3 && j < 17)
                        {
                            
                            vissza[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (j==rndj && i>3 && i<17)
                        {
                           
                            vissza[i, j] = 1;
                        }
                    }
                }
            }
            return vissza;
        }

        public void Palya_Felvesz(long x,long y)
        {
            terkep.Add(new Palya_Elem(y, x, Palya_Feltoltes(20, 20,0)));

        }
        public void Palya_Felvesz(long x, long y,int[,]matrix)
        {
            terkep.Add(new Palya_Elem(y, x, matrix));

        }
        public int Hasznalt_Palyaresz(long x,long y)
        {
            for (int i = 0; i < terkep.Count; i++)
            {
                if (Terkep_Tartalmaz_X(x) && Terkep_Tartalmaz_Y(y))
                {
                    return i;
                }
            }
            return 0;
        }
        public bool Terkep_Tartalmaz_X(long x)
        {
            foreach (var item in terkep)
            {
                if (item.X == x) {
                    return true;
                }
            }
            return false;
        }
        public bool Terkep_Tartalmaz_Y(long y)
        {
            foreach (var item in terkep)
            {
                if (item.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public int Terkep_Darab(long x,long y,int px,int py)
        {

            return terkep[Hasznalt_Palyaresz(x, y)].palyaresz[py,px];

            
        }

    }
}
