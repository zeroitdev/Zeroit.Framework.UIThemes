// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.Orains
{
    public class OrainsControlBox : Control
    {

        public OrainsControlBox()
            : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(60, 25);
        }
        public enum ButtonHover
        {
            Minimize,
            Maximize,
            Close,
            None
        }
        ButtonHover ButtonState = ButtonHover.None;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int X = e.Location.X;
            int Y = e.Location.Y;
            if (Y > 0 && Y < (Height - 2))
            {
                if (X > 0 && X < 30)
                {
                    ButtonState = ButtonHover.Minimize;
                }
                else if (X > 31 && X < Width)
                {
                    ButtonState = ButtonHover.Close;
                }
                else
                {
                    ButtonState = ButtonHover.None;
                }
            }
            else
            {
                ButtonState = ButtonHover.None;
            }
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);

            G.Clear(BackColor);
            Font ButtonFont = new Font("Marlett", 9);
            G.DrawString("r", ButtonFont, new SolidBrush(Color.FromArgb(90, 90, 90)), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });

            G.DrawString("0", ButtonFont, new SolidBrush(Color.FromArgb(90, 90, 90)), new Point(22, 7), new StringFormat { Alignment = StringAlignment.Center });

            switch (ButtonState)
            {
                case ButtonHover.None:

                    break;
                case ButtonHover.Minimize:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), new Rectangle(10, 0, Width - 40, Height - 1));

                    HatchBrush BodyHatch = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(15, Color.White), Color.Transparent);
                    G.FillRectangle(BodyHatch, new Rectangle(10, 0, Width - 40, Height - 1));

                    G.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Rectangle(11, 1, Width - 40, Height - 3));
                    G.DrawRectangle(Pens.Black, new Rectangle(10, 0, Width - 40, Height - 1));
                    G.DrawString("0", ButtonFont, new SolidBrush(Color.Cyan), new Point(22, 7), new StringFormat { Alignment = StringAlignment.Center });
                    break;
                case ButtonHover.Close:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), new Rectangle(30, 0, Width - 5, Height - 2));

                    HatchBrush BodyHatch1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(15, Color.White), Color.Transparent);
                    G.FillRectangle(BodyHatch1, new Rectangle(30, 0, Width - 5, Height - 2));

                    G.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Rectangle(31, 1, Width - 5, Height - 1));
                    G.DrawRectangle(Pens.Black, new Rectangle(30, 0, Width - 10, Height - 1));
                    G.DrawString("r", ButtonFont, new SolidBrush(Color.Red), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });

                    break;
            }
            G.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Rectangle(10, 0, Width - 1, Height - 1));
            G.DrawRectangle(Pens.Black, new Rectangle(9, 0, Width - 3, Height + 1));


            e.Graphics.DrawImage(B, new Point(0, 0));
            G.Dispose();
            B.Dispose();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            switch (ButtonState)
            {
                case ButtonHover.Close:
                    Parent.FindForm().Close();
                    break;
                case ButtonHover.Minimize:
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                    break;
                case ButtonHover.Maximize:
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                    break;
            }
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ButtonState = ButtonHover.None;
            Invalidate();
        }
    }

}


