// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Deumos
{
    public class DeumosGroupBox : ThemeContainer153
    {

        public DeumosGroupBox()
        {
            ControlMode = true;

            SetColor("Back", 14, 14, 14);
            SetColor("MainFill", 20, 20, 20);
            SetColor("MainOutline1", 32, 32, 32);
            SetColor("MainOutline2", Color.Black);
            SetColor("TitleShadow", 50, Color.Black);
            SetColor("TitleFill", 20, 20, 20);
            SetColor("Text", Color.White);
            SetColor("TitleOutline1", 32, 32, 32);
            SetColor("TitleOutline2", Color.Black);

            BackColor = Color.FromArgb(20, 20, 20);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("Back");

            B1 = new SolidBrush(GetColor("MainFill"));
            B2 = new SolidBrush(GetColor("TitleFill"));
            B3 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("MainOutline1"));
            P2 = new Pen(GetColor("MainOutline2"));
            P3 = new Pen(GetColor("TitleShadow"));
            P4 = new Pen(GetColor("TitleOutline1"));
            P5 = new Pen(GetColor("TitleOutline2"));

            BackColor = GetColor("MainFill");
        }

        private Color C1;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;

        private Pen P5;
        private Size S1;

        private Rectangle R1;
        protected override void PaintHook()
        {
            G.Clear(C1);

            if (this.Text.Length == 0)
            {
                G.FillRectangle(B1, ClientRectangle);
                DrawBorders(P1, 1);
                DrawBorders(P2);
            }
            else
            {
                G.FillRectangle(B1, 0, 13, Width, Height - 13);
                DrawBorders(P1, 0, 13, Width, Height - 13, 1);
                DrawBorders(P2, 0, 13, Width, Height - 13);


                S1 = Measure();
                R1 = new Rectangle(8, 0, S1.Width + 16, 26);

                DrawBorders(P3, 7, 0, R1.Width + 1, 27);

                G.FillRectangle(B2, R1);

                DrawText(B3, Center(R1, S1));

                DrawBorders(P4, R1, 1);
                DrawBorders(P5, R1);

                DrawCorners(C1, 0, 13, Width, Height - 13);
            }

        }

    }


}


