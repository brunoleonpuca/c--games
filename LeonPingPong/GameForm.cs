﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeonPingPong
{
    public partial class gameForm : Form
    {
        public int speed_left = 4; //speed for the ball x
        public int speed_top = 4; //speed for the ball y
        public int points = 0; //score count

        

        public gameForm()
        {
            InitializeComponent(); //lo que debe suceder al inicializar el juego (condiciones)

            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None; 
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = playground.Bottom - (playground.Bottom / 10); //ubica la raqueta abajo del playground

            gameOverLabel.Left = (playground.Width / 2) - (gameOverLabel.Width / 2); 
            gameOverLabel.Top = (playground.Height / 2) - (gameOverLabel.Height / 2); //ubica el game over en el centro del playground
            gameOverLabel.Visible = false; //la convierte invisible al empezar el juego, dsp deberia aparecer tapando todo lo demas
        }

        private void timer1_Tick(object sender, EventArgs e) //acciones que suceden a partir del interval time, refresh events segun tiempo
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                points += 1;
                pointsLabel.Text = points.ToString();
                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }

            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }

            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                gameOverLabel.Visible = true;
                ball.Visible = false;
                racket.Visible = false;
            }
        }

        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.F1) //reset value for the game
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                pointsLabel.Text = "0";
                timer1.Enabled = true;
                gameOverLabel.Visible = false;
                ball.Visible = true;
                racket.Visible = true;
                playground.BackColor = Color.White;
            }
        }
    }
}
