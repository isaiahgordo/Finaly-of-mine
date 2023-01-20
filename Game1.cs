using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

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
        Gold gold;
        Texture2D boxText,lockText,whiteText,goldText;        
        Vector2 gravite,vect;
        Box box;
        Lock locked;
        Player.Room room;
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
            vect = new Vector2(10, 200);
            base.Initialize();
            player = new Player( new Vector2(12.5f, 12.5f));           
            box = new Box(boxText, new Rectangle(graph.PreferredBackBufferWidth/2-50,graph.PreferredBackBufferHeight/2-50, 100, 100), Color.White);
            locked = new Lock(lockText, Color.White, new Rectangle(graph.PreferredBackBufferWidth/2,graph.PreferredBackBufferHeight/2, 25, 25),whiteText,graph,random);
            gold = new Gold(goldText, new Rectangle(graph.PreferredBackBufferWidth / 2 - 50, graph.PreferredBackBufferHeight / 2 - 50, 100, 100), new Color(251,222,34));
        }
        protected override void LoadContent()
        {
            spriBat = new SpriteBatch(GraphicsDevice);            
            font = Content.Load<SpriteFont>("File");
            boxText = Content.Load<Texture2D>("woodside");
            lockText = Content.Load<Texture2D>("3dCl");
            whiteText = Content.Load<Texture2D>("white");
            goldText = Content.Load<Texture2D>("Binka");
            // TODO: use this.Content to load your game content here
        }
        bool b;
        protected override void Update(GameTime gameTime)
        {            
            mouseState = Mouse.GetState();
            player.Find(mouseState);
            KeyboardState Kstate= Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            room=player.TheRoom;
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
                { 
                    levels = Levels.Wait; 
                    screen = Screen.Game;
                }
            }
            else if (screen == Screen.Game)
            {
                if (levels == Levels.One)
                { 
                    player.Move(graph,Kstate);
                    if (player.bounds.Contains(mouseState.Position))
                    {
                        i = random.Next(1, 4);
                        if (locked.locked(player.TheRoom, mouseState, Kstate) == true)
                        {
                            b = locked.locked(player.TheRoom, mouseState, Kstate);
                            locked.thelock(b);                          
                        }
                    }                    
                }
                else if (levels == Levels.Wait)
                {
                    mouseState = Mouse.GetState();
                    if (mouseState.RightButton == ButtonState.Released)
                    { 
                        screen=Screen.Intro; 
                    }
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
                    string s= locked.Locknum.Remove(1);
                    int.TryParse(s, out int t);
                    Vector2 nect=new Vector2(box.centure.X, box.centure.Y);
                    box.Draw(spriBat);
                    if(room!=Player.Room.Start)
                        spriBat.DrawString(font,t.ToString(), nect, color);
                    else
                        locked.Draw(spriBat, font);
                    gold.Draw(spriBat, b);
                }
                else if(levels == Levels.Wait)
                {
                    spriBat.DrawString(font,"AD to turn left click to zoom releas to un, release right",vect,Color.Blue);
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