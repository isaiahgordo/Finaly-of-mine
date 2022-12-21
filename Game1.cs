using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Finaly_of_mine
{
    
    public class Game1 : Game
    {        
        private GraphicsDeviceManager graph;
        private SpriteBatch spriBat;
        Screen screen;
        MouseState mouseState;        
        SpriteFont font;
        Player player;
        Wall wall;
        Texture2D grassText,playText,finishText;        
        Vector2 gravite,vect;
        Finish finish;
        enum Levels
        {
            Zero, One, Two, Three, Fore
        }
        Levels levels;
        enum Screen
        {
            Intro,
            Middle,
            Game,
            Endtro
        }
        public Game1()
        {
            graph = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen=Screen.Intro;                          
            gravite = new Vector2(0, -100);
            levels = Levels.Zero;
            vect = new Vector2(25, 200);
            base.Initialize();
            player = new Player(playText, new Rectangle(0, 375, 75, 75), Color.White, new Vector2(25, 25));
            wall = new Wall(grassText, new Rectangle(0, 0, 75, 105), Color.White);
            finish = new Finish(finishText, new Rectangle(graph.PreferredBackBufferWidth - 100, 0, 100, 100), Color.White);
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);
            grassText = Content.Load<Texture2D>("Rockwall");
            font = Content.Load<SpriteFont>("File");
            playText = Content.Load<Texture2D>("download");
            finishText = Content.Load<Texture2D>("Bean");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            KeyboardState kstate = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Middle;
            if (screen == Screen.Middle)
                if (kstate.IsKeyDown(Keys.A))
                {
                    levels = Levels.One;
                    screen = Screen.Game;
                }    
            if(levels == Levels.One&&screen==Screen.Game)
            {
                player.Move(graph,kstate,finish.centure);
                if (player.oget == 5)
                    levels = Levels.Two;
            }
            if(levels== Levels.Fore)
              if(mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Endtro;           
            if(screen==Screen.Endtro)            
                if(mouseState.LeftButton==ButtonState.Pressed)
                    base.Exit();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            int i = 0;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriBat.Begin();
            if(screen == Screen.Intro)
            {                
                spriBat.DrawString(font,"Left clicks to continue",vect,Color.Blue);
            }
            if(screen == Screen.Middle)
            {
                spriBat.DrawString(font, "Wasd to play e to finish on bean the cat, A to continue", vect, Color.Blue);
            }
            if(screen==Screen.Game)
            {
                if (levels == Levels.One)
                    i = 1;
                finish.Draw(spriBat);
                player.Draw(spriBat,i); 
                wall.Draw(spriBat);
                
            }
            if (screen == Screen.Endtro)
            {
                //spriBat.Draw();
            }
            spriBat.End();
            base.Draw(gameTime);
        }
    }
}