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
        Levels level;
        SpriteFont font;
        Texture2D grassText,playText;
        Rectangle myRect,playRect,plusRect;
        Vector2 vect,gravite,grassPlus;
        enum Screen
        {
            Intro,
            Middle,
            Game,
            Endtro
        }
        enum Levels
        {
            Zero,One,Two,Three,Four
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
            level=Levels.Zero;
            vect = new Vector2(100, 200);
            myRect =new Rectangle(0,375,75,105);
            playRect = new Rectangle(0, 300, 75, 75);            
            gravite = new Vector2(0, -100);
            grassPlus = new Vector2(75, 0);
            plusRect = new Rectangle((int)(myRect.X + grassPlus.X), myRect.Y, myRect.Width, myRect.Height);
            base.Initialize();            
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);
            grassText = Content.Load<Texture2D>("Grass");
            font = Content.Load<SpriteFont>("File");
            playText = Content.Load<Texture2D>("download");
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
                { level = Levels.One; screen = Screen.Game; }         
            if(level==Levels.Four)
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriBat.Begin();
            if(screen == Screen.Intro)
            {                
                spriBat.DrawString(font,"Left clicks to continue",vect,Color.Blue);
            }
            if(screen == Screen.Middle)
            {
                spriBat.DrawString(font, "Wasd to play, A to continue", vect, Color.Blue);
            }
            if(level==Levels.One)
            {
                spriBat.Draw(grassText, myRect, Color.White);
                for (int i = 0; i < 10; i++)
                { 

                    spriBat.Draw(grassText, plusRect, Color.White); 
                }              
                spriBat.Draw(playText, playRect, Color.White);
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