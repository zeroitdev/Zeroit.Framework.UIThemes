// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Close.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCClose"
    public class SLCClose : ThemeControl154
    {
        Label LB = new Label();

        protected override void ColorHook()
        {
        }

        public SLCClose()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Size = new Size(20, 20);


        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.White);
            G.FillRectangle(new SolidBrush(Color.FromArgb(239, 239, 239)), new Rectangle(-1, -1, Width + 1, Height + 1));



            switch (State)
            {
                case MouseState.None:


                    //// circle

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point((int)(Height - 18.5), Height - 20);
                    PB3.CenterColor = Color.FromArgb(193, 26, 26);
                    PB3.SurroundColors = new Color[] { Color.FromArgb(229, 110, 110) };
                    PB3.FocusScales = new PointF(0.6f, 0.6f);


                    G.FillPath(PB3, GPF);

                    G.DrawPath(new Pen(Color.FromArgb(159, 41, 41)), GPF);
                    G.SetClip(GPF);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();
                    break;
                case MouseState.Down:
                    //// circle

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF1 = new GraphicsPath();
                    GPF1.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                    PathGradientBrush PB31 = default(PathGradientBrush);
                    PB31 = new PathGradientBrush(GPF1);
                    PB31.CenterPoint = new Point((int)(Height - 18.5), Height - 20);
                    PB31.CenterColor = Color.FromArgb(221, 32, 32);
                    PB31.SurroundColors = new Color[] { Color.FromArgb(229, 110, 110) };
                    PB31.FocusScales = new PointF(0.6f, 0.6f);


                    G.FillPath(PB31, GPF1);

                    G.DrawPath(new Pen(Color.White), GPF1);
                    G.SetClip(GPF1);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();
                    break;
                case MouseState.Over:
                    //// circle

                    G.SmoothingMode = SmoothingMode.HighQuality;

                    GraphicsPath GPF2 = new GraphicsPath();
                    GPF2.AddEllipse(new Rectangle(Width - 20, Height - 19, 15, 15));
                    PathGradientBrush PB32 = default(PathGradientBrush);
                    PB32 = new PathGradientBrush(GPF2);
                    PB32.CenterPoint = new Point((int)(Height - 18.5), Height - 20);
                    PB32.CenterColor = Color.FromArgb(221, 32, 32);
                    PB32.SurroundColors = new Color[] { Color.FromArgb(229, 110, 110) };
                    PB32.FocusScales = new PointF(0.6f, 0.6f);


                    G.FillPath(PB32, GPF2);

                    G.DrawPath(new Pen(Color.FromArgb(159, 41, 41)), GPF2);
                    G.SetClip(GPF2);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Width - 20, Height - 18, 6, 6));
                    G.ResetClip();
                    break;
            }

        }
    }
    #endregion

}

