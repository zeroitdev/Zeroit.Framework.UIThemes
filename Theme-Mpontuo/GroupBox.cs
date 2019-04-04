// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoGroupbox : ThemeContainerControl
    {
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(40, 40, 40));
            DrawGradient(Color.FromArgb(65, 65, 65), Color.FromArgb(42, 42, 42), 0, 0, Width, 15, 90);
            G.DrawRectangle(new Pen(Color.FromArgb(65, 65, 65)), 0, 0, Width - 1, Height - 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), Width - 1, 0, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, Height - 1, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), Width - 1, Height - 1, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, 0, 1, 1);
            G.DrawString(Text, Parent.Font, new SolidBrush(Parent.ForeColor), 5, 1);
            BackColor = Color.FromArgb(40, 40, 40);
        }
    }
}

