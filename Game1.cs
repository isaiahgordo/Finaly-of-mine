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
        Texture2D enimyText;        
        Vector2 gravite,vect;
        Enimy enimy;                    
        enum Levels
        {
            Zero, One, Two, Three, Four, Wait
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
            player = new Player( new Vector2(12.5f, 12.5f));           
            enimy = new Enimy(enimyText, new Rectangle(0, 0, 75, 75), Color.White,new Vector2(6.25f,6.25f));            
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);            
            font = Content.Load<SpriteFont>("File");
            enimyText = Content.Load<Texture2D>("woodside");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            
            mouseState = Mouse.GetState();
            KeyboardState Kstate= Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
            {
                levels = Levels.Zero;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    levels = Levels.One;
                    screen = Screen.Game;
                }
                else if (mouseState.RightButton == ButtonState.Pressed)
                { levels = Levels.Wait; screen = Screen.Game; }
            }
            else if (screen == Screen.Game)
            {
                if (levels == Levels.One)
                { }
                else if (levels == Levels.Wait)
                {
                    mouseState = Mouse.GetState();
                    if (mouseState.RightButton == ButtonState.Released)
                    { screen=Screen.Intro; }
                }
            }
               
            if(screen==Screen.Endtro)            
                if(mouseState.LeftButton == ButtonState.Pressed)
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
                spriBat.DrawString(font, "Left click to continue, Right for intrutions don't release", vect,Color.Blue);
            }           
            else if(screen==Screen.Game)
            {                
                if(levels == Levels.One)
                { 
                    
                }
                else if(levels == Levels.Wait)
                {
                    spriBat.DrawString(font,"AD to turn, release right",vect,Color.Blue);
                }
            }
            else if (screen == Screen.Endtro)               
                spriBat.DrawString(font,"The End",vect,Color.Blue);            
            spriBat.End();
            base.Draw(gameTime);
        }
    }
}