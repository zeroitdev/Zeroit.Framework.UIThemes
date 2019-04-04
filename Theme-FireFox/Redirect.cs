// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Redirect.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FireFox.Helpers;

namespace Zeroit.Framework.UIThemes.FireFox
{

    public class FirefoxRedirect : Control
    {

        #region " Private "
        private MouseState State;

        private Graphics G;
        private Color FC;
        #endregion
        private Font FF = null;

        #region " Control "

        public FirefoxRedirect()
        {
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            BackColor = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            switch (State)
            {

                case MouseState.Over:
                    FC = Color.FromArgb(23, 140, 229);
                    FF = new Font("Segoe UI", 10f, FontStyle.Underline);

                    break;
                case MouseState.Down:
                    FC = Color.FromArgb(255, 149, 0);
                    FF = new Font("Segoe UI", 10f, FontStyle.Regular);

                    break;
                default:
                    FC = Color.FromArgb(0, 149, 221);
                    FF = new Font("Segoe UI", 10f, FontStyle.Underline);

                    break;
            }

            using (SolidBrush B = new SolidBrush(FC))
            {
                G.DrawString(Text, FF, B, new Point(0, 0));
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Down;
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
            base.OnMouseEnter(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

    }


}


