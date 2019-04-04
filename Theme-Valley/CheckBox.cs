// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    [DefaultEvent("CheckedChanged")]
    public class ValleyCheckBox : Control
    {
        #region Variables
        private MouseState State = MouseState.None;
        private bool _Checked;
        #endregion

        #region  Properties
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
                CheckedChanged(this);
            base.OnClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        #endregion

        #region  Mouse States

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.Clear(BackColor);

            G.DrawRectangle(new Pen(Color.FromArgb(192, 192, 192)), new Rectangle(0, 0, 15, 15));

            switch (State)
            {
                case MouseState.Over:
                    G.DrawRectangle(new Pen(Color.FromArgb(160, 160, 160)), new Rectangle(0, 0, 15, 15));
                    break;
            }

            if (Checked)
            {
                G.DrawString("�", new Font("Wingdings", 9), new SolidBrush(Color.FromArgb(56, 56, 56)), new Point(0, 2));
            }

            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(15, 15, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 15, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(15, 0, 1, 1));

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(131, 131, 131)), new Point(18, -3));

            base.OnPaint(e);


        }
    }
}


