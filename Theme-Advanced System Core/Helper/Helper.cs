// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Helper.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.AdvancedCore
{

    static class Drawing
	{
	
		public static GraphicsPath RoundRect(Rectangle rect, int slope)
		{
			GraphicsPath gp = new GraphicsPath();
			int arcWidth = slope * 2;
			gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90);
			gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90);
			gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90);
			gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90);
			gp.CloseAllFigures();
			return gp;
		}
	
	}
	
	public static class Prevent
	{
	
		public static void Prevents(Graphics g, int w, int h)
		{
			string txt = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("VGhlbWUlMjBjcmVhdGVkJTIwYnklMjBIYXdrJTIwSEY=")).Replace("%20", " ");
			Size txtSize = new Size(Convert.ToInt32(g.MeasureString(txt, new Font("Arial", 8)).Width), Convert.ToInt32(g.MeasureString(txt, new Font("Arial", 8)).Height));
			g.DrawString(txt, new Font("Arial", 8), new SolidBrush(Color.FromArgb(125, 125, 125)), new Point(w - txtSize.Width - 6, h - txtSize.Height - 4));
		}
	
	}

}
