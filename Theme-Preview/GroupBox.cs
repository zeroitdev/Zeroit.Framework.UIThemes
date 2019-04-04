// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
    public class PVGroupbox : ThemedContainer
    {
        public PVGroupbox() : base()
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

            //| Pretty much the same as the button, minus the button itself. Looked good as a container.
            GraphicsPath Out1Path = D.RoundRect(BorderRect, 3);
            GraphicsPath Out2Path = D.RoundRect(BorderInnerRect, 5);
            LinearGradientBrush Out2LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.FromArgb(0, 0, 10))), BorderInnerRect);
            G.DrawPath(new Pen(Out2LGB, 3F), Out2Path);
            G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), Out1Path);

            //| Drawing the text area
            if (Text.Length > 0)
            {
                Rectangle TextRect = new Rectangle(1, 1, G.MeasureString(Text, Font).ToSize().Width, G.MeasureString(Text, Font).ToSize().Height + 5);
                Rectangle TextInnerRect = new Rectangle(1, 2, G.MeasureString(Text, Font).ToSize().Width, G.MeasureString(Text, Font).ToSize().Height + 5 - 1);
                Rectangle TextInnerRect2 = new Rectangle(1, 1, G.MeasureString(Text, Font).ToSize().Width, G.MeasureString(Text, Font).ToSize().Height + 5 - 1);
                Rectangle TextDropshadow = new Rectangle(2, 2, G.MeasureString(Text, Font).ToSize().Width - 1, G.MeasureString(Text, Font).ToSize().Height + 4);


                GraphicsPath TextPath = D.RoundRect(TextRect, 3);
                GraphicsPath TextInnerPath = D.RoundRect(TextInnerRect, 3);
                GraphicsPath TextInnerPath2 = D.RoundRect(TextInnerRect2, 3);
                GraphicsPath TextDSPath = D.RoundRect(TextDropshadow, 3);

                G.DrawPath(new Pen(Color.Black, 2F), TextDSPath);
                G.FillPath(new SolidBrush(Pal.ColDim), TextPath);
                G.DrawPath(new Pen(Color.FromArgb(45, Pal.ColHighest)), TextInnerPath);
                G.DrawPath(new Pen(Color.FromArgb(30, Pal.ColHighest)), TextInnerPath2);
                G.DrawPath(new Pen(Color.Black), TextPath);
                D.DrawTextWithShadow(G, new Rectangle(TextInnerRect.X - 10, TextInnerRect.Y + 1, TextInnerRect.Width + 20, TextInnerRect.Height - 4), Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
            }
        }
    }
}
