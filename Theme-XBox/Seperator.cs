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

namespace Zeroit.Framework.UIThemes.Xbox
{
    public class XboxSeperator : ThemeControl
    {
        private Orientation _Direction;
        public Orientation Direction
        {
            get { return _Direction; }
            set
            {
                _Direction = value;
                Invalidate();
            }
        }

        public override void PaintHook()
        {
            G.Clear(Color.LightGray);
            DrawGradient(Color.GhostWhite, Color.LightGray, 0, 0, Width, 5, 90);
            if (_Direction == Orientation.Horizontal)
            {
                G.DrawLine(new Pen(Color.FromArgb(190, 190, 190)), 0, Height / 2, Width, Height / 2);
                G.DrawLine(Pens.LightGray, 0, Height / 2 + 1, Width, Height / 2 + 1);
            }
            else
            {
                G.DrawLine(Pens.LightGray, Width / 2, 0, Width / 2, Height);
                G.DrawLine(new Pen(Color.FromArgb(190, 190, 190)), Width / 2 + 1, 0, Width / 2 + 1, Height);
                DrawGradient(Color.FromArgb(52, 18, 150), Color.FromArgb(32, 32, 32), 0, 0, Width, 10, 90);
            }
        }
    }

}


