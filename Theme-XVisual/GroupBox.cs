// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualGroupBox : ContainerControl
    {

        public enum InnerShade
        {
            Light,
            Dark
        }
        private InnerShade _Shade;
        public InnerShade Shade
        {
            get { return _Shade; }
            set
            {
                _Shade = value;
                Invalidate();
            }
        }

        public xVisualGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Size = new Size(174, 115);
            _Shade = InnerShade.Light;
            DoubleBuffered = true;
        }
        TextureBrush TopTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(49, 45, 41),
        Color.FromArgb(51, 47, 43),
        Color.FromArgb(47, 43, 39)
    });
        TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(55, 52, 48),
        Color.FromArgb(57, 50, 50),
        Color.FromArgb(53, 50, 46)
    });
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle BarRect = new Rectangle(0, 0, Width - 1, 32);
            base.OnPaint(e);

            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (_Shade)
            {
                case InnerShade.Light:
                    LinearGradientBrush mainGradient = new LinearGradientBrush(ClientRectangle, Color.FromArgb(228, 230, 232), Color.FromArgb(199, 201, 205), 90);
                    G.FillRectangle(mainGradient, ClientRectangle);
                    G.DrawRectangle(Pens.Black, ClientRectangle);
                    break;
                case InnerShade.Dark:
                    G.FillRectangle(InnerTexture, ClientRectangle);
                    G.DrawRectangle(Pens.Black, ClientRectangle);
                    break;
            }

            LinearGradientBrush TopOverlay = new LinearGradientBrush(ClientRectangle, Color.FromArgb(5, Color.White), Color.FromArgb(10, Color.White), 90);
            G.FillRectangle(TopTexture, BarRect);

            ColorBlend blend = new ColorBlend();

            //Add the Array of Color
            Color[] bColors = new Color[] {
            Color.FromArgb(20, Color.White),
            Color.FromArgb(10, Color.Black),
            Color.FromArgb(10, Color.White)
        };
            blend.Colors = bColors;

            //Add the Array Single (0-1) colorpoints to place each Color
            float[] bPts = new float[] {
            0,
            0.9f,
            1
        };
            blend.Positions = bPts;

            using (LinearGradientBrush br = new LinearGradientBrush(BarRect, Color.White, Color.Black, LinearGradientMode.Vertical))
            {

                //Blend the colors into the Brush
                br.InterpolationColors = blend;

                //Fill the rect with the blend
                G.FillRectangle(br, BarRect);

            }

            G.DrawRectangle(Pens.Black, BarRect);

            //// Top Bar Highlights
            G.DrawLine(Draw.GetPen(Color.FromArgb(112, 109, 107)), 1, 1, Width - 2, 1);
            G.DrawLine(Draw.GetPen(Color.FromArgb(67, 63, 60)), 1, BarRect.Height - 1, Width - 2, BarRect.Height - 1);

            switch (_Shade)
            {
                case InnerShade.Light:
                    Color[] c = {
                    Color.FromArgb(153, 153, 153),
                    Color.FromArgb(173, 174, 177),
                    Color.FromArgb(200, 201, 204)
                };
                    Draw.InnerGlow(G, new Rectangle(1, 33, Width - 2, Height - 34), c);
                    break;
                case InnerShade.Dark:
                    Color[] c1 = {
                    Color.FromArgb(43, 40, 38),
                    Color.FromArgb(50, 47, 44),
                    Color.FromArgb(55, 52, 49)
                };
                    Draw.InnerGlow(G, new Rectangle(1, 33, Width - 2, Height - 34), c1);
                    break;
            }

            Font drawFont = new Font("Arial", 9, FontStyle.Bold);
            G.DrawString(Text, drawFont, Brushes.White, new Rectangle(15, 3, Width - 1, 26), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

