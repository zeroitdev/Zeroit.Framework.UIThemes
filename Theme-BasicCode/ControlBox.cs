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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;




namespace Zeroit.Framework.UIThemes.BasicCode
{

    public class BCEvoCtrlBox : ThemeControl154
    {
        private bool _Min = true;
        private bool _Max = true;

        private int X;
        protected override void ColorHook()
        {
        }

        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;

                if (value == Orientation.Vertical)
                {
                    LockHeight = 0;
                    LockWidth = 14;
                }
                else
                {
                    LockHeight = 14;
                    LockWidth = 0;
                }

                Invalidate();
            }
        }

        public bool MinButton
        {
            get { return _Min; }
            set
            {
                _Min = value;
                int tempwidth = 40;
                if (_Min)
                    tempwidth += 25;
                if (_Max)
                    tempwidth += 25;
                this.Width = tempwidth + 1;
                this.Height = 16;
                Invalidate();
            }
        }

        public bool MaxButton
        {
            get { return _Max; }
            set
            {
                _Max = value;
                int tempwidth = 40;
                if (_Min)
                    tempwidth += 25;
                if (_Max)
                    tempwidth += 25;
                this.Width = tempwidth + 1;
                this.Height = 16;
                Invalidate();
            }
        }

        public BCEvoCtrlBox()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            LockHeight = 14;
            LockWidth = 72;
            Location = new Point(50, 2);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (_Min & _Max)
            {
                if (X > 0 & X < 20)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (X > 26 & X < 45)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (X > 51 & X < 70)
                {
                    Parent.FindForm().Close();
                }
            }
            else if (_Min)
            {
                if (X > 0 & X < 20)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (X > 26 & X < 45)
                {
                    Parent.FindForm().Close();
                }
            }
            else if (_Max)
            {
                if (X > 0 & X < 20)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (X > 26 & X < 45)
                {
                    Parent.FindForm().Close();
                }
            }
            else
            {
                if (X > 0 & X < 20)
                {
                    Parent.FindForm().Close();
                }
            }
        }

        private LinearGradientBrush ExBrush;
        private LinearGradientBrush SBrush;
        private LinearGradientBrush MinBrush;
        private LinearGradientBrush MNone;
        private GraphicsPath MinPath;
        private GraphicsPath SPath;
        private GraphicsPath ExPath;
        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighSpeed;
            MinPath = CreateRound(new Rectangle(0, 5, 17, 6), 6);
            SPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
            ExPath = CreateRound(new Rectangle(50, 5, 17, 6), 6);
            MinBrush = new LinearGradientBrush(new Rectangle(0, 5, 17, 6), Color.FromArgb(190, 244, 236, 0), Color.FromArgb(255, 218, 211, 0), LinearGradientMode.Vertical);
            SBrush = new LinearGradientBrush(new Rectangle(0, 5, 17, 6), Color.FromArgb(255, 236, 144, 0), Color.FromArgb(255, 218, 133, 0), LinearGradientMode.Vertical);
            ExBrush = new LinearGradientBrush(new Rectangle(0, 5, 17, 6), Color.FromArgb(255, 238, 0, 0), Color.FromArgb(255, 167, 0, 0), LinearGradientMode.Vertical);
            MNone = new LinearGradientBrush(new Rectangle(0, 5, 17, 6), Color.FromArgb(255, 43, 43, 43), Color.FromArgb(255, 10, 10, 10), LinearGradientMode.Vertical);

            if (_Min & _Max)
            {
                LockHeight = 14;
                LockWidth = 72;
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 20)
                    {
                        G.FillPath(MinBrush, MinPath);
                        G.FillPath(MNone, SPath);
                        G.FillPath(MNone, ExPath);
                        G.DrawPath(Pens.Black, ExPath);
                        G.DrawPath(Pens.Black, SPath);
                        G.DrawPath(Pens.Black, MinPath);
                    }
                    if (X > 26 & X < 45)
                    {
                        G.FillPath(SBrush, SPath);
                        G.FillPath(MNone, MinPath);
                        G.FillPath(MNone, ExPath);
                        G.DrawPath(Pens.Black, ExPath);
                        G.DrawPath(Pens.Black, MinPath);
                        G.DrawPath(Pens.Black, SPath);
                    }
                    if (X > 51 & X < 70)
                    {
                        G.FillPath(ExBrush, ExPath);
                        G.FillPath(MNone, MinPath);
                        G.FillPath(MNone, SPath);
                        G.DrawPath(Pens.Black, MinPath);
                        G.DrawPath(Pens.Black, SPath);
                        G.DrawPath(Pens.Black, ExPath);
                    }
                }
                else if (State == MouseState.None)
                {
                    G.FillPath(MNone, ExPath);
                    G.FillPath(MNone, MinPath);
                    G.FillPath(MNone, SPath);
                    G.DrawPath(Pens.Black, MinPath);
                    G.DrawPath(Pens.Black, SPath);
                    G.DrawPath(Pens.Black, ExPath);
                }
            }
            else if (_Min)
            {
                LockHeight = 14;
                LockWidth = 47;
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 20)
                    {
                        ExPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
                        G.FillPath(MinBrush, MinPath);
                        G.FillPath(MNone, ExPath);
                        G.DrawPath(Pens.Black, ExPath);
                        G.DrawPath(Pens.Black, MinPath);
                    }
                    if (X > 26 & X < 45)
                    {
                        ExPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
                        G.FillPath(ExBrush, ExPath);
                        G.FillPath(MNone, MinPath);
                        G.DrawPath(Pens.Black, MinPath);
                        G.DrawPath(Pens.Black, ExPath);
                    }
                }
                else if (State == MouseState.None)
                {
                    ExPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
                    G.FillPath(MNone, MinPath);
                    G.FillPath(MNone, ExPath);
                    G.DrawPath(Pens.Black, ExPath);
                    G.DrawPath(Pens.Black, MinPath);
                }
            }
            else if (_Max)
            {
                LockHeight = 14;
                LockWidth = 47;
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 20)
                    {
                        SPath = CreateRound(new Rectangle(0, 5, 17, 6), 6);
                        ExPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
                        G.FillPath(SBrush, SPath);
                        G.FillPath(MNone, ExPath);
                        G.DrawPath(Pens.Black, ExPath);
                        G.DrawPath(Pens.Black, SPath);
                    }
                    if (X > 26 & X < 45)
                    {
                        ExPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
                        SPath = CreateRound(new Rectangle(0, 5, 17, 6), 6);
                        G.FillPath(ExBrush, ExPath);
                        G.FillPath(MNone, SPath);
                        G.DrawPath(Pens.Black, SPath);
                        G.DrawPath(Pens.Black, ExPath);
                    }
                }
                else if (State == MouseState.None)
                {
                    SPath = CreateRound(new Rectangle(0, 5, 17, 6), 6);
                    ExPath = CreateRound(new Rectangle(25, 5, 17, 6), 6);
                    G.FillPath(MNone, SPath);
                    G.FillPath(MNone, ExPath);
                    G.DrawPath(Pens.Black, ExPath);
                    G.DrawPath(Pens.Black, SPath);
                }
            }
            else
            {
                LockHeight = 14;
                LockWidth = 19;
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 20)
                    {
                        ExPath = CreateRound(new Rectangle(0, 5, 17, 6), 6);
                        G.FillPath(ExBrush, ExPath);
                        G.DrawPath(Pens.Black, ExPath);
                    }
                }
                else if (State == MouseState.None)
                {
                    ExPath = CreateRound(new Rectangle(0, 5, 17, 6), 6);
                    G.FillPath(MNone, ExPath);
                    G.DrawPath(Pens.Black, ExPath);
                }
            }
        }
    }
    
}
