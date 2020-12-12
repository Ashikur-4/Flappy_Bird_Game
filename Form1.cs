using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipespeed = 8; // default pipespeed
        int gravity = 20; //default gravityspeed
        int score = 0; //default score =0

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerend(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity; //link the flappybird picbox to the gravity , += means itt will add the speed of gravity pic box top locaton , so its can move
            PipeBottom.Left -= pipespeed; // link the bottom pipes left position to the pipe speed integer, it will reduce the pipe speed value from the left position of the pipe picture box so it will move left with each tick
            Pipeup.Left -= pipespeed; // the same is happening with the top pipe, reduce the value of pipe speed integer from the left position of the pipe using the -= sign
            Gamesc.Text = "Score :" + score; //show the current score on the score text label

            if (PipeBottom.Left < -40)
            {
                // if the bottom pipes location is -150 then we will reset it back to 800 and add 1 to the score
                PipeBottom.Left = 600;
                score++;
            }
            if(Pipeup.Left < -45)
            {
                // if the top pipe location is -180 then we will reset the pipe back to the 950 and add 1 to the score
                Pipeup.Left = 650;
                score++;
            }

            // the if statement below is checking if the pipe hit the ground, pipes or if the player has left the screen from the top
            // the two pipe symbols stand for OR inside of an if statement so we can have multiple conditions inside of this if statement because its all going to do the same thing

            if (FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Pipeup.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Ground.Bounds))
            {
                EndGame();
            }

            if(score > 5)
            {
                pipespeed = 25;
            }

            if(score > 20 )
            {
                pipespeed = 30;                        
            }
            if(FlappyBird.Top < -25)
            {
                EndGame();
            }



        }

        private void GameisDown(object sender, KeyEventArgs e)
        {
            // this is the game key is down event thats linked to the main form
            if (e.KeyCode == Keys.Space)
            {
                gravity = -20;
            }

        }

        private void GameisUp(object sender, KeyEventArgs e)
        {
            // this is the game key is up event thats linked to the main form
            if (e.KeyCode == Keys.Space)
            {
                gravity = 20 ;
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            Gamesc.Text += "\t Game over...!!! ";
        }
    }
}
