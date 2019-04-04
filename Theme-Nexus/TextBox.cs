// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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

    public class NexusTextbox : ThemedTextbox
    {
        public NexusTextbox() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = Pal.ColDark;
            BorderStyle = BorderStyle.None;
            Multiline = true;
            Font = new Font("Segoe UI", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            if (!Multiline)
            {
                Height = 21;
            }
            G.Clear(this.BackColor);
            Height = 20;

            //| Drawing the main BG (because VB won't do transperency)
            Rectangle MainRect = new Rectangle(0, 0, Width, Height);
            Rectangle MainRectHighlight = new Rectangle(1, 1, Width - 3, Height - 4);
            Rectangle MainRectBorderFill = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle MainRectBorderDraw = new Rectangle(0, 0, Width - 1, Height - 2);
            TextureBrush BGTextureBrush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            G.FillRectangle(BGTextureBrush, MainRect);
            G.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), MainRect);
            G.DrawRectangle(new Pen(Color.FromArgb(25, Color.WhiteSmoke)), MainRectHighlight);
            G.DrawRectangle(new Pen(Color.FromArgb(200, Color.Black)), MainRectBorderDraw);
            G.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.Black)), MainRectBorderFill);

            D.DrawTextWithShadow(G, new Rectangle(2, 0, Width, Height), Text, Font, HorizontalAlignment.Left, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }

}
