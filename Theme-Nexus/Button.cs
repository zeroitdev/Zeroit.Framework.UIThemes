// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
    public class NexusButton : ThemedControl
    {
        public Color OverlayCol { get; set; }
        public bool DrawSeparator { get; set; }
        public NexusButton() : base()
        {
            Font = new Font("Segoe UI", 11.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(this.BackColor);

            //| Drawing the main rectangle base.
            Rectangle MainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle MainHighlightRect = new Rectangle(1, 1, Width - 3, Height - 3);
            TextureBrush BGTextureBrush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            G.FillRectangle(BGTextureBrush, MainRect);

            if (OverlayCol != null)
            {
                G.FillRectangle(new SolidBrush(OverlayCol), MainRect);
            }


            //| Detail to the main rect's top & bottom gradients
            var GradientHeight = Height / 2;
            Rectangle ShineRect = new Rectangle(0, 0, Width, GradientHeight);
            Rectangle ShineRect2 = new Rectangle(0, GradientHeight, Width, GradientHeight);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Pal.ColMed)), ShineRect);
            D.FillGradientBeam(G, Color.Transparent, Color.FromArgb(60, Pal.ColHighest), ShineRect, GradientAlignment.Vertical);
            D.FillGradientBeam(G, Color.Transparent, Color.FromArgb(30, Pal.ColHighest), ShineRect2, GradientAlignment.Vertical);
            if (DrawSeparator)
            {
                G.DrawLine(new Pen(Color.FromArgb(50, Color.Black)), new Point(1, ShineRect.Height), new Point(Width - 2, ShineRect.Height));
                G.DrawLine(new Pen(Color.FromArgb(35, Pal.ColHighest)), new Point(1, ShineRect.Height + 1), new Point(Width - 2, ShineRect.Height + 1));
                G.DrawLine(new Pen(Color.FromArgb(50, Color.Black)), new Point(1, ShineRect.Height + 2), new Point(Width - 2, ShineRect.Height + 2));
            }

            //| Goind back through and making the rect below the detail darker
            LinearGradientBrush DarkLGB = new LinearGradientBrush(MainRect, Color.FromArgb(20, Color.Black), Color.FromArgb(100, Color.Black), 90);
            G.FillRectangle(DarkLGB, MainRect);

            switch (State)
            {
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(30, Pal.ColHighest)), MainRect);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(56, Color.Black)), MainRect);
                    break;
            }

            G.DrawRectangle(new Pen(Color.FromArgb(40, Pal.ColHighest)), MainHighlightRect);
            G.DrawRectangle(Pens.Black, MainRect);
            D.DrawTextWithShadow(G, new Rectangle(0, 0, Width, Height), Text, Font, HorizontalAlignment.Center, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }
}
