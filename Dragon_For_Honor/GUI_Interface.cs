using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GeonBit.UI;
using Microsoft.Xna.Framework.Graphics;
namespace Dragon_For_Honor
{
    class GUI_Interface
    {

        public static List<Panel> Windows = new List<Panel>();

        public void GUI_Betolt()
        {
            Window_Fo_Menu();
            Window_Uj_Jatek();
            Window_Betoltes();
            Window_Beallitasok_Grafika();
            Window_Jatek();
            Window_Jatek_Menu();
            Window_Jatek_Betoltes();
            Window_Jatek_Beallitasok_Grafika();
            Test();
            Biztos_Kilep();
        }

        public void Window_Keszites(Panel panel)
        {
            Windows.Add(panel);

        }

        public void Window_Fo_Menu()
        {
            //öüóűŰúőŐ
            //entitás készítés
            Panel panel = new Panel(new Vector2(500, 430));
            Header header = new Header("Dragon For Honor", Anchor.TopCenter);
            Button Uj_Jatek = new Button("Uj jatek");
            Button Jatek_Betoltes = new Button("Betoltes");
            Button Beallitasok = new Button("Beallitasok");
            Button Kilepes = new Button("Kilepes");

            UserInterface.Active.AddEntity(panel);

            //add entitás
            panel.AddChild(header);
            panel.AddChild(Uj_Jatek);
            panel.AddChild(Jatek_Betoltes);
            panel.AddChild(Beallitasok);
            panel.AddChild(Kilepes);

            //onclick

            Uj_Jatek.OnClick += (Entity entity) =>
            {
                Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Uj_Jatek);
            };
            Jatek_Betoltes.OnClick += (Entity entity) =>
            {
                Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Betoltes);
            };
            Beallitasok.OnClick += (Entity entity) =>
              {

                  Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Beallitasok);

              };

            Kilepes.OnClick += (Entity kilep) =>
            {
                Menu_Manager.Jatek_Menu_Felhoz(Menu_Manager.Menu.Biztos_Kilep);
                Menu_Manager.Hasznalhato(false);
            };

            //Window csinálás
            Window_Keszites(panel);
        }
        public void Window_Uj_Jatek()
        {
            Panel panel = new Panel(new Vector2(600, 500));
           
            Header fent_kozep = new Header("Valassza ki a nehezsegi szintet!", Anchor.TopCenter);
            RadioButton Konnyu = new RadioButton("Konnyu");
            RadioButton Kozepes = new RadioButton("Kozepes");
            RadioButton Nehez = new RadioButton("Nehez");
            CheckBox targyak_elvesztese = new CheckBox("Targyak elvesztese");
            CheckBox vegleges_halal = new CheckBox("Vegleges halal");


            Button Vissza = new Button("Vissza");
            Konnyu.Checked = true;
            Button Jatek_Inditasa = new Button("Jatek inditasa");

            UserInterface.Active.AddEntity(panel);





            
            panel.AddChild(fent_kozep);
            panel.AddChild(Konnyu);
            panel.AddChild(Kozepes);
            panel.AddChild(Nehez);
            panel.AddChild(targyak_elvesztese);
            panel.AddChild(vegleges_halal);
            panel.AddChild(Jatek_Inditasa);
            panel.AddChild(Vissza);

            Vissza.OnClick += (Entity vissza) =>
            {
                Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Fo_Menu);
            };


            Jatek_Inditasa.OnClick += (Entity entity) =>
              {
                  Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Jatek);
                  Game1.jatek_elinditva = true;

              };


            Window_Keszites(panel);

        }
        public void Window_Betoltes()
        {

            Panel panel = new Panel(new Vector2(600, 500));
            Header fent_kozep = new Header("Jatek betoltese", Anchor.TopCenter);




            Button Vissza = new Button("Vissza");



            UserInterface.Active.AddEntity(panel);






            panel.AddChild(fent_kozep);



            panel.AddChild(Vissza);

            Vissza.OnClick += (Entity vissza) =>
            {
                Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Fo_Menu);
            };


            Window_Keszites(panel);

        }
        public void Window_Jatek_Betoltes()
        {

            Panel panel = new Panel(new Vector2(600, 500));
            Header fent_kozep = new Header("Jatek betoltese", Anchor.TopCenter);




            Button Vissza = new Button("Vissza");



            UserInterface.Active.AddEntity(panel);






            panel.AddChild(fent_kozep);



            panel.AddChild(Vissza);

            Vissza.OnClick += (Entity vissza) =>
            {
                Menu_Manager.Jatek_Menu_Eltuntet(Menu_Manager.Menu.Jatek_Betoltes);
            };


            Window_Keszites(panel);

        }
        public void Window_Beallitasok_Grafika()
        {
            Panel panel = new Panel(new Vector2(800, 500));
            Button grafika_button = new Button("Grafika");
            //grafika_button.Locked=true;
            grafika_button.Locked = true;

            
            grafika_button.SetPosition(Anchor.TopLeft, new Vector2(0, -40));
            grafika_button.Size = new Vector2(190, 40);
            //grafika_button.
            grafika_button.FillColor = new Color(150,150,150);
            Header fent_kozep = new Header("Beallitasok", Anchor.TopCenter);
            Label felbontas_label = new Label("Felbontas:",Anchor.CenterLeft, new Vector2(230,70),new Vector2(50));
            felbontas_label.SetPosition(Anchor.AutoInline, new Vector2(10,95));
            felbontas_label.Scale = 1.5f;
            //felbontas_label.Size = new Vector2(40);
            DropDown felbontas = new DropDown(new Vector2(300,200));
            felbontas.Anchor = Anchor.CenterRight;
            string[] felbontasok = new string[4];
            felbontasok[0] = "800x600";
            felbontasok[1] = "1240x640";
            felbontasok[2] = "1366x720";
            felbontasok[3] = "1920x1080";
            for (int i = 0; i < felbontasok.Length; i++)
            {
                string[] adatok = felbontasok[i].Split('x');
                if (int.Parse(adatok[0])<= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width &&
                    int.Parse(adatok[1])<= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
                    )
                {
                    felbontas.AddItem(felbontasok[i]);

                }

            }
            
            felbontas.SelectedIndex = Game1.kijelolt_felbontas;
            CheckBox full_screen_check_box = new CheckBox("Teljes kepernyo");
            full_screen_check_box.Checked=true;
            Button Ment = new Button("Alkalmaz");
            Button Vissza = new Button("Vissza");

            Game1.felbontas = felbontas.SelectedValue;

            UserInterface.Active.AddEntity(panel);





            panel.AddChild(grafika_button);
            panel.AddChild(fent_kozep);
            
            panel.AddChild(felbontas_label);
             
            panel.AddChild(felbontas);
            panel.AddChild(full_screen_check_box);
            panel.AddChild(Ment);
            panel.AddChild(Vissza);


            Ment.OnClick += (Entity entity) => {
                string sor= felbontas.SelectedValue;
                string[] adatok = sor.Split('x');
                Game1.x_felbontas =int.Parse( adatok[0]);
                Game1.y_felbontas = int.Parse(adatok[1]);
                Game1.ment = true;
                Game1.felbontas = felbontas.SelectedValue;
                if (full_screen_check_box.Checked)
                {
                    Game1.full_screen = true;
                }
                else
                {
                    Game1.full_screen = false;
                }
            };
            
            Vissza.OnClick += (Entity vissza) =>
            {
                Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Fo_Menu);
            };


            Window_Keszites(panel);
        }

        public void Window_Jatek()
        {
            string[] adatok = Game1.felbontas.Split('x');


            Panel panel = new Panel(new Vector2(int.Parse(adatok[0]), int.Parse(adatok[1])));

            
            Window_Keszites(panel);

        }
        public static Label label;
        public void Window_Jatek_Menu()
        {
            Panel panel = new Panel(new Vector2(500, 430));
            Header header = new Header("Dragon For Honor", Anchor.TopCenter);
            Button Vissza_A_Jatekba = new Button("Vissza a jatekba");
            Button Jatek_Betoltes = new Button("Betoltes");
            Button Beallitasok = new Button("Beallitasok");
            Button Kilepes = new Button("Kilepes");



            UserInterface.Active.AddEntity(panel);

            //add entitás
            panel.AddChild(header);
            panel.AddChild(Vissza_A_Jatekba);
            panel.AddChild(Jatek_Betoltes);
            panel.AddChild(Beallitasok);
            panel.AddChild(Kilepes);

            //onclick
             
            Vissza_A_Jatekba.OnClick += (Entity entity) =>
              {
                  Menu_Manager.Jatek_Menu_Eltuntet(Menu_Manager.Menu.Jatek_Menu);
                  Game1.jatek_megallitva = false;
              };
            Jatek_Betoltes.OnClick += (Entity entity) =>
            {
                Menu_Manager.Jatek_Menu_Felhoz(Menu_Manager.Menu.Jatek_Betoltes);
            };
            Beallitasok.OnClick += (Entity entity) =>
            {

                Menu_Manager.Jatek_Menu_Felhoz(Menu_Manager.Menu.Jatek_Beallitasok);

            };

            Kilepes.OnClick += (Entity kilep) =>
            {

                Menu_Manager.Jatek_Menu_Felhoz(Menu_Manager.Menu.Biztos_Kilep);
                Menu_Manager.Hasznalhato(false);
            };

            //Window csinálás
            Window_Keszites(panel);
        }
        public void Window_Jatek_Beallitasok_Grafika()
        {
            Panel panel = new Panel(new Vector2(800, 500));
            Button grafika_button = new Button("Grafika");
            //grafika_button.Locked=true;
            grafika_button.Locked = true;


            grafika_button.SetPosition(Anchor.TopLeft, new Vector2(0, -40));
            grafika_button.Size = new Vector2(190, 40);
            //grafika_button.
            grafika_button.FillColor = new Color(150, 150, 150);
            Header fent_kozep = new Header("Beallitasok", Anchor.TopCenter);
            Label felbontas_label = new Label("Felbontas:", Anchor.CenterLeft, new Vector2(230, 70), new Vector2(50));
            felbontas_label.SetPosition(Anchor.AutoInline, new Vector2(10, 95));
            felbontas_label.Scale = 1.5f;
            //felbontas_label.Size = new Vector2(40);
            DropDown felbontas = new DropDown(new Vector2(300, 200));
            felbontas.Anchor = Anchor.CenterRight;
            string[] felbontasok = new string[4];
            felbontasok[0] = "800x600";
            felbontasok[1] = "1240x640";
            felbontasok[2] = "1366x720";
            felbontasok[3] = "1920x1080";
            for (int i = 0; i < felbontasok.Length; i++)
            {
                string[] adatok = felbontasok[i].Split('x');
                if (int.Parse(adatok[0]) <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width &&
                    int.Parse(adatok[1]) <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
                    )
                {
                    felbontas.AddItem(felbontasok[i]);

                }

            }

            felbontas.SelectedIndex = Game1.kijelolt_felbontas;
            CheckBox full_screen_check_box = new CheckBox("Teljes kepernyo");
            full_screen_check_box.Checked = true;
            Button Ment = new Button("Alkalmaz");
            Button Vissza = new Button("Vissza");

            Game1.felbontas = felbontas.SelectedValue;

            UserInterface.Active.AddEntity(panel);





            panel.AddChild(grafika_button);
            panel.AddChild(fent_kozep);

            panel.AddChild(felbontas_label);

            panel.AddChild(felbontas);
            panel.AddChild(full_screen_check_box);
            panel.AddChild(Ment);
            panel.AddChild(Vissza);


            Ment.OnClick += (Entity entity) => {
                string sor = felbontas.SelectedValue;
                string[] adatok = sor.Split('x');
                Game1.x_felbontas = int.Parse(adatok[0]);
                Game1.y_felbontas = int.Parse(adatok[1]);
                Game1.ment = true;
                Game1.felbontas = felbontas.SelectedValue;
                if (full_screen_check_box.Checked)
                {
                    Game1.full_screen = true;
                }
                else
                {
                    Game1.full_screen = false;
                }
            };

            Vissza.OnClick += (Entity vissza) =>
            {
                Menu_Manager.Jatek_Menu_Eltuntet(Menu_Manager.Menu.Jatek_Beallitasok);
            };


            Window_Keszites(panel);
        }

        public void Biztos_Kilep()
        {
            Panel panel = new Panel(new Vector2(400, 150));
            Label Kilep_Label = new Label("Biztos kiszeretne lépni?",Anchor.TopCenter);
            Button Kilep = new Button("Igen",ButtonSkin.Default,Anchor.CenterLeft,new Vector2(150,50));
            Button Nem_Lepki = new Button("Nem", ButtonSkin.Default, Anchor.CenterRight, new Vector2(150, 50));

            Kilep.SetPosition(Anchor.CenterLeft, new Vector2(10,20));
            Nem_Lepki.SetPosition(Anchor.CenterRight, new Vector2(10, 20));

            UserInterface.Active.AddEntity(panel);

            panel.AddChild(Kilep_Label);
            panel.AddChild(Kilep);
            panel.AddChild(Nem_Lepki);

            Kilep.OnClick += (Entity entity) =>
              {
                  Game1.kilep = true;
              };

            Nem_Lepki.OnClick += (Entity entity) =>
            {
                Menu_Manager.Jatek_Menu_Eltuntet(Menu_Manager.Menu.Biztos_Kilep);
                Menu_Manager.Hasznalhato(true);
            };
             Window_Keszites(panel);

        }
        public void Test()
        {
            Panel panel = new Panel(new Vector2(200, 50),PanelSkin.Default,Anchor.TopRight);
            label = new Label("x y",Anchor.AutoCenter,new Vector2(200,50),new Vector2(0,-15));
            UserInterface.Active.AddEntity(panel);
            
            panel.AddChild(label);

            Window_Keszites(panel);

        }
    }
}
