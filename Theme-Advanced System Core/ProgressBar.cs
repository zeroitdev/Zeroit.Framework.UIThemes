// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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

    public class ASCProgressBar : Control
{

	private int _Maximum = 100;
	public int Maximum {
		get { return _Maximum; }
		set {
			if (value < 1)
				value = 1;
			if (value < _Value)
				_Value = value;
			_Maximum = value;
			Invalidate();
		}
	}

	private int _Value;
	public int Value {
		get { return _Value; }
		set {
			if (value > _Maximum)
				value = Maximum;
			_Value = value;
			Invalidate();
		}
	}

	private int _percent;
	public int Percent {
		get { return _percent; }
	}

	public ASCProgressBar()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
		Size = new Size(200, 40);
		Font = new Font("Arial", 11);
	}

	protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	{
		base.OnPaint(e);

		Graphics G = e.Graphics;

		G.SmoothingMode = SmoothingMode.HighQuality;
		G.Clear(Parent.BackColor);

		int slope = 3;
		_percent = (_Value / _Maximum) * 100;

		int midY = ((Height - 1) / 2);
		Rectangle mainRect = new Rectangle(12, midY - 4, Width - 25, 7);
		GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);
		LinearGradientBrush barBrush = new LinearGradientBrush(mainRect, Color.FromArgb(32, 32, 32), Color.FromArgb(45, 45, 45), 90f);
		G.FillPath(barBrush, mainPath);

		Rectangle barRect = new Rectangle(12, midY - 4, Convert.ToInt32(((Width / _Maximum) * _Value) - ((_percent - 1) / 4)), 7);
		if (barRect.Width > 0) {
			LinearGradientBrush barHorizontal = new LinearGradientBrush(barRect, Color.FromArgb(5, 80, 140), Color.FromArgb(45, 180, 200), 0f);
			G.FillPath(barHorizontal, Drawing.RoundRect(barRect, slope));

			ColorBlend vertCB = new ColorBlend(5);
			vertCB.Colors[0] = Color.Transparent;
			vertCB.Colors[1] = Color.Transparent;
			vertCB.Colors[2] = Color.FromArgb(0, 150, 220);
			vertCB.Colors[3] = Color.Transparent;
			vertCB.Colors[4] = Color.Transparent;
			vertCB.Positions = new float[] {
				0.0f,
				0.4f,
				0.5f,
				0.6f,
				1.0f
			};
			LinearGradientBrush barVertical = new LinearGradientBrush(barRect, Color.Black, Color.Black, 90f);
			barVertical.InterpolationColors = vertCB;
			G.FillPath(barVertical, Drawing.RoundRect(barRect, slope));
		}

		if (_Value > 0) {
			Rectangle bubbleRect = new Rectangle(barRect.Width - 3, 0, midY * 2 - 3, midY * 2);
			GraphicsPath bubblePath = Drawing.RoundRect(bubbleRect, midY);
			PathGradientBrush bubbleBrush = new PathGradientBrush(bubblePath);
			bubbleBrush.CenterColor = Color.FromArgb(230, 245, 255);
			bubbleBrush.SurroundColors = new Color[]{ Color.Transparent};
			G.FillPath(bubbleBrush, bubblePath);
		}

	}
}

}