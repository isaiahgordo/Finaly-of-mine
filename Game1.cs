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
        Texture2D grassText,playText,finishText;        
        Vector2 gravite,vect;
        Enimy enimy;
        int n = 0,t=0;
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
            enimy = new Enimy(finishText, new Rectangle(0, 0, 75, 75), Color.White,new Vector2(6.25f,6.25f));
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);
            grassText = Content.Load<Texture2D>("Rockwall");
            font = Content.Load<SpriteFont>("File");
            playText = Content.Load<Texture2D>("redEye");
            finishText = Content.Load<Texture2D>("slimy");
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
            if (screen == Screen.Game)
                if (levels == Levels.One)
                {
                    player.Move(graph, kstate, enimy.centure,t);
                    enimy.Move(graph,n);
                    if (player.oget == 5)
                    { levels = Levels.Two;n = 1; }
                }
                else if (levels == Levels.Two)
                {
                    player.Move(graph,kstate,enimy.centure,t);
                    enimy.Move(graph,n);
                    if(player.oget == 5) { levels = Levels.Three;n = 2; }
                }
                else if(levels==Levels.Three)
                {                    
                    player.Move(graph, kstate, enimy.centure,t);
                    enimy.Move(graph, n);
                    if (player.oget == 5) { levels = Levels.Fore; n = 3; }
                }
                else if (levels == Levels.Fore)
                {                   
                    player.Move(graph, kstate, enimy.centure, t);
                    enimy.Move(graph, n);
                    if (player.oget == 5)
                        screen = Screen.Endtro; 
                }        
            if(screen==Screen.Endtro)            
                if(mouseState.LeftButton==ButtonState.Pressed)
                    base.Exit();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {             
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriBat.Begin();
            if(screen == Screen.Intro)
            {                
                spriBat.DrawString(font,"Left clicks to continue",vect,Color.Blue);
            }
            if(screen == Screen.Middle)
            {
                spriBat.DrawString(font, "Wasd to play f to win, A to continue", vect, Color.Blue);
            }
            if(screen==Screen.Game)
            {
                enimy.Draw(spriBat);
                player.Draw(spriBat);                                
            }
            if (screen == Screen.Endtro)
            {
                spriBat.DrawString(font,"The End",vect,Color.Blue);
            }
            spriBat.End();
            base.Draw(gameTime);
        }
    }
}