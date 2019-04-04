// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Ambience
{
    #region  ControlBox

    public class AmbianceControlBox : Control
    {

        #region  Enums

        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        #endregion
        #region  MouseStates
        MouseState State = MouseState.None;
        int X;
        Rectangle CloseBtn = new Rectangle(3, 2, 17, 17);
        Rectangle MinBtn = new Rectangle(23, 2, 17, 17);
        Rectangle MaxBtn = new Rectangle(43, 2, 17, 17);

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (X > 3 && X < 20)
            {
                FindForm().Close();
            }
            else if (X > 23 && X < 40)
            {
                FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 43 && X < 60)
            {
                if (_EnableMaximize == true)
                {
                    if (FindForm().WindowState == FormWindowState.Maximized)
                    {
                        FindForm().WindowState = FormWindowState.Minimized;
                        FindForm().WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        FindForm().WindowState = FormWindowState.Minimized;
                        FindForm().WindowState = FormWindowState.Maximized;
                    }
                }
            }
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
        #region  Properties

        bool _EnableMaximize = true;
        public bool EnableMaximize
        {
            get
            {
                return _EnableMaximize;
            }
            set
            {
                _EnableMaximize = value;
                if (_EnableMaximize == true)
                {
                    this.Size = new Size(64, 22);
                }
                else
                {
                    this.Size = new Size(44, 22);
                }
                Invalidate();
            }
        }

        #endregion

        public AmbianceControlBox()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer), true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Font = new Font("Marlett", 7);
            Anchor = (System.Windows.Forms.AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_EnableMaximize == true)
            {
                this.Size = new Size(64, 22);
            }
            else
            {
                this.Size = new Size(44, 22);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // Auto-decide control location on the theme container
            Location = new Point(5, 13);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            LinearGradientBrush LGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90);
            G.FillEllipse(LGBClose, CloseBtn);
            G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
            G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle((int)6.5, 8, 0, 0));

            LinearGradientBrush LGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
            G.FillEllipse(LGBMinimize, MinBtn);
            G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
            G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, (int)4.4, 0, 0));

            if (_EnableMaximize == true)
            {
                LinearGradientBrush LGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
                G.FillEllipse(LGBMaximize, MaxBtn);
                G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
            }

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush xLGBClose_1 = new LinearGradientBrush(CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90);
                    G.FillEllipse(xLGBClose_1, CloseBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
                    G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle((int)6.5, 8, 0, 0));

                    LinearGradientBrush xLGBMinimize_1 = new LinearGradientBrush(MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
                    G.FillEllipse(xLGBMinimize_1, MinBtn);
                    G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
                    G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, (int)4.4, 0, 0));

                    if (_EnableMaximize == true)
                    {
                        LinearGradientBrush xLGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90);
                        G.FillEllipse(xLGBMaximize, MaxBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                        G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
                    }
                    break;
                case MouseState.Over:
                    if (X > 3 && X < 20)
                    {
                        LinearGradientBrush xLGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(248, 152, 124), Color.FromArgb(231, 92, 45), 90);
                        G.FillEllipse(xLGBClose, CloseBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
                        G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle((int)6.5, 8, 0, 0));
                    }
                    else if (X > 23 && X < 40)
                    {
                        LinearGradientBrush xLGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90);
                        G.FillEllipse(xLGBMinimize, MinBtn);
                        G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
                        G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, (int)4.4, 0, 0));
                    }
                    else if (X > 43 && X < 60)
                    {
                        if (_EnableMaximize == true)
                        {
                            LinearGradientBrush xLGBMaximize = new LinearGradientBrush(MaxBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90);
                            G.FillEllipse(xLGBMaximize, MaxBtn);
                            G.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                            G.DrawString("1", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
                        }
                    }
                    break;
            }

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}
