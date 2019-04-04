// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BitDefender
{


    public class BitdefenderSeparator : Control
    {
        public BitdefenderSeparator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            Width = 400;
            Height = 3;
            BackColor = Color.Transparent;
        }

        #region "Declarations"
        private Graphics G;
        private LinearGradientBrush LGB1;
        private LinearGradientBrush LGB2;
        private Pen P1;
        private Pen P2;
        private ColorBlend CB1;
        private ColorBlend CB2;
        private Color C1;
        private Color C2;
        #endregion
        private ContainerObjectDisposable conObj = new ContainerObjectDisposable();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //#Zone " Declarations "
            List<Color> Colors1 = new List<Color>();
            List<Color> Colors2 = new List<Color>();

            C1 = Color.FromArgb(62, 62, 62);
            C2 = Color.FromArgb(1, 1, 1);

            G = e.Graphics;

            LGB1 = new LinearGradientBrush(new Point(0, 0), new Point(Width, 0), Color.Transparent, Color.Transparent);
            LGB2 = new LinearGradientBrush(new Point(0, 1), new Point(Width, 1), Color.Transparent, Color.Transparent);
            conObj.AddObjectRange(new LinearGradientBrush[]{
            LGB1,
            LGB2
        });

            CB1 = new ColorBlend();
            CB2 = new ColorBlend();
            //#End Zone

            //#Zone " Colors first line "
            for (int i = 0; i <= 255; i += 51)
            {
                Colors1.Add(Color.FromArgb(i, C1));
            }
            for (int i = 255; i >= 0; i += -51)
            {
                Colors1.Add(Color.FromArgb(i, C1));
            }
            //#End Zone

            //#Zone " Colors Second line "
            for (int i = 0; i <= 255; i += 51)
            {
                Colors2.Add(Color.FromArgb(i, C2));
            }
            for (int i = 255; i >= 0; i += -51)
            {
                Colors2.Add(Color.FromArgb(i, C2));
            }
            //#End Zone

            //#Zone " colorblend first line  "
            CB1.Colors = Colors1.ToArray();
            CB1.Positions = new float[]{
            0.0f,
            0.08f,
            0.16f,
            0.24f,
            0.32f,
            0.4f,
            0.48f,
            0.56f,
            0.64f,
            0.72f,
            0.8f,
            1.0f
        };
            //#End Zone

            //#Zone " colorblend second line "
            CB2.Colors = Colors2.ToArray();
            CB2.Positions = new float[]{
            0.0f,
            0.08f,
            0.16f,
            0.24f,
            0.32f,
            0.4f,
            0.48f,
            0.56f,
            0.64f,
            0.72f,
            0.8f,
            1.0f
        };
            //#End Zone

            //#Zone " Pen "
            LGB1.InterpolationColors = CB1;
            LGB2.InterpolationColors = CB2;

            P1 = new Pen(LGB1);
            P2 = new Pen(LGB2);
            conObj.AddObjectRange(new Pen[]{
            P1,
            P2
        });
            //#End Zone

            G.DrawLine(P1, 0, 0, Width, 0);
            G.DrawLine(P2, 0, 1, Width, 1);

            conObj.Dispose();
        }
    }
    

}


