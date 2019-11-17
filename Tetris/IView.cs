using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface IView
    {
        System.Drawing.Rectangle[] rec { get; set; }
        System.Drawing.Color[] color { get; set; }
        bool end_game { get; set; }
        event Action Load_Panel;
        event Action Start_game;
        event Action Start_block_fall;
        event Action Check_if_gameover;
        event Action Left_Arrow;
        event Action Right_Arrow;
    }
}
