// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-22-2018
// ***********************************************************************
// <copyright file="Switch.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.AdvancedCore
{
    
[DefaultEvent("CheckedChanged")]
public class ASCSwitch : Control
{

	public event CheckedChangedEventHandler CheckedChanged;
	public delegate void CheckedChangedEventHandler(object sender);

	private bool _checked;
	public bool Checked {
		get { return _checked; }
		set {
			_checked = value;
			Invalidate();
		}
	}

	public ASCSwitch()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
		Size = new Size(40, 17);
	}

	protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	{
		base.OnPaint(e);

		Graphics G = e.Graphics;
		G.SmoothingMode = SmoothingMode.HighQuality;
		G.Clear(Parent.BackColor);

		int slope = (Height - 1) / 2;
		Height = 17;

		Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
		GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);

		if (_checked) {
			LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, Color.FromArgb(10, 30, 50), Color.FromArgb(5, 80, 140), 90f);
			G.FillPath(bgBrush, mainPath);
			Rectangle switchRect = new Rectangle(Width - 14, 3, 10, 10);
			LinearGradientBrush switchBrush = new LinearGradientBrush(switchRect, Color.FromArgb(100, 220, 250), Color.FromArgb(15, 150, 220), 90f);
			G.FillEllipse(switchBrush, switchRect);
			int textY = ((Height - 1) / 2) - Convert.ToInt32((G.MeasureString("On", new Font("Arial", 8)).Height / 2) + 1);
			G.DrawString("On", new Font("Arial", 8), new SolidBrush(Color.FromArgb(180, 180, 180)), new Point(5, textY));
			G.DrawPath(new Pen(Color.FromArgb(5, 80, 140)), mainPath);
		} else {
			LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, Color.FromArgb(40, 40, 40), Color.FromArgb(80, 80, 80), 90f);
			G.FillPath(bgBrush, mainPath);
			Rectangle switchRect = new Rectangle(3, 3, 10, 10);
			LinearGradientBrush switchBrush = new LinearGradientBrush(switchRect, Color.FromArgb(150, 150, 150), Color.FromArgb(120, 120, 120), 90f);
			G.FillEllipse(switchBrush, switchRect);
			int textY = ((Height - 1) / 2) - Convert.ToInt32((G.MeasureString("Off", new Font("Arial", 8)).Height / 2) + 1);
			G.DrawString("Off", new Font("Arial", 8), new SolidBrush(Color.FromArgb(180, 180, 180)), new Point(15, textY));
			G.DrawPath(new Pen(Color.FromArgb(80, 80, 80)), mainPath);
		}

	}

	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);

		if (_checked) {
			_checked = false;
		} else {
			_checked = true;
		}

		if (CheckedChanged != null) {
			CheckedChanged(this);
		}
		Invalidate();

	}

}

}