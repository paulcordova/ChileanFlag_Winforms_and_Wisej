using System.Drawing;
using System.Windows.Forms;


namespace ChileanFlagWin
{
     

    public partial class Form1 : Form
    {
        private readonly BanderaChileDrawer drawer = new BanderaChileDrawer();
        public Form1()
        {
            InitializeComponent();

            Text = "Bandera Chilena - WinForm";
            DoubleBuffered = true;
            ClientSize = new Size(900, 600);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var margin = 20;
            var rect = new RectangleF(margin, margin, ClientSize.Width - 2 * margin, ClientSize.Height - 2 * margin);
            drawer.Draw(e.Graphics, rect);
        }
    }
}
