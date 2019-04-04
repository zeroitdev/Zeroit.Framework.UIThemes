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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualControlBox : Control
    {
        public xVisualControlBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Size = new Size(83, 28);
            Location = new Point(12, 12);
            DoubleBuffered = true;
        }
        #region " MouseStates "
        MouseState State = MouseState.None;
        int X;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (X > 10 & X < 25)
            {
                Parent.FindForm().Close();
            }
            else if (X > 33 & X < 48)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 56 & X < 71)
            {
                if (Parent.FindForm().WindowState == FormWindowState.Normal)
                {
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else
                {
                    Parent.FindForm().WindowState = FormWindowState.Normal;
                }
            }
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }
        #endregion
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);

            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush ControlGradient = new LinearGradientBrush(new Rectangle(10, 2, 15, 16), Color.FromArgb(67, 67, 67), Color.FromArgb(80, 80, 81), 90);
            //// Control Box
            G.FillEllipse(ControlGradient, new Rectangle(10, 2, 15, 16));
            //Main Circle
            G.FillEllipse(ControlGradient, new Rectangle(33, 2, 15, 16));
            G.FillEllipse(ControlGradient, new Rectangle(56, 2, 15, 16));
            G.DrawEllipse(Pens.Black, new Rectangle(10, 2, 15, 16));
            G.DrawEllipse(Pens.Black, new Rectangle(33, 2, 15, 16));
            G.DrawEllipse(Pens.Black, new Rectangle(56, 2, 15, 16));

            LinearGradientBrush ControlTopCircle = new LinearGradientBrush(new Rectangle(13, 4, 9, 7), Color.FromArgb(193, 190, 176), Color.FromArgb(90, 91, 92), 90);
            G.FillEllipse(ControlTopCircle, new Rectangle(13, 4, 9, 7));
            //Top Circle
            G.FillEllipse(ControlTopCircle, new Rectangle(36, 4, 9, 7));
            //Top Circle
            G.FillEllipse(ControlTopCircle, new Rectangle(59, 4, 9, 7));
            //Top Circle

            LinearGradientBrush NControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(90, 91, 92), Color.FromArgb(155, 165, 174), 90);

            switch (State)
            {
                case MouseState.None:
                    None:
                    G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
                    //Bottom Circle
                    G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
                    G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
                    break;
                case MouseState.Over:
                    if (X > 10 & X < 25)
                    {
                        LinearGradientBrush ControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(50, Color.Red), Color.FromArgb(10, Color.Red), 90);
                        G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
                        //Bottom Circle
                        G.FillEllipse(ControlBottomCircle, new Rectangle(13, 12, 9, 5));
                        //Bottom Circle
                        G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
                        G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
                    }
                    else if (X > 33 & X < 48)
                    {
                        LinearGradientBrush ControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(50, Color.Yellow), Color.FromArgb(10, Color.Yellow), 90);
                        G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
                        //Bottom Circle
                        G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
                        G.FillEllipse(ControlBottomCircle, new Rectangle(36, 12, 9, 5));
                        G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
                    }
                    else if (X > 56 & X < 71)
                    {
                        LinearGradientBrush ControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(50, Color.Green), Color.FromArgb(10, Color.Green), 90);
                        G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
                        //Bottom Circle
                        G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
                        G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
                        G.FillEllipse(ControlBottomCircle, new Rectangle(59, 12, 9, 5));
                    }
                    else
                    {
                        goto None;
                    }
                    break;
                case MouseState.Down:

                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

