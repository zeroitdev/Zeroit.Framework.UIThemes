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


namespace Zeroit.Framework.UIThemes.Nameless
{
    public class NamelessChecBox : ThemeControl154
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
        public NamelessChecBox()
        {
            Click += changeCheck;
            LockHeight = 17;
        }
        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            //G.Clear(Color.Transparent);
            G.Clear(BackColor);
            Rectangle chkRec = new Rectangle(2, 1, Height - 2, Height - 2);
            Rectangle chkRecInner = new Rectangle(3, 2, Height - 4, Height - 4);
            Rectangle chkRecInner2 = new Rectangle(4, 3, Height - 6, Height - 6);
            DrawGradient(Color.DimGray, Color.Black, chkRec);
            Pen P2 = new Pen(Color.FromArgb(25, 25, 25));
            Pen P3 = new Pen(Color.FromArgb(130, 130, 130));
            Pen P4 = new Pen(Color.FromArgb(30, 30, 30));
            G.DrawRectangle(P2, chkRec);
            G.DrawRectangle(P3, chkRecInner);
            G.DrawRectangle(P4, chkRecInner2);


            if (State == MouseState.Over)
            {
                Rectangle chkRec1 = new Rectangle(2, 1, Height - 2, Height - 2);
                Rectangle chkRecInner1 = new Rectangle(3, 2, Height - 4, Height - 4);
                Rectangle chkRecInner12 = new Rectangle(4, 3, Height - 6, Height - 6);
                DrawGradient(Color.Gray, Color.Black, chkRec1);
                Pen P12 = new Pen(Color.FromArgb(40, 40, 40));
                Pen P13 = new Pen(Color.FromArgb(140, 140, 140));
                Pen P14 = new Pen(Color.FromArgb(50, 50, 50));
                G.DrawRectangle(P12, chkRec1);
                G.DrawRectangle(P13, chkRecInner1);
                G.DrawRectangle(P14, chkRecInner12);
            }

            switch (CheckedState)
            {
                case true:

                    Rectangle chkRec12 = new Rectangle(2, 1, Height - 2, Height - 2);
                    Rectangle chkRecInner12 = new Rectangle(3, 2, Height - 4, Height - 4);
                    Rectangle chkRecInner22 = new Rectangle(4, 3, Height - 6, Height - 6);
                    DrawGradient(Color.Gray, Color.Black, chkRec12);
                    Pen P22 = new Pen(Color.FromArgb(20, 20, 20));
                    Pen P23 = new Pen(Color.FromArgb(150, 150, 150));
                    Pen P24 = new Pen(Color.FromArgb(40, 40, 40));
                    G.DrawRectangle(P22, chkRec12);
                    G.DrawRectangle(P23, chkRecInner12);
                    G.DrawRectangle(P24, chkRecInner22);

                    G.SmoothingMode = SmoothingMode.HighQuality;
                    Rectangle chkPoly = new Rectangle(chkRec12.X + chkRec12.Width / 4, chkRec12.Y + chkRec12.Height / 4, chkRec12.Width / 2, chkRec12.Height / 2);
                    Point[] Poly = {
                    new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
                    new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
                    new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
                };

                    Pen P1 = new Pen((Color.White), 2);

                    for (int i = 0; i <= Poly.Length - 2; i++)
                    {
                        G.DrawLine(P1, Poly[i], Poly[i + 1]);
                    }


                    break;

            }
            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 19, 1);
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