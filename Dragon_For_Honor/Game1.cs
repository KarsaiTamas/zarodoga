using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GeonBit.UI;
using System.IO;
using System.Collections.Generic;


namespace Dragon_For_Honor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 


    public class Game1 : Game
    {
        public static bool kilep = false;
        public static int x_felbontas = 800;
        public static int y_felbontas = 600;
        public static int kijelolt_felbontas = 0;
        public static bool ment = false;
        public static bool full_screen = false;
        public static string felbontas;
        float walk_timer;
        public static int tick;
        public static int eltelt_ido;
        public static int frame_ido;
        public static bool jatek_elinditva = false;
        public static bool jatek_megallitva = false;
        public static long x_plusz = 0;
        public static long y_plusz = 0;
        public static int szamlalo=0;
        public static long x_eleje;
        public static long x_vege;
        public static long y_eleje;
        public static long y_vege;



        /*public void Kilepes()
        {
            kilep = true;
        }*/
        public void Kilep()
        {
            this.Exit();
        }

        public void Ellenorzo_Kiiras()
        {
              //   a.WriteLine("" + Grafika.palya_bal_fent[Game1.y].Y + Grafika.palya_bal_fent[Game1.y].X[Game1.x]);



         }

        public void Kepernyo_Felbontas()
        {
             
            graphics.PreferredBackBufferHeight = y_felbontas;
            graphics.PreferredBackBufferWidth = x_felbontas;

            graphics.IsFullScreen = full_screen;
            graphics.ApplyChanges();

        }

        private void Check_Keys()
        {

            Globals.dir_up = Keyboard.GetState().IsKeyDown(Keys.Up);
            Globals.dir_down = Keyboard.GetState().IsKeyDown(Keys.Down);
            Globals.dir_bal = Keyboard.GetState().IsKeyDown(Keys.Left);
            Globals.dir_jobb = Keyboard.GetState().IsKeyDown(Keys.Right);
            Globals.menu = Keyboard.GetState().IsKeyDown(Keys.F10);

        }

        GraphicsDeviceManager graphics;
       public static  SpriteBatch spriteBatch;
       // Texture2D Fold_Sprite;
         GUI_Interface IGUI = new GUI_Interface();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Kepernyo_Felbontas();
            Grafika.InitializeGrafika(Content);
            UserInterface.Initialize(Content, BuiltinThemes.hd);
            IGUI.GUI_Betolt();
            Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Fo_Menu);
             
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Fold_Sprite = Content.Load<Texture2D>("1");

            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            UserInterface.Active.Update(gameTime);

            // TODO: Add your update logic here
            if (kilep == true)
            {
                Kilep();
            }
            base.Update(gameTime);
            if (ment==true)
            {
                Kepernyo_Felbontas();
                
                ment = false;
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx - 1) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy - 1))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx - 1, Types.player.mapy - 1, Grafika.palya.Palya_1());     
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx - 1) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy + 1))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx - 1, Types.player.mapy + 1);
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx + 1) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy + 1))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx + 1, Types.player.mapy + 1);
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx + 1) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy - 1))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx + 1, Types.player.mapy - 1);
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx - 1) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx - 1, Types.player.mapy - 1);
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx + 1) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx + 1, Types.player.mapy);
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy - 1))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx, Types.player.mapy - 1);
            }
            if (!Grafika.palya.Terkep_Tartalmaz_X(Types.player.mapx) && Grafika.palya.Terkep_Tartalmaz_Y(Types.player.mapy + 1))
            {
                Grafika.palya.Palya_Felvesz(Types.player.mapx, Types.player.mapy + 1);
            }
             
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.Black);
            UserInterface.Active.Draw(spriteBatch);
            if (jatek_elinditva==true)
            {
                if (jatek_megallitva==false)
                {

                
            
            tick = (int)gameTime.TotalGameTime.TotalMilliseconds;
            eltelt_ido = (tick - frame_ido);
            frame_ido = tick;

            if (walk_timer<tick)
            {
                Game_Logic.Process_Movement();
                walk_timer = tick + 30;

                    }
                    Check_Keys();
            Game_Logic.Check_Movement();
                    
                    Grafika.Grafika_Renderelese();

                    Menu_Manager.Jatek_Menu_Felhoz(Menu_Manager.Menu.Test);
                    UserInterface.Active.Draw(spriteBatch);

                    
                }
            }
            if (Game_Logic.Menu_Behoz())
                {
                jatek_megallitva = true;
                Menu_Manager.Jatek_Menu_Felhoz(Menu_Manager.Menu.Jatek_Menu);
                UserInterface.Active.Draw(spriteBatch);
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    jatek_megallitva = false;
                    Menu_Manager.Menu_Valtas(Menu_Manager.Menu.Jatek);
                }
            }
            
            
            
           
            // TODO: Add your drawing code here

             
            base.Draw(gameTime);
        }
    }
}
