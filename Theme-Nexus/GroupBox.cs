// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
    public class NexusGroupbox : ThemedContainer
    {
        private HorizontalAlignment _TextAlignment = HorizontalAlignment.Center;
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                _TextAlignment = value;
            }
        }

        private int _TextYOffset = 2;
        public int TextYOffset
        {
            get
            {
                return _TextYOffset;
            }
            set
            {
                _TextYOffset = value;
            }
        }
        public NexusGroupbox() : base()
        {
            MinimumSize = new Size(10, 10);
            TopGrip = 20;
            Font = new Font("Segoe UI", 10.0F);
            BackColor = Color.FromArgb(21, 23, 25);
            ForeColor = Color.FromArgb(160, Color.White);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            try
            {
                this.ParentForm.TransparencyKey = Color.Fuchsia;
                this.ParentForm.MinimumSize = MinimumSize;
                if (!(this.ParentForm.FormBorderStyle == FormBorderStyle.None))
                {
                    this.ParentForm.FormBorderStyle = FormBorderStyle.None;
                }
            }
            catch (Exception ex)
            {
            }
            G.Clear(this.ParentForm.TransparencyKey);

            //| Drawing the main rectangle base.
            Rectangle MainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle MainHighlightRect = new Rectangle(1, 1, Width - 3, Height - 3);
            TextureBrush BGTextureBrush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);

            Bitmap Logo = (Bitmap)D.CodeToImage(D.LogoTexture);

            G.FillRectangle(BGTextureBrush, MainRect);
            G.DrawRectangle(new Pen(Color.FromArgb(40, Pal.ColHighest)), MainHighlightRect);
            G.DrawRectangle(Pens.Black, MainRect);



            //| Detail to the main rect's top grip
            Rectangle ShineRect = new Rectangle(0, 0, Width, TopGrip);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Pal.ColMed)), ShineRect);
            LinearGradientBrush SubShineLGB1 = new LinearGradientBrush(ShineRect, Color.Black, Color.Black, 0F, false);
            LinearGradientBrush SubShineLGB2 = new LinearGradientBrush(ShineRect, Color.Black, Color.Black, 0F, false);
            ColorBlend Blend = new ColorBlend();
            Blend.Positions = new[] { 0, 1f / 3.0f, 2f / 3.0f, 1 };
            Blend.Colors = new[] { Color.FromArgb(50, Color.Black), Color.FromArgb(150, Color.Black), Color.FromArgb(50, Color.Black), Color.Transparent };
            SubShineLGB1.InterpolationColors = Blend;
            SubShineLGB1.RotateTransform(45F);
            Blend.Colors = new[] { Color.FromArgb(50, Pal.ColHighest), Color.FromArgb(150, Pal.ColHighest), Color.FromArgb(50, Pal.ColHighest), Color.Transparent };
            SubShineLGB2.InterpolationColors = Blend;
            SubShineLGB2.RotateTransform(45F);
            D.FillGradientBeam(G, Color.Transparent, Color.FromArgb(80, Pal.ColHighest), ShineRect, GradientAlignment.Vertical);
            G.DrawLine(new Pen(SubShineLGB1), new Point(1, ShineRect.Height), new Point(Width - 2, ShineRect.Height));
            G.DrawLine(new Pen(SubShineLGB2), new Point(1, ShineRect.Height + 1), new Point(Width - 2, ShineRect.Height + 1));

            //| Goind back through and making the rect below the detail darker
            Rectangle DarkRect = new Rectangle(0, ShineRect.Height, Width - 1, Height - 1 - ShineRect.Height);
            LinearGradientBrush DarkLGB = new LinearGradientBrush(DarkRect, Color.FromArgb(20, Color.Black), Color.FromArgb(100, Color.Black), 90);
            G.FillRectangle(DarkLGB, DarkRect);

            //G.DrawImage(Logo, New Point((Width / 2) - (Logo.Width / 1.52), 0))
            D.DrawTextWithShadow(G, new Rectangle(0, 0, Width, TopGrip + TextYOffset), Text, Font, TextAlignment, ForeColor, Color.Black);


            //| The inner and slightly brigher rectangle of the form
            Rectangle InnerRect = new Rectangle(5, TopGrip, Width - 11, Height - 6 - TopGrip);
            Rectangle InnerHighlightRect = new Rectangle(6, TopGrip + 1, Width - 13, Height - 8 - TopGrip);
            G.FillRectangle(BGTextureBrush, InnerRect);
            G.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), InnerRect);
            G.DrawRectangle(new Pen(Color.FromArgb(40, Pal.ColHighest)), InnerHighlightRect);
            G.DrawRectangle(Pens.Black, InnerRect);
        }
    }
}
