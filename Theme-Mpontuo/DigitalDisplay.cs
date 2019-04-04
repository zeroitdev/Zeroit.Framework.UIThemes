// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="DigitalDisplay.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public partial class MpontuoDigitalDisplay : Control
    {
        private Color _digitColor = Color.FromArgb(66, 130, 181);
        public Color DigitColor
        {
            get
            {
                return _digitColor;
            }
            set
            {
                _digitColor = value;
                Invalidate();
            }
        }

        private string _digitText = "88.88";
        public string DigitText
        {
            get
            {
                return _digitText;
            }
            set
            {
                _digitText = value;
                Invalidate();
            }
        }

        public MpontuoDigitalDisplay()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            SubscribeToEvents();
        }

        private void DigitalGauge_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            MpontuoSevenSegmentHelper sevenSegmentHelper = new MpontuoSevenSegmentHelper(e.Graphics);

            SizeF digitSizeF = sevenSegmentHelper.GetStringSize(_digitText, this.Font);
            float scaleFactor = Math.Min(ClientSize.Width / digitSizeF.Width, ClientSize.Height / digitSizeF.Height);
            Font font = new Font(this.Font.FontFamily, scaleFactor * this.Font.SizeInPoints);
            digitSizeF = sevenSegmentHelper.GetStringSize(_digitText, font);

            using (SolidBrush brush = new SolidBrush(_digitColor))
            {
                using (SolidBrush lightBrush = new SolidBrush(Color.FromArgb(20, _digitColor)))
                {
                    sevenSegmentHelper.DrawDigits(_digitText, font, brush, lightBrush, (float)((ClientSize.Width - digitSizeF.Width) / 2.0), (float)((ClientSize.Height - digitSizeF.Height) / 2.0));
                }
            }
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            base.Paint += DigitalGauge_Paint;
        }

    }

    public class MpontuoSevenSegmentHelper
    {
        private Graphics _graphics;

        // Indicates what segments are illuminated for all 10 digits
        private static byte[,] _segmentData = { { 1, 1, 1, 0, 1, 1, 1 }, { 0, 0, 1, 0, 0, 1, 0 }, { 1, 0, 1, 1, 1, 0, 1 }, { 1, 0, 1, 1, 0, 1, 1 }, { 0, 1, 1, 1, 0, 1, 0 }, { 1, 1, 0, 1, 0, 1, 1 }, { 1, 1, 0, 1, 1, 1, 1 }, { 1, 0, 1, 0, 0, 1, 0 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 0, 1, 1 }, { 0, 0, 0, 1, 0, 0, 0 }, { 1, 1, 1, 1, 1, 0, 0 }, { 1, 1, 1, 1, 1, 1, 0 } };

        // Points that define each of the seven segments
        private readonly Point[][] _segmentPoints = new Point[7][];

        public MpontuoSevenSegmentHelper(Graphics graphics)
        {
            this._graphics = graphics;
            _segmentPoints[0] = new Point[] {
            new Point(3, 2),
            new Point(39, 2),
            new Point(31, 10),
            new Point(11, 10)
        };
            _segmentPoints[1] = new Point[] {
            new Point(2, 3),
            new Point(10, 11),
            new Point(10, 31),
            new Point(2, 35)
        };
            _segmentPoints[2] = new Point[] {
            new Point(40, 3),
            new Point(40, 35),
            new Point(32, 31),
            new Point(32, 11)
        };
            _segmentPoints[3] = new Point[] {
            new Point(3, 36),
            new Point(11, 32),
            new Point(31, 32),
            new Point(39, 36),
            new Point(31, 40),
            new Point(11, 40)
        };
            _segmentPoints[4] = new Point[] {
            new Point(2, 37),
            new Point(10, 41),
            new Point(10, 61),
            new Point(2, 69)
        };
            _segmentPoints[5] = new Point[] {
            new Point(40, 37),
            new Point(40, 69),
            new Point(32, 61),
            new Point(32, 41)
        };
            _segmentPoints[6] = new Point[] {
            new Point(11, 62),
            new Point(31, 62),
            new Point(39, 70),
            new Point(3, 70)
        };
        }

        public SizeF GetStringSize(string text, Font font)
        {
            SizeF sizef = new SizeF(0F, _graphics.DpiX * font.SizeInPoints / 72);

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) || text[i] == '-')
                {
                    sizef.Width += 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
                }
                else if (text[i] == ':' || text[i] == '.')
                {
                    sizef.Width += 12 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
                }
            }
            return sizef;
        }

        public void DrawDigits(string text, Font font, Brush brush, Brush brushLight, float x, float y)
        {
            for (int cnt = 0; cnt < text.Length; cnt++)
            {
                // For digits 0-9
                if (char.IsDigit(text[cnt]))
                {
                    x = DrawDigit(Convert.ToInt32(text[cnt]) - Convert.ToInt32('0'), font, brush, brushLight, x, y);
                    // For colon :
                }
                else if (text[cnt] == ':')
                {
                    x = DrawColon(font, brush, x, y);
                    // For dot .
                }
                else if (text[cnt] == '.')
                {
                    x = DrawDot(font, brush, x, y);
                }
                else if (text[cnt] == '-')
                {
                    x = DrawMinus(font, brush, brushLight, x, y);
                }
                else if (text[cnt] == 'P')
                {
                    x = DrawP(font, brush, brushLight, x, y);
                }
                else if (text[cnt] == 'A')
                {
                    x = DrawP(font, brush, brushLight, x, y);
                }
            }
        }

        private float DrawDigit(int num, Font font, Brush brush, Brush brushLight, float x, float y)
        {
            for (int cnt = 0; cnt < _segmentPoints.Length; cnt++)
            {
                if (_segmentData[num, cnt] == 1)
                {
                    FillPolygon(_segmentPoints[cnt], font, brush, x, y);
                }
                else
                {
                    FillPolygon(_segmentPoints[cnt], font, brushLight, x, y);
                }
            }
            return x + 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        }

        private float DrawDot(Font font, Brush brush, float x, float y)
        {
            Point[][] dotPoints = new Point[1][];

            dotPoints[0] = new Point[] {
            new Point(2, 64),
            new Point(6, 61),
            new Point(10, 64),
            new Point(6, 69)
        };

            for (int cnt = 0; cnt < dotPoints.Length; cnt++)
            {
                FillPolygon(dotPoints[cnt], font, brush, x, y);
            }
            return x + 12 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        }

        private float DrawMinus(Font font, Brush brush, Brush brushLight, float x, float y)
        {
            DrawDigit(10, font, brush, brushLight, x, y);
            return x + 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        }

        private float DrawP(Font font, Brush brush, Brush brushLight, float x, float y)
        {
            DrawDigit(11, font, brush, brushLight, x, y);
            return x + 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        }

        private float DrawA(Font font, Brush brush, Brush brushLight, float x, float y)
        {
            DrawDigit(12, font, brush, brushLight, x, y);
            return x + 42 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        }

        private float DrawColon(Font font, Brush brush, float x, float y)
        {
            Point[][] colonPoints = new Point[2][];

            colonPoints[0] = new Point[] {
            new Point(2, 21),
            new Point(6, 17),
            new Point(10, 21),
            new Point(6, 25)
        };
            colonPoints[1] = new Point[] {
            new Point(2, 51),
            new Point(6, 47),
            new Point(10, 51),
            new Point(6, 55)
        };

            for (int cnt = 0; cnt < colonPoints.Length; cnt++)
            {
                FillPolygon(colonPoints[cnt], font, brush, x, y);
            }
            return x + 12 * _graphics.DpiX * font.SizeInPoints / 72 / 72;
        }

        private void FillPolygon(Point[] polygonPoints, Font font, Brush brush, float x, float y)
        {
            PointF[] polygonPointsF = new PointF[polygonPoints.Length];

            for (int cnt = 0; cnt < polygonPoints.Length; cnt++)
            {
                polygonPointsF[cnt].X = x + polygonPoints[cnt].X * _graphics.DpiX * font.SizeInPoints / 72 / 72;
                polygonPointsF[cnt].Y = y + polygonPoints[cnt].Y * _graphics.DpiY * font.SizeInPoints / 72 / 72;
            }
            _graphics.FillPolygon(brush, polygonPointsF);
        }
    }

    
}

