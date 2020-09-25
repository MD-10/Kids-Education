using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class TrianglePictureBox2 : PictureBox
{
    public TrianglePictureBox2()
    {
        this.BackColor = Color.Transparent;
    }
    protected override void OnResize(EventArgs e)
    {
        Point[] p = { new Point(this.Width - 1, this.Height - 1), new Point(this.Width - 1, 0), new Point(0, (this.Height - 1) / 2) };
        base.OnResize(e);
        using (var gp = new GraphicsPath())
        {
            gp.AddPolygon(p);
            this.Region = new Region(gp);
        }
    }
}