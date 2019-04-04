// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Green
{

    
    public class GreenTheme : Control
    {

        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            if (Parent is System.Windows.Forms.Form)
            {
                var _with1 = (System.Windows.Forms.Form)Parent;
                _with1.FormBorderStyle = 0;
                _with1.BackColor = C1;
                _with1.ForeColor = Color.FromArgb(12, 12, 12);
            }
            base.OnHandleCreated(e);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (new Rectangle(Parent.Location.X, Parent.Location.Y, Width, 22).IntersectsWith(new Rectangle(MousePosition.X, MousePosition.Y, 1, 1)))
            {
                Capture = false;
                Message M = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
                DefWndProc(ref M);
            }
            base.OnMouseDown(e);
        }

        Graphics G;
        Bitmap B;
        Rectangle R1;
        Rectangle R2;
        Color C1;
        Color C2;
        Color C3;
        Color C4;
        Pen P1;
        Pen P2;
        Pen P3;
        SolidBrush B1;
        LinearGradientBrush B2;

        LinearGradientBrush B3;

        public GreenTheme()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            C1 = Color.FromArgb(41, 57, 34);
            //Background
            C2 = Color.FromArgb(190, 255, 159);
            //Highlight
            C3 = Color.FromArgb(22, 22, 22);
            //Shadow
            C4 = Color.FromArgb(20, 107, 18);
            P1 = new Pen(C4);
            //Border
            P2 = new Pen(C1);
            P3 = new Pen(C2);
            B1 = new SolidBrush(C2);
            Font = new Font("Verdana", 7f, FontStyle.Bold);

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Height > 0)
            {
                R1 = new Rectangle(0, 2, Width, 18);
                R2 = new Rectangle(0, 21, Width, 10);
                B2 = new LinearGradientBrush(R1, C1, C3, 90f);
                B3 = new LinearGradientBrush(R2, Color.FromArgb(70, 0, 0, 0), Color.Transparent, 90f);
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C1);

            for (int I = 0; I <= Width + 17; I += 4)
            {
                G.DrawLine(P1, I, 21, I - 17, 37);
                G.DrawLine(P1, I - 1, 21, I - 16, 37);
            }
            G.FillRectangle(B3, R2);

            G.FillRectangle(B2, R1);
            G.DrawString(Text, Font, B1, 5, 5);

            G.DrawRectangle(P2, 1, 1, Width - 3, 19);
            G.DrawRectangle(P3, 1, 39, Width - 3, Height - 41);

            G.DrawRectangle(P1, 0, 0, Width - 1, Height - 1);
            G.DrawLine(P1, 0, 21, Width, 21);
            G.DrawLine(P1, 0, 38, Width, 38);

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }
    
    
    
}
