// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Professional
{
    internal class Adjustments
    {

        //Default FontFamily that will be used throughout the entire theme
        public static readonly FontFamily DefaultFontFamily = new FontFamily("Verdana");

        //Roundness of the corners of most controls. Higher = more circular
        public static readonly int Roundness = 4;

    }

    internal class DrawingHelper
    {

        public enum RoundingStyle
        {
            All,
            Top,
            Bottom,
            Left,
            Right
        }

        public GraphicsPath RoundRect(Rectangle rect, int slope, RoundingStyle style = RoundingStyle.All)
        {

            GraphicsPath gp = new GraphicsPath();
            int arcWidth = slope * 2;

            switch (style)
            {
                case RoundingStyle.All:
                    gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90F, 90F);
                    break;
                case RoundingStyle.Top:
                    gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddLine(new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height));
                    break;
                case RoundingStyle.Bottom:
                    gp.AddLine(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y));
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90F, 90F);
                    break;
                case RoundingStyle.Left:
                    gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180F, 90F);
                    gp.AddLine(new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90F, 90F);
                    break;
                case RoundingStyle.Right:
                    gp.AddLine(new Point(rect.X, rect.Y + rect.Height), new Point(rect.X, rect.Y));
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    break;
            }

            gp.CloseAllFigures();

            return gp;

        }

        public enum ColorAdjustmentType
        {
            Lighten,
            Darken
        }

        public Color AdjustColor(Color c, int intensity, ColorAdjustmentType adjustment, bool keepAlpha = true)
        {

            int r = 0;
            int g = 0;
            int b = 0;

            if (intensity < 1)
            {
                intensity = 1;
            }
            else if (intensity > 255)
            {
                intensity = 255;
            }

            if (adjustment == ColorAdjustmentType.Lighten)
            {
                r = Convert.ToInt32(IncrementValue(c.R, intensity));
                g = Convert.ToInt32(IncrementValue(c.G, intensity));
                b = Convert.ToInt32(IncrementValue(c.B, intensity));
            }
            else
            {
                r = Convert.ToInt32(DecrementValue(c.R, intensity));
                g = Convert.ToInt32(DecrementValue(c.G, intensity));
                b = Convert.ToInt32(DecrementValue(c.B, intensity));
            }

            if (keepAlpha)
            {
                return Color.FromArgb(c.A, r, g, b);
            }
            else
            {
                return Color.FromArgb(255, r, g, b);
            }


        }

        private object IncrementValue(int initialValue, int intensity, int maximum = 255)
        {
            if (initialValue + intensity < maximum)
            {
                return initialValue + intensity;
            }
            else
            {
                return maximum;
            }
        }

        private object DecrementValue(int initialValue, int intensity, int minimum = 0)
        {
            if (initialValue - intensity > minimum)
            {
                return initialValue - intensity;
            }
            else
            {
                return minimum;
            }
        }

    }

    internal class MultiLineHandler
    {

        public List<string> GetLines(Graphics g, string str, Font font, int maxLength)
        {

            List<string> result = new List<string>();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            str = str.Replace("\r", "").Replace("\n", "");

            string[] words = null;
            if (str.Contains(" "))
            {
                words = str.Replace(Environment.NewLine, null).Split(' ');
            }
            else
            {
                result.Add(str);
                return result;
            }

            for (var i = 0; i < words.Length; i++)
            {

                if (i == words.Length - 1)
                {
                    if (g.MeasureString(sb.ToString() + " " + words[i], font).Width < maxLength)
                    {
                        sb.Append(words[i]);
                        result.Add(sb.ToString());
                    }
                    else
                    {
                        result.Add(sb.ToString());
                        result.Add(words[i]);
                    }
                }
                else if (g.MeasureString(sb.ToString() + " " + words[i], font).Width > maxLength)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                    sb.Append(words[i] + " ");
                }
                else
                {
                    sb.Append(words[i] + " ");
                }

            }

            return result;

        }

    }
        
}
