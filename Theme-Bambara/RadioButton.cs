// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class BambaraRadioButton : Control
    {
        private bool _check;
        public bool Checked
        {
            get { return _check; }
            set
            {
                _check = value;
                Invalidate();
            }
        }

        public BambaraRadioButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(180, 25);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (!Checked)
                Checked = true;
            foreach (BambaraRadioButton ctrl in Controls) /*from ctrl1 in Parent.Controls.OfType<BambaraRadioButton>() where ctrl1.Handle != Handlewhere ctrl1.Enabled)*/
            {
                ctrl.Checked = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle selectionrect = new Rectangle(3, 3, 18, 18);
            Rectangle innerselectionrect = new Rectangle(4, 4, 17, 17);
            Rectangle selectrect = new Rectangle(8, 8, 8, 8);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(BackColor);
            g.DrawString(Text, new Font("Segoe UI", 11, FontStyle.Regular), new SolidBrush(Color.FromArgb(245, 245, 245)), new Rectangle(25, 4, Width, 16), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            if (Checked)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), selectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(40, 37, 33)), innerselectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(246, 180, 12)), selectrect);
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), selectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(40, 37, 33)), innerselectionrect);
                g.FillEllipse(new SolidBrush(Color.FromArgb(20, 18, 17)), selectrect);
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
