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
    class Wall
    {
        private Rectangle _bounds;
        private Texture2D _texture;
        private Color _color;
        private List<Rectangle> levelone=new List<Rectangle>(),levelTwo,levelThree,levelfour;
        int i,n=0,t=0;
        public Wall(Texture2D texture,Rectangle bounds, Color color)
        {
            _bounds = bounds;
            _texture = texture;
            _color = color;
            while (n < 10)
            { levelone.Add(_bounds);n++; }
            levelTwo = levelone;
            levelThree = levelone;
            levelfour=levelone;
        }
        public Texture2D Texture
        { get { return _texture; } }
        public Rectangle Bounds 
        { 
            get { return _bounds; }
            set { _bounds = value; } 
        }
        public int tGetSet
        {
            get { return t; }
            set { t = value; }
        }
        public void WallBounds(GraphicsDeviceManager graph)
        {
            if(t==0)
                for (i = 0; i < levelone.Count; i++)
                { 
                    Rectangle temp = levelone[i];
                    temp.Y = 100;
                    switch (i)
                    {
                    case 0:                        
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;                            
                            break;                        
                    case 1:                        
                            temp.X = graph.PreferredBackBufferWidth - 2*temp.Width;
                            break;                        
                    case 2:
                        temp.X = graph.PreferredBackBufferWidth - 3*temp.Width;
                        break;
                    case 3:
                        temp.X = graph.PreferredBackBufferWidth - 4*temp.Width;
                        break;
                    case 4:
                        temp.X = graph.PreferredBackBufferWidth - 5*temp.Width;
                        break;
                    case 5:
                        temp.X = graph.PreferredBackBufferWidth - 6*temp.Width;
                        break;
                    case 6:
                        temp.X = 0;
                        break;
                    case 7:
                        temp.X = temp.Width;
                        break;
                    case 8:
                        temp.X = 2*temp.Width;
                        break ;
                        default:
                        { 
                            temp.X = 2 * temp.Width; 
                            temp.Y = 0;
                        }
                        break;
                    }
                levelone[i] = temp;
                }
            else if(t==1)
                for(i=0;i<levelTwo.Count;i++)
                {
                    Rectangle temp = levelTwo[i];
                    temp.Y = 100;
                    switch (i)
                    {
                        case 0:
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;
                            break;
                        case 1:
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;
                            temp.Y += 100;
                            break;
                        case 2:
                            temp.X = graph.PreferredBackBufferWidth - 2 * temp.Width;
                            break;
                        case 3:
                            temp.X = graph.PreferredBackBufferWidth - 3 * temp.Width;
                            break;
                        case 4:
                            temp.X = graph.PreferredBackBufferWidth - 3 * temp.Width;
                            temp.Y -= 200;
                            break;
                        case 5:
                            temp.X = graph.PreferredBackBufferWidth - 4 * temp.Width;
                            break;
                        case 6:
                            temp.X = 0;
                            break;
                        case 7:
                            temp.X = temp.Width;
                            break;
                        case 8:
                            temp.X = 2 * temp.Width;
                            break;
                        default:
                            {
                                temp.X = 2 * temp.Width;
                                temp.Y += 100;
                            }
                            break;
                    }
                    levelTwo[i] = temp;
                }
            else if(t==3)
                for(i=0;i<levelThree.Count;i++)
                {
                    Rectangle temp = levelTwo[i];
                    temp.Y = 100;
                    switch (i)
                    {
                        case 0:
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;
                            break;
                        case 1:
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;
                            temp.Y += 100;
                            break;
                        case 2:
                            temp.X = graph.PreferredBackBufferWidth - 2 * temp.Width;
                            break;
                        case 3:
                            temp.X = graph.PreferredBackBufferWidth - 3 * temp.Width;
                            break;
                        case 4:
                            temp.X = graph.PreferredBackBufferWidth - 3 * temp.Width;
                            temp.Y -= 200;
                            break;
                        case 5:
                            temp.X = graph.PreferredBackBufferWidth - 4 * temp.Width;
                            break;
                        case 6:
                            temp.X = 0;
                            break;
                        case 7:
                            temp.X = temp.Width;
                            break;
                        case 8:
                            temp.X = 2 * temp.Width;
                            break;
                        default:
                            {
                                temp.X = 2 * temp.Width;
                                temp.Y += 100;
                            }
                            break;
                    }
                    levelThree[i] = temp;
                }
            else if(t==4)
                for(i=0;i<levelfour.Count;i++)
                {
                    Rectangle temp = levelTwo[i];
                    temp.Y = 100;
                    switch (i)
                    {
                        case 0:
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;
                            break;
                        case 1:
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;
                            temp.Y += 100;
                            break;
                        case 2:
                            temp.X = graph.PreferredBackBufferWidth - 2 * temp.Width;
                            break;
                        case 3:
                            temp.X = graph.PreferredBackBufferWidth - 3 * temp.Width;
                            break;
                        case 4:
                            temp.X = graph.PreferredBackBufferWidth - 3 * temp.Width;
                            temp.Y -= 200;
                            break;
                        case 5:
                            temp.X = graph.PreferredBackBufferWidth - 4 * temp.Width;
                            break;
                        case 6:
                            temp.X = 0;
                            break;
                        case 7:
                            temp.X = temp.Width;
                            break;
                        case 8:
                            temp.X = 2 * temp.Width;
                            break;
                        default:
                            {
                                temp.X = 2 * temp.Width;
                                temp.Y += 100;
                            }
                            break;
                    }
                    levelfour[i] = temp;
                }

        }        
        public void WallBounds()
        {
            levelone.Sort();
            levelTwo.Sort();
            levelThree.Sort();
            levelfour.Sort();
            Rectangle rect = new Rectangle(levelone[0].X, levelone[levelone.Count].Y,Bounds.Width,Bounds.Height),ngle=new Rectangle(levelTwo[0].X,levelTwo[levelTwo.Count].Y,Bounds.Width,Bounds.Height);
        }
        public Color Color
        { 
            get { return _color; }
            set { _color = value; }
        }
        public void Draw(SpriteBatch sB)
        {
            if (t == 0)
                foreach (var b in levelone)
                    sB.Draw(Texture, b, Color);
            else if (t == 1)
                foreach (var b in levelTwo)
                    sB.Draw(Texture, b, Color);
            else if (t == 2)
                foreach (var b in levelThree)
                    sB.Draw(Texture,b, Color);
            else if(t==3)
                foreach(var b in levelfour)
                    sB.Draw(Texture,b,Color);
        }
        
    }
}
