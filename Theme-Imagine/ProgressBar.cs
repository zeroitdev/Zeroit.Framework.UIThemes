// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Newer
{
    public class ImagineProgressBar : ThemeControl154
    {
        Color BG;
        Brush Prog;
        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                    value = 0;
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                Invalidate();
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
                _Value = value;
                Invalidate();
            }
        }
        public ImagineProgressBar()
        {
            SetColor("Prog", 12, 27, 74);
            SetColor("BG", 13, 13, 13);
            BackColor = GetColor("BG");
        }
        protected override void ColorHook()
        {
            BG = GetColor("BG");
            Prog = GetBrush("Prog");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(15, Color.LightBlue), Color.Transparent);
            G.FillRectangle(Prog, 0, 0, Convert.ToInt32(_Value / _Maximum * Width), Height);
            G.FillRectangle(HB, new Rectangle(0, 0, Convert.ToInt32(_Value / _Maximum * Width), Height));
            DrawGradient(Color.FromArgb(40, Color.White), Color.FromArgb(10, Color.White), ClientRectangle);
            DrawBorders(Pens.Black, ClientRectangle);
        }

    }

}

