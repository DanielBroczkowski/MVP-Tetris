using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form, IView
    {
        #region interface
        public Rectangle[] rec { get; set; }
        public Color[] color { get; set; }
        public bool end_game{get;set;}
        Pen p;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
        
        SolidBrush myBrush;
        #endregion

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
        }

        public event Action Load_Panel;
        public event Action Start_game;
        public event Action Move_Figure_down;
        public event Action End_game_check;
        public event Action Left_Arrow;
        public event Action Right_Arrow;
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Panel?.Invoke();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 150; i++)
            {
                    p = new Pen(color[i]);
                    myBrush = new SolidBrush(color[i]);
                    e.Graphics.DrawRectangle(p, rec[i]);
                    e.Graphics.FillRectangle(myBrush, rec[i]);
                    p.Dispose();
            }
            

        }
        private bool _ticks = false;

        private void button_start_game_Click(object sender, EventArgs e)
        {
            button_start_game.Enabled = false;

            end_game = false;
            Start_game?.Invoke();
            panel1.Invalidate();
            timer1.Interval=700;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            End_game_check?.Invoke();
            if (end_game == false)
            {
                _ticks = true;
                if (_ticks == true)
                {
                    Move_Figure_down?.Invoke();
                    panel1.Invalidate();
                    _ticks = false;
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Koniec Gry");
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Left_Arrow?.Invoke();

                panel1.Invalidate();
            }
            else if (e.KeyCode == Keys.Right)
            {
                Right_Arrow?.Invoke();

                panel1.Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                timer1.Interval = 100;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                timer1.Interval = 700;
            }
        }
    }
}
