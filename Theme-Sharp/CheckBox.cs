// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.Sharp
{
    public class SharpCheckBox : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private MouseState State = MouseState.None;
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
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 18;
        }
        #endregion

        public SharpCheckBox() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(145, 16);
            ForeColor = Color.FromArgb(210, 210, 222);
            DoubleBuffered = true;
            Font = new Font("Verdana", 8);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(BackColor);
            if (Checked == false)
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(3, 3, 12, 11), Color.FromArgb(37, 47, 57), Color.FromArgb(62, 68, 74), 90);
                G.FillRectangle(BTNLGBOver, new Rectangle(3, 3, 12, 11));



            }
            else
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(3, 3, 12, 11), Color.FromArgb(73, 83, 93), Color.FromArgb(40, 50, 60), 90);
                G.FillRectangle(BTNLGBOver, new Rectangle(3, 3, 12, 11));

                Rectangle chkRec12 = new Rectangle(3, 2, Height - 5, Height - 6);
                Rectangle chkPoly = new Rectangle(chkRec12.X + chkRec12.Width / 4, chkRec12.Y + chkRec12.Height / 4, chkRec12.Width / 2, chkRec12.Height / 2);
                Point[] Poly = {
                new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
                new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
                new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
            };

                Pen P1 = new Pen((Color.White), 2);

                for (int i = 0; i <= Poly.Length - 2; i++)
                {
                    G.DrawLine(P1, Poly[i], Poly[i + 1]);
                }


            }
            G.DrawRectangle(new Pen(Color.FromArgb(93, 103, 113)), 1, 1, 16, 15);
            G.DrawRectangle(new Pen(Color.FromArgb(13, 23, 33)), 2, 2, 14, 13);
            G.DrawRectangle(new Pen(Color.FromArgb(113, 123, 133)), 3, 3, 12, 11);
            Brush txtbrush = new SolidBrush(Color.FromArgb(210, 220, 230));
            G.DrawString(Text, Font, txtbrush, new Point(18, 2), new StringFormat
            {
                LineAlignment = StringAlignment.Near,
                Alignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


