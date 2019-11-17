using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Presenter
    {
        IView view = new Form1();
        Model model = new Model();
        public Presenter(IView view, Model model)
        {
            this.view = view;
            this.model = model;
            this.view.Load_Panel += LoadPanel;
            this.view.Right_Arrow += Right_Arrow_Presenter;
            this.view.Left_Arrow += Left_Arrow_Presenter;
            this.view.Start_game += Startgame;
            this.view.Start_block_fall += Move_figure_down;
            this.view.Check_if_gameover += End_game_check;
        }

        private void LoadPanel()
        {
            view.rec = model.Load_Panel_Rectangle();
            view.color = (model.Load_Panel_Color());
        }

        private void Startgame()
        {
            LoadPanel();
            model.startgame();
            view.rec = model.Load_Panel_Rectangle();
            view.color = (model.Load_Panel_Color());
        }

        private void Move_figure_down()
        {
            model.figure_down();
            view.rec = model.Load_Panel_Rectangle();
            view.color = (model.Load_Panel_Color());
        }

        private void Right_Arrow_Presenter()
        {
            model.Right_Arrow_Model();
            LoadPanel();
        }

        private void Left_Arrow_Presenter()
        {
            model.Left_Arrow_Model();
            LoadPanel();
        }

        private void End_game_check()
        {
            view.end_game = model.End_game_check();
        }

    }
}
