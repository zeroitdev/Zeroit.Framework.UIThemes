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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Reactor
{
    [DefaultEvent("CheckedChanged")]
    public class ReactorCheckBox : Control
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
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
        #endregion

        public ReactorCheckBox()
            : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            ForeColor = Color.White;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            Height = 16;

            G.Clear(BackColor);

            Color bordColor = Color.FromArgb(46, 45, 44);
            LinearGradientBrush backGrad = new LinearGradientBrush(new Rectangle(1, 1, 14, Height - 2), Color.FromArgb(10, 9, 8), Color.FromArgb(31, 29, 26), 90);
            LinearGradientBrush glossGradient = new LinearGradientBrush(new Rectangle(1, 1, 13, Height / 2 - 2), Color.FromArgb(80, Color.White), Color.FromArgb(50, Color.White), 90);

            if (_Checked)
            {
                bordColor = Color.FromArgb(225, 110, 30);
                backGrad = new LinearGradientBrush(new Rectangle(1, 1, 14, Height - 2), Color.FromArgb(209, 68, 0), Color.FromArgb(210, 75, 0), 90);
            }
            else
            {
                bordColor = Color.FromArgb(46, 45, 44);
                backGrad = new LinearGradientBrush(new Rectangle(1, 1, 14, Height - 2), Color.FromArgb(24, 24, 24), Color.FromArgb(30, 30, 30), 90);
            }

            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(18, Height / 2 + (Font.Height) - 18));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(36, 34, 30))), 2, Height - 1, 14, Height - 1);
            G.FillRectangle(backGrad, new Rectangle(1, 1, 14, Height - 2));
            G.DrawRectangle(new Pen(new SolidBrush(bordColor)), new Rectangle(1, 1, 12, Height - 4));
            if (_Checked)
            {
                G.FillRectangle(glossGradient, new Rectangle(1, 1, 13, Height / 2 - 2));
            }
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(0, 0, 14, Height - 2));
        }

    }

}


