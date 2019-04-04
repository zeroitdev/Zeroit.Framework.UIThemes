// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchTrackBar : ThemeControl154
    {

        public TwitchTrackBar()
        {
            Width = 100;
            Height = 10;
            Transparent = true;
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(125, 30);
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            switch (State)
            {
                case MouseState.Over:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(245, 245, 245), Color.FromArgb(206, 206, 206), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
                case MouseState.None:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(207, 207, 207), Color.FromArgb(150, 150, 150), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
                case MouseState.Down:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(144, 144, 144), Color.FromArgb(100, 100, 100), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
                default:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(207, 207, 207), Color.FromArgb(150, 150, 150), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
            }

        }
    }

}

