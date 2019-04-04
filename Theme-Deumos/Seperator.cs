// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Deumos
{
    public class DeumosSeperator : ThemeControl153
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


        public DeumosSeperator()
        {
            LockHeight = 14;

            SetColor("Line1", Color.Black);
            SetColor("Line2", 22, 22, 22);
        }

        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            P1 = GetPen("Line1");
            P2 = GetPen("Line2");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            if (_Orientation == Orientation.Vertical)
            {
                G.DrawLine(P1, 6, 0, 6, Height);
                G.DrawLine(P2, 7, 0, 7, Height);
            }
            else
            {
                G.DrawLine(P1, 0, 6, Width, 6);
                G.DrawLine(P2, 0, 7, Width, 7);
            }

        }
    }


}


