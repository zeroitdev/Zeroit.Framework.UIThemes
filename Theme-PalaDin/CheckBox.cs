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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Paladin
{
    public class PaladinCheckBox : ThemeControl154
    {
        private bool _CheckedState;
        public bool CheckedState
        {
            get { return _CheckedState; }
            set
            {
                _CheckedState = value;
                Invalidate();
            }
        }
        public PaladinCheckBox()
        {
            Click += changeCheck;
            Size = new Size(146, 17);
            MinimumSize = new Size(145, 16);
            MaximumSize = new Size(146, 17);

        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            Color C3 = Color.FromArgb(150, 150, 150);
            Color C4 = Color.FromArgb(140, 140, 140);




            // G.DrawLine(New Pen(Color.FromArgb(230, 230, 230)), 3, 10, Height - 10, Height - 5)

            //G.DrawLine(New Pen(Color.FromArgb(230, 230, 230)), 3, 5, Height - 10, Height - 5)
            G.Clear(Color.FromArgb(190, 190, 190));
            SolidBrush RecLGB = new SolidBrush(Color.FromArgb(180, 180, 180));
            Rectangle chkRec = new Rectangle(2, 1, Height - 2, Height - 2);
            Rectangle chkRecInner = new Rectangle(3, 2, Height - 4, Height - 4);
            Rectangle chkRecInner2 = new Rectangle(4, 3, Height - 6, Height - 6);
            G.FillRectangle(RecLGB, chkRec);
            Pen P2 = new Pen(Color.FromArgb(90, 90, 90));
            Pen P3 = new Pen(Color.FromArgb(235, 235, 235));
            Pen P4 = new Pen(Color.FromArgb(145, 145, 145));
            G.DrawRectangle(P2, chkRec);
            G.DrawRectangle(P3, chkRecInner);
            G.DrawRectangle(P4, chkRecInner2);


            switch (CheckedState)
            {
                case true:
                    G.SmoothingMode = SmoothingMode.HighQuality;
                    Rectangle chkPoly = new Rectangle(chkRec.X + chkRec.Width / 4, chkRec.Y + chkRec.Height / 4, chkRec.Width / 2, chkRec.Height / 2);
                    Point[] Poly = {
                    new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
                    new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
                    new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
                };

                    Pen P1 = new Pen((Color.Black), 2);

                    for (int i = 0; i <= Poly.Length - 2; i++)
                    {
                        G.DrawLine(P1, Poly[i], Poly[i + 1]);
                    }

                    break;
            }

            //DrawText(New SolidBrush(Color.Black), HorizontalAlignment.Left, 17, 0)


            //DrawText(New SolidBrush(Color.WhiteSmoke), HorizontalAlignment.Left, 20, 1)
            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Left, 19, 0);

        }
        public void changeCheck(object sender, EventArgs e)
        {
            switch (CheckedState)
            {
                case true:
                    CheckedState = false;
                    break;
                case false:
                    CheckedState = true;
                    break;
            }
        }
    }

}

