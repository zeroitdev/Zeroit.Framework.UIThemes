// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="AlertBox.cs" company="Zeroit Dev Technologies">
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

    public class BambaraAlertBox : Control
    {
        private System.Windows.Forms.Timer withEventsField__mytimer;
        public System.Windows.Forms.Timer _mytimer
        {
            get { return withEventsField__mytimer; }
            set
            {
                if (withEventsField__mytimer != null)
                {
                    withEventsField__mytimer.Tick -= MyTimer_Tick;
                }
                withEventsField__mytimer = value;
                if (withEventsField__mytimer != null)
                {
                    withEventsField__mytimer.Tick += MyTimer_Tick;
                }
            }

        }
        public enum AlertStyle
        {
            Info,
            Success,
            Error
        }

        private AlertStyle _style;
        public AlertStyle Style
        {
            get { return _style; }
            set { _style = value; }
        }

        private string _text;
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (_text != null)
                {
                    _text = value;
                }
            }
        }

        public new bool Visible
        {
            get { return base.Visible == false; }
            set { base.Visible = value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public void ShowAlertBox(AlertStyle mystyle, string str, int interval)
        {
            _style = mystyle;
            Text = str;
            Visible = true;
            _mytimer.Interval = interval;
            _mytimer.Enabled = true;
        }

        public BambaraAlertBox()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(450, 30);
            DoubleBuffered = true;
            _mytimer = new Timer();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle textrect = new Rectangle(20, 10, Width - 21, Height - 21);
            Rectangle logorect = new Rectangle(7, 7, 20, 20);
            Rectangle logocirclerect = new Rectangle(5, 5, 20, 20);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            base.OnPaint(e);
            switch (_style)
            {
                case AlertStyle.Success:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, 0, 255, 0)), rect);
                    g.DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), rect);
                    g.DrawString(Text, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), textrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    g.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(Color.FromArgb(255, 255, 255)), logorect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case AlertStyle.Error:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, 255, 0, 0)), rect);
                    g.DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), rect);
                    g.DrawString(Text, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), textrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    g.DrawString("r", new Font("Marlett", 10), new SolidBrush(Color.FromArgb(255, 255, 255)), logorect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case AlertStyle.Info:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, 0, 0, 255)), rect);
                    g.DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), rect);
                    g.DrawString(Text, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), textrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    g.DrawString("i", new Font("Segoe UI", 12), new SolidBrush(Color.FromArgb(255, 255, 255)), logorect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
            g.DrawEllipse(new Pen(Color.FromArgb(255, 255, 255)), logocirclerect);
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Visible = false;
            _mytimer.Enabled = false;
        }
    }

}
