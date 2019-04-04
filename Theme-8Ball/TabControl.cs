// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TabControl.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.EightBall
{

    public class EightBallTabControl : TabControl
{

    public EightBallTabControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        Size = new Size(400, 200);
        SizeMode = TabSizeMode.Fixed;
        ItemSize = new Size(35, 145);
        Font = new Font("Verdana", 8);
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();
        Alignment = TabAlignment.Left;
    }


    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;
        G.Clear(Parent.BackColor);

        Color FontColor = new Color();
        Pen borderPen = new Pen(Color.FromArgb(55, 55, 55));

        Rectangle mainAreaRect = new Rectangle(ItemSize.Height + 2, 2, Width - 1 - ItemSize.Height - 2, Height - 3);
        GraphicsPath mainAreaPath = Drawing.TabControlRect(mainAreaRect, 4);
        G.FillPath(new SolidBrush(Color.FromArgb(100, 100, 100)), mainAreaPath);
        G.DrawPath(borderPen, mainAreaPath);


        for (int i = 0; i <= TabCount - 1; i++)
        {

            if (i == SelectedIndex)
            {
                Rectangle mainRect = GetTabRect(i);
                GraphicsPath mainPath = Drawing.LeftRoundRect(mainRect, 6);

                G.FillPath(new SolidBrush(Color.FromArgb(100, 100, 100)), mainPath);
                G.DrawPath(borderPen, mainPath);

                Rectangle orbRect = new Rectangle(mainRect.X + 12, mainRect.Y + (mainRect.Height / 2) - 8, 16, 16);
                G.FillEllipse(Brushes.SteelBlue, orbRect);
                G.FillEllipse(new LinearGradientBrush(orbRect, Color.FromArgb(30, Color.White), Color.FromArgb(10, Color.Black), 115f), orbRect);

                G.DrawEllipse(new Pen(Color.FromArgb(40, 105, 145)), orbRect);

                G.SmoothingMode = SmoothingMode.None;
                G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), new Point(mainRect.X + mainRect.Width, mainRect.Y + 1), new Point(mainRect.X + mainRect.Width, mainRect.Y + mainRect.Height - 1));
                G.SmoothingMode = SmoothingMode.HighQuality;

                FontColor = Color.White;

                int titleX = (mainRect.Location.X + 28 + 8);
                int titleY = (mainRect.Location.Y + mainRect.Height / 2) - Convert.ToInt32((G.MeasureString(TabPages[i].Text, Font).Height / 2));
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(FontColor), new Point(titleX, titleY));


            }
            else
            {
                Rectangle tabRect = GetTabRect(i);
                Rectangle mainRect = new Rectangle(tabRect.X + 6, tabRect.Y, tabRect.Width - 6, tabRect.Height);
                GraphicsPath mainPath = Drawing.LeftRoundRect(mainRect, 6);

                G.FillPath(new SolidBrush(Color.FromArgb(75, 75, 75)), mainPath);
                G.DrawPath(borderPen, mainPath);

                Rectangle orbRect = new Rectangle(mainRect.X + 12, mainRect.Y + (mainRect.Height / 2) - 8, 16, 16);
                G.FillEllipse(Brushes.Gray, orbRect);
                G.DrawEllipse(Pens.DimGray, orbRect);

                FontColor = Color.Silver;

                int titleX = (mainRect.Location.X + 28 + 8);
                int titleY = (mainRect.Location.Y + mainRect.Height / 2) - Convert.ToInt32((G.MeasureString(TabPages[i].Text, Font).Height / 2));
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(FontColor), new Point(titleX, titleY));

            }

            try
            {
                TabPages[i].BackColor = Color.FromArgb(100, 100, 100);
            }
            catch
            {
            }

        }

    }

}

}

