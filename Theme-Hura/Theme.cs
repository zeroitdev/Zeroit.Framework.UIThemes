// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Hura
{

    class HuraModule
    {

        #region " G"
        public Graphics G;
        #endregion
        public Bitmap B;


        public HuraModule()
        {
            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);
        }

        public Bitmap TextBitmap;

        public Graphics TextGraphics;
        public SizeF MeasureString(string text, Font font)
        {
            return TextGraphics.MeasureString(text, font);
        }

        public SizeF MeasureString(string text, Font font, int width)
        {
            return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic);
        }

        public GraphicsPath CreateRoundPath;

        public Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

    }
    
    
}


