// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Unique
{

    public class UniqueProgressBar : Control
    {
        private Timer _mytimer;
        private int _myval = 0;
        private int _val;
        public int Value
        {
            get
            {
                return _val;
            }
            set
            {
                if (value > _max)
                {
                    _val = _max;
                }
                else if (value < 0)
                {
                    _val = 0;
                }
                else
                {
                    _val = value;
                }
                Invalidate();
            }
        }

        private int _max;
        public int Maximum
        {
            get
            {
                return _max;
            }
            set
            {
                if (value < 1)
                {
                    _max = 1;
                }
                else
                {
                    _max = value;
                }
                if (value < _val)
                {
                    _val = _max;
                }
                Invalidate();
            }
        }

        private bool _showPercentage = false;
        public bool ShowPercentage
        {
            get
            {
                return _showPercentage;
            }
            set
            {
                _showPercentage = value;
                Invalidate();
            }
        }

        public UniqueProgressBar() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(200, 20);
            DoubleBuffered = true;
            _max = 100;
            _mytimer = new Timer();
            _mytimer.Interval = 500;
            SubscribeToEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            int percent = Convert.ToInt32((Width - 1) * (_val / (double)_max));
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(1, 1, percent - 3, Height - 3);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(new SolidBrush(Color.FromArgb(129, 127, 125)), Draw.RoundRect(outerrect, 3));
            if (percent != 0)
            {
                try
                {
                    if (_myval == 0)
                    {
                        g.FillPath(new SolidBrush(Color.FromArgb(72, 72, 72)), Draw.RoundRect(innerrect, 3));
                    }
                    else if (_myval == 1)
                    {
                        g.FillPath(new SolidBrush(Color.FromArgb(62, 62, 62)), Draw.RoundRect(innerrect, 3));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            if (!DesignMode)
            {
                _mytimer.Start();
            }
            if (_showPercentage)
            {
                g.DrawString(string.Format("{0}%", _val), new Font("Verdana", 10F, FontStyle.Regular), Brushes.White, new Rectangle(10, 1, Width - 1, Height - 1), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (_myval == 0)
            {
                _myval = 1;
            }
            else
            {
                _myval = 0;
            }
            Invalidate();
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            _mytimer.Tick += MyTimer_Tick;
        }

    }

}