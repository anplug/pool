namespace Pool
{
    partial class Form
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonResize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.amountOfBalls = new System.Windows.Forms.Label();
            this.ballsCountLabel = new System.Windows.Forms.Label();
            this.board = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(891, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(60, 30);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Spawn";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // buttonResize
            // 
            this.buttonResize.Location = new System.Drawing.Point(957, 5);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(60, 30);
            this.buttonResize.TabIndex = 2;
            this.buttonResize.Text = "Resize";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.Click += new System.EventHandler(this.ResizeBalls_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.amountOfBalls);
            this.panel1.Controls.Add(this.ballsCountLabel);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.buttonResize);
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 40);
            this.panel1.TabIndex = 3;
            // 
            // amountOfBalls
            // 
            this.amountOfBalls.AutoSize = true;
            this.amountOfBalls.Location = new System.Drawing.Point(91, 14);
            this.amountOfBalls.Name = "amountOfBalls";
            this.amountOfBalls.Size = new System.Drawing.Size(0, 13);
            this.amountOfBalls.TabIndex = 4;
            // 
            // ballsCountLabel
            // 
            this.ballsCountLabel.AutoSize = true;
            this.ballsCountLabel.Location = new System.Drawing.Point(3, 14);
            this.ballsCountLabel.Name = "ballsCountLabel";
            this.ballsCountLabel.Size = new System.Drawing.Size(82, 13);
            this.ballsCountLabel.TabIndex = 3;
            this.ballsCountLabel.Text = "Amount of balls:";
            // 
            // board
            // 
            this.board.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.board.BackColor = System.Drawing.Color.DarkCyan;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(1025, 460);
            this.board.TabIndex = 4;
            this.board.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1028, 503);
            this.Controls.Add(this.board);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(835, 537);
            this.Name = "Form";
            this.Text = "Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.Label ballsCountLabel;
        private System.Windows.Forms.Label amountOfBalls;
    }
}

