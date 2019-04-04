// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
    public class NexusRadiobutton : ThemedControl
    {
        public bool Checked { get; set; }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (Control Cont in Parent.Controls)
            {
                if (Cont is NexusRadiobutton)
                {
                    ((NexusRadiobutton)Cont).Checked = false;
                    Cont.Invalidate();
                }
            }
            Checked = true;
        }
        public NexusRadiobutton() : base()
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

            //| Stuff
            Rectangle CheckRect = new Rectangle(0, 0, Height - 1, Height - 1);
            Rectangle CheckRectHighlight = new Rectangle(1, 1, Height - 3, Height - 3);
            LinearGradientBrush DarkLGB = new LinearGradientBrush(CheckRect, Color.FromArgb(20, Color.Black), Color.FromArgb(100, Color.Black), 90);
            G.FillEllipse(DarkLGB, CheckRect);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.DrawEllipse(new Pen(Color.FromArgb(40, Pal.ColHighest)), CheckRectHighlight);
            G.DrawEllipse(Pens.Black, CheckRect);

            if (Checked)
            {
                Rectangle CheckRectChecked = new Rectangle(3, 3, Height - 7, Height - 7);
                G.FillEllipse(new SolidBrush(Color.FromArgb(100, Pal.ColHighest)), CheckRectChecked);
                G.DrawEllipse(new Pen(Color.FromArgb(140, Pal.ColHighest)), CheckRectChecked);
            }

            D.DrawTextWithShadow(G, new Rectangle(Height + 2, 0, Width, Height), Text, Font, HorizontalAlignment.Left, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }
}
