using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finaly_of_mine
{
    class Lock
    {
        private Texture2D _texture;
        private Color _colour;
        private bool _locked;
        private Rectangle _bounds;
        private string _locknum;
        public void thelock(bool b)
        {
            if (b == true)
                _locked = b;
        }
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
        public string Locknum
        { get { return _locknum; } }
        public bool locked(Player.Room room,MouseState ms,Random r,KeyboardState ks)
        {
            int i, n, t;
            r = new Random();
            ms = Mouse.GetState();
            if (room == Player.Room.Start && ms.LeftButton == ButtonState.Pressed)
            { 
                Bounds=new Rectangle(Bounds.X,Bounds.Y,200,200);
                i = r.Next(0, 60);
                n= r.Next(0, 60);
                t= r.Next(0, 60);
                return true;
            }
            else
                return false;
        }
        public Vector2 Vect(GraphicsDeviceManager graph)
        {
            Vector2 v = new Vector2(graph.PreferredBackBufferWidth,graph.PreferredBackBufferHeight);
            return v;
        }
        private Vector2 Vect;
        
        
        
        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            sb.Draw(Texture, Bounds, Colour);
            sb.DrawString(font, Locknum,);
        }
        public Lock(Texture2D texture, Color colour, Rectangle bounds)
        {
            _texture = texture;
            _colour = colour;            
            _bounds = bounds;
        }
    }
}
