
using System;
using System.Drawing;
using Wisej.Web;

namespace ChileanFlagWisej
{
	public partial class Window1 : Form
	{
        private readonly BanderaChileDrawer drawer = new BanderaChileDrawer();

        public Window1()
		{
			InitializeComponent();

            Text = "Bandera Chilena - Wisej.NET";
            this.Size = new Size(900, 600);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
     
            base.OnPaint(e);

            var rect = new RectangleF(0, 0, this.Width, this.Height);
            drawer.Draw(e.Graphics, rect);
        }

        private void Window1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
