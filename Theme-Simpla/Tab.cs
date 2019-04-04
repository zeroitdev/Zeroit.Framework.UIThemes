// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Simpla
{

    public class SimplaTabControl : TabControl
    {

        private Color mainBackground;
        private Color topBackground;

        private Color activeTabColor;
        public enum ColorSchemes
        {
            DarkGray,
            Green,
            Blue,
            White,
            Red
        }
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }
        private Color _textColor;
        public SimplaTabControl() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            BackColor = Color.FromArgb(34, 34, 34);
            topBackground = Color.FromArgb(34, 34, 34);
            mainBackground = Color.FromArgb(34, 34, 34);
            ForeColor = Color.White;
            _textColor = ForeColor;
            activeTabColor = Color.FromArgb(20, 20, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);

            try
            {
                SelectedTab.BackColor = mainBackground;
            }
            catch
            {
            }

            G.Clear(topBackground);
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (ColorScheme)
            {
                case ColorSchemes.DarkGray:
                    activeTabColor = Color.FromArgb(10, 10, 10);
                    _textColor = Color.White;
                    break;
                case ColorSchemes.Green:
                    activeTabColor = Color.FromArgb(94, 165, 1);
                    _textColor = Color.White;
                    break;
                case ColorSchemes.Blue:
                    activeTabColor = Color.FromArgb(0, 97, 166);
                    _textColor = Color.White;
                    break;
                case ColorSchemes.White:
                    activeTabColor = Color.FromArgb(245, 245, 245);
                    _textColor = Color.FromArgb(36, 36, 36);
                    break;
                case ColorSchemes.Red:
                    activeTabColor = Color.FromArgb(170, 0, 0);
                    _textColor = Color.White;
                    break;
            }

            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                Rectangle TabRect = new Rectangle(GetTabRect(i).X + 3, GetTabRect(i).Y, GetTabRect(i).Width - 5, GetTabRect(i).Height);
                G.FillRectangle(new SolidBrush(mainBackground), TabRect);
                G.DrawString(TabPages[i].Text, new Font("Tahoma", 9, FontStyle.Bold), new SolidBrush(ForeColor), TabRect, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }

            G.FillRectangle(new SolidBrush(mainBackground), 0, ItemSize.Height, Width, Height);

            if (!(SelectedIndex == -1))
            {
                Rectangle TabRect = new Rectangle(GetTabRect(SelectedIndex).X + 3, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width - 5, GetTabRect(SelectedIndex).Height);
                G.FillPath(new SolidBrush(activeTabColor), Draw.RoundRect(TabRect, 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(TabRect, 4));
                G.DrawString(TabPages[SelectedIndex].Text, new Font("Tahoma", 9, FontStyle.Bold), new SolidBrush(_textColor), TabRect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage(B, new Point(0, 0));
            G.Dispose();
            B.Dispose();
        }
    }

}

