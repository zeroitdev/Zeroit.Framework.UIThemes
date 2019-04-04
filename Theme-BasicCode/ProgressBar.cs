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
using System.Drawing.Drawing2D;




namespace Zeroit.Framework.UIThemes.BasicCode
{


    public class BCEvoProgressBar : ThemeControl154
    {


        private ColorBlend Blend;
        public BCEvoProgressBar()
        {
            Blend = new ColorBlend();
            Blend.Colors = new Color[] {
            Color.FromArgb(150, 0, 0),
            Color.FromArgb(190, 0, 0),
            Color.FromArgb(190, 0, 0),
            Color.FromArgb(150, 0, 0)
        };
            Blend.Positions = new float[] {
            0f,
            0.4f,
            0.6f,
            1f
        };
        }

        protected override void OnCreation()
        {
            if (!DesignMode)
            {
                System.Threading.Thread T = new System.Threading.Thread(MoveGlow);
                T.IsBackground = true;
                T.Start();
            }
        }

        private float GlowPosition = -1f;
        private void MoveGlow()
        {
            while (true)
            {
                GlowPosition += 0.01f;
                if (GlowPosition >= 1f)
                    GlowPosition = -1f;
                Invalidate();
                System.Threading.Thread.Sleep(10);
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                if (value < 0)
                    value = 0;

                _Value = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (_Value > value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }

        public void Increment(int amount)
        {
            Value += amount;
        }


        protected override void ColorHook()
        {
        }

        private int Progress;
        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            DrawBorders(new Pen(Color.FromArgb(32, 32, 32)), 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, 8);

            DrawGradient(Color.FromArgb(8, 8, 8), Color.FromArgb(23, 23, 23), 2, 2, Width - 4, Height - 4, 90f);

            Progress = Convert.ToInt32((_Value / _Maximum) * Width);

            if (!(Progress == 0))
            {
                G.SetClip(new Rectangle(3, 3, Progress - 6, Height - 6));
                G.FillRectangle(new SolidBrush(Color.FromArgb(150, 0, 0)), 0, 0, Progress, Height);

                DrawGradient(Blend, Convert.ToInt32(GlowPosition * Progress), 0, Progress, Height, 0f);
                DrawBorders(new Pen(Color.FromArgb(15, Color.White)), 3, 3, Progress - 6, Height - 6);

                G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 3, 3, Width - 6, Convert.ToInt32(Height / 2 - 3));
                G.ResetClip();
            }

            DrawBorders(Pens.Black, 2);
            DrawBorders(Pens.Black);
        }
    }
    
}
