// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Drawing.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.EightBall
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

    public static GraphicsPath TopRoundRect(Rectangle rect, int slope)
    {
        GraphicsPath gp = new GraphicsPath();
        int arcWidth = slope * 2;
        gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90);
        gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90);
        gp.AddLine(new Point(rect.X + rect.Width, rect.Y + arcWidth), new Point(rect.X + rect.Width, rect.Y + rect.Height));
        gp.AddLine(new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height));
        gp.AddLine(new Point(rect.X, rect.Y + rect.Height), new Point(rect.X, rect.Y + arcWidth));
        gp.CloseAllFigures();
        return gp;
    }

    public static GraphicsPath LeftRoundRect(Rectangle rect, int slope)
    {
        GraphicsPath gp = new GraphicsPath();
        int arcWidth = slope * 2;
        gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90);
        gp.AddLine(new Point(rect.X + arcWidth, rect.Y), new Point(rect.Width, rect.Y));
        gp.AddLine(new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
        gp.AddLine(new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X + arcWidth, rect.Y + rect.Height));
        gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90);
        gp.CloseAllFigures();
        return gp;
    }

    public static GraphicsPath TabControlRect(Rectangle rect, int slope)
    {
        GraphicsPath gp = new GraphicsPath();
        int arcWidth = slope * 2;
        gp.AddLine(new Point(rect.X, rect.Y), new Point(rect.X, rect.Y));
        gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90);
        gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90);
        gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90);
        gp.CloseAllFigures();
        return gp;
    }

    public static void ShadowedString(Graphics g, string s, Font font, Brush brush, Point pos)
    {
        g.DrawString(s, font, Brushes.Black, new Point(pos.X + 1, pos.Y + 1));
        g.DrawString(s, font, brush, pos);
    }

    public static Rectangle getSmallerRect(Rectangle rect, int value)
    {
        return new Rectangle(rect.X + value, rect.Y + value, rect.Width - (value * 2), rect.Height - (value * 2));
    }

    public static Color AlterColor(Color original, int amount = -20)
    {
        Color c = original;
        int a = amount;
        int r = 0;
        int g = 0;
        int b = 0;
        if (c.R + a < 0)
        {
            r = 0;
        }
        else if (c.R + a > 255)
        {
            r = 255;
        }
        else
        {
            r = c.R + a;
        }
        if (c.G + a < 0)
        {
            g = 0;
        }
        else if (c.G + a > 255)
        {
            g = 255;
        }
        else
        {
            g = c.G + a;
        }
        if (c.B + a < 0)
        {
            b = 0;
        }
        else if (c.B + a > 255)
        {
            b = 255;
        }
        else
        {
            b = c.B + a;
        }
        return Color.FromArgb(r, g, b);
    }


}

}

