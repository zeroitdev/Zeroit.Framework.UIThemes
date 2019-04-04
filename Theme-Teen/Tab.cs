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

namespace Zeroit.Framework.UIThemes.Thirteen
{
    public class ThirteenTabControl : TabControl
    {
        private Color _AccentColor;
        public Color AccentColor
        {
            get { return _AccentColor; }
            set
            {
                _AccentColor = value;
                Invalidate();
            }
        }

        private Color MainColor;
        private Color ClearColor;
        public enum ColorSchemes
        {
            Light,
            Dark
        }
        public event ColorSchemeChangedEventHandler ColorSchemeChanged;
        public delegate void ColorSchemeChangedEventHandler();
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                if (ColorSchemeChanged != null)
                {
                    ColorSchemeChanged();
                }
            }
        }
        protected void OnColorSchemeChanged()
        {
            Invalidate();
            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    ClearColor = Color.FromArgb(50, 50, 50);
                    MainColor = Color.FromArgb(35, 35, 35);
                    ForeColor = Color.White;
                    break;
                case ColorSchemes.Light:
                    ClearColor = Color.White;
                    MainColor = Color.FromArgb(200, 200, 200);
                    ForeColor = Color.Black;
                    break;
            }
        }
        public ThirteenTabControl() : base()
        {
            ColorSchemeChanged += OnColorSchemeChanged;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
            AccentColor = Color.DodgerBlue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            try
            {
                SelectedTab.BackColor = MainColor;
            }
            catch
            {
            }
            G.Clear(ClearColor);

            for (int i = 0; i <= TabPages.Count - 1; i++)
            {
                //If Not i = SelectedIndex Then
                Rectangle TabRect = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 2, GetTabRect(i).Height);
                G.FillRectangle(new SolidBrush(MainColor), TabRect);
                G.DrawString(TabPages[i].Text, new Font("Segoe UI Semilight", 9.75f), new SolidBrush(ForeColor), TabRect, new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
                //End If
            }

            G.FillRectangle(new SolidBrush(MainColor), 0, ItemSize.Height, Width, Height);

            if (!(SelectedIndex == -1))
            {
                Rectangle TabRect = new Rectangle(GetTabRect(SelectedIndex).X - 2, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width + 4, GetTabRect(SelectedIndex).Height);
                G.FillRectangle(new SolidBrush(AccentColor), TabRect);
                G.DrawString(TabPages[SelectedIndex].Text, new Font("Segoe UI Semilight", 9.75f), new SolidBrush(ForeColor), TabRect, new StringFormat
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

