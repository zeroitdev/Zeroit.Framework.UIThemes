// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Reactor Theme.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Reactor
{

    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }


    
    public class ReactorTheme : ContainerControl
    {

        ReactorTopButton CloseBtn = new ReactorTopButton
        {
            Location = new Point(412, 7),
            ButtonType = ReactorTopButton.topButtonType.Close,
            CloseButtonFunction = ReactorTopButton.closeFunc.CloseForm
        };
        ReactorTopButton MinimBtn = new ReactorTopButton
        {
            Location = new Point(393, 7),
            ButtonType = ReactorTopButton.topButtonType.Minimize

        };
        #region " Control Help - Movement & Flicker Control "
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion

        public ReactorTheme()
            : base()
        {
            Dock = DockStyle.Fill;
            MoveHeight = 45;
            Font = new Font("Verdana", 6.75f);
            DoubleBuffered = true;

            Controls.Add(CloseBtn);
            Controls.Add(MinimBtn);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            if (!(this.ParentForm.FormBorderStyle == FormBorderStyle.None))
            {
                this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            }

            CloseBtn.Location = new Point(Width - 23, 7);
            MinimBtn.Location = new Point(Width - 42, 7);

            LinearGradientBrush glossLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, 15), Color.FromArgb(102, 97, 93), Color.FromArgb(55, 54, 52), 90);
            LinearGradientBrush glossLGB2 = new LinearGradientBrush(new Rectangle(0, 15, Width, 15), Color.Black, Color.FromArgb(26, 25, 21), 90);
            LinearGradientBrush shadowLGB = new LinearGradientBrush(new Rectangle(5, 31, Width - 11, 20), Color.FromArgb(23, 23, 22), Color.FromArgb(38, 38, 38), 90);

            G.Clear(Color.FromArgb(26, 25, 21));
            G.FillRectangle(glossLGB, new Rectangle(0, 0, Width, 15));
            G.FillRectangle(glossLGB2, new Rectangle(0, 15, Width, 15));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(42, 41, 37))), 4, 30, Width - 9, Height - 36);
            G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), new Rectangle(5, 31, Width - 11, Height - 38));
            G.FillRectangle(shadowLGB, new Rectangle(5, 31, Width - 11, 20));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(24, 24, 24))), 5, 32, Width - 7, 32);
            G.DrawRectangle(Pens.Black, new Rectangle(5, 31, Width - 11, Height - 38));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(151, 150, 146))), 1, 1, Width - 2, 1);

            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));

            //G.DrawString(Text, Font, Brushes.Black, Width / 2 - (3 * Text.Length) + 3, 7)
            //G.DrawString(Text, Font, Brushes.White, Width / 2 - (3 * Text.Length) + 3, 8)
            G.DrawString(Text, Font, Brushes.Black, new Rectangle(0, 10, Width - 1, 10), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
            G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 11, Width - 1, 11), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
        }


    }

    //-------------------- [ /TopButton ] ---------------------
    [ToolboxItem(false)]
    public class ReactorTopButton : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        Color buttonColor;
        public enum topButtonType : byte
        {
            Blank = 0,
            Minimize = 1,
            Maximize = 2,
            Close = 3
        }
        private MouseState State = MouseState.None;
        private topButtonType _tbType = topButtonType.Blank;
        public topButtonType ButtonType
        {
            get { return _tbType; }
            set
            {
                _tbType = value;
                Invalidate();
            }
        }
        private bool _defaultFunc = true;
        public bool UseStandardFunction
        {
            get { return _defaultFunc; }
            set { _defaultFunc = value; }
        }

        public enum closeFunc : byte
        {
            CloseForm = 0,
            CloseApp = 1
        }
        private closeFunc _closeFunc = 0;
        public closeFunc CloseButtonFunction
        {
            get { return _closeFunc; }
            set { _closeFunc = value; }
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public void buttonFunction(object sender, EventArgs e)
        {

            switch (_defaultFunc)
            {
                case true:
                    switch (ButtonType)
                    {
                        case topButtonType.Close:
                            switch (CloseButtonFunction)
                            {
                                case closeFunc.CloseForm:
                                    this.Parent.FindForm().Close();
                                    break;
                                case closeFunc.CloseApp:
                                    Application.Exit();
                                    System.Environment.Exit(0);
                                    break;
                            }
                            break;
                        case topButtonType.Minimize:
                            this.Parent.FindForm().WindowState = FormWindowState.Minimized;
                            break;
                        case topButtonType.Maximize:
                            this.Parent.FindForm().WindowState = FormWindowState.Maximized;
                            break;
                    }
                    break;
            }
        }
        #endregion

        public ReactorTopButton()
            : base()
        {
            Click += buttonFunction;
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 6.75f);
            Size = new Size(17, 17);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            Size = new Size(17, 17);
            G.Clear(Color.FromArgb(36, 34, 30));

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, Width - 4, Height - 1);
                    LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
                    G.FillRectangle(backGrad, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(46, 45, 44))), new Rectangle(1, 1, Width - 3, Height - 4));
                    buttonColor = Color.FromArgb(163, 163, 162);
                    break;
                case MouseState.Over:
                    //Mouse Hover
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(46, 44, 38))), 2, Height - 1, Width - 4, Height - 1);
                    LinearGradientBrush backGrad1 = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(219, 78, 0), Color.FromArgb(230, 95, 0), 90);
                    G.FillRectangle(backGrad1, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(245, 120, 10))), new Rectangle(1, 1, Width - 3, Height - 4));
                    buttonColor = Color.FromArgb(255, 255, 255);
                    break;
                case MouseState.Down:
                    //Mouse Down
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, Width - 4, Height - 1);
                    LinearGradientBrush backGrad2 = new LinearGradientBrush(new Rectangle(1, 1, Width - 1, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 270);
                    G.FillRectangle(backGrad2, new Rectangle(1, 1, Width - 1, Height - 2));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(46, 45, 44))), new Rectangle(1, 1, Width - 3, Height - 4));

                    break;
            }

            switch (ButtonType)
            {
                case topButtonType.Minimize:
                    G.FillRectangle(new SolidBrush(buttonColor), new Rectangle(4, 10, 9, 2));
                    break;
                case topButtonType.Maximize:
                    G.DrawRectangle(new Pen(new SolidBrush(buttonColor)), new Rectangle(4, 4, 8, 7));
                    G.DrawLine(new Pen(new SolidBrush(buttonColor)), 4, 5, Width - 6, 5);
                    break;
                case topButtonType.Close:
                    G.DrawLine(new Pen(new SolidBrush(buttonColor), 2), 4, 4, 12, 11);
                    G.DrawLine(new Pen(new SolidBrush(buttonColor), 2), 12, 4, 4, 11);
                    G.DrawLine(new Pen(new SolidBrush(buttonColor)), 4, 4, 5, 5);
                    G.DrawLine(new Pen(new SolidBrush(buttonColor)), 4, 11, 5, 10);
                    break;
            }

            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, 7), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(glossGradient, new Rectangle(1, 1, Width - 2, 7));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(21, 20, 18))), new Rectangle(0, 0, Width - 1, Height - 2));
        }
    }

    
}


