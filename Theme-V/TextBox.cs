﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.V
{
    public class VTextBox : ThemeControl154
    {
        private TextBox withEventsField_Txt = new TextBox();
        public TextBox Txt
        {
            get { return withEventsField_Txt; }
            set
            {
                if (withEventsField_Txt != null)
                {
                    withEventsField_Txt.TextChanged -= TextChngTxtBox;
                }
                withEventsField_Txt = value;
                if (withEventsField_Txt != null)
                {
                    withEventsField_Txt.TextChanged += TextChngTxtBox;
                }
            }

        }
        private bool _Mulitline;
        public bool Multiline
        {
            get { return _Mulitline; }
            set { _Mulitline = value; }
        }
        private bool _PassMask;
        public bool UsePasswordMask
        {
            get { return _PassMask; }
            set
            {
                _PassMask = value;
                Txt.UseSystemPasswordChar = value;
            }
        }
        private int _maxchars;
        public int MaxCharacters
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                Txt.MaxLength = value;
            }
        }


        public VTextBox()
        {
            TextChanged += TextChng;
            Txt.TextAlign = HorizontalAlignment.Left;
            Txt.BorderStyle = BorderStyle.None;
            Txt.Location = new Point(10, 6);
            Txt.Font = new Font("Verdana", 8);
            Controls.Add(Txt);
            Text = "";
            Txt.Text = "";
            Size = new Size(150, 25);
        }

        protected override void ColorHook()
        {
            Txt.ForeColor = Color.White;
            Txt.BackColor = Color.FromArgb(15, 15, 15);
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(15, 15, 15));
            Txt.Size = new Size(Width - 20, Height - 10);
            switch (Multiline)
            {
                case true:
                    Size = new Size(Width, Height);
                    break;
                case false:
                    Size = new Size(Width, 25);
                    break;
            }

            G.FillRectangle(new SolidBrush(Color.FromArgb(15, 15, 15)), new Rectangle(1, 1, Width - 2, Height - 2));
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(32, 32, 32))), 1);
            DrawBorders(new Pen(new SolidBrush(Color.Black)));
            DrawCorners(Color.FromArgb(15, 15, 15));
            DrawCorners(Color.FromArgb(15, 15, 15), new Rectangle(1, 1, Width - 2, Height - 2));
        }
        public void TextChngTxtBox(object sender, EventArgs e)
        {
            Text = Txt.Text;
        }
        public void TextChng(object sender, EventArgs e)
        {
            Txt.Text = Text;
        }
    }
}




