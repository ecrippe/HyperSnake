namespace Snake
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.powerup = new System.Windows.Forms.Label();
            this.enemy = new System.Windows.Forms.Label();
            this.lblPowerup = new System.Windows.Forms.Label();
            this.lblEnemies = new System.Windows.Forms.Label();
            this.hscore = new System.Windows.Forms.Label();
            this.lblHighscore = new System.Windows.Forms.Label();
            this.bhs = new System.Windows.Forms.Label();
            this.ehs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.SpringGreen;
            this.pbCanvas.Location = new System.Drawing.Point(17, 16);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(550, 550);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(595, 115);
            this.score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(159, 56);
            this.score.TabIndex = 1;
            this.score.Text = "Score: ";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(925, 124);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 38);
            this.lblScore.TabIndex = 2;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(37, 115);
            this.lblGameOver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(115, 47);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.Text = "label2";
            this.lblGameOver.Visible = false;
            this.lblGameOver.Click += new System.EventHandler(this.lblGameOver_Click);
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer.Location = new System.Drawing.Point(595, 187);
            this.timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(146, 56);
            this.timer.TabIndex = 4;
            this.timer.Text = "Timer:";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(925, 201);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 38);
            this.lblTimer.TabIndex = 5;
            // 
            // powerup
            // 
            this.powerup.AutoSize = true;
            this.powerup.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerup.Location = new System.Drawing.Point(595, 254);
            this.powerup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerup.Name = "powerup";
            this.powerup.Size = new System.Drawing.Size(190, 56);
            this.powerup.TabIndex = 6;
            this.powerup.Text = "Powerup:";
            // 
            // enemy
            // 
            this.enemy.AutoSize = true;
            this.enemy.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemy.Location = new System.Drawing.Point(595, 322);
            this.enemy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemy.Name = "enemy";
            this.enemy.Size = new System.Drawing.Size(285, 56);
            this.enemy.TabIndex = 7;
            this.enemy.Text = "Poison Apples:";
            // 
            // lblPowerup
            // 
            this.lblPowerup.AutoSize = true;
            this.lblPowerup.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerup.Location = new System.Drawing.Point(925, 268);
            this.lblPowerup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPowerup.Name = "lblPowerup";
            this.lblPowerup.Size = new System.Drawing.Size(0, 38);
            this.lblPowerup.TabIndex = 8;
            // 
            // lblEnemies
            // 
            this.lblEnemies.AutoSize = true;
            this.lblEnemies.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemies.Location = new System.Drawing.Point(925, 336);
            this.lblEnemies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnemies.Name = "lblEnemies";
            this.lblEnemies.Size = new System.Drawing.Size(0, 38);
            this.lblEnemies.TabIndex = 9;
            // 
            // hscore
            // 
            this.hscore.AutoSize = true;
            this.hscore.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hscore.Location = new System.Drawing.Point(595, 398);
            this.hscore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hscore.Name = "hscore";
            this.hscore.Size = new System.Drawing.Size(245, 56);
            this.hscore.TabIndex = 10;
            this.hscore.Text = "High Score:";
            // 
            // lblHighscore
            // 
            this.lblHighscore.AutoSize = true;
            this.lblHighscore.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighscore.Location = new System.Drawing.Point(925, 412);
            this.lblHighscore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighscore.Name = "lblHighscore";
            this.lblHighscore.Size = new System.Drawing.Size(0, 38);
            this.lblHighscore.TabIndex = 11;
            // 
            // bhs
            // 
            this.bhs.AutoSize = true;
            this.bhs.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bhs.Location = new System.Drawing.Point(611, 519);
            this.bhs.Name = "bhs";
            this.bhs.Size = new System.Drawing.Size(199, 24);
            this.bhs.TabIndex = 12;
            this.bhs.Text = "Ben\'s High Score: 4009";
            // 
            // ehs
            // 
            this.ehs.AutoSize = true;
            this.ehs.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ehs.Location = new System.Drawing.Point(873, 519);
            this.ehs.Name = "ehs";
            this.ehs.Size = new System.Drawing.Size(212, 24);
            this.ehs.TabIndex = 13;
            this.ehs.Text = "Elliot\'s High Score: 5000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1159, 600);
            this.Controls.Add(this.ehs);
            this.Controls.Add(this.bhs);
            this.Controls.Add(this.lblHighscore);
            this.Controls.Add(this.hscore);
            this.Controls.Add(this.lblEnemies);
            this.Controls.Add(this.lblPowerup);
            this.Controls.Add(this.enemy);
            this.Controls.Add(this.powerup);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.score);
            this.Controls.Add(this.pbCanvas);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "HyperSnake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label powerup;
        private System.Windows.Forms.Label enemy;
        private System.Windows.Forms.Label lblPowerup;
        private System.Windows.Forms.Label lblEnemies;
        private System.Windows.Forms.Label hscore;
        private System.Windows.Forms.Label lblHighscore;
        private System.Windows.Forms.Label bhs;
        private System.Windows.Forms.Label ehs;
    }
}

