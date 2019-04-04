// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Metro
{
    public class MetroUIGroup : ThemeContainer154
    {

        public MetroUIGroup()
        {
            ControlMode = true;

            SetColor("background", Color.FromArgb(53, 157, 181));
            SetColor("inside", Color.White);
            SetColor("txt", Color.White);
        }

        Color bg;
        Color inside;
        Brush txt;
        protected override void ColorHook()
        {
            bg = GetColor("background");
            inside = GetColor("inside");
            txt = GetBrush("txt");
        }

        protected override void PaintHook()
        {
            G.Clear(bg);
            G.FillRectangle(new SolidBrush(inside), new Rectangle(1, 25, Width - 2, Height - 26));
            DrawText(txt, HorizontalAlignment.Left, 2, 0);
        }
    }
    
}


