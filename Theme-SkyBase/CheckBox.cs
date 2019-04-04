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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SkyLimit
{

    public class SkyDarkCheck : Control
    {

        public enum MouseState
        {
            None,
            Down
        }

        #region "Properties"

        private bool chk;
        public bool Checked
        {
            get { return chk; }
            set
            {
                chk = value;
                Invalidate();
            }
        }

        private MouseState ms;
        public MouseState State
        {
            get { return ms; }
            set
            {
                ms = value;
                Invalidate();
            }
        }

        #endregion

        Color C1 = Color.FromArgb(51, 49, 47);

        Color C2 = Color.FromArgb(80, 77, 77);
        Color C3 = Color.FromArgb(70, 69, 68);
        Color C4 = Color.FromArgb(64, 60, 59);

        Color C5 = Color.Transparent;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Parent.BackColor);
            C3 = Color.FromArgb(70, 69, 68);
            C4 = Color.FromArgb(64, 60, 59);
            switch (Enabled)
            {
                case true:
                    switch (State)
                    {
                        case MouseState.Down:
                            C5 = Color.FromArgb(121, 151, 160);
                            C3 = Color.FromArgb(64, 60, 59);
                            C4 = Color.FromArgb(70, 69, 68);
                            break;
                        case MouseState.None:
                            C5 = Color.FromArgb(151, 181, 190);
                            break;
                    }
                    break;
                case false:
                    C5 = Color.FromArgb(88, 88, 88);
                    break;
            }

            Rectangle chkRec = new Rectangle(0, 0, Height - 1, Height - 1);
            LinearGradientBrush G1 = new LinearGradientBrush(new Point(chkRec.X, chkRec.Y), new Point(chkRec.X, chkRec.Y + chkRec.Height), C3, C4);
            G.FillRectangle(G1, chkRec);
            G1.Dispose();
            G.DrawRectangle(ConversionFunctions.ToPen(C1), chkRec);
            G.DrawRectangle(ConversionFunctions.ToPen(C2), new Rectangle(chkRec.X + 1, chkRec.Y + 1, chkRec.Width - 2, chkRec.Height - 2));
            Rectangle chkPoly = new Rectangle(chkRec.X + chkRec.Width / 4, chkRec.Y + chkRec.Height / 4, chkRec.Width / 2, chkRec.Height / 2);
            Point[] Poly = {
            new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
            new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
            new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
        };
            
            if (Checked)
            {
                G.SmoothingMode = SmoothingMode.HighQuality;
                Pen P1 = new Pen(ConversionFunctions.ToBrush(C5), 2);
                for (int i = 0; i <= Poly.Length - 2; i++)
                {
                    G.DrawLine(P1, Poly[i], Poly[i + 1]);
                }
            }
            G.DrawString(Text, Font, ConversionFunctions.ToBrush(C5), new Rectangle(chkRec.X + chkRec.Width + 5, 0, Width - chkRec.X - chkRec.Width - 5, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (Enabled)
            {
                State = MouseState.None;
                Checked = !Checked;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (Enabled)
            {
                State = MouseState.Down;
            }
        }
    }

}