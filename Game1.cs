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
        Texture2D playText,enimyText;        
        Vector2 gravite,vect;
        Enimy enimy;
        int t = 0;
        class Timer
        {
            private float _interval,_currentTime;                       
            public bool Tick(GameTime gime)
            {
                _currentTime += (float)gime.TotalGameTime.TotalSeconds;
                if (_currentTime >= _interval)
                {
                    _currentTime -= _interval;
                    return true;
                }
                else return false;
            }
            public Timer(float interval, float currentTime)
            {
                _interval = interval;
                _currentTime = currentTime;
            }
        }
        Timer timer;
        enum Levels
        {
            Zero, One, Two, Three, Four
        }
        Levels levels;
        enum Screen
        {
            Intro,            
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
            player = new Player(playText, new Rectangle(0, 375, 75, 75), Color.White, new Vector2(12.5f, 12.5f));           
            enimy = new Enimy(enimyText, new Rectangle(0, 0, 75, 75), Color.White,new Vector2(6.25f,6.25f));
            timer= new Timer(2f,0f);
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);            
            font = Content.Load<SpriteFont>("File");
            playText = Content.Load<Texture2D>("redEye");
            enimyText = Content.Load<Texture2D>("slimy");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            KeyboardState kstate = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)                
                if (kstate.IsKeyDown(Keys.A))
                {
                    levels = Levels.One;
                    screen = Screen.Game;
                }
            if (screen == Screen.Game)
                if (levels == Levels.One)
                {                    
                    enimy.Move(graph,1);
                    player.Move(graph, kstate, enimy.centure);
                    if (player.oget == 5)
                    { levels = Levels.Two; player.oget = 0; }
                    if (timer.Tick(gameTime) == true) ;
                }
                if (levels == Levels.Two)
                {                    
                    enimy.Move(graph,2);
                    player.Move(graph, kstate, enimy.centure);
                    if (player.oget == 5) { levels = Levels.Three;t+=1; player.oget = 0 ; }
                }
                if(levels==Levels.Three)
                {                    
                    player.Move(graph, kstate, enimy.centure);
                    enimy.Move(graph,3);
                    if (player.oget == 5) { levels = Levels.Four;t+=1; player.oget = 0; }
                }
                if (levels == Levels.Four)
                {                                                                         
                    enimy.Move(graph,4);
                    player.Move(graph, kstate, enimy.centure);
                    if (player.oget == 5)
                     screen = Screen.Endtro;
                }
            if(screen==Screen.Endtro)            
                if(kstate.IsKeyDown(Keys.A))
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
                spriBat.DrawString(font, "Wasd to play press f on slimy to win, A to continue", vect,Color.Blue);
            }           
            if(screen==Screen.Game)
            {                
                enimy.Draw(spriBat);
                player.Draw(spriBat);
                spriBat.DrawString(font, t.ToString(), new Vector2(0, 0), Color.Blue);
                spriBat.DrawString(font, "slimy", enimy.Emyvec, Color.Blue);TextureAddressMode a lot
            }
            else if (screen == Screen.Endtro)
            {
                spriBat.DrawString(font, t.ToString(),new Vector2(0,0),Color.Blue);
                spriBat.DrawString(font,"The End",vect,Color.Blue);
            }
            spriBat.End();
            base.Draw(gameTime);
        }
    }
}