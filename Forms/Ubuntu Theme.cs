// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Ubuntu Theme.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.Form.UIThemes.Ubuntu
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
        //Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        //    Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        //    Dim P As GraphicsPath = New GraphicsPath()
        //    Dim ArcRectangleWidth As Integer = Curve * 2
        //    P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        //    P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        //    P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        //    P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        //    P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        //    Return P
        //End Function
    }

    public class UbuntuTheme : ContainerControl
    {
        public UbuntuTheme()
        {
            SizeChanged += UbuntuTheme1_SizeChanged;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(25, 25, 25);
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TopBar = new Rectangle(0, 0, Width - 1, 30);
            Rectangle FixBottom = new Rectangle(0, 26, Width - 1, 0);
            Rectangle Body = new Rectangle(0, 5, Width - 1, Height - 6);

            base.OnPaint(e);

            G.Clear(Color.Fuchsia);

            G.SmoothingMode = SmoothingMode.HighSpeed;

            LinearGradientBrush lbb = new LinearGradientBrush(Body, Color.FromArgb(242, 241, 240), Color.FromArgb(240, 240, 238), 90);
            G.FillPath(lbb, Draw.RoundRect(Body, 1));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(60, 60, 60))), Draw.RoundRect(Body, 1));

            LinearGradientBrush lgb = new LinearGradientBrush(TopBar, Color.FromArgb(87, 86, 81), Color.FromArgb(60, 59, 55), 90);
            //Dim tophatch As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(20, 20, 20), Color.Transparent)
            G.FillPath(lgb, Draw.RoundRect(TopBar, 4));
            //G.FillPath(tophatch, Draw.RoundRect(TopBar, 4))
            G.DrawPath(Pens.Black, Draw.RoundRect(TopBar, 3));
            G.DrawPath(Pens.Black, Draw.RoundRect(FixBottom, 1));
            G.FillRectangle(Brushes.White, 1, 27, Width - 2, Height - 29);

            Font drawFont = new Font("Tahoma", 10, FontStyle.Regular);
            G.DrawString(Text, drawFont, new SolidBrush(Color.WhiteSmoke), new Rectangle(25, 0, Width - 1, 27), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            G.DrawIcon(Parent.FindForm().Icon, new Rectangle(5, 5, 16, 16));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 26;
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

        private void UbuntuTheme1_SizeChanged(object sender, System.EventArgs e)
        {
        }
    }


    #region Duplicate
    //public class UbuntuControlBox : Control
    //{

    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    int X;
    //    Rectangle CloseBtn = new Rectangle(43, 2, 17, 17);
    //    Rectangle MinBtn = new Rectangle(3, 2, 17, 17);
    //    Rectangle MaxBtn = new Rectangle(23, 2, 17, 17);

    //    Rectangle bgr = new Rectangle(0, 0, (int)62.5, 21);
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        if (X > 3 && X < 20)
    //        {
    //            Parent.FindForm().WindowState = FormWindowState.Minimized;
    //        }
    //        else if (X > 23 && X < 40)
    //        {
    //            if (Parent.FindForm().WindowState == FormWindowState.Maximized)
    //            {
    //                Parent.FindForm().WindowState = FormWindowState.Minimized;
    //                Parent.FindForm().WindowState = FormWindowState.Normal;
    //            }
    //            else
    //            {
    //                Parent.FindForm().WindowState = FormWindowState.Minimized;
    //                Parent.FindForm().WindowState = FormWindowState.Maximized;
    //            }

    //        }
    //        else if (X > 43 && X < 60)
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

    //    public UbuntuControlBox()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        DoubleBuffered = true;
    //        Font = new Font("Marlett", 7);
    //        Anchor = AnchorStyles.Top | AnchorStyles.Right;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);

    //        base.OnPaint(e);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        G.Clear(BackColor);

    //        LinearGradientBrush bg0 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
    //        G.FillPath(bg0, Draw.RoundRect(bgr, 10));

    //        LinearGradientBrush lgb10 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //        G.FillEllipse(lgb10, MinBtn);
    //        G.DrawEllipse(Pens.DimGray, MinBtn);
    //        G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

    //        LinearGradientBrush lgb20 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //        G.FillEllipse(lgb20, MaxBtn);
    //        G.DrawEllipse(Pens.DimGray, MaxBtn);
    //        G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

    //        LinearGradientBrush lgb30 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
    //        G.FillEllipse(lgb30, CloseBtn);
    //        G.DrawEllipse(Pens.DimGray, CloseBtn);
    //        G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                LinearGradientBrush bg = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
    //                G.FillPath(bg, Draw.RoundRect(bgr, 10));

    //                LinearGradientBrush lgb1 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                G.FillEllipse(lgb1, MinBtn);
    //                G.DrawEllipse(Pens.DimGray, MinBtn);
    //                G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

    //                LinearGradientBrush lgb2 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                G.FillEllipse(lgb2, MaxBtn);
    //                G.DrawEllipse(Pens.DimGray, MaxBtn);
    //                G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

    //                LinearGradientBrush lgb3 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
    //                G.FillEllipse(lgb3, CloseBtn);
    //                G.DrawEllipse(Pens.DimGray, CloseBtn);
    //                G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
    //                break;
    //            case MouseState.Over:
    //                if (X > 3 && X < 20)
    //                {
    //                    LinearGradientBrush bg1 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
    //                    G.FillPath(bg1, Draw.RoundRect(bgr, 10));

    //                    LinearGradientBrush lgb11 = new LinearGradientBrush(MinBtn, Color.FromArgb(172, 171, 166), Color.FromArgb(76, 75, 71), 90);
    //                    G.FillEllipse(lgb11, MinBtn);
    //                    G.DrawEllipse(Pens.DimGray, MinBtn);
    //                    G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

    //                    LinearGradientBrush lgb21 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                    G.FillEllipse(lgb21, MaxBtn);
    //                    G.DrawEllipse(Pens.DimGray, MaxBtn);
    //                    G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

    //                    LinearGradientBrush lgb31 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
    //                    G.FillEllipse(lgb31, CloseBtn);
    //                    G.DrawEllipse(Pens.DimGray, CloseBtn);
    //                    G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
    //                }
    //                else if (X > 23 && X < 40)
    //                {
    //                    LinearGradientBrush bg3 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
    //                    G.FillPath(bg3, Draw.RoundRect(bgr, 10));

    //                    LinearGradientBrush lgb13 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                    G.FillEllipse(lgb13, MinBtn);
    //                    G.DrawEllipse(Pens.DimGray, MinBtn);
    //                    G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

    //                    LinearGradientBrush lgb23 = new LinearGradientBrush(MaxBtn, Color.FromArgb(172, 171, 166), Color.FromArgb(76, 75, 71), 90);
    //                    G.FillEllipse(lgb23, MaxBtn);
    //                    G.DrawEllipse(Pens.DimGray, MaxBtn);
    //                    G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

    //                    LinearGradientBrush lgb33 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
    //                    G.FillEllipse(lgb33, CloseBtn);
    //                    G.DrawEllipse(Pens.DimGray, CloseBtn);
    //                    G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
    //                }
    //                else if (X > 43 && X < 60)
    //                {
    //                    LinearGradientBrush bg3 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
    //                    G.FillPath(bg3, Draw.RoundRect(bgr, 10));

    //                    LinearGradientBrush lgb13 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                    G.FillEllipse(lgb13, MinBtn);
    //                    G.DrawEllipse(Pens.DimGray, MinBtn);
    //                    G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

    //                    LinearGradientBrush lgb23 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                    G.FillEllipse(lgb23, MaxBtn);
    //                    G.DrawEllipse(Pens.DimGray, MaxBtn);
    //                    G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

    //                    LinearGradientBrush lgb33 = new LinearGradientBrush(CloseBtn, Color.FromArgb(255, 170, 136), Color.FromArgb(243, 101, 26), 90);
    //                    G.FillEllipse(lgb33, CloseBtn);
    //                    G.DrawEllipse(Pens.DimGray, CloseBtn);
    //                    G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
    //                }
    //                break;
    //            default:
    //                LinearGradientBrush bg4 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
    //                G.FillPath(bg4, Draw.RoundRect(bgr, 10));

    //                LinearGradientBrush lgb14 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                G.FillEllipse(lgb14, MinBtn);
    //                G.DrawEllipse(Pens.DimGray, MinBtn);
    //                G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

    //                LinearGradientBrush lgb24 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
    //                G.FillEllipse(lgb24, MaxBtn);
    //                G.DrawEllipse(Pens.DimGray, MaxBtn);
    //                G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

    //                LinearGradientBrush lgb34 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
    //                G.FillEllipse(lgb34, CloseBtn);
    //                G.DrawEllipse(Pens.DimGray, CloseBtn);
    //                G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}

    //public class UbuntuButtonOrange : Control
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

    //    public UbuntuButtonOrange()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(86, 109, 109);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

    //        base.OnPaint(e);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Tahoma", 11, FontStyle.Regular);
    //        Pen p = new Pen(Color.FromArgb(157, 118, 103), 1);
    //        Brush nb = new SolidBrush(Color.FromArgb(86, 109, 109));
    //        switch (State)
    //        {
    //            case MouseState.None:

    //                LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(249, 163, 128), Color.FromArgb(237, 139, 99), 90);
    //                G.FillPath(lgb, Draw.RoundRect(ClientRectangle, 3));
    //                G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

    //                G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                LinearGradientBrush lgb1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 186, 153), Color.FromArgb(255, 171, 135), 90);
    //                G.FillPath(lgb1, Draw.RoundRect(ClientRectangle, 3));
    //                G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

    //                G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Down:
    //                LinearGradientBrush lgb2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 116, 83), Color.FromArgb(194, 101, 65), 90);
    //                G.FillPath(lgb2, Draw.RoundRect(ClientRectangle, 3));
    //                G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

    //                G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
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

    //public class UbuntuButtonGray : Control
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

    //    public UbuntuButtonGray()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(90, 84, 82);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

    //        base.OnPaint(e);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        G.Clear(BackColor);
    //        Font drawFont = new Font("Tahoma", 11, FontStyle.Regular);
    //        Pen p = new Pen(Color.FromArgb(166, 166, 166), 1);
    //        Brush nb = new SolidBrush(Color.FromArgb(80, 84, 82));
    //        switch (State)
    //        {
    //            case MouseState.None:

    //                LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(223, 223, 223), Color.FromArgb(197, 197, 197), 90);
    //                G.FillPath(lgb, Draw.RoundRect(ClientRectangle, 3));
    //                G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

    //                G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                LinearGradientBrush lgb1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(243, 243, 243), Color.FromArgb(217, 217, 217), 90);
    //                G.FillPath(lgb1, Draw.RoundRect(ClientRectangle, 3));
    //                G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

    //                G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Down:
    //                LinearGradientBrush lgb2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(212, 211, 216), Color.FromArgb(156, 155, 151), 90);
    //                G.FillPath(lgb2, Draw.RoundRect(ClientRectangle, 3));
    //                G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

    //                G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
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

    //[DefaultEvent("CheckedChanged")]
    //public class UbuntuCheckBox : Control
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

    //    public UbuntuCheckBox() : base()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.WhiteSmoke;
    //        ForeColor = Color.Black;
    //        Size = new Size(145, 16);
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle checkBoxRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

    //        G.Clear(BackColor);

    //        LinearGradientBrush bodyGrad = new LinearGradientBrush(checkBoxRectangle, Color.FromArgb(102, 101, 96), Color.FromArgb(76, 75, 71), 90);
    //        G.FillRectangle(bodyGrad, bodyGrad.Rectangle);
    //        G.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, Height - 3, Height - 3));
    //        G.DrawRectangle(new Pen(Color.FromArgb(42, 47, 49)), checkBoxRectangle);

    //        Font drawFont = new Font("Tahoma", 10, FontStyle.Regular);
    //        Brush nb = new SolidBrush(Color.FromArgb(86, 83, 87));
    //        G.DrawString(Text, drawFont, nb, new Point(16, 7), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });


    //        if (Checked)
    //        {
    //            Rectangle chkPoly = new Rectangle(checkBoxRectangle.X + checkBoxRectangle.Width / 4, checkBoxRectangle.Y + checkBoxRectangle.Height / 4, checkBoxRectangle.Width / 2, checkBoxRectangle.Height / 2);
    //            Point[] Poly = {
    //            new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
    //            new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
    //            new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
    //        };
    //            G.SmoothingMode = SmoothingMode.HighQuality;
    //            Pen P1 = new Pen(Color.FromArgb(247, 150, 116), 2);
    //            LinearGradientBrush chkGrad = new LinearGradientBrush(chkPoly, Color.FromArgb(200, 200, 200), Color.FromArgb(255, 255, 255), 0f);
    //            for (int i = 0; i <= Poly.Length - 2; i++)
    //            {
    //                G.DrawLine(P1, Poly[i], Poly[i + 1]);
    //            }
    //        }

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();

    //    }

    //}

    //[DefaultEvent("CheckedChanged")]
    //public class UbuntuRadioButton : Control
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
    //            if (!object.ReferenceEquals(C, this) && C is UbuntuRadioButton)
    //            {
    //                ((UbuntuRadioButton)C).Checked = false;
    //            }
    //        }
    //    }
    //    #endregion

    //    public UbuntuRadioButton() : base()
    //    {
    //        BackColor = Color.WhiteSmoke;
    //        ForeColor = Color.Black;
    //        Size = new Size(150, 16);
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        dynamic radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        G.Clear(BackColor);

    //        LinearGradientBrush bgGrad = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(102, 101, 96), Color.FromArgb(76, 75, 71), 90);
    //        G.FillEllipse(bgGrad, radioBtnRectangle);

    //        G.DrawEllipse(new Pen(Color.Gray), new Rectangle(1, 1, Height - 3, Height - 3));
    //        G.DrawEllipse(new Pen(Color.FromArgb(42, 47, 49)), radioBtnRectangle);

    //        if (Checked)
    //        {
    //            LinearGradientBrush chkGrad = new LinearGradientBrush(new Rectangle(4, 4, Height - 9, Height - 9), Color.FromArgb(247, 150, 116), Color.FromArgb(197, 100, 66), 90);
    //            G.FillEllipse(chkGrad, new Rectangle(4, 4, Height - 9, Height - 9));
    //        }

    //        Font drawFont = new Font("Tahoma", 10, FontStyle.Regular);
    //        Brush nb = new SolidBrush(Color.FromArgb(86, 83, 87));
    //        G.DrawString(Text, drawFont, nb, new Point(16, 1), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Near
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }

    //}

    //public class UbuntuGroupBox : ContainerControl
    //{

    //    public UbuntuGroupBox()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        DoubleBuffered = true;
    //    }
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle TopBar = new Rectangle(0, 0, Width - 1, 20);
    //        Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

    //        base.OnPaint(e);

    //        G.Clear(Color.Transparent);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        LinearGradientBrush bodygrade = new LinearGradientBrush(ClientRectangle, Color.White, Color.White, 120);
    //        G.FillPath(bodygrade, Draw.RoundRect(new Rectangle(0, 12, Width - 1, Height - 15), 1));

    //        LinearGradientBrush outerBorder = new LinearGradientBrush(ClientRectangle, Color.FromArgb(50, 50, 50), Color.DimGray, 90);
    //        G.DrawPath(new Pen(outerBorder), Draw.RoundRect(new Rectangle(0, 12, Width - 1, Height - 15), 1));

    //        LinearGradientBrush lbb = new LinearGradientBrush(TopBar, Color.FromArgb(87, 86, 81), Color.FromArgb(60, 59, 55), 90);
    //        G.FillPath(lbb, Draw.RoundRect(TopBar, 1));

    //        G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), Draw.RoundRect(TopBar, 2));

    //        Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);

    //        G.DrawString(Text, drawFont, new SolidBrush(Color.White), TopBar, new StringFormat
    //        {
    //            Alignment = StringAlignment.Center,
    //            LineAlignment = StringAlignment.Center
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}

    //public class UbuntuTextBox : Control
    //{
    //    private TextBox withEventsField_txtbox = new TextBox();
    //    public TextBox txtbox
    //    {
    //        get { return withEventsField_txtbox; }
    //        set
    //        {
    //            if (withEventsField_txtbox != null)
    //            {
    //                withEventsField_txtbox.TextChanged -= TextChngTxtBox;
    //            }
    //            withEventsField_txtbox = value;
    //            if (withEventsField_txtbox != null)
    //            {
    //                withEventsField_txtbox.TextChanged += TextChngTxtBox;
    //            }
    //        }

    //    }
    //    #region " Control Help - Properties & Flicker Control "
    //    private bool _passmask = false;
    //    public new bool UseSystemPasswordChar
    //    {
    //        get { return _passmask; }
    //        set
    //        {
    //            txtbox.UseSystemPasswordChar = UseSystemPasswordChar;
    //            _passmask = value;
    //            Invalidate();
    //        }
    //    }
    //    private int _maxchars = 32767;
    //    public new int MaxLength
    //    {
    //        get { return _maxchars; }
    //        set
    //        {
    //            _maxchars = value;
    //            txtbox.MaxLength = MaxLength;
    //            Invalidate();
    //        }
    //    }
    //    private HorizontalAlignment _align;
    //    public new HorizontalAlignment TextAlignment
    //    {
    //        get { return _align; }
    //        set
    //        {
    //            _align = value;
    //            Invalidate();
    //        }
    //    }

    //    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
    //    {
    //    }
    //    protected override void OnTextChanged(System.EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }
    //    protected override void OnBackColorChanged(System.EventArgs e)
    //    {
    //        base.OnBackColorChanged(e);
    //        txtbox.BackColor = BackColor;
    //        Invalidate();
    //    }
    //    protected override void OnForeColorChanged(System.EventArgs e)
    //    {
    //        base.OnForeColorChanged(e);
    //        txtbox.ForeColor = ForeColor;
    //        Invalidate();
    //    }
    //    protected override void OnFontChanged(System.EventArgs e)
    //    {
    //        base.OnFontChanged(e);
    //        txtbox.Font = Font;
    //    }
    //    protected override void OnGotFocus(System.EventArgs e)
    //    {
    //        base.OnGotFocus(e);
    //        txtbox.Focus();
    //    }
    //    public void TextChngTxtBox(object sender, EventArgs e)
    //    {
    //        Text = txtbox.Text;
    //    }
    //    public void TextChng(object sender, EventArgs e)
    //    {
    //        txtbox.Text = Text;
    //    }
    //    public void NewTextBox()
    //    {
    //        var _with1 = txtbox;
    //        _with1.Multiline = false;
    //        _with1.BackColor = Color.FromArgb(43, 43, 43);
    //        _with1.ForeColor = ForeColor;
    //        _with1.Text = string.Empty;
    //        _with1.TextAlign = HorizontalAlignment.Center;
    //        _with1.BorderStyle = BorderStyle.None;
    //        _with1.Location = new Point(5, 4);
    //        _with1.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold);
    //        _with1.Size = new Size(Width - 10, Height - 11);
    //        _with1.UseSystemPasswordChar = UseSystemPasswordChar;

    //    }
    //    #endregion

    //    public UbuntuTextBox() : base()
    //    {
    //        TextChanged += TextChng;

    //        NewTextBox();
    //        Controls.Add(txtbox);

    //        Text = "";
    //        BackColor = Color.White;
    //        ForeColor = Color.FromArgb(102, 102, 102);
    //        Size = new Size(135, 35);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);

    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

    //        Height = txtbox.Height + 11;
    //        Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);
    //        var _with2 = txtbox;
    //        _with2.Width = Width - 12;
    //        _with2.ForeColor = Color.FromArgb(102, 102, 102);
    //        _with2.Font = drawFont;
    //        _with2.TextAlign = TextAlignment;
    //        _with2.UseSystemPasswordChar = UseSystemPasswordChar;

    //        G.Clear(BackColor);

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;

    //        G.FillRectangle(new SolidBrush(Color.White), ClientRectangle);
    //        G.DrawPath(new Pen(Color.FromArgb(255, 207, 188)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 1));
    //        G.DrawPath(new Pen(Color.FromArgb(255, 207, 188)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));
    //        G.DrawPath(new Pen(Color.FromArgb(205, 87, 40)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
    //        G.DrawPath(new Pen(Color.FromArgb(205, 87, 40)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //} 
    #endregion

}


