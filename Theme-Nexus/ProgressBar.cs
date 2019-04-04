// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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
    public class NexusProgressBar : ThemedControl
    {
        //| The original user who asked for the theme wanted Vibelander's prog bar. 
        //| So credits to UnReLaTeD for the basic progress bar design!
        private int PValue = 50;
        public int Value
        {
            get
            {
                return PValue;
            }
            set
            {
                PValue = value;
                Invalidate();
            }
        }
        public int Minimum { get; set; }
        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
            }
        }
        public NexusProgressBar() : base()
        {
            Font = new Font("Segoe UI", 11.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(this.BackColor);
            Height = 24;

            Rectangle BarRect = new Rectangle(2, 2, Convert.ToInt32(ValueToPercentage(PValue) * Width - 5), Height - 5);
            int Val = Convert.ToInt32(ValueToPercentage(PValue) * Width - 5);

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

            //| The progress bar
            LinearGradientBrush ProgressLGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(100, 51, 159, 231), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
            Rectangle ProgressPath = new Rectangle(1, 1, Val + 2, Height - 4);
            Rectangle ProgressPathSmall = new Rectangle(3, 3, Val, Height / 2 - 3);
            if (Val > 1)
            {
                TextureBrush BlueTextureBrush = new TextureBrush(D.CodeToImage(D.BlueTexture), WrapMode.TileFlipXY);
                G.FillRectangle(BlueTextureBrush, ProgressPath);
                G.FillRectangle(ProgressLGB, ProgressPath);
            }
            if (Val > 1)
            {
                G.DrawLine(new Pen(Color.FromArgb(130, 131, 197, 241)), new Point(4, 3), new Point(Val, 3));
                D.FillGradientBeam(G, Color.Transparent, Color.FromArgb(60, Color.White), new Rectangle(3, 3, Val, Height / 2 - 3), GradientAlignment.Vertical);
                G.DrawRectangle(new Pen(Color.FromArgb(12, 33, 55), 1F), new Rectangle(1, 1, Val + 2, Height - 4));
            }
        }
        private float ValueToPercentage(int val)
        {
            var min = Minimum;
            var max = Maximum;
            return (val - min) / (max - min);
        }
    }
}
