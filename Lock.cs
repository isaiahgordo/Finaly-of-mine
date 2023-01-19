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
        
        private Texture2D _texture,_texture2;
        private Color _colour;
        private bool _locked;
        private Rectangle _bounds,_bounds2=new Rectangle(0,200,50,50);
        private string _locknum;
        private Vector2 _vect,_vector=new Vector2(250,50);
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
        { 
            get { return _locknum; }            
        }
        public bool locked(Player.Room room,MouseState ms,Random r,KeyboardState ks)
        {
            int i, n, t;
            r = new Random();
            ms = Mouse.GetState();
            if (room == Player.Room.Start && ms.LeftButton == ButtonState.Pressed)
            { 
                Bounds=new Rectangle(Bounds.X,Bounds.Y,200,200);
                i = r.Next(10);
                n= r.Next(10);
                t= r.Next(10);
                
                
                return true;
            }
            else
                return false;
        }
        private int[] _ints = new int[10];
        public Vector2 Vect(GraphicsDeviceManager graph)
        {
            Vector2 v = new Vector2(graph.PreferredBackBufferWidth, graph.PreferredBackBufferHeight);
            Vect(v);
            return v;
        }
        private Vector2 Vect(Vector2 vector)
        {
            _vect=vector;
            return vector;
        }
        public Vector2 DrawingVector
        {
            get { return _vect; }
        }       
        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            sb.Draw(Texture,Bounds,Colour);
            sb.DrawString(font,Locknum,DrawingVector,_colour);
            foreach (int i in _ints)
            {
                _vector = new Vector2(_bounds2.Y, _bounds2.Width);
                sb.Draw(_texture,_bounds2,Color.LightGray);
                sb.DrawString(font,i.ToString(),_vector,Color.Black);
                _bounds2.X += 50;
                _vector += new Vector2(50, 50);
                if (i == 3 || i == 6)
                {
                    _bounds2.X = 0;
                    _bounds2.Y += 50;
                    _vector = new Vector2(_bounds2.Y, _bounds2.Width);
                }
                else if (i == 9)
                {
                    _bounds2.X = 50;
                    _vector = new Vector2(_bounds2.Y, _bounds2.Width);
                }                
            }
        }
        public Lock(Texture2D texture, Color colour, Rectangle bounds,Texture2D texture2)
        {
            _texture = texture;
            _colour = colour;            
            _bounds = bounds;
        }
    }
}
