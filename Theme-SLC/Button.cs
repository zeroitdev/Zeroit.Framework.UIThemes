// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{

    #region "SLCbtn"
    public class SLCbtn : ThemeControl154
    {



        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Color.White);

            switch (State)
            {
                case MouseState.None:

                    //// bnt form

                    LinearGradientBrush linear0 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                    GraphicsPath gp0 = new GraphicsPath();
                    gp0 = CreateRound(0, 0, Width - 1, Height - 1, 7);
                    G.FillPath(linear0, gp0);
                    G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp0);
                    G.SetClip(gp0);
                    GraphicsPath btninsideborder = CreateRound(1, 1, Width - 3, Height - 3, 7);
                    G.DrawPath(new Pen(Color.White, 1), btninsideborder);
                    G.ResetClip();

                    //// circle



                    //Dim GPF As New GraphicsPath
                    //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                    //Dim PB2 As PathGradientBrush
                    //PB2 = New PathGradientBrush(GPF)
                    //PB2.CenterColor = Color.FromArgb(69, 128, 156)
                    //PB2.SurroundColors = {Color.FromArgb(8, 25, 33)}
                    //PB2.FocusScales = New PointF(0.9F, 0.9F)


                    //G.FillPath(PB2, GPF)

                    //G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)

                    //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                    DrawText(new SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1);
                    break;
                case MouseState.Down:
                    //// bnt form

                    LinearGradientBrush linear1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                    GraphicsPath gp1 = new GraphicsPath();
                    gp1 = CreateRound(0, 0, Width - 1, Height - 1, 7);
                    G.FillPath(linear1, gp1);
                    G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp1);
                    G.SetClip(gp1);
                    GraphicsPath btninsideborder1 = CreateRound(1, 1, Width - 3, Height - 3, 7);
                    G.DrawPath(new Pen(Color.White, 1), btninsideborder1);
                    G.ResetClip();

                    //// circle



                    //Dim GPF As New GraphicsPath
                    //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                    //Dim PB2 As PathGradientBrush
                    //PB2 = New PathGradientBrush(GPF)
                    //PB2.CenterColor = Color.FromArgb(86, 161, 196)
                    //PB2.SurroundColors = {Color.FromArgb(94, 176, 215)}
                    //PB2.FocusScales = New PointF(0.9F, 0.9F)


                    //G.FillPath(PB2, GPF)

                    //G.DrawPath(New Pen(Color.FromArgb(105, 194, 236)), GPF)

                    //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                    DrawText(new SolidBrush(Color.FromArgb(86, 161, 196)), HorizontalAlignment.Left, 5, 1);

                    break;
                case MouseState.Over:
                    //// bnt form

                    LinearGradientBrush linear2 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90f);
                    GraphicsPath gp2 = new GraphicsPath();
                    gp2 = CreateRound(0, 0, Width - 1, Height - 1, 7);
                    G.FillPath(linear2, gp2);
                    G.DrawPath(new Pen(Color.FromArgb(105, 112, 115)), gp2);
                    G.SetClip(gp2);
                    GraphicsPath btninsideborder2 = CreateRound(1, 1, Width - 3, Height - 3, 7);
                    G.DrawPath(new Pen(Color.FromArgb(50, Color.Gray), 1), btninsideborder2);
                    G.ResetClip();

                    //// circle


                    //Dim GPF As New GraphicsPath
                    //GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                    //Dim PB2 As PathGradientBrush
                    //PB2 = New PathGradientBrush(GPF)
                    //PB2.CenterColor = Color.FromArgb(69, 128, 156)
                    //PB2.SurroundColors = {Color.FromArgb(8, 25, 33)}
                    //PB2.FocusScales = New PointF(0.9F, 0.9F)


                    //G.FillPath(PB2, GPF)

                    //G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
                    //G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))
                    DrawText(new SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1);
                    break;
            }

        }
    }
    #endregion

}

