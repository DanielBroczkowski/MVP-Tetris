namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.screen = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_start_game = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_left = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.Location = new System.Drawing.Point(126, 87);
            this.screen.MaximumSize = new System.Drawing.Size(240, 440);
            this.screen.MinimumSize = new System.Drawing.Size(240, 440);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(240, 440);
            this.screen.TabIndex = 1;
            this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.Create_gameBoy_screen);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(113, 677);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameBoy_button_left);
            // 
            // button_start_game
            // 
            this.button_start_game.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button_start_game.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_start_game.FlatAppearance.BorderSize = 0;
            this.button_start_game.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button_start_game.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button_start_game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start_game.Location = new System.Drawing.Point(272, 677);
            this.button_start_game.Name = "button_start_game";
            this.button_start_game.Size = new System.Drawing.Size(40, 41);
            this.button_start_game.TabIndex = 0;
            this.button_start_game.UseVisualStyleBackColor = false;
            this.button_start_game.Click += new System.EventHandler(this.Start_game_click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Continue_or_end);
            // 
            // button_left
            // 
            this.button_left.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_left.FlatAppearance.BorderSize = 0;
            this.button_left.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button_left.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_left.Location = new System.Drawing.Point(160, 677);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(26, 23);
            this.button_left.TabIndex = 2;
            this.button_left.UseVisualStyleBackColor = false;
            this.button_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameBoy_button_right);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(136, 697);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 31);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameBoy_button_down);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameBoy_button_up);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris.Properties.Resources.back1;
            this.ClientSize = new System.Drawing.Size(492, 845);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_start_game);
            this.Controls.Add(this.screen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Initialize_GameBoy);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameBoy_key_down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameBoy_key_up);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Button button_start_game;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button3;
    }
}

