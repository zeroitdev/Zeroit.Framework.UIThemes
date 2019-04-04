// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region  Imports

using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
	
#endregion
	
	

namespace Zeroit.Framework.UIThemes.PlayUI
{
    #region  ControlBox

    public class PlayUIControlBox : Control
    {

        #region  Enums

        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        #endregion
        #region  MouseStates

        MouseState State = MouseState.None;
        int X;
        Rectangle MinBtn = new Rectangle(3, 2, 17, 17);
        Rectangle CloseBtn = new Rectangle(23, 2, 17, 17);

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (X > 0 && X < 17)
            {
                FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 20 && X < 40)
            {
                FindForm().Close();
            }

            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }
        #endregion

        public PlayUIControlBox()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer), true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Font = new Font("Marlett", 7);
            Anchor = (System.Windows.Forms.AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(45, 23);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Location = new Point(Parent.Width - 50, 5);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            LinearGradientBrush LGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(29, 29, 29), Color.FromArgb(29, 29, 29), 90);
            G.FillEllipse(LGBClose, CloseBtn);
            G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)), new Rectangle(26, 8, 0, 0));

            LinearGradientBrush LGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(29, 29, 29), Color.FromArgb(29, 29, 29), 90);
            G.FillEllipse(LGBMinimize, MinBtn);
            G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)), new Rectangle((int)6.5, 8, 0, 0));

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush xLGBClose_1 = new LinearGradientBrush(CloseBtn, Color.FromArgb(29, 29, 29), Color.FromArgb(29, 29, 29), 90);
                    G.FillEllipse(xLGBClose_1, CloseBtn);
                    G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)), new Rectangle(26, 8, 0, 0));

                    LinearGradientBrush xLGBMinimize_1 = new LinearGradientBrush(MinBtn, Color.FromArgb(29, 29, 29), Color.FromArgb(29, 29, 29), 90);
                    G.FillEllipse(xLGBMinimize_1, MinBtn);
                    G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)), new Rectangle((int)6.5, 8, 0, 0));
                    break;
                case MouseState.Over:
                    if (X > 23 && X < 40)
                    {
                        LinearGradientBrush xLGBClose = new LinearGradientBrush(CloseBtn, Color.FromArgb(37, 37, 37), Color.FromArgb(37, 37, 37), 90);
                        G.FillEllipse(xLGBClose, CloseBtn);
                        G.DrawString("r", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)), new Rectangle(26, 8, 0, 0));
                    }
                    else if (X > 3 && X < 20)
                    {
                        LinearGradientBrush xLGBMinimize = new LinearGradientBrush(MinBtn, Color.FromArgb(37, 37, 37), Color.FromArgb(37, 37, 37), 90);
                        G.FillEllipse(xLGBMinimize, MinBtn);
                        G.DrawString("0", new Font("Marlett", 7), new SolidBrush(Color.FromArgb(117, 117, 119)), new Rectangle((int)6.5, 8, 0, 0));
                    }
                    break;
            }

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}