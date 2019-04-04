// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Butterscotch Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Butter
{

    
    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    static class Draw
    {
        
        public static GraphicsPath RoundRect(Rectangle rectangle, int curve)
        {
            GraphicsPath p = new GraphicsPath();
            int arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }
        public static GraphicsPath RoundRect(int x, int y, int width, int height, int curve)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height);
            GraphicsPath p = new GraphicsPath();
            int arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }

        //Special Thanks to Mephobia's for NoiseBrush Functions...
        public static TextureBrush NoiseBrush(Color[] colors)
        {
            Bitmap b = new Bitmap(128, 128);
            Random r = new Random(128);
            for (int x = 0; x <= b.Width - 1; x++)
            {
                for (int y = 0; y <= b.Height - 1; y++)
                {
                    b.SetPixel(x, y, colors[r.Next(colors.Length)]);
                }
            }
            TextureBrush T = new TextureBrush(b);
            b.Dispose();
            return T;
        }
    }

    public class ButterscotchTheme : ContainerControl
    {
        private System.Windows.Forms.Timer withEventsField__mytimer;
        public System.Windows.Forms.Timer _mytimer
        {
            get { return withEventsField__mytimer; }
            set
            {
                if (withEventsField__mytimer != null)
                {
                    withEventsField__mytimer.Tick -= MyTimer_Tick;
                }
                withEventsField__mytimer = value;
                if (withEventsField__mytimer != null)
                {
                    withEventsField__mytimer.Tick += MyTimer_Tick;
                }
            }
        }
        int _myval = 0;
        private Point _mousepos = new Point(0, 0);
        private bool _drag = false;

        private Icon _icon;
        public Icon Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                Invalidate();
            }
        }

        private bool _border = true;
        public bool Border
        {
            get { return _border; }
            set
            {
                _border = value;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(60, 7, Width - 141, 37).Contains(e.Location))
            {
                _drag = true;
                _mousepos = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _drag = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_drag)
            {
                Parent.Location = new Point(MousePosition.X - _mousepos.X, MousePosition.Y - _mousepos.Y);
            }
        }

        public ButterscotchTheme()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            _mytimer = new Timer();
            _mytimer.Interval = 2000;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle headrect = new Rectangle(60, 7, Width - 141, 37);
            base.OnPaint(e);
            g.Clear(Color.Fuchsia);
            TextureBrush bodygb = Draw.NoiseBrush(new Color[]{
            Color.FromArgb(34, 29, 23),
            Color.FromArgb(50, 45, 39)
        });
            g.FillPath(bodygb, Draw.RoundRect(rect, 3));
            try
            {
                g.DrawIcon(_icon, new Rectangle(8, 8, 38, 38));
            }
            catch
            {
            }
            if (_myval == 0)
            {
                g.DrawString(Text, new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(206, 209, 208)), headrect, new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
            }
            else if (_myval == 1)
            {
                g.DrawString(Text, new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(128, 128, 128)), headrect, new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
            }
            if (Border == true)
            {
                g.DrawPath(new Pen(Color.FromArgb(212, 212, 212), 3), Draw.RoundRect(rect, 3));
            }
            if (!DesignMode)
                _mytimer.Start();
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
            else if (_myval == 1)
            {
                _myval = 0;
            }
            Invalidate();
        }
    }

    
}
