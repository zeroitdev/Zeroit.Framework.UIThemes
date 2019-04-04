// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireGroupBox : ContainerControl
    {

        public TheEmpireGroupBox()
        {
            Font = new Font("Segoe UI", 9);
            ForeColor = Color.Black;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }


        Color EmpirePurple = Color.FromArgb(55, 173, 242);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(13, 19, (int)e.Graphics.MeasureString(Text, new Font("Segoe UI", 10)).Width + 2, 4));
            e.Graphics.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(0, 23, Width, 2));

            e.Graphics.DrawString(Text, new Font("Segoe UI", 10), Brushes.Black, new Point(16, 0));

            base.OnPaint(e);
        }

    }


}