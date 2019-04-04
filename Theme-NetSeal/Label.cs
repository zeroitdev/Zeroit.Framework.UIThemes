// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSLabel : Control
    {

        public NSLabel()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Segoe UI", 11.25f, FontStyle.Bold);

            B1 = new SolidBrush(Color.FromArgb(51, 181, 229));
        }

        private string _Value1 = "NET";
        public string Value1
        {
            get { return _Value1; }
            set
            {
                _Value1 = value;
                Invalidate();
            }
        }

        private string _Value2 = "SEAL";
        public string Value2
        {
            get { return _Value2; }
            set
            {
                _Value2 = value;
                Invalidate();
            }
        }


        private SolidBrush B1;
        private PointF PT1;
        private PointF PT2;
        private SizeF SZ1;

        private SizeF SZ2;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);

            SZ1 = G.MeasureString(Value1, Font, Width, StringFormat.GenericTypographic);
            SZ2 = G.MeasureString(Value2, Font, Width, StringFormat.GenericTypographic);

            PT1 = new PointF(0, Height / 2 - SZ1.Height / 2);
            PT2 = new PointF(SZ1.Width + 1, Height / 2 - SZ1.Height / 2);

            G.DrawString(Value1, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(Value1, Font, Brushes.WhiteSmoke, PT1);

            G.DrawString(Value2, Font, Brushes.Black, PT2.X + 1, PT2.Y + 1);
            G.DrawString(Value2, Font, B1, PT2);
        }

    }


}


