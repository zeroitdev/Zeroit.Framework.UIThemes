// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusStrip.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireStatusStrip : ContainerControl
    {

        public TheEmpireStatusStrip()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Dock = DockStyle.Bottom;
            Height = 27;
        }


        Color EmpirePurple = Color.FromArgb(55, 173, 242);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);

            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(25, 25, 25), Color.FromArgb(36, 36, 36), 90f);
            e.Graphics.FillRectangle(LGB, LGB.Rectangle);
            e.Graphics.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(0, Height - 2, Width, 2));

            e.Graphics.DrawString(Text, new Font("Segoe UI", 9), Brushes.White, new Point(6, 4));
            base.OnPaint(e);
        }

    }


}