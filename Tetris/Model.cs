using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tetris
{
    class Model
    {
        Field field = new Field();
        public Rectangle[] Load_Panel_Rectangle()
        {
            return field.Fillup_tab_rec();
        }

        public Color[] Load_Panel_Color()
        {
            return field.Return_colour_matrix();
        }

        public void startgame()
        {
            field.Draw_block();
        }

        public void figure_down()
        {
            field.Move_block_down();
        }

        public bool End_game_check()
        {
            return field.Return_game_over();
        }

        public void Left_Arrow_Model()
        {
            field.Move_block_left();
        }

        public void Right_Arrow_Model()
        {
            field.Move_block_right();
        }
    }
}
