using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_For_Honor
{
    class Types
    {
        public static PlayerStruct player = new PlayerStruct(); 

        [Serializable]
        public struct PlayerStruct {

            public string nev;
            public int sprite;
            public int level;
            public int exp;
            public int map;
            public int x;
            public int y;
            public byte dir;
            public long mapx;
            public long mapy;
            public int csak_karakter_rajzolasx;
            public int csak_karakter_rajzolasy;
            public int xoffset;
            public int yoffset;
            public int haladas;
            public byte lepesek;
            public long grafika_x;
            public long grafika_y;
        }

        public struct RECT {
            public int top;
            public int bal;
            public int jobb;
            public int bottom;


        }
    }
}
