﻿// ***********************************************************************
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  GroupBox 

    public class iTalkGroupBox : ContainerControl
    {
        public iTalkGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true; // Reduce control flicker
            this.Size = new Size(212, 104);
            this.MinimumSize = new Size(136, 50);
            this.Padding = new Padding(5, 28, 5, 5); // Set padding so controls won't overlay when full-docked
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TitleBox = new Rectangle(51, 3, Width - 103, 18);
            Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality; // Specifies antialiased rendering

            // Draw the body of the GroupBox
            G.FillPath(Brushes.White, RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), 8));
            // Draw the border of the GroupBox
            G.DrawPath(new Pen(Color.FromArgb(159, 159, 161)), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), 8));

            // Draw the background of the title box
            G.FillPath(Brushes.White, RoundRectangle.RoundRect(TitleBox, 1));
            // Draw the border of the title box
            G.DrawPath(new Pen(Color.FromArgb(182, 180, 186)), RoundRectangle.RoundRect(TitleBox, 4));
            // Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, new Font("Tahoma", 9F, FontStyle.Regular), new SolidBrush(Color.FromArgb(53, 53, 53)), TitleBox, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}