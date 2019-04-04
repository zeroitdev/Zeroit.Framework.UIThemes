// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Image.cs" company="Zeroit Dev Technologies">
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
    public class NexusImage : ThemedControl
    {
        public Bitmap Image { get; set; }
        private ImageMode _ImageMode = ImageMode.Normal;
        public ImageMode ImageMode
        {
            get
            {
                return _ImageMode;
            }
            set
            {
                _ImageMode = value;
            }
        }
        public NexusImage() : base()
        {
            Font = new Font("Segoe UI", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(this.BackColor);

            //| Drawing the main BG (because VB won't do transperency)
            Rectangle MainRect = new Rectangle(0, 0, Width, Height);
            TextureBrush BGTextureBrush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            G.FillRectangle(BGTextureBrush, MainRect);
            G.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), MainRect);

            //| Drawing the image
            if (!((Image == null)))
            {
                if (ImageMode == ImageMode.Normal)
                {
                    G.DrawImage(Image, new Point(0, 0));
                }
                else
                {
                    G.DrawImage(Image, new Rectangle(0, 0, Width, Height));
                }
            }
        }
    }
}
