// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Check.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightCheck : ThemeControl
    {

        #region " Properties "
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
        #endregion

        public LightCheck()
        {
            MouseDown += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }

        public override void PaintHook()
        {
            G.Clear(this.Parent.BackColor);
            this.ForeColor = this.Parent.ForeColor;
            switch (CheckedState)
            {
                case true:
                    HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, 15, 15, 270);
                    DrawGradient(Color.FromArgb(35, Color.Black), Color.Transparent, 0, 0, 15, 15, 180);
                    G.FillRectangle(hb, 0, 0, 15, 15);
                    G.DrawString("a", new Font("Marlett", 12), Brushes.Black, new Point(-3, -1));
                    break;
                case false:
                    HatchBrush hb1 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, 15, 15, 270);
                    DrawGradient(Color.FromArgb(35, Color.Black), Color.Transparent, 0, 0, 15, 15, 180);
                    G.FillRectangle(hb1, 0, 0, 15, 15);
                    break;
            }

            DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));

            DrawText(HorizontalAlignment.Left, this.ForeColor, 17, 0);
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


