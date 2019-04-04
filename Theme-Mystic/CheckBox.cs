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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Mystic
{
    [DefaultEvent("CheckedChanged")]
    public class MysticCheckBox : Control
    {

        #region " Variables "
        private MouseState _State = MouseState.None;
        #endregion
        private bool _Checked;

        #region " Properties "
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        #endregion

        #region " Mouse States "

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _State = MouseState.None;
            Invalidate();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(44, 51, 62));
            G.FillRectangle(new SolidBrush(Color.FromArgb(36, 39, 46)), new Rectangle(0, 0, 15, 15));
            G.DrawLine(new Pen(Color.FromArgb(26, 29, 33)), new Point(0, 0), new Point(0, 14));
            G.DrawLine(new Pen(Color.FromArgb(26, 29, 33)), new Point(0, 0), new Point(14, 0));
            if (Checked)
            {
                G.FillRectangle(new LinearGradientBrush(new Point(3, 3), new Point(3, 13), Color.FromArgb(123, 255, 201), Color.FromArgb(41, 131, 113)), new Rectangle(3, 3, 9, 9));
                G.FillRectangle(new LinearGradientBrush(new Point(4, 4), new Point(4, 11), Color.FromArgb(9, 204, 157), Color.FromArgb(41, 131, 113)), new Rectangle(4, 4, 7, 7));
                G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, new Point(18, -1));
            }
            else
            {
                switch (_State)
                {
                    case MouseState.None:
                        G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(Color.FromArgb(121, 131, 141)), new Point(18, -1));
                        break;
                    case MouseState.Over:
                        G.DrawRectangle(new Pen(Color.FromArgb(0, 205, 155), 2), new Rectangle(1, 1, 13, 13));
                        G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, new Point(18, -1));
                        break;
                    case MouseState.Down:
                        G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, new Point(18, -1));
                        break;
                }
            }
        }
    }

}

