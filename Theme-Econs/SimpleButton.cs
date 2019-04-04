// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="SimpleButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Zeroit.Framework.UIThemes.Econs
{
    public class EconsSimpleButton : ThemeControl154
    {

        public EconsSimpleButton()
        {
            Font = new Font("Segoe UI", 9);
            SetColor("Gradient top normal", 237, 237, 237);
            SetColor("Gradient top over", 242, 242, 242);
            SetColor("Gradient top down", 235, 235, 235);
            SetColor("Gradient bottom normal", 230, 230, 230);
            SetColor("Gradient bottom over", 235, 235, 235);
            SetColor("Gradient bottom down", 223, 223, 223);
            SetColor("Border", 167, 167, 167);
            SetColor("Text normal", 60, 60, 60);
            SetColor("Text down/over", 20, 20, 20);
            SetColor("Text disabled", Color.Gray);
        }

        Color GTN;
        Color GTO;
        Color GTD;
        Color GBN;
        Color GBO;
        Color GBD;
        Color Bo;
        Color TN;
        Color TD;
        Color TDO;
        protected override void ColorHook()
        {
            GTN = GetColor("Gradient top normal");
            GTO = GetColor("Gradient top over");
            GTD = GetColor("Gradient top down");
            GBN = GetColor("Gradient bottom normal");
            GBO = GetColor("Gradient bottom over");
            GBD = GetColor("Gradient bottom down");
            Bo = GetColor("Border");
            TN = GetColor("Text normal");
            TDO = GetColor("Text down/over");
            TD = GetColor("Text disabled");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            LinearGradientBrush LGB = default(LinearGradientBrush);
            G.SmoothingMode = SmoothingMode.HighQuality;


            switch (State)
            {
                case MouseState.None:
                    LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTN, GBN, 90f);
                    break;
                case MouseState.Over:
                    LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTO, GBO, 90f);
                    break;
                default:
                    LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTD, GBD, 90f);
                    break;
            }

            if (!Enabled)
            {
                LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), GTN, GBN, 90f);
            }

            GraphicsPath buttonpath = CreateRound(Rectangle.Round(LGB.Rectangle), 3);
            G.FillPath(LGB, CreateRound(Rectangle.Round(LGB.Rectangle), 3));
            if (!Enabled)
                G.FillPath(new SolidBrush(Color.FromArgb(50, Color.White)), CreateRound(Rectangle.Round(LGB.Rectangle), 3));
            G.SetClip(buttonpath);
            LGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 6), Color.FromArgb(80, Color.White), Color.Transparent, 90f);
            G.FillRectangle(LGB, Rectangle.Round(LGB.Rectangle));



            G.ResetClip();
            G.DrawPath(new Pen(Bo), buttonpath);

            if (Enabled)
            {
                switch (State)
                {
                    case MouseState.None:
                        DrawText(new SolidBrush(TN), HorizontalAlignment.Center, 1, 0);
                        break;
                    default:
                        DrawText(new SolidBrush(TDO), HorizontalAlignment.Center, 1, 0);
                        break;
                }
            }
            else
            {
                DrawText(new SolidBrush(TD), HorizontalAlignment.Center, 1, 0);
            }
        }
    }

}