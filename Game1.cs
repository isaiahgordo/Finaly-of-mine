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
        Texture2D myTexture;
        Rectangle myRect;
        enum Screen
        {
            Intro,
            Middle,
            Endtro
        }
        enum Levels
        {
            One,Two,Three,Four
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
            myRect=new Rectangle(0,0,75,75);
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("1stTexture");
            font = Content.Load<SpriteFont>("File");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Middle;
            if (screen == Screen.Middle)
                if (mouseState.LeftButton == ButtonState.Pressed)
                    level =Levels.One;            
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
                //spriBat.Draw();
            }
            if(screen == Screen.Middle)
            {
                //spriBat.Draw();
            }
            if(level==Levels.One)
            {
                //spriBat.Draw();
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