// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="NumericUpDown.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.FireFox
{
    public class FirefoxNumericUpDown : Control
    {

        #region " Private "
        private Graphics G;
        private int _Value;
        private int _Min;
        private int _Max;
        private Point Loc;
        private bool Down;
        private bool _EnabledCalc;
        #endregion
        private Color ETC;

        #region " Properties "

        public new bool Enabled
        {
            get { return EnabledCalc; }
            set
            {
                _EnabledCalc = value;
                Invalidate();
            }
        }

        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return _EnabledCalc; }
            set
            {
                Enabled = value;
                Invalidate();
            }
        }

        public int Value
        {
            get { return _Value; }

            set
            {
                if (value <= _Max & value >= Minimum)
                {
                    _Value = value;
                }

                Invalidate();

            }
        }

        public int Minimum
        {
            get { return _Min; }

            set
            {
                if (value < Maximum)
                {
                    _Min = value;
                }

                if (value < Minimum)
                {
                    value = Minimum;
                }

                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _Max; }

            set
            {
                if (value > Minimum)
                {
                    _Max = value;
                }

                if (value > Maximum)
                {
                    value = Maximum;
                }

                Invalidate();
            }
        }

        #endregion

        #region " Control "

        public FirefoxNumericUpDown()
        {
            DoubleBuffered = true;
            Value = 0;
            Minimum = 0;
            Maximum = 100;
            Cursor = Cursors.IBeam;
            BackColor = Color.White;
            ForeColor = Color.FromArgb(66, 78, 90);
            Font = Theme.GlobalFont;
            Enabled = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Loc.X = e.X;
            Loc.Y = e.Y;
            Invalidate();

            if (Loc.X < Width - 23)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Default;
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 30;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseClick(e);


            if (Enabled)
            {
                if (Loc.X > Width - 21 && Loc.X < Width - 3)
                {
                    if (Loc.Y < 15)
                    {
                        if ((Value + 1) <= Maximum)
                        {
                            Value += 1;
                        }
                    }
                    else
                    {
                        if ((Value - 1) >= Minimum)
                        {
                            Value -= 1;
                        }
                    }
                }
                else
                {
                    Down = !Down;
                    Focus();
                }

            }

            Invalidate();
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (Down)
                {
                    Value = Value + Convert.ToInt32(e.KeyChar.ToString());
                }

                if (Value > Maximum)
                {
                    Value = Maximum;
                }

            }
            catch
            {
            }
        }
        
        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);


            if (e.KeyCode == Keys.Up)
            {
                if ((Value + 1) <= Maximum)
                {
                    Value += 1;
                }

                Invalidate();


            }
            else if (e.KeyCode == Keys.Down)
            {
                if ((Value - 1) >= Minimum)
                {
                    Value -= 1;
                }

            }
            else if (e.KeyCode == Keys.Back)
            {
                string BC = Value.ToString();
                BC = BC.Remove(Convert.ToInt32(BC.Length - 1));

                if ((BC.Length == 0))
                {
                    BC = "0";
                }

                Value = Convert.ToInt32(BC);

            }

            Invalidate();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);


            if (Enabled)
            {
                ETC = Color.FromArgb(66, 78, 90);

                using (Pen P = new Pen(Helpers.GreyColor(190)))
                {
                    Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, Helpers.GreyColor(190));
                    G.DrawLine(P, new Point(Width - 24, (int)13.5f), new Point(Width - 5, (int)13.5f));
                }

                Helpers.DrawRoundRect(G, new Rectangle(Width - 24, 4, 19, 21), 3, Helpers.GreyColor(200));

            }
            else
            {
                ETC = Helpers.GreyColor(170);

                using (Pen P = new Pen(Helpers.GreyColor(230)))
                {
                    Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, Helpers.GreyColor(190));
                    G.DrawLine(P, new Point(Width - 24, (int)13.5f), new Point(Width - 5, (int)13.5f));
                }

                Helpers.DrawRoundRect(G, new Rectangle(Width - 24, 4, 19, 21), 3, Helpers.GreyColor(220));

            }
            
            using (SolidBrush B = new SolidBrush(ETC))
            {
                G.DrawString("t", new Font("Marlett", 8, FontStyle.Bold), B, new Point(Width - 22, 5));
                G.DrawString("u", new Font("Marlett", 8, FontStyle.Bold), B, new Point(Width - 22, 13));
                Helpers.CenterString(G, Value.ToString(), new Font("Segoe UI", 10), ETC, new Rectangle(Width / 2 - 10, 0, Width - 5, Height));
            }

        }

        #endregion

    }


}


