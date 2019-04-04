// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

using System.ComponentModel.Design;

namespace Zeroit.Framework.UIThemes.Ghost
{

    [Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", typeof(IDesigner))]
    public class GhostGroupBox : ThemeControl154
    {

        public GhostGroupBox() : base()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.ContainerControl, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(60, 60, 60));
            HatchBrush asdf = default(HatchBrush);
            asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
            asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
            G.FillRectangle(asdf, 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), 1, 1, Width - 2, this.CreateGraphics().MeasureString(Text, Font).Height + 8);

            G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), 1, this.CreateGraphics().MeasureString(Text, Font).Height + 8, Width - 2, this.CreateGraphics().MeasureString(Text, Font).Height + 8);

            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(90, 90, 90)), 1);
            G.DrawString(Text, Font, Brushes.White, 5, 5);
        }
    }
}
