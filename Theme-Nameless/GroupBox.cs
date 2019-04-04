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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Nameless
{
    public class NamelessGroupBox : ThemeContainer154
    {
        public NamelessGroupBox()
        {
            ControlMode = true;
            Header = 22;
        }
        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, Color.DimGray));
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.DrawLine(new Pen(Color.FromArgb(120, 120, 120)), 0, 23, Width, 23);



            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(120, 120, 120)))), new Rectangle(0, 0, Width - 1, Height - 1));


            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(2, 2, Width - 5, 11), Color.FromArgb(150, 150, 150), Color.FromArgb(50, 50, 50), 90);
            G.FillRectangle(HeaderLGB, new Rectangle(2, 2, Width - 5, 8));

            //'

            DrawBorders(new Pen(Color.FromArgb(130, 130, 130)), new Rectangle(3, 3, Width - 6, 18));


            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0);

        }
    }


}