using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System.IO;
using GeonBit.UI;
using System.Collections.Generic;

namespace Dragon_For_Honor
{
    class Grafika
    {
        public static Texture2D[] characters = new Texture2D[1];
        public static Texture2D[] palya_elem = new Texture2D[2];

        public static void InitializeGrafika(ContentManager manager)
        {
            Karakter_Betoltes(manager);
            Palya_Betoltes(manager);
        }
        public static void Grafika_Renderelese()
        {
            Game1.spriteBatch.Begin();
            Draw_Player();
            
            Game1.spriteBatch.End();
        }
 

        public static long Convert_Mapx(long x)
        {
            return x - (Globals.TileView.bal * 32)-Globals.kamera.Left ; 
        }

        public static long Convert_MapY(long y)
        {
            return y - (Globals.TileView.top * 32) - Globals.kamera.Top;
        }

        private static void Draw_Sprite(Texture2D[] rajzolando,int sprite,long x2,long y2,Rectangle srcrec)
        {
            long x,y;
            x = Convert_Mapx(x2);
            y = Convert_MapY(y2);
            Game1.spriteBatch.Draw(rajzolando[sprite], new Vector2(x,y),srcrec, Color.White);
        }
        public static Palya palya = new Palya();
        private static void Draw_Map(long x,long y,long palyax,long palyay)
        {
            int[,] kepernyo;
            string[] adatok = Game1.felbontas.Split('x');
            kepernyo = new int[int.Parse(adatok[0])/100, int.Parse(adatok[1])/100];
            
            int tartozkodasi_hely = palya.Hasznalt_Palyaresz(palyax, palyay);
           
                for (int i = 0; i < palya.terkep[tartozkodasi_hely].palyaresz.GetLength(0); i++)
                {

                    for (int j = 0; j < palya.terkep[tartozkodasi_hely].palyaresz.GetLength(1); j++)
                    {

                        //string sajt = "";
                        //int xxxxxxxxxxx = 0;
                        Draw_Sprite(palya_elem,
                                    palya.terkep[tartozkodasi_hely].palyaresz[i, j],
                                       ((j * 100 - x) + 2000 * palyax),
                                      ((i * 100 - y) + 2000 * palyay),                 //0
                                    new Rectangle(0, 0, 100, 100));

                    }
                }
            
            
            if (Game1.x_eleje == null)
            {
                Game1.x_eleje = x;
            }
            if (Game1.y_eleje == null)
            {
                Game1.y_eleje = y;
            }
 










            /*              Draw_Sprite(palya_elem,
                  palya_bal_fent[Y_Hely(palya_bal_fent, int.Parse(hosszy))].Nev[palya_bal_fent[Y_Hely(palya_bal_fent, int.Parse(hosszy))].X_Hely(int.Parse(hosszx))],
                   (palya_bal_fent[Y_Hely(palya_bal_fent, int.Parse(hosszy))].X[palya_bal_fent[Y_Hely(palya_bal_fent, int.Parse(hosszy))].X_Hely(int.Parse(hosszx))]+j) * 100 - x,
                  (palya_bal_fent[Y_Hely(palya_bal_fent, int.Parse(hosszy))].Y+i) * 100 - y,                 //0
                  new Rectangle(0, 0, 100, 100));/*








// Draw_Sprite(palya_elem, 0, (5 * 100) + x, (5 * 100) + y, new Rectangle(0, 0, 100, 100));*/

        }
        public static int x_vege = (palya.terkep[palya.Hasznalt_Palyaresz(Types.player.mapx, Types.player.mapy)].palyaresz.GetLength(1)) * 100;
        public static int y_vege= (palya.terkep[palya.Hasznalt_Palyaresz(Types.player.mapx, Types.player.mapy)].palyaresz.GetLength(0)) * 100;
        private static void Draw_Player()
        {
            byte animacio;
            int x, y;
            Rectangle srcrec;
            int sprite_szam;
            int sprite_left;
            sprite_left = 0;
            sprite_szam = 0;
            animacio = 0;

            //séta
            switch (Types.player.dir)
            {
                case Constants.dir_up:
                    if (Types.player.yoffset>8)
                    {
                        animacio = Types.player.lepesek;
                    }
                    break;
                case Constants.dir_down:
                    if (Types.player.yoffset < -8)
                    {
                        animacio = Types.player.lepesek;
                    }
                    break;
                case Constants.dir_bal:
                    if (Types.player.xoffset > 8)
                    {
                        animacio = Types.player.lepesek;
                    }
                    break;
                case Constants.dir_jobb:
                    if (Types.player.xoffset < -8)
                    {
                        animacio = Types.player.lepesek;
                    }
                    break;
            }

            switch (Types.player.dir)
            {
                case Constants.dir_up:
                    sprite_left = 3;
                    break;
                    
                case Constants.dir_jobb:
                    sprite_left = 2;
                    break;
                case Constants.dir_bal:
                    sprite_left = 1;
                    break;
                case Constants.dir_down:
                    sprite_left = 0;
                    break;
            }
            string[] adatok = Game1.felbontas.Split('x');
            srcrec = new Rectangle((animacio+1) * (characters[sprite_szam].Width / 5), sprite_left * (characters[sprite_szam].Height / 4), characters[sprite_szam].Width / 5, characters[sprite_szam].Height / 4);
            x =Types.player.x * 32 + Types.player.xoffset-((characters[sprite_szam].Width/32-5)/2);
            y = Types.player.y *32 + Types.player.yoffset;

            Types.player.mapx = (long)Math.Ceiling((x / 2000.0));
            //a
            Types.player.mapy = (long)Math.Ceiling((y / 2000.0));
            if (Types.player.mapx % 2 == 0)
            {
                Types.player.grafika_x = x + 390;
            }
            else
            {
                Types.player.grafika_x = x + 380;
            }

            Types.player.grafika_y = y+285 ;
            /*if (Game1.x_eleje < x - (int.Parse(adatok[0]) - 100) / 2 && Game1.y_eleje < y - (int.Parse(adatok[1]) - 100) / 2 &&
                x_vege < x + (int.Parse(adatok[0]) + 100) / 2 && y_vege < y + (int.Parse(adatok[1]) + 100) / 2)
            {*/
            
                Draw_Map(x, y, Types.player.mapx + 1, Types.player.mapy);
                Draw_Map(x , y, Types.player.mapx - 1, Types.player.mapy);
                Draw_Map(x , y, Types.player.mapx, Types.player.mapy - 1);
                Draw_Map(x , y, Types.player.mapx, Types.player.mapy + 1);
                Draw_Map(x , y, Types.player.mapx + 1, Types.player.mapy + 1);
                Draw_Map(x , y, Types.player.mapx - 1, Types.player.mapy + 1);
                Draw_Map(x , y, Types.player.mapx + 1, Types.player.mapy - 1);
                Draw_Map(x, y, Types.player.mapx - 1, Types.player.mapy - 1);
                Draw_Map(x, y, Types.player.mapx, Types.player.mapy);
            
            Draw_Sprite(characters, sprite_szam, (int.Parse(adatok[0]) - 100) / 2, (int.Parse(adatok[1]) - 100) / 2, srcrec);
 
 
            
                /*}
            else if (Game1.y_eleje < y - (int.Parse(adatok[1]) - 100) / 2 && Game1.x_eleje > x - (int.Parse(adatok[0]) - 100) / 2)
            {
                if (Game_Logic.Mozgunk_E())
                {
                    switch (Types.player.dir)
                    {
                        case Constants.dir_jobb:
                            Types.player.csak_karakter_rajzolasx += 2;
                            break;
                        case Constants.dir_bal:
                            Types.player.csak_karakter_rajzolasx -= 2;
                            break;
                    }

                }
                Draw_Map(csak_player_mozgas_Palyax, y, Types.player.mapx, Types.player.mapy);
                Draw_Sprite(characters, sprite_szam, Types.player.csak_karakter_rajzolasx, (int.Parse(adatok[1]) - 100) / 2, srcrec);
                x = csak_player_mozgas_Palyax;
                y = csak_player_mozgas_Palyay;
            }
            else if (Game1.y_eleje > y - (int.Parse(adatok[1]) - 100) / 2 && Game1.x_eleje < x - (int.Parse(adatok[0]) - 100) / 2)
            {
                if (Game_Logic.Mozgunk_E())
                {
                    switch (Types.player.dir)
                    {

                        case Constants.dir_up:
                            Types.player.csak_karakter_rajzolasy -= 2;
                            break;
                        case Constants.dir_down:
                            Types.player.csak_karakter_rajzolasy += 2;
                            break;
                    }

                }
                Draw_Map(x, csak_player_mozgas_Palyay, Types.player.mapx, Types.player.mapy);
                Draw_Sprite(characters, sprite_szam, (int.Parse(adatok[0]) - 100) / 2, Types.player.csak_karakter_rajzolasy, srcrec);
                x = csak_player_mozgas_Palyax;
                y = csak_player_mozgas_Palyay;
            }
           
            else if (Game1.x_eleje > x - (int.Parse(adatok[0]) - 100) / 2 && Game1.y_eleje > y - (int.Parse(adatok[1]) - 100) / 2 
                )
            {
                if (Game_Logic.Mozgunk_E())
                {
                    switch (Types.player.dir)
                    {
                        case Constants.dir_up:
                            Types.player.csak_karakter_rajzolasy -= 2;
                            break;
                        case Constants.dir_jobb:
                            Types.player.csak_karakter_rajzolasx += 2;
                            break;
                        case Constants.dir_bal:
                            Types.player.csak_karakter_rajzolasx -= 2;
                            break;
                        case Constants.dir_down:
                            Types.player.csak_karakter_rajzolasy += 2;
                            break;

                    }
                }
                Draw_Map(csak_player_mozgas_Palyax, csak_player_mozgas_Palyay, Types.player.mapx, Types.player.mapy);
                Draw_Sprite(characters, sprite_szam, Types.player.csak_karakter_rajzolasx, Types.player.csak_karakter_rajzolasy, srcrec);
                x = csak_player_mozgas_Palyax;
                y = csak_player_mozgas_Palyay;
            }
           
            else
            {
                if (Game_Logic.Mozgunk_E())
                {
                    switch (Types.player.dir)
                    {
                        case Constants.dir_up:
                            Types.player.csak_karakter_rajzolasy -= 2;
                            break;
                        case Constants.dir_jobb:
                            Types.player.csak_karakter_rajzolasx += 2;
                            break;
                        case Constants.dir_bal:
                            Types.player.csak_karakter_rajzolasx -= 2;
                            break;
                        case Constants.dir_down:
                            Types.player.csak_karakter_rajzolasy += 2;
                            break;

                    }
                }
                Draw_Map(csak_player_mozgas_Palyax, csak_player_mozgas_Palyay, Types.player.mapx, Types.player.mapy);
                Draw_Sprite(characters, sprite_szam, Types.player.csak_karakter_rajzolasx, Types.player.csak_karakter_rajzolasy, srcrec);
                x = csak_player_mozgas_Palyax;
                y = csak_player_mozgas_Palyay;
            }*/
        }

        private static void Karakter_Betoltes(ContentManager manager)
        {
            characters[0] = manager.Load<Texture2D>("kepek/FoKarakter");
        }
        private static void Palya_Betoltes(ContentManager manager)
        {
            palya_elem[0] = manager.Load<Texture2D>("kepek/1");
            palya_elem[1] = manager.Load<Texture2D>("kepek/2");
        }
    }
}
