// ***********************************************************************
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

namespace Zeroit.Framework.UIThemes.SpicyLips
{
    public class BlackTextBox : ThemeControl154
    {
        private TextBox withEventsField_Txt = new TextBox();
        private TextBox Txt
        {
            get { return withEventsField_Txt; }
            set
            {
                if (withEventsField_Txt != null)
                {
                    withEventsField_Txt.TextChanged -= TextBox_TextChanged;
                }
                withEventsField_Txt = value;
                if (withEventsField_Txt != null)
                {
                    withEventsField_Txt.TextChanged += TextBox_TextChanged;
                }
            }
        }
        public BlackTextBox()
        {
            TextChanged += PropertyTextChanged;
            Txt.TextAlign = HorizontalAlignment.Left;
            Txt.BorderStyle = BorderStyle.None;
            Txt.Location = new Point(2, 2);
            Controls.Add(Txt);
            Txt.Text = " ";
            Text = " ";
            Size = new Size(100, 20);
            LockHeight = 20;
        }
        protected override void ColorHook()
        {
            Txt.ForeColor = Color.White;
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(9, 9, 9));
            Txt.BackColor = Color.FromArgb(9, 9, 9);
            G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(Pens.Black, 1, 1, Width - 3, Height - 3);
            Txt.Size = new Size(this.Width - 4, Txt.Height - 4);
        }
        public void TextBox_TextChanged(object sender, EventArgs e)
        {
            Text = Txt.Text;
        }
        public void PropertyTextChanged(object sender, EventArgs e)
        {
            Txt.Text = Text;
        }
    }

}