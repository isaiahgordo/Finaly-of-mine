using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Finale_of_mine
{
    class Lock
    {        
        private Texture2D _texture,_texture2;
        private Color _colour;
        private bool _locked=true;
        private Rectangle _bounds;
        private int[] _locknum= new int[3];
        private Vector2 _vector=new Vector2(250,50);
        private string testing = "";
        public void thelock(bool b)
        {
            if (b == _locked)
                _locked = b;
            else 
                _locked=false;
        }
        public bool Locked
        { get { return _locked; } }
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Color Colour
        {
            get { return _colour; }
        }
        public Rectangle Bounds
        {
            get { return _bounds; }
            set{ _bounds = value; }
        }        
        public int[] Locknum
        { 
            get { return _locknum; }            
        }
        string numpad="",dapmun="";
        public void locked(Player.Room room,MouseState ms,KeyboardState ks)
        {
            Rectangle rect;            
            ms = Mouse.GetState();
            numpad = "";
            int i = 0;
            testing = "HERE";
            if (room == Player.Room.Start && ms.LeftButton == ButtonState.Pressed)
            {
                
                for (int x = 0; x < 151; x += 50)
                    for (int y = 200; y < 351; y += 50)
                    { 
                        
                        rect = new Rectangle(x, y, 50, 50);
                        if (rect.Contains(ms.Position))
                            if (i == 0)
                                numpad = "1";
                            else if (i == 1)
                                numpad = "2";
                            else if (i == 2)
                                numpad = "3";
                            else if (i == 3)
                                numpad = "4";
                            else if (i == 4)
                                numpad = "5";
                            else if (i == 5)
                                numpad = "6";
                            else if (i == 6)
                                numpad = "7";
                            else if (i == 7)
                                numpad = "8";
                            else if (i == 8)
                                numpad = "9";
                            else if (i == 9)
                                numpad = "0";
                            else if (i == 10)
                                dapmun += numpad;
                            else if (dapmun == _locknum.ToString())
                                _locked = false;
                            else
                                i++; continue;
                    }
                dapmun += numpad;            
            }
        }              
        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            int i = 1;
            for (int x = 0; x <= 100; x += 50)
                for (int y = 200; y <=300; y += 50)
                {
                    _vector=new Vector2(x+18,y+5);                    
                    sb.Draw(_texture2, new Rectangle(x, y, 50, 50), Color.LightGray);
                    sb.DrawString(font, i.ToString(), _vector, Color.Black);
                    i++;
                }
            sb.Draw(_texture2, new Rectangle(0, 350, 50, 50), Color.LightGray);
            sb.DrawString(font, "0", new Vector2(18, 355), Color.Black);
            sb.Draw(_texture2, new Rectangle(50, 350, 100, 50), Color.LightGray);
            sb.DrawString(font, "Enter", new Vector2(68, 355), Color.Black);
            sb.Draw(Texture, Bounds, Colour);
            sb.DrawString(font, testing, new Vector2(10, 10), Color.Black);
            sb.DrawString(font, dapmun, new Vector2(200, 300), Color.Blue);
        }        
        public Lock(Texture2D texture, Color colour, Rectangle bounds,Texture2D texture2,Random r)
        {
            _texture = texture;
            _colour = colour;            
            _bounds = bounds;
            _texture2= texture2;
            _locknum[0] = r.Next(10);
            _locknum[1] = r.Next(10);
            _locknum[2]= r.Next(10);
        }
    }
}