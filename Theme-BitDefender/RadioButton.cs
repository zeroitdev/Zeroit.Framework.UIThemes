// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BitDefender
{

    public class BitdefenderRadiobutton : Control
    {
        #region "Init"
        #region "Event"
        public event ChangeCheckedEventHandler ChangeChecked;
        public delegate void ChangeCheckedEventHandler(object sender, bool check);
        private bool _Check;
        public bool Checked
        {
            get { return _Check; }
            set
            {
                _Check = value;
                Invalidate();

                if (ChangeChecked != null)
                {
                    ChangeChecked(this, value);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Checked = !Checked;
        }

        #endregion
        private int oldHeight;
        public BitdefenderRadiobutton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            Width = 100;
            Height = 15;
            BackColor = Color.Transparent;
            oldHeight = 15;
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Height = oldHeight;
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
        #endregion



        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;
        private LinearGradientBrush LGB1;
        private LinearGradientBrush LGB2;
        private Pen P1;
        private Pen P2;
        private Graphics G;
        private string S1;
        private Font F1;
        private void Init(PaintEventArgs e)
        {
            G = e.Graphics;

            R1 = new Rectangle(0, 0, Height - 1, Height - 1);
            R2 = new Rectangle(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2);
            R3 = new Rectangle(R2.X + 1, R2.Y + 1, R2.Width - 2, R2.Height - 2);

            GP1 = new GraphicsPath();
            GP1.AddEllipse(R1);
            GP2 = new GraphicsPath();
            GP2.AddEllipse(R2);
            GP3 = new GraphicsPath();
            GP3.AddEllipse(R3);

            LGB1 = new LinearGradientBrush(R1, Color.FromArgb(29, 29, 29), Color.FromArgb(39, 39, 39), LinearGradientMode.Vertical);
            LGB2 = new LinearGradientBrush(R3, Color.FromArgb(84, 135, 171), Color.FromArgb(113, 176, 200), LinearGradientMode.Vertical);

            P1 = Pens.Black;
            P2 = new Pen(new SolidBrush(Color.FromArgb(68, 68, 68)));

            S1 = Text;

            F1 = new Font("Verdana", 8, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Init(e);
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            if (Checked)
            {
                G.FillPath(LGB2, GP3);
                G.DrawPath(P1, GP3);
                G.DrawPath(P2, GP2);
                G.DrawString(S1, F1, new SolidBrush(Color.FromArgb(106, 166, 193)), 18, 1);
            }
            else
            {
                G.FillPath(LGB1, GP1);
                G.DrawPath(P1, GP1);
                G.DrawPath(P2, GP2);
                G.DrawString(S1, F1, new SolidBrush(Color.FromArgb(147, 147, 147)), 18, 1);
            }

        }
    }


}


