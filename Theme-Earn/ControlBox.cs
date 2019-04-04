// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Earn
{
    public class EarnControlBox : ThemeControl154
    {
        private int X;
        Color BG;
        Color Icons;

        SolidBrush glow;
        int a;
        int b;

        int c;
        protected override void ColorHook()
        {
            Icons = GetColor("Icon");
            BG = GetColor("Background");
            glow = GetBrush("Glow");
        }

        public EarnControlBox()
        {
            IsAnimated = true;
            SetColor("Icons", Color.FromArgb(240, 240, 240));
            SetColor("Icon", Color.FromArgb(240, 240, 240));
            SetColor("Background", Color.FromArgb(75, 77, 89));
            SetColor("Glow", Color.FromArgb(240, 240, 240));
            this.Size = new Size(44, 18);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (X <= 22)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Parent.FindForm().Close();
            }
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(75, 77, 89));
            G.DrawString("0", new Font("Marlett", 8.25f), GetBrush("Icon"), new Point(5, 4));
            G.DrawString("r", new Font("Marlett", 10), GetBrush("Icon"), new Point(24, 5));
        }
    }


}

