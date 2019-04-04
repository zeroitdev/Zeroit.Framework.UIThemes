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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{

    internal static class Preferences
    {

        // Color that will be used to fill controls throughout the entire theme
        // Intense bright colors will work the best
        public static Color MainColor = Color.Red;

        // Color of the border that will draw around the outside of most controls
        public static Color BorderColor = Color.FromArgb(30, 30, 30);

        // Color of the text that will be drawn
        public static Color TextColor = Color.Silver;

        // Background color of container controls such as the form skin and groupbox
        public static Color BackgroundColor = Color.FromArgb(40, 40, 40);

        // Background color of most controls
        // Some controls have offset background colors for visual purposes
        public static Color ControlBackColor = Color.FromArgb(70, 70, 70);

        // Background color of secondary controls such as the progress bar and textbox
        public static Color SecondaryBackColor = Color.FromArgb(35, 35, 35);

        // Font style of the text that will appear on most controls
        public static string FontFamily = "Arial";

        // Determines how round your controls will be.
        // 0 = no rounding, 10 = maximum rounding
        public static int Rounding = 4;

    }

    internal class DrawingHelper
    {

        public enum RoundingStyle
        {
            All,
            Top,
            Bottom,
            Left,
            Right,
            TopRight,
            BottomRight
        }

        public GraphicsPath RoundRect(Rectangle rect, int slope, RoundingStyle style = RoundingStyle.All)
        {

            GraphicsPath gp = new GraphicsPath();
            int arcWidth = slope * 2;

            gp.StartFigure();

            if (slope == 0)
            {
                gp.AddRectangle(rect);
                gp.CloseAllFigures();
                return gp;
            }

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
                case RoundingStyle.TopRight:
                    gp.AddLine(new Point(rect.X, rect.Y + 1), new Point(rect.X, rect.Y));
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddLine(new Point(rect.X + rect.Width, rect.Y + rect.Height - 1), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    gp.AddLine(new Point(rect.X + 1, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height));
                    break;
                case RoundingStyle.BottomRight:
                    gp.AddLine(new Point(rect.X, rect.Y + 1), new Point(rect.X, rect.Y));
                    gp.AddLine(new Point(rect.X + rect.Width - 1, rect.Y), new Point(rect.X + rect.Width, rect.Y));
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    gp.AddLine(new Point(rect.X + 1, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height));
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

        public Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }

        public Color GrayScale(int rgb)
        {
            return Color.FromArgb(rgb, rgb, rgb);
        }

        public void DrawCenteredString(Graphics g, string text, Font font, Brush brush, Rectangle rect, bool shadow = false, int yOffset = 0)
        {

            SizeF textSize = g.MeasureString(text, font);
            int textX = Convert.ToInt32(rect.X + (rect.Width / 2.0) - (textSize.Width / 2.0));
            int textY = Convert.ToInt32(rect.Y + (rect.Height / 2.0) - (textSize.Height / 2.0) + yOffset);

            if (shadow)
            {
                g.DrawString(text, font, Brushes.Black, textX + 1, textY + 1);
            }
            g.DrawString(text, font, brush, textX, textY + 1);

        }

        public Rectangle ResizeRect(Rectangle rect, int difference)
        {
            return new Rectangle(rect.X + difference, rect.Y + difference, rect.Width - (difference * 2), rect.Height - (difference * 2));
        }

    }

    public class MorphicSkin : ContainerControl
    {
        private Graphics g;
        private DrawingHelper dh = new DrawingHelper();

        private int moveHeight = 40;
        private bool formCanMove;
        private int mouseX;
        private int mouseY;
        private Rectangle minRect;
        private Rectangle exitRect;
        private bool overMin;
        private bool overExit;

        private Font _headerFont;
        private Image _iconImage;

        public Font HeaderFont
        {
            get
            {
                return _headerFont;
            }
            set
            {
                _headerFont = value;
                Invalidate();
            }
        }

        public Image IconImage
        {
            get
            {
                return _iconImage;
            }
            set
            {
                _iconImage = value;
                Invalidate();
            }
        }

        public MorphicSkin()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Font = new Font("Arial", 9);
            BackColor = Preferences.BackgroundColor;
            HeaderFont = new Font("Arial", 12F, FontStyle.Bold);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            FindForm().TransparencyKey = Color.Fuchsia;
            FindForm().FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            BackColor = Preferences.BackgroundColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.Clear(FindForm().TransparencyKey);

            Rectangle boundsRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath boundsPath = dh.RoundRect(boundsRect, Preferences.Rounding);
            g.FillPath(new SolidBrush(Preferences.BackgroundColor), boundsPath);

            Rectangle headerRect = new Rectangle(0, 0, Width - 1, moveHeight);
            GraphicsPath headerPath = dh.RoundRect(headerRect, Preferences.Rounding, DrawingHelper.RoundingStyle.Top);
            LinearGradientBrush headerBrush = new LinearGradientBrush(headerRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
            g.FillPath(headerBrush, headerPath);
            headerBrush.Dispose();

            if (IconImage != null)
            {
                Rectangle iconRect = new Rectangle(8, 8, moveHeight - 16, moveHeight - 16);
                g.DrawImage(IconImage, iconRect);
            }

            if (!overExit)
            {
                g.DrawString("r", new Font("Marlett", 12F, FontStyle.Bold), new SolidBrush(Preferences.BorderColor), new Point(Width - 32, 13));
            }
            else
            {
                g.DrawString("r", new Font("Marlett", 12F, FontStyle.Bold), new SolidBrush(dh.AdjustColor(Preferences.BorderColor, 120, DrawingHelper.ColorAdjustmentType.Lighten)), new Point(Width - 32, 13));
            }

            if (!overMin)
            {
                g.DrawString("0", new Font("Marlett", 14F, FontStyle.Bold), new SolidBrush(Preferences.BorderColor), new Point(Width - 54, 9));
            }
            else
            {
                g.DrawString("0", new Font("Marlett", 14F, FontStyle.Bold), new SolidBrush(dh.AdjustColor(Preferences.BorderColor, 120, DrawingHelper.ColorAdjustmentType.Lighten)), new Point(Width - 54, 9));
            }

            exitRect = new Rectangle(Width - 32, 9, 21, 21);
            minRect = new Rectangle(Width - 54, 9, 21, 21);

            dh.DrawCenteredString(g, Text, HeaderFont, new SolidBrush(Preferences.TextColor), headerRect, false, 1);

            Pen borderPen = new Pen(Preferences.BorderColor);
            g.DrawPath(borderPen, headerPath);
            g.DrawPath(borderPen, boundsPath);
            borderPen.Dispose();

        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Y <= moveHeight)
            {

                if (minRect.Contains(e.Location))
                {
                    overMin = true;
                }
                else
                {
                    overMin = false;
                }

                if (exitRect.Contains(e.Location))
                {
                    overExit = true;
                }
                else
                {
                    overExit = false;
                }

                if (formCanMove == true)
                {
                    FindForm().Location = new Point(MousePosition.X - mouseX, MousePosition.Y - mouseY);
                }

                Invalidate();

            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseX = e.X;
            mouseY = e.Y;
            if (e.Y <= moveHeight && !overExit && !overMin)
            {
                formCanMove = true;
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            formCanMove = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (overMin)
            {
                FindForm().WindowState = FormWindowState.Minimized;
                overMin = false;
                Invalidate();
            }

            if (overExit)
            {
                FindForm().Close();
            }

        }

    }
    
}
