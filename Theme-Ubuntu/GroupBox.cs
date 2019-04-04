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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Ubuntu
{
    public class UbuntuGroupBox : ContainerControl
    {

        public UbuntuGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TopBar = new Rectangle(0, 0, Width - 1, 20);
            Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

            base.OnPaint(e);

            G.Clear(Color.Transparent);

            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush bodygrade = new LinearGradientBrush(ClientRectangle, Color.White, Color.White, 120);
            G.FillPath(bodygrade, Draw.RoundRect(new Rectangle(0, 12, Width - 1, Height - 15), 1));

            LinearGradientBrush outerBorder = new LinearGradientBrush(ClientRectangle, Color.FromArgb(50, 50, 50), Color.DimGray, 90);
            G.DrawPath(new Pen(outerBorder), Draw.RoundRect(new Rectangle(0, 12, Width - 1, Height - 15), 1));

            LinearGradientBrush lbb = new LinearGradientBrush(TopBar, Color.FromArgb(87, 86, 81), Color.FromArgb(60, 59, 55), 90);
            G.FillPath(lbb, Draw.RoundRect(TopBar, 1));

            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), Draw.RoundRect(TopBar, 2));

            Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);

            G.DrawString(Text, drawFont, new SolidBrush(Color.White), TopBar, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


