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
        public bool locked(Player.Room room,MouseState ms,KeyboardState ks)
        {
            ms = Mouse.GetState();
            if (room == Player.Room.Start && ms.LeftButton == ButtonState.Pressed)
            { 
                Bounds=new Rectangle(Bounds.X,Bounds.Y,200,200);
               
                
                
                return true;
            }
            else
                return false;
        }              
        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            sb.Draw(Texture,Bounds,Colour);
            sb.DrawString(font,Locknum,_vect,_colour);
            int i = 1;
            {
                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location += new Point(50, 0);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location += new Point(50, 0);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location -= new Point(100, -50);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location += new Point(50, 0);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location += new Point(50, 0);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location -= new Point(100, -50);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location += new Point(50, 0);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location += new Point(50, 0);
                i++;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);
                _bounds2.Location -= new Point(50, -50);
                i-=10;

                sb.Draw(_texture2, _bounds2, Color.LightGray);
                _vector = new Vector2(_bounds2.Center.X - 50, _bounds2.Center.Y);
                sb.DrawString(font, i.ToString(), _vector, Color.Black);                
            }
            
        }
        
        public Lock(Texture2D texture, Color colour, Rectangle bounds,Texture2D texture2,GraphicsDeviceManager graph,Random r)
        {
            _texture = texture;
            _colour = colour;            
            _bounds = bounds;
            _texture2= texture2;            
            _vect = new Vector2(graph.PreferredBackBufferWidth - 250, graph.PreferredBackBufferHeight);
            _locknum = (r.Next(10) * 10 + r.Next(10) * 10 + r.Next(10)).ToString();
        }
    }
}