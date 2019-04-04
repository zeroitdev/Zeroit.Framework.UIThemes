// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.Visible
{
    public class VISeperator : ThemeControl154
    {
        private Orientation _Orientation;
        public Orientation Orientation
        {
            get
            {
                return _Orientation;
            }
            set
            {
                _Orientation = value;

                if (value == System.Windows.Forms.Orientation.Vertical)
                {
                    LockHeight = 0;
                    LockWidth = 14;
                }
                else
                {
                    LockHeight = 14;
                    LockWidth = 0;
                }

                Invalidate();
            }
        }

        public VISeperator()
        {
            Transparent = true;
            BackColor = Color.Transparent;

            LockHeight = 14;
        }

        protected override void ColorHook()
        {

        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            ColorBlend BL1 = new ColorBlend();
            ColorBlend BL2 = new ColorBlend();
            BL1.Positions = new float[] { 0.0F, 0.15F, 0.85F, 1.0F };
            BL2.Positions = new float[] { 0.0F, 0.15F, 0.5F, 0.85F, 1.0F };

            BL1.Colors = new Color[] { Color.Transparent, Color.Black, Color.Black, Color.Transparent };
            BL2.Colors = new Color[] { Color.Transparent, Color.FromArgb(24, 24, 24), Color.FromArgb(40, 40, 40), Color.FromArgb(36, 36, 36), Color.Transparent };

            if (_Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                DrawGradient(BL1, 6, 0, 1, Height);
                DrawGradient(BL2, 7, 0, 1, Height);
            }
            else
            {
                DrawGradient(BL1, 0, 6, Width, 1, 0.0F);
                DrawGradient(BL2, 0, 7, Width, 1, 0.0F);
            }

        }

    }
}


