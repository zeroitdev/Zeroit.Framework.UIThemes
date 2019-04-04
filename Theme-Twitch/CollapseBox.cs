// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CollapseBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchCollapseBox : ThemeContainer154
    {
        public bool twIsCollapsable { get; set; }
        int hgt;
        public TwitchCollapseBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Red);
            SetColor("Header", Color.Red);
            SetColor("Text", Color.Red);
            Cursor = Cursors.Hand;
            this.Click += BoxClicked;
            //BoxClicked;
            Size = new Size(245, 188);
            twIsCollapsable = true;
        }



        private void BoxClicked(object sender, EventArgs e)
        {
            if (twIsCollapsable == true)
            {
                if (this.Height > 25)
                {
                    hgt = this.Height;
                    foreach (Control ctrl in Controls)
                    {
                        ctrl.Visible = false;
                    }
                    this.Height = 25;
                }
                else
                {
                    this.Height = hgt;
                    foreach (Control ctrl in this.Controls)
                    {
                        ctrl.Visible = true;
                    }
                }
            }
        }

        Pen border;
        Brush headercolor;

        Brush textcolor;
        protected override void ColorHook()
        {
            border = GetPen("Border");
            headercolor = GetBrush("Header");
            textcolor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(0, 0, Width, Height));
            G.DrawLine(Pens.Black, 0, 0, Width, 0);
            DrawText(new SolidBrush(Color.FromArgb(87, 87, 87)), HorizontalAlignment.Left, 4, 0);
            G.DrawLine(Pens.Black, 0, Height, Width, Height);
            G.DrawLine(Pens.Black, 0, 24, Width, 24);
            if (twIsCollapsable == true)
            {
                foreach (Control ctrl in Controls)
                {
                    if (ctrl.Visible == false)
                    {
                        G.DrawString("v", Font, new SolidBrush(Color.FromArgb(87, 87, 87)), Width - 20, 6);
                    }
                    else
                    {
                        G.DrawString("^", Font, new SolidBrush(Color.FromArgb(87, 87, 87)), Width - 20, 8);
                    }
                }
            }
        }
    }

}

