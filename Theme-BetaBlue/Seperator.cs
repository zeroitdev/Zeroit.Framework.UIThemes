// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.BetaBlue
{
    
    public class BetaBlueSeperator : Control
    {

        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                UpdateOffset();
                Invalidate();
            }
        }

        Graphics G;
        Bitmap B;
        int I;
        Color C1;
        Pen P1;
        Pen P2;
        public BetaBlueSeperator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            C1 = Color.FromArgb(0, 95, 218);
            //Background
            P1 = new Pen(Color.FromArgb(55, 55, 55));
            //Shadow
            P2 = new Pen(Color.FromArgb(0, 105, 246));
            //Highlight
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateOffset();
            base.OnSizeChanged(e);
        }

        public void UpdateOffset()
        {
            I = Convert.ToInt32(_Orientation == 0 ? Height / 2 - 1 : Width / 2 - 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C1);

            if (_Orientation == 0)
            {
                G.DrawLine(P1, 0, I, Width, I);
                G.DrawLine(P2, 0, I + 1, Width, I + 1);
            }
            else
            {
                G.DrawLine(P2, I, 0, I, Height);
                G.DrawLine(P1, I + 1, 0, I + 1, Height);
            }

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

    }

}

