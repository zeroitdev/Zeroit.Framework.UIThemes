// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-22-2018
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Zeroit.Framework.UIThemes.Advantium
{
    
//Theme
    [ToolboxItem(false)]
    public class AdvantiumTheme : ThemeContainer154
    {

        public AdvantiumTheme()
        {
            TransparencyKey = Color.Fuchsia;
            //MoveHeight = 35;

            SetColor("BackColor", Color.FromArgb(40, 40, 40));
            SetColor("BorderInner", Color.FromArgb(65, 65, 65));
            SetColor("BorderColor", Color.Black);
            SetColor("TextColor", Color.LawnGreen);
        }


        Color C1;
        Color BC;
        Color BA;
        Color T1;
        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            BC = GetColor("BorderColor");
            BA = GetColor("BorderInner");
            T1 = GetColor("TextColor");
        }


        protected override void PaintHook()
        {
            G.Clear(C1);
            DrawGradient(Color.FromArgb(20, 20, 20), Color.FromArgb(40, 40, 40), new Rectangle(0, 0, Width, 35), 90);

            HatchBrush T = new HatchBrush(HatchStyle.Percent10, Color.FromArgb(25, 25, 25), Color.FromArgb(35, 35, 35));
            G.FillRectangle(T, new Rectangle(11, 25, Width - 23, Height - 36));

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(22, 22, 22))), new Rectangle(11, 25, Width - 23, Height - 36));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(40, 40, 40))), new Rectangle(12, 26, Width - 25, Height - 38));
            DrawCorners(Color.FromArgb(40, 40, 40), new Rectangle(11, 25, Width - 22, Height - 35));

            DrawBorders(new Pen(new SolidBrush(BA)), 1);
            DrawBorders(new Pen(new SolidBrush(BC)));
            DrawCorners(TransparencyKey);
            DrawText(new SolidBrush(T1), HorizontalAlignment.Left, 15, -3);
        }
    }

}