using System;
using System.Drawing;
using System.Windows.Forms;

public class TextProgressBar : ProgressBar
{
    public Color FillColor { get; set; } = Color.RoyalBlue;
    public Brush FontColor { get; set; } = Brushes.White;
    public string CustomText { get; set; }

    public TextProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;
        Graphics g = e.Graphics;

        // Draw the background color of the progress bar
        Color backgroundColor = Color.FromArgb(18, 18, 32);
        using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
        {
            g.FillRectangle(backgroundBrush, rect);
        }

        // Modify the rectangle for the progress bar
        rect.Inflate(-3, -3);
        if (Value > 0)
        {
            Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
            g.FillRectangle(new SolidBrush(FillColor), clip);
        }

        string text = string.IsNullOrEmpty(CustomText) ? $"{Value}%" : CustomText;
        SizeF textSize = g.MeasureString(text, Font);

        PointF locationToDraw = new PointF((Width / 2) - (textSize.Width / 2), (Height / 2) - (textSize.Height / 2));

        // Draw shadow effect for the text
        PointF shadowOffset = new PointF(locationToDraw.X + 1, locationToDraw.Y + 1);
        g.DrawString(text, Font, Brushes.Black, shadowOffset);

        // Draw the text
        g.DrawString(text, Font, FontColor, locationToDraw);
    }


    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Remove the base call to avoid painting the background
    }

}
