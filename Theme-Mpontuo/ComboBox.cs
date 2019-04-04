// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoComboBox : ComboBox
    {
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        private int _StartIndex = 0;
        public int StartIndex
        {
            get
            {
                return _StartIndex;
            }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }
        public void ReplaceItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), e.Bounds); //37 37 37
                }
                using (SolidBrush b = new SolidBrush(Color.FromArgb(66, 130, 181)))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, e.Bounds);
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
        }

        public MpontuoComboBox() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = Color.FromArgb(66, 130, 181);
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Invalidate();
            SubscribeToEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            LinearGradientBrush T = new LinearGradientBrush(new Rectangle(0, 0, Width, 20), Color.FromArgb(50, 50, 50), Color.FromArgb(30, 42, 42, 42), 90);
            LinearGradientBrush T2 = new LinearGradientBrush(new Rectangle(0, 0, Width, 20), Color.FromArgb(50, 50, 50), Color.Gray, 90);
            try
            {
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.Clear(Color.FromArgb(37, 37, 37));

                G.FillRectangle(T, new Rectangle(Width - 20, 0, Width, 20));
                G.DrawLine(Pens.Black, Width - 20, 0, Width - 20, Height);
                try
                {
                    //.DrawString(Items(SelectedIndex).ToString, Font, Brushes.White, New Rectangle(New Point(3, 3), New Size(Width - 18, Height)))
                    G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(66, 130, 181)), new Rectangle(3, 0, Width - 20, Height), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
                catch
                {
                }

                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(37, 37, 37))), 0, 0, 0, 0);
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(0, 0, 0))), new Rectangle(1, 1, Width - 3, Height - 3));

                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 0, Height - 1, Width, Height - 1);

                DrawTriangle(Color.FromArgb(66, 130, 181), new Point(Width - 14, 8), new Point(Width - 7, 8), new Point(Width - 11, 11), G);
            }
            catch
            {
            }
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.DrawItem += ReplaceItem;
        }

    }
}

