// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-19-2019
// ***********************************************************************
// <copyright file="Knight Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Form.UIThemes.Knight
{

    

    enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    public class KnightTheme : ContainerControl
    {

        #region " Declarations "
        private int _Header = 38;
        private bool _Down = false;
        #endregion
        private Point _MousePoint;

        #region " MouseStates "
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _Down = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Location.Y < _Header && e.Button == MouseButtons.Left)
            {
                _Down = true;
                _MousePoint = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_Down == true)
            {
                ParentForm.Location = new Point(MousePosition.X - _MousePoint.X, MousePosition.Y - _MousePoint.Y);
            }
        }

        #endregion
        
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        public KnightTheme()
        {
            BackColor = Color.FromArgb(46, 49, 61);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(236, 73, 99));
            G.FillRectangle(new SolidBrush(Color.FromArgb(46, 49, 61)), new Rectangle(0, _Header, Width, Height - _Header));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(0, 1, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 2, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 1, 1, 1));
            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;
            G.DrawString(Text, new Font("Segoe UI", 12), Brushes.White, new RectangleF(0, 0, Width, _Header), _StringF);
        }

    }

    

}


