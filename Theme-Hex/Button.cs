// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Hex
{
    public class HexButton : Control
    {

        #region " Declarations "
        #endregion
        private MouseState _State;
        
        #region " Mouse States "
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
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

        public HexButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Size = new Size(90, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(30, 33, 40));
            G.DrawPath(new Pen(Color.FromArgb(236, 95, 75)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));
            G.FillPath(new SolidBrush(Color.FromArgb(236, 95, 75)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));

            switch (_State)
            {
                case MouseState.Over:
                    G.DrawPath(new Pen(Color.FromArgb(20, Color.White)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));
                    G.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));
                    break;
                case MouseState.Down:
                    G.DrawPath(new Pen(Color.FromArgb(25, Color.Black)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));
                    G.FillPath(new SolidBrush(Color.FromArgb(25, Color.Black)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));
                    break;
            }

            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;
            G.DrawString(Text, new Font("Segoe UI", 9), Brushes.White, new RectangleF(0, 0, Width - 1, Height - 1), _StringF);
        }

    }


}


