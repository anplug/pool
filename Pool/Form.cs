using System;

namespace Pool
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly Table table;

        public Form()
        {
            InitializeComponent();
            this.table = new Table(this.board, this.amountOfBalls);
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.table.SpawnBall();
        }
        private void ResizeBalls_Click(object sender, EventArgs e)
        {
            this.table.ResizeAllBalls();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            this.table.UpdateTick();
        }
    }
}
