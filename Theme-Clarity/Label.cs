﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Clarity
{
    public class ClarityLabel : ThemeControl154
    {
        #region "Properties"
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            int textSize1 = 0;
            textSize = Convert.ToInt32(CreateGraphics().MeasureString(Text, Font).Width);
            textSize1 = Convert.ToInt32(this.CreateGraphics().MeasureString(Text, Font).Height);

            this.Width = 5 + textSize;
            this.Height = textSize1;
        }
        public ClarityLabel()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            this.Size = new Size(50, 16);

        }
        protected override void ColorHook()
        {
        }
        #endregion
        #region "Color Of Control"
        protected override void PaintHook()
        {
            G.Clear(BackColor);

            G.DrawString(Text, Font, new SolidBrush(Color.Black), new Point(1, 0));
            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, 255, 255)), new Point(1, 1));
        }
        #endregion
    }

}


