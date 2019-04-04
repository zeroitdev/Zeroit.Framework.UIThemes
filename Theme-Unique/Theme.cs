// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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

    internal enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2
    }


    internal static class Draw
    {
        
        public static GraphicsPath RoundRect(Rectangle rectangle, int curve)
        {
            GraphicsPath p = new GraphicsPath();
            int arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180F, 90F);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90F, 90F);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0F, 90F);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90F, 90F);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }
        public static GraphicsPath RoundRect(int x, int y, int width, int height, int curve)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height);
            GraphicsPath p = new GraphicsPath();
            int arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180F, 90F);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90F, 90F);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0F, 90F);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90F, 90F);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }
    }


    public class UniqueTheme : ContainerControl
{
	private Timer _mytimer;
	private int _myval = 0;
	private Point _mousepos = new Point(0, 0);
	private bool _drag = false;
	private Icon _icon;
	public Icon Icon
	{
		get
		{
			return _icon;
		}
		set
		{
			_icon = value;
			Invalidate();
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left && (new Rectangle(55, 1, Width - 180, 35)).Contains(e.Location))
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

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		Invalidate();
	}

	public UniqueTheme() : base()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
		BackColor = Color.FromArgb(32, 32, 32);
		DoubleBuffered = true;
		_mytimer = new Timer();
		_mytimer.Interval = 1000;
		SubscribeToEvents();
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
		Rectangle outerrect = new Rectangle(7, 18, Width - 15, Height - 19);
		Rectangle innerrect = new Rectangle(11, 22, Width - 23, Height - 27);
		Rectangle headleftrecct = new Rectangle(1, 1, 35, 35);
		Rectangle headcenterrect = new Rectangle(55, 1, Width - 180, 35);
		Rectangle headrightrecct = new Rectangle(Width - 105, 1, 100, 35);
		base.OnPaint(e);
		g.Clear(Color.Fuchsia);
		g.FillPath(new SolidBrush(Color.FromArgb(89, 87, 85)), Draw.RoundRect(outerrect, 3));
		g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(outerrect, 3));
		g.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), Draw.RoundRect(innerrect, 3));
		g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(innerrect, 3));
		LinearGradientBrush leftheader = new LinearGradientBrush(headleftrecct, Color.FromArgb(56, 68, 85), Color.FromArgb(41, 42, 46), LinearGradientMode.Vertical);
		g.FillPath(leftheader, Draw.RoundRect(headleftrecct, 4));
		g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(headleftrecct, 4));
		LinearGradientBrush centerheader = new LinearGradientBrush(headcenterrect, Color.FromArgb(56, 68, 85), Color.FromArgb(41, 42, 46), LinearGradientMode.Vertical);
		g.FillPath(centerheader, Draw.RoundRect(headcenterrect, 4));
		g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(headcenterrect, 4));
		LinearGradientBrush rightheader = new LinearGradientBrush(headcenterrect, Color.FromArgb(56, 68, 85), Color.FromArgb(41, 42, 46), LinearGradientMode.Vertical);
		g.FillPath(rightheader, Draw.RoundRect(headrightrecct, 4));
		g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(headrightrecct, 4));
		try
		{
			g.DrawIcon(_icon, new Rectangle(6, 6, 26, 26));
		}
		catch (Exception ex)
		{
		}
		if (_myval == 0)
		{
			g.DrawString(Text, new Font("Verdana", 11F, FontStyle.Bold), new SolidBrush(Color.FromArgb(180, 180, 180)), headcenterrect, new StringFormat() {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
		}
		else if (_myval == 1)
		{
			g.DrawString(Text, new Font("Verdana", 11F, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), headcenterrect, new StringFormat() {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
		}
		if (!DesignMode)
		{
			_mytimer.Start();
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