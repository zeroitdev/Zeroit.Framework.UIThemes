// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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



    [DefaultEvent("ChangeChecked")]
    public class BitdefenderCheckbox : Control
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

        public BitdefenderCheckbox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            Width = 55;
            Height = 25;
            BackColor = Color.Transparent;
            oldsize = new Size(55, 25);
        }
        #endregion

        #region "draw"

        #region "draw init object"

        #region "Declaration draw object"
        private ContainerObjectDisposable cn;
        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;
        private Rectangle R4;
        private Rectangle R5;
        private Rectangle R6;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;
        private GraphicsPath GP4;
        private GraphicsPath GP5;
        private GraphicsPath GP6;
        private LinearGradientBrush LGB1;
        private LinearGradientBrush LGB2;
        private LinearGradientBrush LGB3;
        private LinearGradientBrush LGB4;
        private PathGradientBrush PGB1;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Graphics G;
        private Pen P1;
        private Pen P2;
        #endregion
        Size CheckSize;
        private void Init(PaintEventArgs e)
        {
            G = e.Graphics;
            cn = new ContainerObjectDisposable();
            R1 = new Rectangle(1, 1, Width - 2, Height - 2);
            R2 = new Rectangle(2, 2, Width - 4, Height - 4);

            GP1 = Helper.RoundRect(R1, 11);
            cn.AddObject(GP1);
            GP2 = Helper.RoundRect(R2, 11);
            cn.AddObject(GP2);

            B1 = new SolidBrush(Color.FromArgb(40, 40, 40));
            cn.AddObject(B1);
            if (Checked)
            {
                B2 = new SolidBrush(Color.FromArgb(84, 135, 171));
                PGB1 = new PathGradientBrush(GP2)
                {
                    CenterColor = Color.FromArgb(84, 135, 171),
                    SurroundColors = new Color[] { Color.FromArgb(113, 176, 200) },
                    FocusScales = new PointF(0.85f, 0.65f)
                };

            }
            else
            {
                B2 = new SolidBrush(Color.FromArgb(29, 29, 29));
                PGB1 = new PathGradientBrush(GP2)
                {
                    CenterColor = Color.FromArgb(29, 29, 29),
                    SurroundColors = new Color[] { Color.FromArgb(39, 39, 39) },
                    FocusScales = new PointF(0.85f, 0.65f)
                };
            }
            cn.AddObjectRange(new Brush[]{
            B2,
            PGB1
        });
            B3 = new SolidBrush(Color.FromArgb(107, 107, 107));
            cn.AddObject(B3);

            CheckSize = new Size(22, R2.Height);
            R3 = new Rectangle(Width - 2 - 22, 2, CheckSize.Width, CheckSize.Height);
            GP3 = Helper.RoundRect(R3, 11);
            R4 = new Rectangle(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2);
            GP4 = Helper.RoundRect(R4, 11);

            R5 = new Rectangle(0, 2, CheckSize.Width, CheckSize.Height);
            GP5 = Helper.RoundRect(R5, 11);
            R6 = new Rectangle(R5.X + 1, R5.Y + 1, R5.Width - 2, R5.Height - 2);
            GP6 = Helper.RoundRect(R6, 11);
            cn.AddObjectRange(new GraphicsPath[]{
            GP3,
            GP4,
            GP5,
            GP6
        });
            if (Hover)
            {
                LGB1 = new LinearGradientBrush(R3, Color.FromArgb(86, 86, 86), Color.FromArgb(42, 42, 42), LinearGradientMode.Vertical);
                LGB2 = new LinearGradientBrush(new Rectangle(R4.X - 1, R4.Y - 1, R4.Width + 2, R4.Height + 2), Color.FromArgb(147, 147, 147), Color.FromArgb(68, 68, 68), LinearGradientMode.Vertical);
                P1 = new Pen(LGB2);

                LGB3 = new LinearGradientBrush(R5, Color.FromArgb(86, 86, 86), Color.FromArgb(42, 42, 42), LinearGradientMode.Vertical);
                LGB4 = new LinearGradientBrush(new Rectangle(R6.X - 1, R6.Y - 1, R6.Width + 2, R6.Height + 2), Color.FromArgb(147, 147, 147), Color.FromArgb(68, 68, 68), LinearGradientMode.Vertical);
                P2 = new Pen(LGB4);

            }
            else
            {
                LGB1 = new LinearGradientBrush(R3, Color.FromArgb(59, 59, 59), Color.FromArgb(29, 29, 29), LinearGradientMode.Vertical);
                LGB2 = new LinearGradientBrush(new Rectangle(R4.X - 1, R4.Y - 1, R4.Width + 2, R4.Height + 2), Color.FromArgb(101, 101, 101), Color.FromArgb(42, 42, 42), LinearGradientMode.Vertical);
                P1 = new Pen(LGB2);

                LGB3 = new LinearGradientBrush(R5, Color.FromArgb(59, 59, 59), Color.FromArgb(29, 29, 29), LinearGradientMode.Vertical);
                LGB4 = new LinearGradientBrush(new Rectangle(R6.X - 1, R6.Y - 1, R6.Width + 2, R6.Height + 2), Color.FromArgb(101, 101, 101), Color.FromArgb(42, 42, 42), LinearGradientMode.Vertical);
                P2 = new Pen(LGB4);

            }
            cn.AddObjectRange(new Brush[]{
            LGB1,
            LGB2,
            LGB3,
            LGB4,
			//P1,
			//P2
		});

            cn.AddObjectRange(new Pen[]{

            P1,
            P2
        });


        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Init(e);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.FillPath(B1, GP1);


            if (Checked)
            {
                G.FillPath(B2, GP2);
                G.FillPath(PGB1, GP2);
                G.DrawPath(Pens.Black, GP2);
                if (Hover)
                {
                    G.FillPath(LGB1, GP3);
                    G.DrawPath(Pens.Black, GP3);
                    G.DrawPath(P1, GP4);
                    G.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), Brushes.Black, 7, 6);
                    G.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), Brushes.White, 7, 7);
                }
                else
                {
                    G.FillPath(LGB1, GP3);
                    G.DrawPath(Pens.Black, GP3);
                    G.DrawPath(P1, GP4);
                    G.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), Brushes.Black, 7, 6);
                    G.DrawString("ON", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), Brushes.White, 7, 7);
                }
            }
            else
            {
                G.FillPath(B1, GP1);
                G.FillPath(B2, GP2);
                G.FillPath(PGB1, GP2);
                G.DrawPath(Pens.Black, GP2);
                if (Hover)
                {
                    G.FillPath(LGB3, GP5);
                    G.DrawPath(Pens.Black, GP5);
                    G.DrawPath(P2, GP6);
                    G.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), Brushes.Black, Width - 29, 6);
                    G.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), B3, Width - 29, 7);
                }
                else
                {
                    G.FillPath(LGB3, GP5);
                    G.DrawPath(Pens.Black, GP5);
                    G.DrawPath(P2, GP6);
                    G.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), Brushes.Black, Width - 29, 6);
                    G.DrawString("OFF", new Font("Microsoft Sans Serif", 7, FontStyle.Bold), B3, Width - 29, 7);
                }

            }
            cn.Dispose();
        }
        private bool _Hover;
        private bool Hover
        {
            get { return _Hover; }
            set
            {
                _Hover = value;
                Invalidate();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Hover = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Hover = false;
        }

        Size oldsize;
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            this.Size = oldsize;

        }
        #endregion

    }
    

}


