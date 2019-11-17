using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Kratka
    {
        Rectangle rec;
        private Color color;
        private int x, y;
        private const int dimension = 30;
        public Kratka(int x, int y)
        {
            this.x = x * dimension;
            this.y = y * dimension;
            color = Color.Black;
        }
        public Color check_color()
        {
            return color;
        }
        public Rectangle square_return()
        {
            return rec = new Rectangle(x, y, dimension, dimension);
            
        }
        public void change_color(string name)
        {
            this.color = Color.FromName(name);
        }
        public string get_color()
        {
            return color.Name;
        }
    }
}
