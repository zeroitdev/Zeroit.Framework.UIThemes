// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RedProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterRedProgressbar : ThemeControl154
    {

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

        public BoosterRedProgressbar()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(66, 0, 0));

            G.FillRectangle(new SolidBrush(Color.FromArgb(204, 0, 0)), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height);

            CreateRound(0, 0, Width, Height, 5);
            G.DrawLine(new Pen(Color.FromArgb(32, 32, 32)), 0, 1, Width, 1);
            DrawBorders(new Pen(Color.FromArgb(70, 70, 70)), 0);
            G.DrawLine(new Pen(Color.FromArgb(138, 139, 138)), 0, Height - 1, Width, Height - 1);
            DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(138, 139, 138), 0, 0, 1, Height);
            DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(138, 139, 138), Width - 1, 0, Width, Height);
        }
    }


}

