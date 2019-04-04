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

namespace Zeroit.Framework.UIThemes.SimpleGray
{
    public class SimplyGraySeperator : ThemeControl
    {

        private Color _Color1 = Color.DarkGray;
        public Color Color1
        {
            get { return _Color1; }
            set { _Color1 = value; }
        }

        private Color _Color2 = Color.FromArgb(50, 50, 50);
        public Color Color2
        {
            get { return _Color2; }
            set { _Color2 = value; }
        }

        public SimplyGraySeperator()
        {
            AllowTransparent();
            BackColor = Color.Transparent;
            Size S = new Size(150, 10);
            Size = S;
        }

        Color Gr = Color.Gray;
        Color DGr = Color.DarkGray;
        Color T = Color.Transparent;

        Pen PDGr = Pens.DarkGray;
        public override void PaintHook()
        {
            G.Clear(Gr);

            G.DrawLine(new Pen(_Color1), 0, Height / 2, Width, Height / 2);
            G.DrawLine(new Pen(_Color2), 0, Height / 2 + 1, Width, Height / 2 + 1);
        }
    }

}

