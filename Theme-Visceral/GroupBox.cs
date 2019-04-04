// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.CrystalClear
{
    public class VisceralGroupBox : ContainerControl
    {

        private Size _ImageSize;
        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        public VisceralGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TopBar = new Rectangle(10, 0, 130, 25);
            Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

            base.OnPaint(e);

            G.Clear(Color.Transparent);

            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush bodygrade = new LinearGradientBrush(ClientRectangle, Color.FromArgb(15, 15, 15), Color.FromArgb(22, 22, 22), 120);
            G.FillPath(bodygrade, Draw.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), 1));

            LinearGradientBrush outerBorder = new LinearGradientBrush(ClientRectangle, Color.DimGray, Color.Gray, 90);
            G.DrawPath(new Pen(outerBorder), Draw.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), 1));
            LinearGradientBrush outerBorder2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), 90);
            G.DrawPath(new Pen(outerBorder2), Draw.RoundRect(new Rectangle(2, 13, Width - 5, Height - 15), 1));
            //Dim outerBorder3 As New LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), 90S)
            //G.DrawPath(New Pen(outerBorder2), Draw.RoundRect(New Rectangle(3, 14, Width - 7, Height - 17), 1))

            LinearGradientBrush lbb = new LinearGradientBrush(TopBar, Color.FromArgb(30, 30, 32), Color.FromArgb(25, 25, 25), 90);
            G.FillPath(lbb, Draw.RoundRect(TopBar, 1));

            G.DrawPath(Pens.DimGray, Draw.RoundRect(TopBar, 2));

            if ((Image != null))
            {
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                G.DrawImage(Image, new Rectangle(TopBar.Width - 115, 5, 16, 16));
                G.DrawString(Text, Font, Brushes.White, 35, 5);
            }
            else
            {
                G.DrawString(Text, Font, new SolidBrush(Color.White), TopBar, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


    }

}

