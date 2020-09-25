using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class Ballon : PictureBox
{
    public Ballon()
    {
        this.BackColor = Color.Transparent;
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        using (var gp = new GraphicsPath())
        {
            gp.AddEllipse(0 , 0, this.Width , this.Height);
            this.Region = new Region(gp);
        }
    }
}