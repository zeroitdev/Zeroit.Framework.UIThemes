// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Panel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Newer
{

    public class ImaginePanel : ThemeContainer154
    {

        Color BG;
        public ImaginePanel()
        {
            ControlMode = true;
            SetColor("BG", 12, 27, 74);
            BackColor = GetColor("BG");
        }
        protected override void ColorHook()
        {
            BG = GetColor("BG");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            DrawBorders(Pens.Black);
        }
    }

}

