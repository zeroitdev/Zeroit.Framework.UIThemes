// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace Zeroit.Framework.UIThemes.Atrocity
{

    public class aProgressBar : ThemeControl153
    {

        #region "Properties"
        [Description("The maximum ammount of steps the progressbar can go before being full"), Category("Atrocity"), Browsable(true)]
        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }

            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }

        [Description("The current ammount of steps the progressbar has taken."), Category("Atrocity"), Browsable(true)]
        private int _Value;
        public int Value
        {
            get { return _Value; }

            set
            {
                if (value > _Maximum)
                    value = _Maximum;

                _Value = value;
                Invalidate();
            }
        }
        #endregion
        public aProgressBar()
        {
            SetColor("bg", 45, 45, 45);
            SetColor("Grad1", 24, 23, 26);
            SetColor("Grad2", 72, 69, 75);

            SetColor("border1", 65, 65, 65);
            SetColor("border2", 70, 70, 70);

            SetColor("text", 0, 168, 198);
        }

        Color GRAD1;
        Color GRAD2;
        Color BG1;
        Pen P1;

        Pen P2;
        protected override void ColorHook()
        {
            GRAD1 = GetColor("Grad1");
            GRAD2 = GetColor("Grad2");
            BG1 = GetColor("bg");

            P1 = new Pen(GetColor("border1"));
            P2 = new Pen(GetColor("border2"));
        }

        protected override void PaintHook()
        {
            G.Clear(BG1);

            //DrawGradient(GRAD1, GRAD2, 0, 0, CInt(_Value / _Maximum * Width) - 1, Height - 1, -90S)
            G.FillRectangle(new SolidBrush(GRAD1), 0, 0, Convert.ToInt32(_Value / _Maximum * Width) - 1, Height - 1);

            HatchBrush DarkDown = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            G.FillRectangle(DarkDown, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));




            G.DrawString(Convert.ToString(_Value) + "%", new Font("Courier New", 8), new SolidBrush(GetColor("text")), new Point(Width / 2 - 9, Height / 2 - 7));

            DrawBorders(P2, 0);
            DrawBorders(new Pen(Color.Black), 1);
            DrawBorders(P2, 2);

            DrawCorners(BG1);
        }
    }
    
}

