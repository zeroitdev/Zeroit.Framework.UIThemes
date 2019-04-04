// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  NumericUpDown 

    public class BabylonNumericUpDown : Control
    {
        #region  Enums 

        public enum _TextAlignment
        {
            Near,
            Center
        }

        #endregion
        #region  Variables 

        private GraphicsPath Shape;
        private Pen P1;
        private SolidBrush B1;

        private long _Value;
        private long _Minimum;
        private long _Maximum;
        private int Xval;
        private int Yval;
        private bool KeyboardNum;
        private _TextAlignment MyStringAlignment;

        #endregion
        #region  Properties 

        public long Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value <= _Maximum && value >= _Minimum)
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        public long Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < _Maximum)
                {
                    _Minimum = value;
                }
                if (_Value < _Minimum)
                {
                    _Value = Minimum;
                }
                Invalidate();
            }
        }

        public long Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value > _Minimum)
                {
                    _Maximum = value;
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
                Invalidate();
            }
        }

        public _TextAlignment TextAlignment
        {
            get
            {
                return MyStringAlignment;
            }
            set
            {
                MyStringAlignment = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 28;
            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Xval = e.Location.X;
            Yval = e.Location.Y;
            Invalidate();

            if (e.X < Width - 24)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (Xval > this.Width - 23 && Xval < this.Width - 3)
            {
                if (Yval < 15)
                {
                    if ((Value + 1) <= _Maximum)
                    {
                        _Value += 1;
                    }
                }
                else
                {
                    if ((Value - 1) >= _Minimum)
                    {
                        _Value -= 1;
                    }
                }
            }
            else
            {
                KeyboardNum = !KeyboardNum;
                Focus();
            }
            Invalidate();
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (KeyboardNum == true)
                {
                    _Value = Convert.ToInt64(Convert.ToString(Convert.ToString(_Value) + e.KeyChar.ToString()));
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Back)
            {
                string TemporaryValue = _Value.ToString();
                TemporaryValue = TemporaryValue.Remove(Convert.ToInt32(TemporaryValue.Length - 1));
                if (TemporaryValue.Length == 0)
                {
                    TemporaryValue = "0";
                }
                _Value = Convert.ToInt32(TemporaryValue);
            }
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                if ((Value + 1) <= _Maximum)
                {
                    _Value += 1;
                }
                Invalidate();
            }
            else
            {
                if ((Value - 1) >= _Minimum)
                {
                    _Value -= 1;
                }
                Invalidate();
            }
        }

        #endregion

        public BabylonNumericUpDown()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            P1 = new Pen(Color.FromArgb(180, 180, 180));
            B1 = new SolidBrush(Color.White);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            _Minimum = 0;
            _Maximum = 100;

            Font = new Font("Tahoma", 11);
            Size = new Size(70, 28);
            MinimumSize = new Size(62, 28);
            DoubleBuffered = true;
        }

        public void Increment(int Value)
        {
            this._Value += Value;
            Invalidate();
        }

        public void Decrement(int Value)
        {
            this._Value -= Value;
            Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.Clear(Color.Transparent); // Set control background color
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border

            LinearGradientBrush ColorGradient = new LinearGradientBrush(new Rectangle(Width - 23, 4, 19, 19), Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90.0F);
            G.FillRectangle(ColorGradient, ColorGradient.Rectangle); // Fills the body of the rectangle

            G.DrawRectangle(new Pen(Color.FromArgb(252, 252, 252)), new Rectangle(Width - 22, 5, 17, 17));
            G.DrawRectangle(new Pen(Color.FromArgb(180, 180, 180)), new Rectangle(Width - 23, 4, 19, 19));

            G.DrawLine(new Pen(Color.FromArgb(250, 252, 250)), new Point(Width - 22, Height - 16), new Point(Width - 5, Height - 16));
            G.DrawLine(new Pen(Color.FromArgb(180, 180, 180)), new Point(Width - 22, Height - 15), new Point(Width - 5, Height - 15));
            G.DrawLine(new Pen(Color.FromArgb(250, 250, 250)), new Point(Width - 22, Height - 14), new Point(Width - 5, Height - 14));

            G.DrawString("+", new Font("Tahoma", 8), Brushes.Gray, Width - 19, Height - 26);
            G.DrawString("-", new Font("Tahoma", 12), Brushes.Gray, Width - 19, Height - 20);

            switch (MyStringAlignment)
            {
                case _TextAlignment.Near:
                    G.DrawString(Value.ToString(), Font, new SolidBrush(ForeColor), new Rectangle(5, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    break;
                case _TextAlignment.Center:
                    G.DrawString(Value.ToString(), Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    break;
            }
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}