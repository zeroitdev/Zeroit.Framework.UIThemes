// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Notification.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Easy
{
    public class EasyNotification : UserControl
    {
        private string _Text;

        // Initialize
        public EasyNotification()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(200, 25);
        }

        // Notification Property
        [Category("Appearance")]
        public string Notification
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            SizeF s = g.MeasureString(_Text, Font);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            int x = ClientSize.Width;
            int y = ClientSize.Height;

            // Notification Shadow
            g.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(5, 5, x, y));
            // Notification Fill
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, x - 5, y - 5));
            // Notification Text
            g.DrawString(_Text, Font, new SolidBrush(Color.Black), new PointF(5F, (float)(((y - 5) - s.Height) / 2.0)));
        }
    }
}
