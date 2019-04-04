// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Minimize.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Metro
{

    public class MetroUIMinimize : ThemeControl154
    {
        public MetroUIMinimize()
        {
            LockHeight = 20;
            LockWidth = 20;
            SetColor("buttonc", Color.White);
            SetColor("textc", Color.Black);
            Font = new Font("Segoe UI", 12);
        }

        private Color buttonc;
        private Brush textc;
        protected override void ColorHook()
        {
            buttonc = GetColor("buttonc");
            textc = GetBrush("textc");
        }

        protected override void PaintHook()
        {
            G.Clear(buttonc);

            switch (State)
            {
                case MouseState.None:
                    G.DrawString("0", new Font("Marlett", 10), new SolidBrush(Color.Black), new Point(2, 2));

                    break;
                case MouseState.Over:
                    G.DrawString("0", new Font("Marlett", 10), new SolidBrush(Color.Green), new Point(2, 2));
                    break;
                case MouseState.Down:
                    G.DrawString("0", new Font("Marlett", 10), new SolidBrush(Color.DarkGreen), new Point(2, 2));
                    break;
                case MouseState.Block:
                    break;
            }

        }
    }


}


