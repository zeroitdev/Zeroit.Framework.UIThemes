﻿// ***********************************************************************
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Sugar
{
    public class SugarTabControl : TabControl
    {
        //Stupid VB.Net bug. Please don't use more than 9999 tabs :3
        private int[] Xstart = new int[10000];
        //Stupid VB.Net bug. Please don't use more than 9999 tabs :3
        private int[] Xstop = new int[10000];

        public SugarTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            foreach (TabPage p in TabPages)
            {
                p.BackColor = Color.FromArgb(247, 249, 254);
                Application.DoEvents();
                p.BackColor = Color.FromArgb(247, 249, 254);
            }
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int index = 0;
            int height = (int)this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8;
            foreach (int a in Xstart)
            {
                if (e.X > a & e.X < Xstop[index] & e.Y < height & e.Button == MouseButtons.Left)
                {
                    SelectedIndex = index;
                    Invalidate();
                }
                else
                {
                }
                index += 1;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.Clear(Color.Red);
            HatchBrush asdf = default(HatchBrush);
            asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Red), Color.Pink);
            G.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, Width, Height));
            asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
            G.FillRectangle(asdf, 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(190, 210, 217)), 0, 0, Width, Height);

            G.FillRectangle(Brushes.PowderBlue, 0, 0, Width, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8);
            G.FillRectangle(new SolidBrush(Color.FromArgb(190, 210, 217)), 2, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 7, Width - 2, Height - 2);

            int totallength = 0;
            int index = 0;
            foreach (TabPage tab in TabPages)
            {
                if (SelectedIndex == index)
                {
                    G.FillRectangle(new SolidBrush(Color.Red), totallength, 1, this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 10);
                    asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Red), Color.FromArgb(0, Color.Blue));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(199, 211, 229)), totallength, 1, this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 10);
                    asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Blue);
                    G.FillRectangle(asdf, totallength, 1, this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 10);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(190, 210, 217)), totallength, 1, this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 10);

                    LinearGradientBrush gradient = new LinearGradientBrush(new Point(totallength, 1), new Point(totallength, (int)this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8), Color.FromArgb(15, Color.Black), Color.Transparent);
                    G.FillRectangle(gradient, totallength, 1, this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 5);

                    G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), totallength, 2, totallength, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8);

                    G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), totallength + this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8, Width - 1, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8);
                    G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), 1, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8, totallength, this.CreateGraphics().MeasureString("Sasi is awesome", Font).Height + 8);

                }
                Xstart[index] = totallength;
                Xstop[index] = totallength + (int)this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15;
                G.DrawString(tab.Text, Font, Brushes.Black, totallength + 8, 5);
                totallength += (int)this.CreateGraphics().MeasureString(tab.Text, Font).Width + 15;
                index += 1;
            }

            G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), 1, 1, Width - 2, 1);
            //boven
            G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), 1, Height - 2, Width - 2, Height - 2);
            //onder
            G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), 1, 1, 1, Height - 2);
            //links
            G.DrawLine(new Pen(Color.FromArgb(190, 210, 217)), Width - 2, 1, Width - 2, Height - 2);
            //rechts

            G.DrawLine(Pens.Transparent, 0, 0, Width - 1, 0);
            //boven
            G.DrawLine(Pens.Transparent, 0, Height - 1, Width, Height - 1);
            //onder
            G.DrawLine(Pens.Transparent, 0, 0, 0, Height - 1);
            //links
            G.DrawLine(Pens.Transparent, Width - 1, 0, Width - 1, Height - 1);
            //rechts

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnSelectedIndexChanged(System.EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }
    }

}

