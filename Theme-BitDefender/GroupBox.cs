// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BitDefender
{

    public class BitdefenderGroupbox : ContainerControl
    {
        public BitdefenderGroupbox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            Width = 100;
            Height = 55;
            BackColor = Color.Transparent;
        }

        #region "property"
        [Browsable(false)]
        public string Text { get; set; }

        private string _Title = "Title";

        private string _SubTitle = "Subtitle";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Invalidate(false);
            }
        }
        public string Subtitle
        {
            get { return _SubTitle; }
            set
            {
                _SubTitle = value;
                Invalidate(false);
            }
        }
        #endregion


        private Rectangle R1;
        private Rectangle R2;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private Pen P1;
        private Pen P2;
        private SolidBrush B1;
        private SolidBrush B2;
        private Size SZ1;
        private Size SZ2;
        private Font F1;
        private Font F2;
        private string S1;
        private string S2;
        private Graphics G;
        private void Init(PaintEventArgs e)
        {
            G = e.Graphics;

            R1 = new Rectangle(3, 3, Width - 6, Height - 6);
            R2 = new Rectangle(4, 4, Width - 8, Height - 8);

            GP1 = Helper.RoundRect(R1, 11);
            GP2 = Helper.RoundRect(R2, 11);

            P1 = Pens.Black;
            P2 = new Pen(new SolidBrush(Color.FromArgb(68, 68, 68)));

            B1 = new SolidBrush(Color.FromArgb(41, 41, 41));
            B2 = new SolidBrush(Color.White);

            F1 = new Font("Verdana", 10, FontStyle.Bold);
            F2 = new Font("Verdana", 7, FontStyle.Regular);

            S1 = Title.ToUpper();
            S2 = Subtitle;

            SZ1 = G.MeasureString(S1, F1, Width).ToSize();
            SZ2 = G.MeasureString(S2, F2, Width).ToSize();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Init(e);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillPath(B1, GP1);

            G.DrawPath(P1, GP1);
            G.DrawPath(P2, GP2);

            G.DrawString(S1, F1, B2, Convert.ToInt32((Width - SZ1.Width) / 2), 20);
            G.DrawString(S2, F2, B2, Convert.ToInt32((Width - SZ2.Width) / 2), 32);

        }
    }
    
}


