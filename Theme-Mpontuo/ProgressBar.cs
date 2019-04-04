// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoProgressBar : ThemeControl
    {
        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }

                _Value = value;
                Invalidate();
            }
        }

        public MpontuoProgressBar()
        {
            AllowTransparent();
            ForeColor = Color.FromArgb(66, 130, 181);
        }

        private Pen Border = new Pen(Color.Black);
        private Color T = Color.Transparent;
        private Color BackClr = Color.FromArgb(30, 30, 30);
        private SolidBrush UpperColor = new SolidBrush(Color.FromArgb(50, 50, 50));
        private SolidBrush LowerColor = new SolidBrush(Color.FromArgb(42, 42, 42));

        public override void PaintHook()
        {
            G.Clear(BackClr); //Background color of the control

            G.FillRectangle(LowerColor, 1, 1, Convert.ToInt32((_Value / (double)_Maximum) * Width), Height - 2); // \
            G.FillRectangle(UpperColor, 1, 1, Convert.ToInt32((_Value / (double)_Maximum) * Width), (int)(Math.Truncate((double)(Height - 2) / 2))); // > Draw the colors and the border
            G.DrawRectangle(Border, 0, 0, Width - 1, Height - 1); // /

            DrawText(HorizontalAlignment.Center, ForeColor, 0); //Text

            DrawCorners(BackClr, ClientRectangle); //Corners..
        }
    }
}

