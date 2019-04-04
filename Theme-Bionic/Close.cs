// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Close.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Bionic
{
    public class BionicClose : Control
    {

        #region " Declarations "
        #endregion
        private MouseState _State;

        #region " MouseStates "
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _State = MouseState.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Hover;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Environment.Exit(0);
        }
        #endregion
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(12, 12);
        }

        public BionicClose()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            Size = new Size(12, 12);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Color.FromArgb(38, 38, 38));
            G.FillRectangle(new SolidBrush(Color.FromArgb(29, 29, 29)), new Rectangle(0, Height / 2, Width, Height / 2));


            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;

            G.DrawString("r", new Font("Marlett", 11), Brushes.White, new RectangleF(0, 0, Width, Height), _StringF);

            switch (_State)
            {
                case MouseState.Hover:
                    G.DrawString("r", new Font("Marlett", 11), new SolidBrush(Color.FromArgb(25, Color.White)), new RectangleF(0, 0, Width, Height), _StringF);

                    break;
                case MouseState.Down:
                    G.DrawString("r", new Font("Marlett", 11), new SolidBrush(Color.FromArgb(40, Color.Black)), new RectangleF(0, 0, Width, Height), _StringF);

                    break;
            }

        }

    }


}


