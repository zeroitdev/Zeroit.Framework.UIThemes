// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BitDefender
{


    public class BitdefenderButton : Control
    {

        #region "Init"
        public BitdefenderButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            Width = 100;
            Height = 55;
            BackColor = Color.Transparent;
        }


        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        private bool _Down;
        private bool Down
        {
            get { return _Down; }
            set
            {
                _Down = value;
                Invalidate();
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Down = true;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Down = false;
        }

        #region "Mouse state"

        private Thread OpenT;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OpenT = new Thread(EnterAnimation);
            if (!OpenT.IsAlive)
            {
                OpenT.IsBackground = true;
                OpenT.Start();
            }
        }
        private void EnterAnimation()
        {
            Graphics G = this.CreateGraphics();
            R2 = new Rectangle(5, 5, Width - 10, Height - 10);
            GP2 = Helper.RoundRect(R2, 11);
            G.SetClip(GP2);
            for (int fade = 0; fade <= 5; fade += Convert.ToInt32(0.85f))
            {
                Thread.Sleep(50);
                G.FillRectangle(new SolidBrush(Color.FromArgb(fade, Color.White)), ClientRectangle);
            }
        }


        #endregion

        #endregion


        #region "Draw"
        #region "Draw init Object"
        private Color C1;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;
        private SolidBrush B1;
        private SolidBrush B2;
        private Pen P1;
        private Pen P2;
        private LinearGradientBrush LGB1;
        private LinearGradientBrush LGB2;
        private StringFormat SF1;

        private Graphics G;
        private void Init(PaintEventArgs e)
        {
            G = e.Graphics;
            R1 = new Rectangle(3, 3, Width - 6, Height - 6);
            R2 = new Rectangle(5, 5, Width - 10, Height - 10);
            R3 = new Rectangle(6, 6, Width - 12, Height - 12);

            GP1 = Helper.RoundRect(R1, 11);
            GP2 = Helper.RoundRect(R2, 11);
            GP3 = Helper.RoundRect(R3, 11);


            C1 = Color.FromArgb(100, 41, 41, 41);
            C3 = Color.FromArgb(101, 101, 101);
            C4 = Color.FromArgb(60, 60, 60);
            C5 = Color.FromArgb(28, 28, 28);
            C6 = Color.FromArgb(45, 45, 45);

            B1 = new SolidBrush(C1);
            B2 = new SolidBrush(Color.White);
            LGB1 = new LinearGradientBrush(R2, C4, C5, LinearGradientMode.Vertical);
            LGB2 = new LinearGradientBrush(R3, C3, C6, LinearGradientMode.Vertical);

            P1 = new Pen(Brushes.Black);
            P2 = new Pen(LGB2);

            SF1 = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.Character
            };


        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Init(e);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillPath(B1, GP1);
            G.FillPath(LGB1, GP2);
            G.DrawPath(P1, GP2);
            G.DrawPath(P2, GP3);
            if (!Down)
            {
                G.DrawString(Text, Font, B2, R3, SF1);
            }
            else
            {
                R3.X += 1;
                R3.Y += 1;
                G.DrawString(Text, Font, B2, R3, SF1);
            }


        }


        #endregion

    }

    
}


