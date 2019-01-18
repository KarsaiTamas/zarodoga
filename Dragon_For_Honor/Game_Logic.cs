using System;
using System.Collections.Generic;

namespace Dragon_For_Honor
{
    class Game_Logic
    {
        public static bool Mozgunk_E()
        {
            if (Globals.dir_up || Globals.dir_down || Globals.dir_jobb || Globals.dir_bal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Tud_E_Mozogni()
        {
            if (Types.player.haladas!=0)
            {
                return false;
            }
            int d = Types.player.dir;
            if (Globals.dir_up)
            {
                Types.player.dir = Constants.dir_up;
            }
            if (Globals.dir_down)
            {
                Types.player.dir = Constants.dir_down;
            }
            if (Globals.dir_bal)
            {
                Types.player.dir = Constants.dir_bal;
            }
            if (Globals.dir_jobb)
            {
                Types.player.dir = Constants.dir_jobb;
            }

            return true;
        }

        /*public static bool Check_Directions(byte direction)
        {
            int x, y;

            switch (direction)
            {
                case Constants.dir_up:
                    x = Types.player.x;
                    y = Types.player.y - 1;
                    break;
                case Constants.dir_down:
                    x = Types.player.x;
                    y = Types.player.y + 1;
                    break;
                case Constants.dir_bal:
                    x = Types.player.x-1;
                    y = Types.player.y;
                    break;
                case Constants.dir_jobb:
                    x = Types.player.x+1;
                    y = Types.player.y;
                    break;
            }
            return false;
        }*/
        public static bool Lehet_E_Ra_Lepni_Blokkra()
        {
            int block_fajta= Elottem_Levo_Block();
            List<int> jarhatatlan_blokkok = new List<int>();
            jarhatatlan_blokkok.Add(5);
            jarhatatlan_blokkok.Add(1);
            jarhatatlan_blokkok.Add(6);
            jarhatatlan_blokkok.Add(7);
            jarhatatlan_blokkok.Add(8);
            jarhatatlan_blokkok.Add(9);
            if (jarhatatlan_blokkok.Contains(block_fajta))
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public static int Elottem_Levo_Block()
        {
            string[] adatok = Game1.felbontas.Split('x');
            int px;
            int py;

            int block_fajta =0;
            long mapx;
            long mapy;
            switch (Types.player.dir)
            {
                case Constants.dir_up:
                    if (Types.player.grafika_y - 50 >= 0 && Types.player.grafika_x>=0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y - 50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y - 33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 33) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y - 50 < 0 && Types.player.grafika_x >= 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y - 50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px =(int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y - 33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 33) % 2000) / 100 + "")));
                        }
                    }else if(Types.player.grafika_y - 50 >= 0 && Types.player.grafika_x < 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y - 50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y - 33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 33) % 2000) / 100 + "")));
                        }
                    }
                    else
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y - 50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y - 33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y - 33) % 2000) / 100 + "")));
                        }
                    }
                    block_fajta = Grafika.palya.Terkep_Darab(mapx, mapy, px, py);
                 //   GUI_Interface.label.Text = px + " x " + py + " y" + block_fajta;
                    

                    break;
                case Constants.dir_down:

                    if (Types.player.grafika_y + 50 >= 0 && Types.player.grafika_x>= 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y+50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y+50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y+33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y+33) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y + 50 < 0 && Types.player.grafika_x >= 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y + 50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y + 33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px =  (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 33) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y + 50 >= 0 && Types.player.grafika_x < 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y + 50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y + 33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y + 33) % 2000) / 100 + "")));
                        }
                    }
                    else
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y+ 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y+50) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y+50) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y+33) / 2000;
                            mapx = (Types.player.grafika_x) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y+33) % 2000) / 100 + "")));
                        }
                    }
                    block_fajta = Grafika.palya.Terkep_Darab(mapx, mapy, px, py);
                 //   GUI_Interface.label.Text = px + " x " + py + " y" + block_fajta;

                    break;
                case Constants.dir_bal:
                    if (Types.player.grafika_y>= 0 && Types.player.grafika_x - 50 >= 0 )
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 50) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 33) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 33) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y < 0 && Types.player.grafika_x - 50 >= 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 50) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 33) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 33) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y >= 0 && Types.player.grafika_x - 50 < 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 50) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 33) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 33) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    else
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 50) / 2000;
                            px = 19-(int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 50) % 2000) / 100 + "")));
                            py = 19-(int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x - 33) / 2000;
                            px = 19-(int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x - 33) % 2000) / 100 + "")));
                            py = 19-(int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                      
                    block_fajta = Grafika.palya.Terkep_Darab(mapx, mapy, px, py);
                    //GUI_Interface.label.Text = Types.player.mapx + " x " + py + " y" + block_fajta;
                    
                    break;
                case Constants.dir_jobb:
                    if (Types.player.grafika_y>= 0 && Types.player.grafika_x + 50 >= 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 50) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 33) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 33) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y < 0 && Types.player.grafika_x + 50 >= 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 50) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 33) / 2000;
                            px = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 33) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    else if(Types.player.grafika_y >= 0 && Types.player.grafika_x + 50 < 0)
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 50) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 33) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 33) % 2000) / 100 + "")));
                            py = (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    else
                    {
                        if ((int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + ""))) == 0)
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 50) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 50) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));

                        }
                        else
                        {
                            mapy = (Types.player.grafika_y) / 2000;
                            mapx = (Types.player.grafika_x + 33) / 2000;
                            px = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_x + 33) % 2000) / 100 + "")));
                            py = 19 - (int)Math.Abs(Math.Ceiling(double.Parse(((Types.player.grafika_y) % 2000) / 100 + "")));
                        }
                    }
                    block_fajta = Grafika.palya.Terkep_Darab(mapx, mapy, px, py);
                   // GUI_Interface.label.Text = px + " x " + py + " y" + block_fajta;

                    break;
                    
            }
            return block_fajta;

        }

        public static bool Menu_Behoz()
        {
            if (Globals.menu)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Check_Movement()
        {
            if (Mozgunk_E())
            {
                if (Tud_E_Mozogni())
                {
                    Types.player.haladas = 1;
                    switch (Types.player.dir)
                    {
                        case Constants.dir_up:
                            if (Lehet_E_Ra_Lepni_Blokkra())
                            {
                                Types.player.yoffset = 32;
                            
                                Types.player.y -= 1;
                            }
                            break;
                        case Constants.dir_down:
                            if (Lehet_E_Ra_Lepni_Blokkra())
                            {
                                Types.player.yoffset = (32*-1);
                            
                                Types.player.y += 1;
                            }
                            break;
                        case Constants.dir_bal:
                            if (Lehet_E_Ra_Lepni_Blokkra())
                            {
                                Types.player.xoffset = 32;

                           
                                Types.player.x -= 1;
                            }
                            break;
                        case Constants.dir_jobb:
                            if (Lehet_E_Ra_Lepni_Blokkra())
                            {
                                Types.player.xoffset = (32*-1);
                            
                                Types.player.x += 1;
                            }
                            break;

                    }
                }
            }
        }

        public static void Process_Movement()
        {
            int sebesseg = 0;
            switch (Types.player.haladas)
            {
                case 1:
                    sebesseg = 5;
                    break;
                default:
                    return;
            }
            switch (Types.player.dir)
            {
                case Constants.dir_up:
                    Types.player.yoffset -= sebesseg;
                    if (Types.player.yoffset<0)
                    {
                        Types.player.yoffset = 0;
                    }
                    break;
                case Constants.dir_down:
                    Types.player.yoffset += sebesseg;
                    if (Types.player.yoffset > 0)
                    {
                        Types.player.yoffset = 0;
                    }
                    break;
                case Constants.dir_bal:
                    Types.player.xoffset -= sebesseg;
                    if (Types.player.xoffset < 0)
                    {
                        Types.player.xoffset = 0;
                    }
                    break;
                case Constants.dir_jobb:
                    Types.player.xoffset += sebesseg;
                    if (Types.player.xoffset > 0)
                    {
                        Types.player.xoffset = 0;
                    }
                    break;
            }

            if (Types.player.haladas>0)
            {
                if (Types.player.dir==Constants.dir_jobb || Types.player.dir == Constants.dir_down)
                {
                    if (Types.player.xoffset>=0 && Types.player.yoffset>=0)
                    {
                        Types.player.haladas = 0;
                        if (Types.player.lepesek== 0)
                        {
                            Types.player.lepesek = 2;
                        }
                        else
                        {
                            Types.player.lepesek = 0;
                        }
                    }
                }
                else
                {
                    if (Types.player.xoffset <= 0 && Types.player.yoffset <= 0)
                    {
                        Types.player.haladas = 0;
                        if (Types.player.lepesek == 0)
                        {
                            Types.player.lepesek = 2;
                        }
                        else
                        {
                            Types.player.lepesek = 0;
                        }
                    }

                }
                
            }
        }


    }
}
