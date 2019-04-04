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
using System;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInTabControl : TabControl
    {

        #region "Declarations"

        private Color _TextColour = Color.FromArgb(255, 255, 255);
        private Color _BackTabColour = Color.FromArgb(54, 54, 54);
        private Color _BaseColour = Color.FromArgb(35, 35, 35);
        private Color _ActiveColour = Color.FromArgb(47, 47, 47);
        private Color _BorderColour = Color.FromArgb(30, 30, 30);
        private Color _UpLineColour = Color.FromArgb(0, 160, 199);
        private Color _HorizLineColour = Color.FromArgb(23, 119, 151);
        private StringFormat CenterSF = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center

        };
        #endregion

        #region "Properties"

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color UpLineColour
        {
            get { return _UpLineColour; }
            set { _UpLineColour = value; }
        }

        [Category("Colours")]
        public Color HorizontalLineColour
        {
            get { return _HorizLineColour; }
            set { _HorizLineColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Colours")]
        public Color BackTabColour
        {
            get { return _BackTabColour; }
            set { _BackTabColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color ActiveColour
        {
            get { return _ActiveColour; }
            set { _ActiveColour = value; }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        #endregion

        #region "Draw Control"

        public LogInTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(240, 32);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with26 = g;
            _with26.SmoothingMode = SmoothingMode.HighQuality;
            _with26.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with26.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with26.Clear(_BaseColour);
            try
            {
                SelectedTab.BackColor = _BackTabColour;
            }
            catch
            {
            }
            try
            {
                SelectedTab.BorderStyle = BorderStyle.FixedSingle;
            }
            catch
            {
            }
            _with26.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle Base = new Rectangle(new Point(GetTabRect(i).Location.X, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                Rectangle BaseSize = new Rectangle(Base.Location, new Size(Base.Width, Base.Height));
                if (i == SelectedIndex)
                {
                    _with26.FillRectangle(new SolidBrush(_BaseColour), BaseSize);
                    _with26.FillRectangle(new SolidBrush(_ActiveColour), new Rectangle(Base.X + 1, Base.Y - 3, Base.Width, Base.Height + 5));
                    _with26.DrawString(TabPages[i].Text, Font, new SolidBrush(_TextColour), new Rectangle(Base.X + 7, Base.Y, Base.Width - 3, Base.Height), CenterSF);
                    _with26.DrawLine(new Pen(_HorizLineColour, 2), new Point(Base.X + 3, Convert.ToInt32(Base.Height / 2 + 2)), new Point(Base.X + 9, Convert.ToInt32(Base.Height / 2 + 2)));
                    _with26.DrawLine(new Pen(_UpLineColour, 2), new Point(Base.X + 3, Base.Y - 3), new Point(Base.X + 3, Base.Height + 5));
                }
                else
                {
                    _with26.DrawString(TabPages[i].Text, Font, new SolidBrush(_TextColour), BaseSize, CenterSF);
                }
            }
            _with26.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


