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
        public Rectangle[] rec { get; set; }
        public Color[] color { get; set; }
        public bool end_game { get; set; }
        private int game_speed = 500; // speed of falling block
        private int arrow_down_speed = 50; // speed of falling block with boost
        private int number_of_pixels = 264; // number of pixels on the screen (12*22)
        Pen p = new Pen(Color.Black);
        SolidBrush myBrush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance 
                | BindingFlags.NonPublic, null, screen, new object[] { true }); // Optimizing bufforing, so you won't see refreshing
        }

        public event Action Load_Panel;
        public event Action Start_game;
        public event Action Start_block_fall;
        public event Action Left_Arrow;
        public event Action Right_Arrow;
        public event Action Check_if_gameover;

        private void Initialize_GameBoy(object sender, EventArgs e) // Initializing form
        {
            Load_Panel?.Invoke();
        }

        private void Create_gameBoy_screen(object sender, PaintEventArgs e) // Drawing game screen panel
        {
            for (int i = 0; i < number_of_pixels; i++) // drawing every single pixel out of 264
            {
                p = new Pen(color[i]); // Initializnig a pen
                myBrush = new SolidBrush(color[i]);  // Initializing a brush
                e.Graphics.DrawRectangle(p, rec[i]); // Drawing a pixel
                e.Graphics.FillRectangle(myBrush, rec[i]); // Coloring a pixel
                p.Dispose(); // Disposing the pen
            }
        }


        private void Start_game_click(object sender, EventArgs e) // When starting button is clicked, then the game starts
        {
            button_start_game.Enabled = false;
            end_game = false; // Setting flag that the game isn't over 
            Start_game?.Invoke();
            screen.Invalidate(); // Refreshing the screen synchronously 
            timer1.Interval = game_speed; // Setting the game speed
            timer1.Start(); // Launching a timer
        }

        private void Continue_or_end(object sender, EventArgs e) // Deciding if continue the game, or end it
        {
            Check_if_gameover?.Invoke(); // Checking if game is over, to see if we can start a new tick

            if (!end_game) // If game isn't over
            {
                Start_block_fall?.Invoke(); // Allowing a block to fall
                screen.Invalidate(); // Refreshing the screen synchronously 
            }
            else
            {
                timer1.Stop(); // Stopping the timer
                MessageBox.Show("Game Over"); // Communicating that player've lost
            }
        }

        private void GameBoy_key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // When left arrow is pressed
            {
                MessageBox.Show("działa");
                Left_Arrow?.Invoke(); // Invokean event
                screen.Invalidate(); // Refreshing the screen synchronously 
            }

            else if (e.KeyCode == Keys.Right) // When right arrow is pressed
            {
                Right_Arrow?.Invoke(); // Invokean event
                screen.Invalidate(); // Refreshing the screen synchronously 
            }

            else if (e.KeyCode == Keys.Down) // When down arrow is pressed
            {
                timer1.Interval = arrow_down_speed; // speed up the game
            }
        }

        private void GameBoy_button_down(object sender, MouseEventArgs e)
        {
            timer1.Interval = arrow_down_speed; // speed up the game
        }

        private void GameBoy_button_left(object sender, MouseEventArgs e)
        {
            Left_Arrow?.Invoke(); // Invokean event
            screen.Invalidate(); // Refreshing the screen synchronously 
        }

        private void GameBoy_button_right(object sender, MouseEventArgs e)
        {
            Right_Arrow?.Invoke(); // Invokean event
            screen.Invalidate(); // Refreshing the screen synchronously 
        }

        private void GameBoy_button_up(object sender, MouseEventArgs e) // Resetting the game speed to normal, after letting up the down arrow
        {
            timer1.Interval = game_speed;
        }

        private void GameBoy_key_up(object sender, KeyEventArgs e) // Resetting the game speed to normal, after letting up the down arrow
        {
            if(e.KeyCode == Keys.Down)
            {
                timer1.Interval = game_speed;
            }
        }
    }
}
