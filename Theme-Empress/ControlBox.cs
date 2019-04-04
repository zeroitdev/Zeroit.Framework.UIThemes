// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empress
{


    public class EmpressControlBox : Control
    {

        public EmpressControlBox() : base()
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
            Font ButtonFont = new Font("Marlett", 9f);

            G.DrawString("r", ButtonFont, new SolidBrush(Color.FromArgb(200, 200, 200)), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });

            G.DrawString("0", ButtonFont, new SolidBrush(Color.FromArgb(200, 200, 200)), new Point(20, 7), new StringFormat { Alignment = StringAlignment.Center });

            switch (ButtonState)
            {
                case ButtonHover.None:

                    break;
                case ButtonHover.Minimize:
                    G.DrawString("0", ButtonFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Point(20, 7), new StringFormat { Alignment = StringAlignment.Center });
                    break;
                case ButtonHover.Close:
                    G.DrawString("r", ButtonFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });
                    break;
            }



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


