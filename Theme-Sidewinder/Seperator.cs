﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderSeparator : Control
    {

        #region " Drawing "


        private Graphics G;
        public SideWinderSeparator()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            using (Pen P = new Pen(Color.FromArgb(232, 235, 242)) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                G.DrawLine(P, new Point(0, 0), new Point(Width, 0));
            }

        }

        #endregion

    }

}