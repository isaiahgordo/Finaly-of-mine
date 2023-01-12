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
        Texture2D boxText;        
        Vector2 gravite,vect;
        Box box;
        int i = 0;
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
            box = new Box(boxText, new Rectangle(graph.PreferredBackBufferWidth/2-50,graph.PreferredBackBufferHeight/2-50, 100, 100), Color.White);            
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);            
            font = Content.Load<SpriteFont>("File");
            boxText = Content.Load<Texture2D>("woodside");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {            
            mouseState = Mouse.GetState();
            player.Find(mouseState);
            KeyboardState Kstate= Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.Intro)
            {
                levels = Levels.Zero;
                if (mouseState.LeftButton == ButtonState.Pressed)                
                    i++;                
                else if (mouseState.LeftButton == ButtonState.Released&&i>0)
                {
                    screen = Screen.Game;
                    levels = Levels.One;
                }
                else if (mouseState.RightButton == ButtonState.Pressed)
                { levels = Levels.Wait; screen = Screen.Game; }
            }
            else if (screen == Screen.Game)
            {
                if (levels == Levels.One)
                { 
                    player.Move(graph,Kstate);
                    box.Zoom(player.Click(mouseState,box.centure));
                }
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
                    box.Draw(spriBat);
                }
                else if(levels == Levels.Wait)
                {
                    spriBat.DrawString(font,"AD to turn scroll to zoom, release right",vect,Color.Blue);
                }
                else spriBat.DrawString(font,"hello",vect,Color.Blue);
            }
            else if (screen == Screen.Endtro)               
                spriBat.DrawString(font,"The End",vect,Color.Blue);            
            spriBat.End();
            base.Draw(gameTime);
        }
    }
}