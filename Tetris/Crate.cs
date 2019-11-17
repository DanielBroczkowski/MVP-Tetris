using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Crate
    {
        Rectangle rect; // Creating a rectangle
        private Color colour; // Initializing variable containing a color name
        private int x, y; // Initializing variables containing coordinates of the starting square of block
        private const int dimension = 20; // Initializing the size of a single square

        public Crate(int x, int y) // Definition of a single square
        {
            this.x = x * dimension;
            this.y = y * dimension;
            colour = Color.OliveDrab;
        }

        public Rectangle Get_square() // Returns a square
        {
            return rect = new Rectangle(x, y, dimension, dimension);
        }

        public void Change_colour(string name) // Changes the colour
        {
            colour = Color.FromName(name);
        }

        public Color Show_color() // Returns a colour of a block
        {
            return colour;
        }

        public string Get_colour_name() // Returns the name of a colour
        {
            return colour.Name;
        }
    }
}
