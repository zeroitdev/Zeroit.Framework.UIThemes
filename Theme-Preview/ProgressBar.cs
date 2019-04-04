// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVProgressBar : ThemedControl
    {
        private int PValue = 50;
        public int Value
        {
            get
            {
                return PValue;
            }
            set
            {
                Invalidate();
                PValue = value;
            }
        }
        public int Minimum { get; set; }
        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
            }
        }
        public PVProgressBar() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackColor = Pal.ColDark;
            MinimumSize = new Size(21, 21);
            Font = new Font("Trebuchet MS", 10.0F);
            Value = 50;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            //Height = 30
            // Height = 21
            //| If lazy, put back to 21, else
            //| http://cdns2.freepik.com/foto-gratuito/barra-di-avanzamento-ui_29-20000356.jpg
            int ProgHeight = 21;

            G.Clear(BackColor);
            try
            {
                string s = (this.Parent).GetType().Name;
                if (s.Contains("PVGroupbox"))
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(39, Pal.ColDim)), new Rectangle(0, 0, Width, Height));
                }
            }
            catch (Exception ex)
            {

            }

            G.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle BorderRect = new Rectangle(0, 0, Width - 1, ProgHeight - 1);
            Rectangle BorderInnerRect = new Rectangle(1, 1, Width - 3, ProgHeight - 3);
            Rectangle ButtonRect = new Rectangle(5, 5, Width - 11, ProgHeight - 11);
            //| Drawing the BG / assigning main variables
            GraphicsPath Out1Path = D.RoundRect(BorderRect, 3);
            GraphicsPath Out2Path = D.RoundRect(BorderInnerRect, 5);
            LinearGradientBrush Out2LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, ProgHeight), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            G.DrawPath(new Pen(Out2LGB, 3F), Out2Path);
            D.FillDualGradPath(G, Color.FromArgb(100, Color.Black), Color.Transparent, BorderRect, Out2Path, GradientAlignment.Horizontal);
            //| Drawing the bar
            Rectangle BarRect = new Rectangle(2, 2, Convert.ToInt32(ValueToPercentage(PValue) * Width - 4), ProgHeight - 5);
            if (PValue > 0)
            {
                GraphicsPath BarPath = D.RoundRect(BarRect, 3);
                GraphicsPath BarHighlightPath = D.RoundRect(new Rectangle(BarRect.X, BarRect.Y, BarRect.Width, Convert.ToInt32(BarRect.Height / 2.0)), 4);
                LinearGradientBrush BarHighlightLGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Convert.ToInt32(BarRect.Height / 2.0 + 1)), Color.FromArgb(60, Color.AliceBlue), Color.FromArgb(100, Color.White));
                HatchBrush DiagonalHatch = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(15, Color.AliceBlue));
                D.FillDualGradPath(G, Color.FromArgb(45, 75, 210), Color.FromArgb(65, 135, 255), BarRect, BarPath, GradientAlignment.Horizontal);
                G.FillPath(DiagonalHatch, BarPath);
                G.FillPath(BarHighlightLGB, BarHighlightPath);
                D.FillDualGradPath(G, Color.FromArgb(140, Color.FromArgb(10, 30, 100)), Color.FromArgb(10, Color.FromArgb(20, 50, 160)), BarRect, BarPath, GradientAlignment.Horizontal);
                G.DrawPath(new Pen(Pal.ColDark), BarPath);
            }
            G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), Out1Path);
            if (true)
            {
                string BarText = Microsoft.VisualBasic.Strings.FormatPercent(ValueToPercentage(PValue), -1, Microsoft.VisualBasic.TriState.UseDefault, Microsoft.VisualBasic.TriState.UseDefault, Microsoft.VisualBasic.TriState.UseDefault).Replace(".00", "");
                Size TextSize = G.MeasureString(BarText, Font).ToSize();
                if (Height < 38)
                {
                    int Opacity = 0;
                    Opacity = Convert.ToInt32(ValueToPercentage(PValue) * 500);
                    if (Opacity > 255)
                    {
                        Opacity = 255;
                    }

                    D.DrawTextWithShadow(G, new Rectangle(BarRect.Width - TextSize.Width, 0, 100, BarRect.Height + 3), BarText, Font, HorizontalAlignment.Left, Color.FromArgb(Opacity, Color.White), Color.FromArgb(Opacity, Color.Black));
                }
                else
                {
                    GraphicsPath PercentPath = new GraphicsPath();
                    int StartX = Width - 51;
                    PercentPath.AddLine(new Point(StartX, 20), new Point(StartX + 20, 38));
                    PercentPath.AddLine(new Point(StartX + 20, 38), new Point(StartX + 50, 38));
                    PercentPath.AddLine(new Point(StartX + 50, 38), new Point(StartX + 50, 19));

                    G.SmoothingMode = SmoothingMode.None;
                    G.FillRectangle(new SolidBrush(Pal.ColDark), new Rectangle(StartX, 20, 50, 1));
                    G.DrawLine(new Pen(Pal.ColDark), new Point(StartX + 49, 17), new Point(StartX + 49, 19));
                    G.SmoothingMode = SmoothingMode.HighQuality;

                    LinearGradientBrush FillLGB = new LinearGradientBrush(new Point(0, 19), new Point(0, 39), Color.FromArgb(100, Pal.ColDim), Color.FromArgb(85, Color.Black));
                    G.FillPath(FillLGB, PercentPath);
                    D.DrawTextWithShadow(G, new Rectangle(Width - TextSize.Width, 13, 100, 30), BarText, Font, HorizontalAlignment.Left, Color.FromArgb(140, Color.WhiteSmoke), Pal.ColDark);
                    G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), PercentPath);
                }
            }
        }
        private float ValueToPercentage(int val)
        {
            var min = Minimum;
            var max = Maximum;
            return (val - min) / (max - min);
            //vertical:  Return 1 - (value - min) / (max - min)
        }

    }
}
