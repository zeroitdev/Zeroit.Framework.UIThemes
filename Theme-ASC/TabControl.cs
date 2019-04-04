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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.AdvancedCore
{

    public class ASCTabControl : TabControl
{

	public ASCTabControl()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
		ItemSize = new Size(0, 34);
		Padding = new Point(24, 0);
		Font = new Font("Arial", 12);
	}

	protected override void CreateHandle()
	{
		base.CreateHandle();
		Alignment = TabAlignment.Top;
	}

	protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	{
		base.OnPaint(e);

		Graphics G = e.Graphics;

		G.SmoothingMode = SmoothingMode.HighQuality;
		G.Clear(Parent.BackColor);

		Color FontColor = new Color();


		for (int i = 0; i <= TabCount - 1; i++) {
			Rectangle mainRect = GetTabRect(i);

			if (i == SelectedIndex) {
				FontColor = Color.FromArgb(80, 170, 245);
				G.DrawLine(new Pen(Color.FromArgb(5, 135, 250)), new Point(mainRect.X - 2, mainRect.Height - 1), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height - 1));
				G.DrawLine(new Pen(Color.FromArgb(25, 100, 140)), new Point(mainRect.X - 2, mainRect.Height), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height));
			} else {
				FontColor = Color.FromArgb(160, 160, 160);
				G.DrawLine(new Pen(Color.FromArgb(30, 55, 85)), new Point(mainRect.X - 2, mainRect.Height - 1), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height - 1));
				G.DrawLine(new Pen(Color.FromArgb(30, 55, 85)), new Point(mainRect.X - 2, mainRect.Height), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height));
			}

			if (i != 0) {
				G.DrawLine(new Pen(Color.FromArgb(30, 90, 125)), new Point(mainRect.X - 4, mainRect.Height - 7), new Point(mainRect.X + 4, mainRect.Y + 6));
			}

			int titleX = (mainRect.Location.X + mainRect.Width / 2) - Convert.ToInt32((G.MeasureString(TabPages[i].Text, Font).Width / 2));
			int titleY = (mainRect.Location.Y + mainRect.Height / 2) - Convert.ToInt32((G.MeasureString(TabPages[i].Text, Font).Height / 2));
			G.DrawString(TabPages[i].Text, Font, new SolidBrush(FontColor), new Point(titleX, titleY));

			try {
				TabPages[i].BackColor = Parent.BackColor;
			} catch {
			}

		}

	}

}

}