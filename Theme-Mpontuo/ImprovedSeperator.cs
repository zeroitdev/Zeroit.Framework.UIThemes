// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ImprovedSeperator.cs" company="Zeroit Dev Technologies">
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
    public class MpontuoImprovedSeperator : ThemeControl
    {
        private Color _Color1 = Color.FromArgb(66, 130, 181);
        public Color Color1
        {
            get
            {
                return _Color1;
            }
            set
            {
                _Color1 = value;
            }
        }

        private Color _Color2 = Color.Black;
        public Color Color2
        {
            get
            {
                return _Color2;
            }
            set
            {
                _Color2 = value;
            }
        }

        public MpontuoImprovedSeperator()
        {
            AllowTransparent();
            BackColor = Color.Transparent;
            Size S = new Size(150, 10);
            Size = S;
        }

        public override void PaintHook()
        {
            G.Clear(BackColor);

            LinearGradientBrush K = new LinearGradientBrush(new Point(-1, 0), new Point(Width + 2, 0), Color.Empty, Color.Empty);
            Color[] KC = { Color.Transparent, _Color1, Color.Transparent };
            float[] KP = { 0F, 0.5F, 1F };
            K.InterpolationColors = new ColorBlend { Colors = KC, Positions = KP };

            G.FillRectangle(K, new Rectangle(0, Height / 2, Width, 2));
        }
    }
}

