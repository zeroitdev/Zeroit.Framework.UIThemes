// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.NYX
{

    public class NYXGroupBox : ThemeContainer154
    {
        //Coded by HΛWK

        int x = 1;

        bool gR = true;
        public bool Animated
        {
            get { return IsAnimated; }
            set
            {
                IsAnimated = value;
                Invalidate();
            }
        }

        //Coded by HΛWK
        public NYXGroupBox()
        {
            ControlMode = true;
            Font = new Font("Arial", 9);
            Size = new Size(150, 100);
            Animated = true;
        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            if (gR == true)
            {
                x += 1;
            }
            else
            {
                x -= 1;
            }
            if (x >= this.Width - 1)
            {
                x = -39;
            }
            else if (x <= 1)
            {
                gR = true;
            }
            Invalidate();
        }

        protected override void ColorHook()
        {
        }

        //Coded by HΛWK
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, 30, 30));
            int textWidth = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            int textHeight = (int)this.CreateGraphics().MeasureString(Text, Font).Height;
            //Borders
            Point[] borderPoints = {
            new Point(0, 1),
            new Point(1, 0),
            new Point(Width - 2, 0),
            new Point(Width - 1, 1),
            new Point(Width - 1, Height - 2),
            new Point(Width - 2, Height - 1),
            new Point(1, Height - 1),
            new Point(0, Height - 2)
        };
            G.DrawPolygon(Pens.Black, borderPoints);
            G.DrawLine(Pens.Black, new Point(0, textHeight + 4), new Point(Width - 1, textHeight + 4));
            //GroupArea
            Rectangle groupRect = new Rectangle(1, textHeight + 5, Width - 2, Height - (textHeight + 6));
            G.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), groupRect);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(12, 12, 12))), new Rectangle(1, textHeight + 6, Width - 3, Height - (textHeight + 6) - 2));
            //TextArea
            Rectangle textRect = new Rectangle(1, 1, Width - 2, textHeight + 5);
            G.FillRectangle(new SolidBrush(Color.FromArgb(15, 15, 15)), textRect);
            //TextArea Glow
            if (Animated == true)
            {
                Rectangle glowRect = new Rectangle(x, 1, 40, textHeight + 4);
                ColorBlend text_cblend = new ColorBlend(3);
                text_cblend.Colors[0] = Color.FromArgb(15, 15, 15);
                text_cblend.Colors[1] = Color.FromArgb(150, 0, 0);
                text_cblend.Colors[2] = Color.FromArgb(15, 15, 15);
                text_cblend.Positions = new float[]{
                0.0f,
                0.5f,
                1.0f
            };
                DrawGradient(text_cblend, glowRect, 0f);
                //Reinforce Borders
                G.DrawPolygon(Pens.Black, borderPoints);
            }
            G.DrawLine(Pens.Black, new Point(0, (textHeight + 5)), new Point((Width - 1), (textHeight + 5)));
            //Text
            int h = (Width - 1) / 2;
            G.DrawString(Text, Font, Brushes.Black, new Point(h - (textWidth / 2), 4));
            G.DrawString(Text, Font, Brushes.White, new Point(h - (textWidth / 2), 3));
        }
    }

}

