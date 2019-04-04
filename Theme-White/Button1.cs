// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button1.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.WhitePure
{
    public class WhiteButton1 : ThemeControl153
    {

        public WhiteButton1()
        {
            Click += IveBeenClicked__ItTicklesLOL;
            this.Size = new Size(21, 20);

            //BEGIN BUTTON-STATE GRADIENTS
            SetColor("DownGradient2", 185, 185, 185);
            SetColor("DownGradient1", 225, 225, 225);

            SetColor("NoneGradient2", 225, 225, 225);
            SetColor("NoneGradient1", 185, 185, 185);
            //END BUTTON-STATE GRADIENTS


            SetColor("Grad1", 225, 225, 225);
            SetColor("Grad2", 185, 185, 185);

            SetColor("Text", Color.DarkBlue);
            SetColor("Border1", 12, Color.White);
            SetColor("Border2", Color.SlateGray);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private SolidBrush B1;
        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");

            B1 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
        }

        protected override void PaintHook()
        {
            switch (State)
            {
                case MouseState.None:
                    DrawGradient(C3, C4, ClientRectangle, 90f);
                    break;
                case MouseState.Over:
                    DrawGradient(C3, C4, ClientRectangle, 90f);
                    break;
                case MouseState.Down:
                    DrawGradient(C1, C2, ClientRectangle, 90f);
                    break;
            }


            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.White));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));


            DrawText(Brushes.DarkBlue, "X", HorizontalAlignment.Center, 0, 0);
            DrawBorders(P2);


            //DrawBorders(New Pen(Color.FromArgb(0, 168, 198)))
            //DrawCorners(BackColor)
        }

        public void IveBeenClicked__ItTicklesLOL(object sender, EventArgs e)
        {
            FindForm().Close();
        }
    }


}

