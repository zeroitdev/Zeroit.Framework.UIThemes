// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Orains
{
    public class OrainsSeperator : ThemeControl154
    {

        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;

                if (value == Orientation.Vertical)
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

        public OrainsSeperator()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            LockHeight = 10;
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
            Color.Black,
            Color.Black,
            Color.Transparent
        };
            BL2.Colors = new Color[] {
            Color.Transparent,
            Color.FromArgb(35, 35, 35),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(35, 35, 35),
            Color.Transparent
        };

            if (_Orientation == Orientation.Vertical)
            {
                DrawGradient(BL2, 6, 0, 1, Height);
                DrawGradient(BL1, 7, 0, 1, Height);
            }
            else
            {
                DrawGradient(BL2, 0, 6, Width, 1, 0f);
                DrawGradient(BL1, 0, 7, Width, 1, 0f);
            }

        }

    }


}


