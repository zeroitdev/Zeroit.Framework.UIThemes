// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Empire (Tasty) Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Form.UIThemes.Empire
{

    public class TheEmpireThemeContainer : ContainerControl
    {

        public TheEmpireThemeContainer()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
            Dock = DockStyle.Fill;
        }


        Color EmpirePurple = Color.FromArgb(55, 173, 242);
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.Clear(Color.FromArgb(200, 200, 200));

            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width, 37), Color.FromArgb(36, 36, 36), Color.FromArgb(25, 25, 25), 90f);
            G.FillRectangle(LGB, LGB.Rectangle);
            //LGB = New LinearGradientBrush(New Rectangle(0, 41, Width, 4), Color.FromArgb(80, Color.Black), Color.Transparent, 90.0F)
            //e.Graphics.FillRectangle(LGB, LGB.Rectangle)

            G.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(13, 31, (int)G.MeasureString(Text, new Font("Segoe UI", 11)).Width + 6, 4));
            G.FillRectangle(new SolidBrush(EmpirePurple), new Rectangle(0, 35, Width, 2));

            G.DrawString(Text, new Font("Segoe UI", 11), Brushes.Black, new Point(15, 9));
            G.DrawString(Text, new Font("Segoe UI", 11), Brushes.White, new Point(15, 8));

            base.OnPaint(e);
        }

    }

    

}