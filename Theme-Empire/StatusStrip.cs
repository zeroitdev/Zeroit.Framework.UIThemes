// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusStrip.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireStatusStrip : ContainerControl
    {

        public TheEmpireStatusStrip()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Dock = DockStyle.Bottom;
            Height = 27;
        }


        Color EmpirePurple = Color.FromArgb(55, 173, 242);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);

            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(25, 25, 25), Color.FromArgb(36, 36, 36), 90f);
            e.Graphics.FillRectangle(LGB, LGB.Rectangle);
            e.Graphics.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(0, Height - 2, Width, 2));

            e.Graphics.DrawString(Text, new Font("Segoe UI", 9), Brushes.White, new Point(6, 4));
            base.OnPaint(e);
        }

    }


}