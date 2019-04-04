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

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVRadiobutton : ThemedControl
    {
        public bool Checked { get; set; }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (Control Cont in Parent.Controls)
            {
                if (Cont is PVRadiobutton)
                {
                    ((PVRadiobutton)Cont).Checked = false;
                    Cont.Invalidate();
                }
            }
            Checked = true;
        }
        public PVRadiobutton() : base()
        {
            Font = new Font("Trebuchet MS", 10.0F);
            BackColor = Color.FromArgb(21, 23, 25);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = this.Parent.BackColor;
            }
            catch (Exception ex)
            {
            }
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            Height = 20;
            Rectangle x = new Rectangle(0, 0, Height - 2, Height - 2);
            Rectangle x2 = new Rectangle(0, 1, Height - 2, Height - 2);


            G.DrawEllipse(new Pen(Pal.ColHigh), x2);
            G.FillEllipse(new SolidBrush(Pal.ColDark), x);
            G.DrawEllipse(new Pen(Color.FromArgb(200, Color.Black)), x);

            if (Checked)
            {
                Rectangle x3 = new Rectangle(3, 3, Height - 8, Height - 8);
                G.FillEllipse(new SolidBrush(Pal.ColHighest), x3);
            }

            D.DrawTextWithShadow(G, new Rectangle(Height, 0, Width, Height - 4), Text, Font, HorizontalAlignment.Left, Pal.ColHighest, Color.Black);

        }
    }
}
