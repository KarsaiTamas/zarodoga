using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI.Entities;

namespace Dragon_For_Honor
{
    class Menu_Manager
    {
        public static Menu menu;
        public static void Menu_Valtas(Menu menu)
        {
            foreach (var panel in GUI_Interface.Windows)
            {
                panel.Visible = false;
            }
            GUI_Interface.Windows[(int)menu].Visible = true;
        }

        public static void Jatek_Menu_Felhoz(Menu menu)
        {
            GUI_Interface.Windows[(int)menu].Visible = true;
        }
        public static void Jatek_Menu_Eltuntet(Menu menu)
        {
            GUI_Interface.Windows[(int)menu].Visible = false;
        }
        public static void Hasznalhato(bool hasz)
        {

            foreach (var panel in GUI_Interface.Windows)
            {
                panel.Enabled = hasz;
            }
            GUI_Interface.Windows[GUI_Interface.Windows.Count-1].Enabled = true;
        }

        public enum Menu
        {
            Fo_Menu,
            Uj_Jatek,
            Betoltes,
            Beallitasok,
            Jatek,
            Jatek_Menu,
            Jatek_Betoltes,
            Jatek_Beallitasok,
            Test,
            Biztos_Kilep

        }
    }
}
