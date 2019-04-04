// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="EmbeddedButton.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{

    public class PVEmbeddedButton : ThemedControl
    {
        public PVEmbeddedButton() : base()
        {
            Font = new Font("Trebuchet MS", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = this.Parent.BackColor;
            }
            catch (Exception ex)
            {
            }
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;


            Rectangle BorderRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle BorderInnerRect = new Rectangle(1, 1, Width - 3, Height - 3);
            Rectangle ButtonRect = new Rectangle(5, 5, Width - 11, Height - 11);


            //| Drawing the button's hole into the form (Whats the whole that a button goes into? There even a name for that???)
            GraphicsPath Out1Path = D.RoundRect(BorderRect, 3);
            GraphicsPath Out2Path = D.RoundRect(BorderInnerRect, 5);
            LinearGradientBrush Out2LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), BorderInnerRect);
            G.DrawPath(new Pen(Out2LGB, 3F), Out2Path);
            G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), Out1Path);

            //| Drawing the button
            int InnerButtonWidth = 10;
            GraphicsPath ButtonPath = D.RoundRect(ButtonRect, 4);
            GraphicsPath ButtonInnerPath = D.RoundRect(new Rectangle(ButtonRect.X + InnerButtonWidth, ButtonRect.Y, ButtonRect.Width - (InnerButtonWidth * 2), ButtonRect.Height), 4);
            GraphicsPath ButtonHighlightPath = D.RoundRect(new Rectangle(ButtonRect.X, ButtonRect.Y + 1, ButtonRect.Width, ButtonRect.Height - 2), 4);
            switch (State)
            {
                case MouseState.None:
                    G.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), ButtonPath);
                    G.FillPath(new SolidBrush(Pal.ColDim), ButtonInnerPath);
                    D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);
                    break;
                case MouseState.Over:
                    G.FillPath(new SolidBrush(Color.FromArgb(255, Pal.ColDim)), ButtonPath);
                    G.FillPath(new SolidBrush(Color.FromArgb(Pal.ColDim.R + 10, Pal.ColDim.G + 10, Pal.ColDim.B + 10)), ButtonInnerPath);
                    D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);
                    break;
                case MouseState.Down:
                    G.FillPath(new SolidBrush(Color.FromArgb(70, Pal.ColDim)), ButtonPath);
                    G.FillPath(new SolidBrush(Pal.ColDim), ButtonInnerPath);
                    G.FillPath(new SolidBrush(Color.FromArgb(50, Pal.ColDark)), ButtonInnerPath);
                    D.FillGradientBeam(G, Color.FromArgb(35, Color.Black), Color.FromArgb(14, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);
                    break;
            }
            if (State == MouseState.Down)
            {
                ButtonHighlightPath = D.RoundRect(new Rectangle(ButtonRect.X, ButtonRect.Y + 1, ButtonRect.Width, ButtonRect.Height - 1), 4);
                G.DrawPath(new Pen(Color.FromArgb(100, Color.Black), 3F), ButtonHighlightPath);
                D.DrawTextWithShadow(G, BorderInnerRect, Text, Font, HorizontalAlignment.Center, Color.FromArgb(200, Pal.ColHighest), Color.Black);

            }
            else
            {
                G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), ButtonHighlightPath);
                D.DrawTextWithShadow(G, BorderInnerRect, Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);

            }
            G.DrawPath(Pens.Black, ButtonPath);

        }
    }
}
