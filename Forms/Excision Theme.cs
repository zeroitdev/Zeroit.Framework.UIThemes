// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Excision Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Excision
{


    
    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    static class Draw
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

    }
    public class ImageToCodeClass
    {
        public string ImageToCode(Bitmap Img)
        {
            return Convert.ToBase64String((byte[])System.ComponentModel.TypeDescriptor.GetConverter(Img).ConvertTo(Img, typeof(byte[])));
        }

        public Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }
    }
    public class ExcisionTheme : ContainerControl
    {
        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }
        public ExcisionTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(25, 25, 25);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle CR = new Rectangle(0, 0, Width - 1, 35);
            Rectangle Main = new Rectangle(0, 35, Width, Height - 35);

            base.OnPaint(e);

            G.Clear(Color.Fuchsia);

            G.CompositingQuality = CompositingQuality.HighQuality;

            ImageToCodeClass itc = new ImageToCodeClass();
            Bitmap BG = (Bitmap)itc.CodeToImage("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");
            TextureBrush BGT = new TextureBrush(BG, WrapMode.TileFlipXY);
            G.FillRectangle(BGT, Main);


            LinearGradientBrush lbb = new LinearGradientBrush(CR, Color.FromArgb(68, 68, 68), Color.FromArgb(45, 45, 45), 90);
            G.FillRectangle(lbb, CR);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), CR);

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 0, 36, Width - 1, 36);

            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(15, 15, 15))), CreateRound(new Rectangle(0, 0, Width - 1, Height - 1), 10));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(88, 88, 88))), CreateRound(new Rectangle(1, 1, Width - 3, Height - 3), 10));

            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            G.DrawString(Parent.FindForm().Text, drawFont, Brushes.WhiteSmoke, 12, 10);

            //////left upper corner
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);
            //'////right upper corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1);
            //'////left bottom corner
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            //G.FillRectangle(Brushes.Fuchsia, 2, Height - 2, 1, 1)
            //'////right bottom corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1);


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 35;
        private int pos = 0;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
        }
    }

    #region Duplicate
    //public class ExcisionButtonDefault : Control
    //{
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    #endregion

    //    public ExcisionButtonDefault()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
    //        Rectangle InnerRect = new Rectangle(1, 1, Width - 3, Height - 3);


    //        base.OnPaint(e);

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);

    //        //G.CompositingQuality = CompositingQuality.HighQuality
    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        ImageToCodeClass cti = new ImageToCodeClass();

    //        Bitmap BUTTONGRAIN = (Bitmap)cti.CodeToImage("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");
    //        TextureBrush BUTTONIMAGE = new TextureBrush(BUTTONGRAIN, WrapMode.TileFlipXY);
    //        G.FillPath(BUTTONIMAGE, Draw.RoundRect(ClientRectangle, 4));
    //        Pen p = new Pen(new SolidBrush(Color.FromArgb(117, 120, 117)));
    //        G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //        Pen Ip = new Pen(Color.FromArgb(45, Color.White));
    //        G.DrawPath(Ip, Draw.RoundRect(InnerRect, 4));

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Down:
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });

    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionCircleButton : Control
    //{
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    #endregion

    //    public ExcisionCircleButton()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        Size = new Size(64, 64);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
    //        Rectangle InnerRect = new Rectangle(1, 1, Width - 3, Height - 3);


    //        base.OnPaint(e);

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);

    //        //G.CompositingQuality = CompositingQuality.HighQuality
    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        ImageToCodeClass cti = new ImageToCodeClass();

    //        Bitmap BUTTONGRAIN = (Bitmap)cti.CodeToImage("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");
    //        TextureBrush BUTTONIMAGE = new TextureBrush(BUTTONGRAIN, WrapMode.TileFlipXY);
    //        G.FillEllipse(BUTTONIMAGE, ClientRectangle);
    //        Pen p = new Pen(new SolidBrush(Color.FromArgb(117, 120, 117)));
    //        G.DrawEllipse(Pens.Black, ClientRectangle);
    //        Pen Ip = new Pen(Color.FromArgb(45, Color.White));
    //        G.DrawEllipse(Ip, InnerRect);

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Down:
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });

    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionButtonBlue : Control
    //{
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    #endregion

    //    public ExcisionButtonBlue()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
    //        Rectangle InnerRect = new Rectangle(1, 1, Width - 3, Height - 3);


    //        base.OnPaint(e);

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);

    //        //G.CompositingQuality = CompositingQuality.HighQuality
    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                LinearGradientBrush BBG = new LinearGradientBrush(ClientRectangle, Color.FromArgb(85, 156, 188), Color.FromArgb(58, 136, 175), 90);
    //                G.FillPath(BBG, Draw.RoundRect(ClientRectangle, 4));
    //                Pen p = new Pen(new SolidBrush(Color.FromArgb(29, 46, 54)));
    //                G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //                Pen Ip = new Pen(Color.FromArgb(129, 175, 201));
    //                G.DrawPath(Ip, Draw.RoundRect(InnerRect, 4));
    //                break;
    //            case MouseState.Over:
    //                LinearGradientBrush BBG1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(45, 105, 135), Color.FromArgb(30, 90, 120), 90);
    //                G.FillPath(BBG1, Draw.RoundRect(ClientRectangle, 4));
    //                Pen p1 = new Pen(new SolidBrush(Color.FromArgb(29, 46, 54)));
    //                G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //                Pen Ip1 = new Pen(Color.FromArgb(114, 160, 186));
    //                G.DrawPath(Ip1, Draw.RoundRect(InnerRect, 4));
    //                break;
    //            case MouseState.Down:
    //                LinearGradientBrush BBG2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(85, 156, 188), Color.FromArgb(58, 136, 175), 90);
    //                G.FillPath(BBG2, Draw.RoundRect(ClientRectangle, 4));
    //                Pen p2 = new Pen(new SolidBrush(Color.FromArgb(29, 46, 54)));
    //                G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //                Pen Ip2 = new Pen(Color.FromArgb(129, 175, 201));
    //                G.DrawPath(Ip2, Draw.RoundRect(InnerRect, 4));
    //                break;
    //        }
    //        G.DrawString(Text, drawFont, new SolidBrush(Color.WhiteSmoke), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //        {
    //            Alignment = StringAlignment.Center,
    //            LineAlignment = StringAlignment.Center
    //        });


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionButtonWhite : Control
    //{
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    #endregion

    //    public ExcisionButtonWhite()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
    //        Rectangle InnerRect = new Rectangle(1, 1, Width - 3, Height - 3);


    //        base.OnPaint(e);

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);

    //        //G.CompositingQuality = CompositingQuality.HighQuality
    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                LinearGradientBrush BBG = new LinearGradientBrush(ClientRectangle, Color.FromArgb(225, 225, 225), Color.FromArgb(210, 210, 210), 90);
    //                G.FillPath(BBG, Draw.RoundRect(ClientRectangle, 4));
    //                Pen p = new Pen(new SolidBrush(Color.FromArgb(254, 254, 254)));
    //                G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //                Pen Ip = new Pen(Color.FromArgb(255, 255, 255));
    //                G.DrawPath(Ip, Draw.RoundRect(InnerRect, 4));
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(82, 87, 93)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                LinearGradientBrush BBG1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(222, 222, 222), Color.FromArgb(222, 222, 222), 90);
    //                G.FillPath(BBG1, Draw.RoundRect(ClientRectangle, 4));
    //                Pen p1 = new Pen(new SolidBrush(Color.FromArgb(222, 222, 222)));
    //                G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //                Pen Ip1 = new Pen(Color.FromArgb(255, 255, 255));
    //                G.DrawPath(Ip1, Draw.RoundRect(InnerRect, 4));
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(85, 85, 85)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });

    //                break;
    //            case MouseState.Down:
    //                LinearGradientBrush BBG2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(254, 254, 254), Color.FromArgb(248, 246, 247), 90);
    //                G.FillPath(BBG2, Draw.RoundRect(ClientRectangle, 4));
    //                Pen p2 = new Pen(new SolidBrush(Color.FromArgb(254, 254, 254)));
    //                G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
    //                Pen Ip2 = new Pen(Color.FromArgb(255, 255, 255));
    //                G.DrawPath(Ip2, Draw.RoundRect(InnerRect, 4));
    //                G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(82, 87, 93)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionSeparator : Control
    //{
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    #endregion
    //    private bool _Horizontal = true;
    //    public bool Horizontal
    //    {
    //        get { return _Horizontal; }
    //        set
    //        {
    //            _Horizontal = value;
    //            Invalidate();
    //        }
    //    }
    //    public ExcisionSeparator()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.FixedHeight, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        Height = 4;
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);


    //        base.OnPaint(e);

    //        G.Clear(BackColor);

    //        //G.CompositingQuality = CompositingQuality.HighQuality
    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        switch (_Horizontal)
    //        {
    //            case true:
    //                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(26, 24, 25))), 0, 0, Width - 1, 0);
    //                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(75, 73, 74))), 0, 1, Width - 1, 1);
    //                break;
    //            case false:
    //                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(26, 24, 25))), 0, 0, 0, Height - 1);
    //                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(75, 73, 74))), 1, 0, 1, Height - 1);
    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionGroupBox : ContainerControl
    //{

    //    public ExcisionGroupBox()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        DoubleBuffered = true;
    //    }
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle Top = new Rectangle(0, 0, Width - 1, 45);
    //        Rectangle TopInner = new Rectangle(1, 1, Width - 3, 43);
    //        Rectangle Bottom = new Rectangle(0, 43, Width - 1, Height - 44);
    //        Rectangle BottomInner = new Rectangle(1, 45, Width - 3, Height - 47);

    //        base.OnPaint(e);

    //        G.Clear(Color.Transparent);
    //        ImageToCodeClass d = new ImageToCodeClass();

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;

    //        Bitmap GRAINIMAGE2 = (Bitmap)d.CodeToImage("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");
    //        TextureBrush TEXTUREIMAGE2 = new TextureBrush(GRAINIMAGE2, WrapMode.TileFlipXY);
    //        G.FillPath(TEXTUREIMAGE2, Draw.RoundRect(Bottom, 2));
    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 24, 25))), Draw.RoundRect(Bottom, 2));
    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(10, Color.White))), Draw.RoundRect(BottomInner, 2));


    //        Bitmap GRAINIMAGE = (Bitmap)d.CodeToImage("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");
    //        TextureBrush TEXTUREIMAGE = new TextureBrush(GRAINIMAGE, WrapMode.TileFlipXY);
    //        G.FillPath(TEXTUREIMAGE, Draw.RoundRect(Top, 2));
    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 24, 25))), Draw.RoundRect(Top, 2));
    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(10, Color.White))), Draw.RoundRect(TopInner, 2));

    //        G.DrawString(Text, new Font("Tahoma", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(229, 229, 229)), new Rectangle(14, 14, Width - 1, Height - 1), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Near
    //        });


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionPanel : ContainerControl
    //{

    //    public ExcisionPanel()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        Size = new Size(100, 45);
    //        DoubleBuffered = true;
    //    }
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle MainRect = new Rectangle(0, 0, Width - 1, Height - 1);

    //        base.OnPaint(e);

    //        G.Clear(Color.Transparent);
    //        ImageToCodeClass d = new ImageToCodeClass();

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;

    //        G.FillPath(new SolidBrush(Color.FromArgb(58, 56, 57)), Draw.RoundRect(MainRect, 3));
    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(77, 77, 77))), Draw.RoundRect(MainRect, 3));

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //[DefaultEvent("CheckedChanged")]
    //public class ExcisionCheckBox : Control
    //{

    //    #region " Control Help - MouseState & Flicker Control"
    //    private MouseState State = MouseState.None;
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnTextChanged(System.EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }
    //    private bool _Checked;
    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            Invalidate();
    //        }
    //    }
    //    protected override void OnResize(System.EventArgs e)
    //    {
    //        base.OnResize(e);
    //        Height = 14;
    //    }
    //    protected override void OnClick(System.EventArgs e)
    //    {
    //        _Checked = !_Checked;
    //        if (CheckedChanged != null)
    //        {
    //            CheckedChanged(this);
    //        }
    //        base.OnClick(e);
    //    }
    //    public event CheckedChangedEventHandler CheckedChanged;
    //    public delegate void CheckedChangedEventHandler(object sender);
    //    #endregion


    //    public ExcisionCheckBox() : base()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.Black;
    //        Size = new Size(145, 16);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle checkBoxRectangle = new Rectangle(0, 0, Height, Height - 1);
    //        Rectangle Inner = new Rectangle(1, 1, Height - 2, Height - 3);

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;
    //        G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

    //        G.Clear(Color.Transparent);

    //        LinearGradientBrush bodyGrad = new LinearGradientBrush(checkBoxRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(45, 45, 45), 90);
    //        G.FillRectangle(bodyGrad, bodyGrad.Rectangle);
    //        G.DrawRectangle(new Pen(Color.FromArgb(26, 26, 26)), checkBoxRectangle);
    //        G.DrawRectangle(new Pen(Color.FromArgb(70, 70, 70)), Inner);

    //        if (Checked)
    //        {
    //            Font t = new Font("Marlett", 10, FontStyle.Regular);
    //            G.DrawString("a", t, new SolidBrush(Color.FromArgb(222, 222, 222)), -1.5f, 0);
    //        }

    //        Font drawFont = new Font("Tahoma", 8, FontStyle.Bold);
    //        Brush nb = new SolidBrush(Color.FromArgb(200, 200, 200));
    //        G.DrawString(Text, drawFont, nb, new Point(18, 7), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();

    //    }

    //}
    //[DefaultEvent("CheckedChanged")]
    //public class ExcisionRadioButton : Control
    //{

    //    #region " Control Help - MouseState & Flicker Control"
    //    private Rectangle R1;

    //    private LinearGradientBrush G1;
    //    private MouseState State = MouseState.None;
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnResize(System.EventArgs e)
    //    {
    //        base.OnResize(e);
    //        Height = 16;
    //    }
    //    protected override void OnTextChanged(System.EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }
    //    private bool _Checked;
    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            InvalidateControls();
    //            if (CheckedChanged != null)
    //            {
    //                CheckedChanged(this);
    //            }
    //            Invalidate();
    //        }
    //    }
    //    protected override void OnClick(EventArgs e)
    //    {
    //        if (!_Checked)
    //            Checked = true;
    //        base.OnClick(e);
    //    }
    //    public event CheckedChangedEventHandler CheckedChanged;
    //    public delegate void CheckedChangedEventHandler(object sender);
    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        InvalidateControls();
    //    }
    //    private void InvalidateControls()
    //    {
    //        if (!IsHandleCreated || !_Checked)
    //            return;

    //        foreach (Control C in Parent.Controls)
    //        {
    //            if (!object.ReferenceEquals(C, this) && C is ExcisionRadioButton)
    //            {
    //                ((ExcisionRadioButton)C).Checked = false;
    //            }
    //        }
    //    }
    //    #endregion

    //    public ExcisionRadioButton() : base()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.Black;
    //        Size = new Size(150, 16);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        dynamic radioBtnRectangle = new Rectangle(0, 0, Height, Height - 1);
    //        Rectangle Inner = new Rectangle(1, 1, Height - 2, Height - 3);

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;
    //        G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

    //        G.Clear(BackColor);

    //        LinearGradientBrush bgGrad = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(45, 45, 45), 90);
    //        G.FillEllipse(bgGrad, radioBtnRectangle);

    //        G.DrawEllipse(new Pen(Color.FromArgb(26, 26, 26)), radioBtnRectangle);
    //        G.DrawEllipse(new Pen(Color.FromArgb(70, 70, 70)), Inner);

    //        if (Checked)
    //        {
    //            Font t = new Font("Marlett", 6, FontStyle.Bold);
    //            G.DrawString("n", t, new SolidBrush(Color.FromArgb(222, 222, 222)), 3, 4);
    //        }

    //        Font drawFont = new Font("Tahoma", 8, FontStyle.Bold);
    //        Brush nb = new SolidBrush(Color.FromArgb(200, 200, 200));
    //        G.DrawString(Text, drawFont, nb, new Point(18, 7), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }

    //}
    //public class ExcisionControlBox : Control
    //{
    //    public ExcisionControlBox()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        Size = new Size(65, 26);
    //        DoubleBuffered = true;
    //    }
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    int X;
    //    Rectangle MinBtn = new Rectangle(0, 0, 32, 25);
    //    Rectangle CloseBtn = new Rectangle(33, 0, 65, 25);
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        if (X > MinBtn.X & X < MinBtn.X + 32)
    //        {
    //            Parent.FindForm().WindowState = FormWindowState.Minimized;
    //        }
    //        else
    //        {
    //            Parent.FindForm().Close();
    //        }
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseMove(e);
    //        X = e.Location.X;
    //        Invalidate();
    //    }
    //    #endregion
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, 64, 25);
    //        Rectangle InnerRect = new Rectangle(1, 1, 62, 23);


    //        base.OnPaint(e);

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Marlett", 10, FontStyle.Bold);

    //        //G.CompositingQuality = CompositingQuality.HighQuality
    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Near,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                if (X > MinBtn.X & X < MinBtn.X + 32)
    //                {
    //                    G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Near,
    //                        LineAlignment = StringAlignment.Center
    //                    });
    //                    G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(95, Color.Green)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Near,
    //                        LineAlignment = StringAlignment.Center
    //                    });
    //                    G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Center,
    //                        LineAlignment = StringAlignment.Center
    //                    });
    //                }
    //                else
    //                {
    //                    G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Center,
    //                        LineAlignment = StringAlignment.Center
    //                    });
    //                    G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(95, Color.Red)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Center,
    //                        LineAlignment = StringAlignment.Center
    //                    });
    //                    G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Near,
    //                        LineAlignment = StringAlignment.Center
    //                    });
    //                }
    //                break;
    //            case MouseState.Down:
    //                G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Near,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class ExcisionProgressBar : Control
    //{

    //    #region " Control Help - Properties & Flicker Control "
    //    private int OFS = 0;
    //    private int Speed = 50;

    //    private int _Maximum = 100;
    //    public int Maximum
    //    {
    //        get { return _Maximum; }
    //        set
    //        {

    //            if (value == _Value)
    //            {
    //                _Value = value;

    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
    //            //_Value:
    //            //					_Value = value;
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Maximum = value;
    //            Invalidate();
    //        }
    //    }
    //    private int _Value = 0;
    //    public int Value
    //    {
    //        get
    //        {
    //            switch (_Value)
    //            {
    //                case 0:
    //                    return 0;
    //                default:
    //                    return _Value;
    //            }
    //        }
    //        set
    //        {

    //            if (value == _Maximum)
    //            {
    //                value = _Maximum;
    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    //            //_Maximum:
    //            //					value = _Maximum;
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Value = value;
    //            Invalidate();
    //        }
    //    }
    //    private bool _ShowPercentage = false;
    //    public bool ShowPercentage
    //    {
    //        get { return _ShowPercentage; }
    //        set
    //        {
    //            _ShowPercentage = value;
    //            Invalidate();
    //        }
    //    }

    //    protected override void CreateHandle()
    //    {
    //        base.CreateHandle();
    //        // Dim tmr As New Timer With {.Interval = Speed}
    //        // AddHandler tmr.Tick, AddressOf Animate
    //        // tmr.Start()
    //        System.Threading.Thread T = new System.Threading.Thread(Animate);
    //        T.IsBackground = true;
    //        //T.Start()
    //    }
    //    public void Animate()
    //    {
    //        while (true)
    //        {
    //            if (OFS <= Width)
    //            {
    //                OFS += 1;
    //            }
    //            else
    //            {
    //                OFS = 0;
    //            }
    //            Invalidate();
    //            System.Threading.Thread.Sleep(Speed);
    //        }
    //    }
    //    #endregion

    //    public ExcisionProgressBar() : base()
    //    {
    //        DoubleBuffered = true;
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        int intValue = Convert.ToInt32(_Value / _Maximum * Width);
    //        G.Clear(BackColor);

    //        ImageToCodeClass d = new ImageToCodeClass();
    //        Bitmap GRAINIMAGE2 = (Bitmap)d.CodeToImage("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");
    //        TextureBrush TEXTUREIMAGE2 = new TextureBrush(GRAINIMAGE2, WrapMode.TileFlipX);
    //        ////// Inner Fill
    //        G.FillPath(TEXTUREIMAGE2, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));

    //        ////// Bar Fill
    //        LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(2, 2, intValue - 5, Height - 5), Color.FromArgb(60, 60, 60), Color.FromArgb(45, 45, 45), 90);
    //        G.FillPath(g1, Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));

    //        ///// Bar Overlap
    //        //Dim h1 As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(40, Color.White), Color.FromArgb(20, Color.White))
    //        //G.FillPath(h1, Draw.RoundRect(New Rectangle(0, 0, intValue - 1, Height - 2), 1))

    //        ////// Outer Rectangle
    //        G.DrawPath(new Pen(Color.FromArgb(190, 70, 70, 70)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

    //        ////// Bar Size
    //        G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(2, 2, intValue - 5, Height - 5), 2));

    //        if (_ShowPercentage)
    //        {
    //            G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Tahoma", 9, FontStyle.Bold), Brushes.White, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //} 
    #endregion


}