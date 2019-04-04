// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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