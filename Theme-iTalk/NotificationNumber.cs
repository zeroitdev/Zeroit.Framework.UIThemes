// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="NotificationNumber.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  Notification Number 

    public class iTalkNotificationNumber : Control
    {
        #region  Variables 

        private int _Value = 0;
        private int _Maximum = 99;

        #endregion
        #region  Properties 

        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                    default:
                        return _Value;
                }
            }
            set
            {
                
                if (value > _Maximum)
                {
                    value = _Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        #endregion

        public iTalkNotificationNumber()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            Text = null;
            DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Make the width and height of the control unchangeable
            Height = 20;
            Width = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(18, 20)), Color.FromArgb(197, 69, 68), Color.FromArgb(176, 52, 52), 90.0F);

            e.Graphics.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(18, 18)));
            e.Graphics.DrawEllipse(new Pen(Color.FromArgb(205, 70, 66)), new Rectangle(new Point(0, 0), new Size(18, 18))); // Draw border
            e.Graphics.DrawString(_Value.ToString(), new Font("Segoe UI", 8F, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 253)), new Rectangle(0, 0, Width - 2, Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            e.Dispose();
        }
    }

    #endregion
}