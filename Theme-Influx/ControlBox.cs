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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    public class InfluxControlBox : ThemeControl154
    {
        private bool _Min = true;
        private bool _Max = true;

        private int X;
        protected override void ColorHook()
        {
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

        public InfluxControlBox()
            : base()
        {
            Size = new Size(92, 16);
            this.Location = new Point(100, 7);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Transparent = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnMove(System.EventArgs e)
        {
            base.OnMove(e);
            this.Top = 7;
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
                if (X > 0 & X < 25)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (X > 25 & X < 50)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (X > 50 & X < 90)
                {
                    Parent.FindForm().Close();
                }
            }
            else if (_Min)
            {
                if (X > 0 & X < 25)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (X > 25 & X < 65)
                {
                    Parent.FindForm().Close();
                }
            }
            else if (_Max)
            {
                if (X > 0 & X < 25)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (X > 25 & X < 65)
                {
                    Parent.FindForm().Close();
                }
            }
            else
            {
                if (X > 0 & X < 40)
                {
                    Parent.FindForm().Close();
                }
            }
        }

        SolidBrush NormalBrush = new SolidBrush(Color.FromArgb(200, 200, 200));
        SolidBrush OverBrush = new SolidBrush(Color.White);
        Font ControlFont = new Font("Marlett", 8);
        protected override void PaintHook()
        {
            G.Clear(Color.Transparent);
            if (_Min & _Max)
            {
                G.DrawString("r", ControlFont, NormalBrush, new Point(63, 2));
                if (Parent.FindForm().WindowState == FormWindowState.Normal)
                {
                    G.DrawString("1", ControlFont, NormalBrush, new Point(32, 2));
                }
                else
                {
                    G.DrawString("2", ControlFont, NormalBrush, new Point(32, 2));
                }
                G.DrawString("0", ControlFont, NormalBrush, new Point(6, 2));
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 25)
                    {
                        //mouse over close
                        G.DrawString("0", ControlFont, OverBrush, new Point(6, 2));
                    }
                    if (X > 25 & X < 50)
                    {
                        //mouse over maximize
                        if (Parent.FindForm().WindowState == FormWindowState.Normal)
                        {
                            G.DrawString("1", ControlFont, OverBrush, new Point(32, 2));
                        }
                        else
                        {
                            G.DrawString("2", ControlFont, OverBrush, new Point(32, 2));
                        }
                    }
                    if (X > 50 & X < 90)
                    {
                        //mouse over minimize
                        G.DrawString("r", ControlFont, OverBrush, new Point(63, 2));
                    }
                }
            }
            else if (_Min)
            {
                G.DrawString("0", ControlFont, NormalBrush, new Point(6, 2));
                G.DrawString("r", ControlFont, NormalBrush, new Point(38, 2));
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 25)
                    {
                        //mouse over close
                        G.DrawString("0", ControlFont, OverBrush, new Point(6, 2));
                    }
                    if (X > 25 & X < 65)
                    {
                        //mouse over minimize
                        G.DrawString("r", ControlFont, OverBrush, new Point(38, 2));
                    }
                }
            }
            else if (_Max)
            {
                if (Parent.FindForm().WindowState == FormWindowState.Normal)
                {
                    G.DrawString("1", ControlFont, NormalBrush, new Point(6, 2));
                }
                else
                {
                    G.DrawString("2", ControlFont, NormalBrush, new Point(6, 2));
                }
                G.DrawString("r", ControlFont, NormalBrush, new Point(38, 2));
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 25)
                    {
                        //mouse over maximize
                        if (Parent.FindForm().WindowState == FormWindowState.Normal)
                        {
                            G.DrawString("1", ControlFont, OverBrush, new Point(6, 2));
                        }
                        else
                        {
                            G.DrawString("2", ControlFont, OverBrush, new Point(6, 2));
                        }
                    }
                    if (X > 25 & X < 65)
                    {
                        //Mouse over close
                        G.DrawString("r", ControlFont, OverBrush, new Point(38, 2));
                    }
                }
            }
            else
            {
                G.DrawString("r", ControlFont, NormalBrush, new Point(13, 2));
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 40)
                    {
                        //mouse over close
                        G.DrawString("r", ControlFont, OverBrush, new Point(13, 2));
                    }
                }
            }
        }
    }


}


