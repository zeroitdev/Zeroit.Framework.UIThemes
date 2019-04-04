// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  ControlBox 

    public class BabylonControlBox : Control
    {
        #region  Enums 

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion
        #region  Variables 

        private MouseState State = MouseState.None;
        private int i;
        private Rectangle CloseRect = new Rectangle(28, 0, 47, 18);
        private Rectangle MinimizeRect = new Rectangle(0, 0, 28, 18);

        #endregion
        #region  EventArgs 

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (i > 0 && i < 28)
            {
                FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (i > 30 && i < 75)
            {
                FindForm().Close();
            }

            State = MouseState.Down;
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

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            i = e.Location.X;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 77;
            Height = 19;
        }

        #endregion

        public BabylonControlBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Location = new Point(FindForm().Width - 81, -1); // Auto-decide control location on the theme container
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            GraphicsPath GP_MinimizeRect = new GraphicsPath();
            GraphicsPath GP_CloseRect = new GraphicsPath();

            GP_MinimizeRect.AddRectangle(MinimizeRect);
            GP_CloseRect.AddRectangle(CloseRect);
            G.Clear(BackColor);

            switch (State)
            {
                
                case MouseState.None:
                    {
                        
                        LinearGradientBrush MinimizeGradient = new LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                        G.FillPath(MinimizeGradient, GP_MinimizeRect);
                        G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                        G.DrawString("0", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                        LinearGradientBrush CloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                        G.FillPath(CloseGradient, GP_CloseRect);
                        G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                        G.DrawString("r", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);
                        break;
                    }
                case MouseState.Over:
                    {
                        
                        if (i > 0 && i < 28)
                        {
                            LinearGradientBrush MinimizeGradient = new LinearGradientBrush(MinimizeRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90);
                            G.FillPath(MinimizeGradient, GP_MinimizeRect);
                            G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                            G.DrawString("0", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                            LinearGradientBrush CloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                            G.FillPath(CloseGradient, GP_CloseRect);
                            G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                            G.DrawString("r", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);
                        }
                        else if (i > 30 && i < 75)
                        {
                            LinearGradientBrush CloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90);
                            G.FillPath(CloseGradient, GP_CloseRect);
                            G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                            G.DrawString("r", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);

                            LinearGradientBrush MinimizeGradient = new LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                            G.FillPath(MinimizeGradient, RoundRectangle.RoundRect(MinimizeRect, 1));
                            G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                            G.DrawString("0", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);
                        }
                        else
                        {
                            LinearGradientBrush MinimizeGradient = new LinearGradientBrush(MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                            G.FillPath(MinimizeGradient, GP_MinimizeRect);
                            G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_MinimizeRect);
                            G.DrawString("0", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), MinimizeRect.Width - 22, MinimizeRect.Height - 16);

                            LinearGradientBrush CloseGradient = new LinearGradientBrush(CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90);
                            G.FillPath(CloseGradient, GP_CloseRect);
                            G.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), GP_CloseRect);
                            G.DrawString("r", new Font("Marlett", 11F, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), CloseRect.Width - 4, CloseRect.Height - 16);

                        }
                        break;
                    }
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            GP_CloseRect.Dispose();
            GP_MinimizeRect.Dispose();
            B.Dispose();
        }
    }

    #endregion
}