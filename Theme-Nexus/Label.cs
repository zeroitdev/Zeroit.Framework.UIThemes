// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Nexus
{
    public class NexusLabel : ThemedControl
    {
        public NexusLabel() : base()
        {
            Font = new Font("Segoe UI", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(this.BackColor);
            Height = 20;

            //| Drawing the main BG (because VB won't do transperency)
            Rectangle MainRect = new Rectangle(0, 0, Width, Height);
            TextureBrush BGTextureBrush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            G.FillRectangle(BGTextureBrush, MainRect);
            G.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), MainRect);
            D.DrawTextWithShadow(G, new Rectangle(0, 0, Width, Height), Text, Font, HorizontalAlignment.Left, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }

}
