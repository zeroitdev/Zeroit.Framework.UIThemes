// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Deumos
{
    public class DeumosProgressBar : ThemeControl153
    {

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        public DeumosProgressBar()
        {
            SetColor("Frame", 18, 18, 18);
            SetColor("Border1", Color.Black);
            SetColor("Border2", Color.Black);
            SetColor("Gloss1", 30, Color.White);
            SetColor("Gloss2", 5, Color.White);
            SetColor("Back1", 2, 2, 2);
            SetColor("Back2", 8, 8, 8);
            SetColor("Progress1", 38, 38, 38);
            SetColor("Progress2", 52, 52, 52);
            SetColor("ProgressShine", 16, Color.White);
            SetColor("ProgressGloss1", 32, Color.White);
            SetColor("ProgressGloss2", 12, Color.White);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Color C7;
        private Color C8;
        private Color C9;
        private Pen P1;
        private Pen P2;

        private Pen P3;
        protected override void ColorHook()
        {
            C1 = GetColor("Frame");
            C2 = GetColor("Gloss1");
            C3 = GetColor("Gloss2");
            C4 = GetColor("Back1");
            C5 = GetColor("Back2");
            C6 = GetColor("Progress1");
            C7 = GetColor("Progress2");
            C8 = GetColor("ProgressGloss1");
            C9 = GetColor("ProgressGloss2");

            P1 = GetPen("Border1");
            P2 = GetPen("Border2");
            P3 = GetPen("ProgressShine");
        }

        private Rectangle R1;

        private int I1;
        protected override void PaintHook()
        {
            G.Clear(C1);
            DrawGradient(C2, C3, 0, 0, Width, Height / 2);

            DrawGradient(C4, C5, 2, 2, Width - 4, Height - 4);
            DrawBorders(P1, 2);

            I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 6));

            if (!(I1 == 0))
            {
                R1 = new Rectangle(3, 3, I1, Height - 6);

                DrawGradient(C6, C7, R1, 35f);
                DrawBorders(P3, R1);

                DrawGradient(C8, C9, 3, 3, I1, Height / 2 - 3);
            }

            DrawBorders(P2);
            DrawCorners(BackColor);
        }

    }


}


