// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Divider.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Positron
{
    public class PositronDivider : ThemeControl154
    {


        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
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

        public PositronDivider()
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
            BL1.Positions = new float[] {
            0f,
            0.15f,
            0.85f,
            1f
        };
            BL2.Positions = new float[] {
            0f,
            0.15f,
            0.5f,
            0.85f,
            1f
        };
            BL1.Colors = new Color[] {
            Color.Transparent,
            Color.LightGray,
            Color.LightGray,
            Color.Transparent
        };
            BL2.Colors = new Color[] {
            Color.Transparent,
            Color.FromArgb(144, 144, 144),
            Color.FromArgb(160, 160, 160),
            Color.FromArgb(156, 156, 156),
            Color.Transparent
        };
            if (_Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                DrawGradient(BL1, 6, 0, 1, Height);
                DrawGradient(BL2, 7, 0, 1, Height);
            }
            else
            {
                DrawGradient(BL1, 0, 6, Width, 1, 0f);
                DrawGradient(BL2, 0, 7, Width, 1, 0f);
            }
        }
    }
}

