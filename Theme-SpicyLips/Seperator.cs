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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SpicyLips
{
    public class BlackSeperator : ThemeControl154
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
                    LockWidth = 12;
                }
                else
                {
                    LockHeight = 12;
                    LockWidth = 0;
                }

                Invalidate();
            }
        }
        public BlackSeperator()
        {
            LockHeight = 12;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));

            if (_Orientation == Orientation.Horizontal)
            {
                G.DrawLine(new Pen(Color.FromArgb(2, 2, 2)), 0, 6, Width, 6);
                G.DrawLine(new Pen(Color.FromArgb(22, 22, 22)), 0, 7, Width, 7);
            }
            else
            {
                G.DrawLine(new Pen(Color.FromArgb(2, 2, 2)), 6, 0, 6, Height);
                G.DrawLine(new Pen(Color.FromArgb(22, 22, 22)), 7, 0, 7, Height);
            }

        }
    }

}