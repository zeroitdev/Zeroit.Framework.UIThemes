// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Reactor
{
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


