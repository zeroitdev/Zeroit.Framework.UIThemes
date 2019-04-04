// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{

    public class iButton : ThemeControl154
    {
        protected override void ColorHook()
        {
        }

        public iButton()
        {
            IsAnimated = true;
            Size = new Size(100, 28);
            MinimumSize = new Size(40, 20);
            this.Cursor = Cursors.Hand;
        }

        private int glow = 180;

        private bool overButton = false;

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));

            GraphicsPath gp = CreateRound(new Rectangle(0, 0, Width - 1, Height - 1), 8);
            PathGradientBrush pgb = new PathGradientBrush(gp);

            G.FillPath(Brushes.Black, gp);

            pgb.CenterColor = Color.FromArgb(200, Color.SteelBlue);
            pgb.SurroundColors = new Color[] { Color.FromArgb(glow, Color.SteelBlue) };
            pgb.CenterPoint = new Point((this.Width - 1) / 2, (this.Height - 1) / 2);

            G.FillPath(pgb, gp);
            G.DrawPath(Pens.DeepSkyBlue, gp);

            int textWidth = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            int textHeight = (int)this.CreateGraphics().MeasureString(Text, Font).Height;
            SolidBrush textShadow = new SolidBrush(Color.FromArgb(30, 15, 0));
            Rectangle textRect = new Rectangle(3, 3, textWidth + 10, textHeight);
            Point textPoint = new Point((Width / 2) - (textWidth / 2), (Height / 2) - (textHeight / 2));
            Point textShadowPoint = new Point((Width / 2) - (textWidth / 2) + 1, (Height / 2) - (textHeight / 2) + 1);
            G.DrawString(Text, Font, textShadow, textShadowPoint);
            G.DrawString(Text, Font, Brushes.WhiteSmoke, textPoint);

        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            overButton = true;
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            overButton = false;
        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            if (overButton)
            {
                if (glow < 230)
                    glow += 1;
            }
            else
            {
                if (glow > 182)
                {
                    glow -= 2;
                }
                else if (glow > 180 & glow < 182)
                {
                    glow = 180;
                }
            }
        }

    }


}


