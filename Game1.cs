using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        Texture2D boxText,lockText,whiteText;        
        Vector2 gravite,vect;
        Box box;
        Lock locked;
        int i = 0;        
        Random random = new Random();
        Color color;
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
            color = new Color(152, 121, 86,255);
            // TODO: Add your initialization logic here
            screen=Screen.Intro;                          
            gravite = new Vector2(0, -100);            
            levels = Levels.Zero;
            vect = new Vector2(25, 200);
            base.Initialize();
            player = new Player( new Vector2(12.5f, 12.5f));           
            box = new Box(boxText, new Rectangle(graph.PreferredBackBufferWidth/2-50,graph.PreferredBackBufferHeight/2-50, 100, 100), Color.White);
            locked = new Lock(lockText, Color.White, new Rectangle(0, 0, 25, 25),whiteText);
        }

        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);            
            font = Content.Load<SpriteFont>("File");
            boxText = Content.Load<Texture2D>("woodside");
            lockText = Content.Load<Texture2D>("3dCl");
            whiteText = Content.Load<Texture2D>("white");
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
                    if (player.bounds.Contains(mouseState.Position))
                    {
                        i = random.Next(1, 4);
                        if (locked.locked(player.TheRoom, mouseState, random, Kstate) == true)
                        { 
                            locked.thelock(locked.locked(player.TheRoom, mouseState, random, Kstate));
                            locked.Vect(graph);
                        }
                    }
                    
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
                    int t = random.Next(10);                    
                    Vector2 nect=new Vector2(box.centure.X, box.centure.Y);
                    box.Draw(spriBat);
                    spriBat.DrawString(font,t.ToString(), nect, color);
                    locked.Draw(spriBat, font);
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