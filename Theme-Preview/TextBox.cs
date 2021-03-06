﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVTextbox : ThemedTextbox
    {
        private Color _BorderColor;
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
            }
        }
        private Color _InteriorColor = Color.FromArgb(150, Color.WhiteSmoke);
        public Color InteriorColor
        {
            get
            {
                return _InteriorColor;
            }
            set
            {
                _InteriorColor = value;
            }
        }
        public PVTextbox() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            _BorderColor = Color.FromArgb(200, Pal.ColHighest);
            BackColor = Pal.ColDark;
            BorderStyle = BorderStyle.None;
            Multiline = true;
            Font = new Font("Trebuchet MS", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            if (!Multiline)
            {
                Height = 21;
            }

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle BorderRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle BorderInnerRect = new Rectangle(1, 1, Width - 3, Height - 3);
            Rectangle ButtonRect = new Rectangle(5, 5, Width - 11, Height - 11);


            //| Drawing the textbox
            GraphicsPath Out1Path = D.RoundRect(BorderRect, 3);
            GraphicsPath Out2Path = D.RoundRect(BorderInnerRect, 5);
            LinearGradientBrush Out2LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), BorderInnerRect);
            G.DrawPath(new Pen(Out2LGB, 3F), Out2Path);
            G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), Out1Path);


            //My D.drawText method seemed to cause issues.
            G.DrawString(Text, Font, new SolidBrush(InteriorColor), new Point(3, 2));
        }
    }
}
