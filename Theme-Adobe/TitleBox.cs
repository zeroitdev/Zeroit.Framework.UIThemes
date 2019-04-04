// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TitleBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Adobe
{

    public class AdobeTitleBox : ThemeContainer154
{

	#region " Properties "

    public enum fillStyle { Solid, Gradient}
    private fillStyle _fillStyle = fillStyle.Solid;

    private Color solidColor = Color.DarkGray;
    private Color gradientColor1 = Color.DarkSlateGray;
    private Color gradientColor2 = Color.Orange;
    private Color leftSupportColor = Color.Black;
    private Color rightSupportColor = Color.Black;

    private Color fc;
    private LinearGradientMode gradientMode = LinearGradientMode.ForwardDiagonal;

    public override Color ForeColor {
		get { return fc; }
		set {
			fc = value;
			Invalidate();
		}
	}

	#endregion

    public Color SolidColor
    {
        get { return solidColor; }
        set
        {
            solidColor = value;
            Invalidate();
        }
    }

    public Color GradientColor1
    {
        get { return gradientColor1; }
        set
        {
            gradientColor1 = value;
            Invalidate();
        }
    }

    public Color GradientColor2
    {
        get { return gradientColor2; }
        set
        {
            gradientColor2 = value;
            Invalidate();
        }
    }

    public Color LeftSupportColor
    {
        get { return leftSupportColor; }
        set
        {
            leftSupportColor = value;
            Invalidate();
        }
    }

    public Color RightSupportColor
    {
        get { return rightSupportColor; }
        set
        {
            rightSupportColor = value;
            Invalidate();
        }
    }

    public LinearGradientMode GradientMode
    {
        get { return gradientMode; }
        set
        {
            gradientMode = value;
            Invalidate();
        }
    }
    public fillStyle FillType
    {
        get { return _fillStyle; }
        set
        {
            _fillStyle = value;
            Invalidate();
        }
    }
	public AdobeTitleBox()
	{

        
        ControlMode = true;
		ForeColor = Color.White;
	}


	protected override void ColorHook()
	{
	}

    protected override void PaintHook()
	{
        
        
		Pen P1 = new Pen(new SolidBrush(Color.FromArgb(31, 31, 31)));
		Pen P2 = new Pen(new SolidBrush(Color.FromArgb(131, 131, 131)));
        
		int tH = Convert.ToInt32(G.MeasureString(Text, Font).Height);
		int tW = Convert.ToInt32(G.MeasureString(Text, Font).Width);
		G.Clear(BackColor);

        LinearGradientBrush gradbrush = new LinearGradientBrush(new Rectangle(0, 0, Width, tH + 10), gradientColor1, gradientColor1, gradientMode);
        SolidBrush sldBrush = new SolidBrush(solidColor);
		DrawBorders(P1, new Rectangle(10, 10, Width - 20, Height - 10));
		DrawBorders(P2, new Rectangle(10, 10, Width - 20, Height - 10), 1);

        switch (_fillStyle)
        {
            case fillStyle.Solid:
                G.FillRectangle(sldBrush, new Rectangle(0, 0, Width, tH + 10));
                break;
            case fillStyle.Gradient:
                G.FillRectangle(gradbrush, new Rectangle(0, 0, Width, tH + 10));
                break;
            default:
                break;
        }
        


		DrawBorders(P1, new Rectangle(0, 0, Width, tH + 10));
		DrawBorders(P2, new Rectangle(0, 0, Width, tH + 10), 1);
		G.FillPolygon(new SolidBrush(leftSupportColor), new Point[]{
			new Point(1, tH + 9),
			new Point(10, tH + 9),
			new Point(10, tH + 15),
			new Point(1, tH + 9)
		});
		G.FillPolygon(new SolidBrush(rightSupportColor), new Point[]{
			new Point(Width - 1, tH + 9),
			new Point(Width - 10, tH + 9),
			new Point(Width - 10, tH + 15),
			new Point(Width - 1, tH + 9)
		});

        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(Convert.ToInt32((this.Width / 2) - (G.MeasureString(Text, Font).Width / 2)), 4));

	}
}

}
