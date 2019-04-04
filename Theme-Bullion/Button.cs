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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Bullion
{

    public class BullionButton : Control
    {


        private Image _Image;
        private bool ImageSet;
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                ImageSet = value != null;
            }
        }


        Bitmap B;
        Graphics G;
        Rectangle R1;
        Color C1;
        Color C2;
        Color C3;
        Color C4;
        Pen P1;
        Pen P2;
        Pen P3;
        Pen P4;
        Brush B1;
        Brush B2;
        Brush B5;
        LinearGradientBrush B3;

        LinearGradientBrush B4;
        public BullionButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            C1 = Color.FromArgb(244, 244, 244);
            //Background
            C2 = Color.FromArgb(220, 220, 220);
            //Highlight
            C3 = Color.FromArgb(248, 248, 248);
            //Lesser Highlight
            C4 = Color.FromArgb(24, Color.Black);
            P1 = new Pen(Color.FromArgb(255, 255, 255));
            //Shadow
            P2 = new Pen(Color.FromArgb(40, Color.White));
            P3 = new Pen(Color.FromArgb(20, Color.White));
            P4 = new Pen(Color.FromArgb(10, Color.Black));
            //Down-Left
            B1 = new SolidBrush(C1);
            B2 = new SolidBrush(C3);
            B5 = new SolidBrush(Color.FromArgb(170, 170, 170));
            //Text Color
            Font = new Font("Verdana", 8f);
        }

        private int State;
        protected override void OnMouseLeave(EventArgs e)
        {
            State = 0;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            State = 1;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            State = 1;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            State = 2;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            R1 = new Rectangle(2, 2, Width - 4, 4);
            B3 = new LinearGradientBrush(ClientRectangle, C3, C2, 90f);
            B4 = new LinearGradientBrush(R1, C4, Color.Transparent, 90f);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.FillRectangle(B3, ClientRectangle);

            switch (State)
            {
                case 0:
                    //Up
                    G.FillRectangle(B2, 1, 1, Width - 2, Height - 2);
                    G.DrawRectangle(P4, 2, 2, Width - 5, Height - 5);
                    break;
                case 1:
                    //Over
                    G.FillRectangle(B1, 1, 1, Width - 2, Height - 2);
                    G.DrawRectangle(P4, 2, 2, Width - 5, Height - 5);
                    break;
                case 2:
                    //Down
                    G.FillRectangle(B1, 1, 1, Width - 2, Height - 2);
                    G.FillRectangle(B4, R1);
                    G.DrawLine(P4, 2, 2, 2, Height - 3);
                    break;
            }

            SizeF S = G.MeasureString(Text, Font);
            G.DrawString(Text, Font, B5, Convert.ToInt32(Width / 2 - S.Width / 2), Convert.ToInt32(Height / 2 - S.Height / 2));

            G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3);

            if (ImageSet)
                G.DrawImage(_Image, 5, Convert.ToInt32(Height / 2 - _Image.Height / 2), _Image.Width, _Image.Height);

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

    }
    
}


