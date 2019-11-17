using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Field
    {
        private Block block;
        private Rectangle[] tab_rec = new Rectangle[264]; // initializing a table of rectagnles for a matrix (12*22)
        private Color[] colour_matrix = new Color[264];
        private bool stop_moving_down = false; // looks for collision 
        private bool game_over = false; // checks if game is over
        private bool move_left = true; // checks if there is a possible move
        private bool colored_line = true; // checks if there is a fully colored line to delete
        private readonly string[] colours = {"Cyan", "MediumOrchid", "Gainsboro", "Coral", "Pink", "Khaki", "RoyalBlue", "Lime"}; // initializing the list of colours
        private string colour; // contains the colour of currently falling block
        private string bgColour = "OliveDrab";
        private const int cols = 12; // initializing number of columns on the board
        private const int rows = 22; // initializing number of rows on the board
        private readonly Crate[,] matrix_crate = new Crate[cols, rows]; // Initializing the matrix crate for a display


        public Field() // Creating a matrix for display
        {
            for (int i= 0; i <cols; i++)
            {
                for (int j=0; j < rows; j++)
                {
                    matrix_crate[i, j] = new Crate(i,j);
                }
            }
        }

        public Rectangle[] Fillup_tab_rec() // Filling up matrix pixels with squares defined in Crate class
        {
            int idx = 0;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    tab_rec[idx] = matrix_crate[i, j].Get_square(); // Filling up matrix pixels with squares defined in Crate class
                    idx++;
                }
            }
            return tab_rec;
        }


        
        public void Draw_block() // Finally, drawing a block
        {
            block = new Block();
            int idx = block.Get_block_index();
            //Console.WriteLine(idx);
            colour = colours[idx];
           
            for (int i = 0; i < block.Return_coordinates().Length; i++)
            {
                if (matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Get_colour_name() != bgColour) // If there is no space to create a new block, then game is over
                {
                    game_over = true;
                }
                i++;
            }

            if (!game_over) // If ganme isn't over
            {
                for (int i = 0; i < block.Return_coordinates().Length; i++)
                {
                    matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(colour); // Drawing a new block to fall
                    i++;
                }
            }
        }

        public void Move_block_down() // Moving block down
        {
            try
            {
                for (int l= 0; l < block.Bottom_sensor_down().Length; l++) 
                {
                    if(matrix_crate[block.Bottom_sensor_down()[l], block.Bottom_sensor_down()[l + 1]].Get_colour_name() != bgColour) // Checking if a block won't hit another block
                    {
                        stop_moving_down = true;
                    }
                    l++;
                }

                if (!stop_moving_down) // Moving block down
                {
                    for (int i = 0; i < block.Return_coordinates().Length; i++) // Blanking the old positon block
                    {
                        matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(bgColour);
                        i++;
                    }

                    block.Block_coordinates_down(); // Moving down the coordinates of falling block

                    for (int i = 0; i < block.Return_coordinates().Length; i++) // Displaying the new position block
                    {
                        matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(colour);
                        i++;
                    }
                }

                else
                {
                    Check_if_line(); // Checking if there is a colored line
                    stop_moving_down = false; // Letting a new block to fall further
                    Draw_block(); // Drawing a block
                }
            }

            catch (System.IndexOutOfRangeException) // Checking if our block won't fall out of the grid
            {
               Check_if_line(); // Checking if there is a colored line  
               Draw_block(); // Drawing a block
            }
        }


        public void Move_block_left() // Moving block left
        {
            try
            {
                for (int l = 0; l < block.Left_sensor_left().Length; l++)
                {
                    if (matrix_crate[block.Left_sensor_left()[l], block.Left_sensor_left()[l + 1]].Get_colour_name() != bgColour) // Checking if a block won't hit another block
                    {
                        move_left = false;
                    }
                    l++;
                }

                if (move_left)
                {
                    for (int i = 0; i < block.Return_coordinates().Length; i++)
                    {
                        matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(bgColour); // Blanking the old positon block
                        i++;
                    }

                    block.Block_coordinates_left(); // Moving left the coordinates of falling block

                    for (int i = 0; i < block.Return_coordinates().Length; i++)
                    {
                        matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(colour); // Displaying the new position block
                        i++;
                    }
                }
                else
                {
                    move_left = true;
                }
            }

            catch (System.IndexOutOfRangeException)
            {
            }
        }

        public void Move_block_right() // Moving block right
        {
            try
            {
                for (int l = 0; l < block.Right_sensor_right().Length; l++)
                {
                    if (matrix_crate[block.Right_sensor_right()[l], block.Right_sensor_right()[l + 1]].Get_colour_name() != bgColour) // Checking if a block won't hit another block
                    {
                        move_left = false;
                    }
                    l++;
                }

                if (move_left)
                {
                    for (int i = 0; i < block.Return_coordinates().Length; i++)
                    {
                        matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(bgColour); // Blanking the old positon block
                        i++;
                    }

                    block.Block_coordinates_right(); // Moving right the coordinates of falling block

                    for (int i = 0; i < block.Return_coordinates().Length; i++)
                    {
                        matrix_crate[block.Return_coordinates()[i], block.Return_coordinates()[i + 1]].Change_colour(colour); // Displaying the new position block
                        i++;
                    }
                }
                else
                {
                    move_left = true;
                }
            }

            catch (System.IndexOutOfRangeException)
            {
            }
        }

        private void Check_if_line() // Checking for fully colored line to delete
        {
            for (int idx = 0; idx < rows; idx++)
            {
                for(int idx2 = 0; idx2 < cols; idx2++)
                {
                    if (matrix_crate[idx2, idx].Get_colour_name() == bgColour)
                    {
                        colored_line = false;
                    }
                }

                if (colored_line)
                {
                    for (int idx3 = 0; idx3 < cols; idx3++)
                    {
                        for (int idx4 = idx; idx4 >= 0; idx4--)
                        {
                            if (idx4 != 0)
                            {
                                matrix_crate[idx3, idx4].Change_colour(matrix_crate[idx3, idx4 - 1].Get_colour_name()); // Moving down remaining blocks
                            }
                            else
                            {
                                matrix_crate[idx3, idx4].Change_colour(bgColour); // Setting bgcolour to empty fields
                            }
                        }
                    }
                }
                else colored_line = true;
            }
        }

        public Color[] Return_colour_matrix() // Returning a table of colours in grid
        {
            int idx = 0;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    colour_matrix[idx] = matrix_crate[i, j].Show_color(); // filling up colour_matrix with corresponding colours
                    idx++;
                }
            }

            return colour_matrix;
        }

        public bool Return_game_over() // Returning variable containing game status
        {
            return game_over;
        }
    }
}
