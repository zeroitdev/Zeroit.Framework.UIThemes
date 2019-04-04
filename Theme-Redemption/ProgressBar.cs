// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionProgressBar : Control
    {

        #region "Properties"
        private int val;
        public int Value
        {
            get { return val; }
            set
            {
                if (value > max)
                {
                    val = max;
                }
                else if (value < 0)
                {
                    val = 0;
                }
                else
                {
                    val = value;
                }
                Invalidate();
            }
        }
        private int max;
        public int Maximum
        {
            get { return max; }
            set
            {
                if (value < 1)
                {
                    max = 1;
                }
                else
                {
                    max = value;
                }

                if (value < val)
                {
                    val = max;
                }

                Invalidate();
            }
        }
        #endregion
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
        public RedemptionProgressBar()
        {
            max = 100;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            int curve = 6;
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            int Fill = Convert.ToInt32((Width - 1) * (val / max));

            g.Clear(Color.Transparent);
            g.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                g.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), curve));
            }

            if (Fill > 4)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(80, 164, 234)), Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
                HatchBrush FillTexture = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 26, 127, 217), Color.Transparent);
                LinearGradientBrush Gloss = new LinearGradientBrush(new Rectangle(0, 0, Fill, Height - 2), Color.FromArgb(75, Color.White), Color.FromArgb(65, Color.Black), 90);
                g.FillPath(Gloss, Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
                g.FillPath(FillTexture, Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));
                LinearGradientBrush FillGradientBorder = new LinearGradientBrush(new Rectangle(0, 0, Fill, Height - 2), Color.FromArgb(183, 223, 249), Color.FromArgb(41, 141, 226), 90);
                g.DrawPath(new Pen(FillGradientBorder), Draw.RoundRect(new Rectangle(1, 1, Fill - 2, Height - 4), curve));
                g.DrawPath(new Pen(Color.FromArgb(1, 44, 76)), Draw.RoundRect(new Rectangle(0, 0, Fill, Height - 2), curve));

            }

            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            g.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
            g.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));


            e.Graphics.DrawImage((Bitmap)b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
        }
    }


}

