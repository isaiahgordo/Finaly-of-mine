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
        Levels level;
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(screen == Screen.Intro)
            {

            }
            if(screen == Screen.Middle)
            {
                level=Levels.One;
            }
            if(level==Levels.Four)
            {
                screen = Screen.Endtro;
            }
            if(screen==Screen.Endtro)
            {
                base.Exit();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}