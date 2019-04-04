// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Bullion
{

    public class BullionSeperator : Control
    {

        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                UpdateOffset();
                Invalidate();
            }
        }

        Graphics G;
        Bitmap B;
        int I;
        Color C1;
        Pen P1;
        Pen P2;
        public BullionSeperator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            C1 = Color.FromArgb(248, 248, 248);
            //Background
            P1 = new Pen(Color.FromArgb(230, 230, 230));
            //Shadow
            P2 = new Pen(Color.FromArgb(255, 255, 255));
            //Highlight
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateOffset();
            base.OnSizeChanged(e);
        }

        public void UpdateOffset()
        {
            I = Convert.ToInt32(_Orientation == 0 ? Height / 2 - 1 : Width / 2 - 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C1);

            if (_Orientation == 0)
            {
                G.DrawLine(P1, 0, I, Width, I);
                G.DrawLine(P2, 0, I + 1, Width, I + 1);
            }
            else
            {
                G.DrawLine(P2, I, 0, I, Height);
                G.DrawLine(P1, I + 1, 0, I + 1, Height);
            }

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

    }

}


