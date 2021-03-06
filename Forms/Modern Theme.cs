// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Modern Theme.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.Form.UIThemes.Modern
{

    public class Draw
    {
        public static void Gradient(Graphics g, Color c1, Color c2, int x, int y, int width, int height)
        {
            Rectangle R = new Rectangle(x, y, width, height);
            using (LinearGradientBrush T = new LinearGradientBrush(R, c1, c2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(T, R);
            }
        }
        public static void Blend(Graphics g, Color c1, Color c2, Color c3, float c, int d, int x, int y, int width, int height)
        {
            ColorBlend V = new ColorBlend(3);
            V.Colors = new Color[] {
            c1,
            c2,
            c3
        };
            V.Positions = new float[] {
            0,
            c,
            1
        };
            Rectangle R = new Rectangle(x, y, width, height);
            using (LinearGradientBrush T = new LinearGradientBrush(R, c1, c1, (LinearGradientMode)d))
            {
                T.InterpolationColors = V;
                g.FillRectangle(T, R);
            }
        }



    }
    //Pearl Theme
    public class ModernTheme : Control
    {
        private int _TitleHeight = 25;
        public int TitleHeight
        {
            get { return _TitleHeight; }
            set
            {
                if (value > Height)
                    value = Height;
                if (value < 2)
                    Height = 1;
                _TitleHeight = value;
                Invalidate();
            }
        }
        private HorizontalAlignment _TitleAlign;
        public HorizontalAlignment TitleAlign
        {
            get { return _TitleAlign; }
            set
            {
                _TitleAlign = value;
                Invalidate();
            }
        }
        protected override void OnHandleCreated(System.EventArgs e)
        {
            Dock = (DockStyle)5;
            if (Parent is System.Windows.Forms.Form)
                ((System.Windows.Forms.Form)Parent).FormBorderStyle = 0;
            base.OnHandleCreated(e);
        }
        private IntPtr Flag;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            Flag = new IntPtr(2);

            if (new Rectangle(Parent.Location.X, Parent.Location.Y, Width - 1, _TitleHeight - 1).IntersectsWith(new Rectangle(MousePosition.X, MousePosition.Y, 1, 1)))
            {
                Capture = false;
                Message M = Message.Create(Parent.Handle, 161, Flag, IntPtr.Zero);
                DefWndProc(ref M);
            }
            base.OnMouseDown(e);
        }
        Color C1 = Color.FromArgb(240, 240, 240);
        Color C2 = Color.FromArgb(230, 230, 230);
        Color C3 = Color.FromArgb(190, 190, 190);
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics G = Graphics.FromImage(B))
                {
                    G.Clear(Color.FromArgb(245, 245, 245));

                    Draw.Blend(G, Color.White, C2, C1, 0.7f, 1, 0, 0, Width, _TitleHeight);

                    G.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), 0, 0, Width, Convert.ToInt32(_TitleHeight / 2));
                    G.DrawRectangle(new Pen(Color.FromArgb(100, 255, 255, 255)), 1, 1, Width - 3, _TitleHeight - 2);

                    dynamic S = G.MeasureString(Text, Font);
                    dynamic O = 6;
                    if (_TitleAlign == (HorizontalAlignment)2)
                        O = Width / 2 - S.Width / 2;
                    if (_TitleAlign == (HorizontalAlignment)1)
                        O = Width - S.Width - 6;
                    G.DrawString(Text, Font, new SolidBrush(C3), O, Convert.ToInt32(_TitleHeight / 2 - S.Height / 2));

                    G.DrawLine(new Pen(C3), 0, _TitleHeight, Width, _TitleHeight);
                    G.DrawLine(Pens.White, 0, _TitleHeight + 1, Width, _TitleHeight + 1);
                    G.DrawRectangle(new Pen(C3), 0, 0, Width - 1, Height - 1);

                    e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
                }
            }
        }



    }

    

}


