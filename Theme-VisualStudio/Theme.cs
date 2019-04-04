// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{

    #region Global Functions/ Subs/ Enums
    internal static class DrawHelpers
    {
        public static GraphicsPath RoundRectangle(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0F, 90F);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90F, 90F);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public static GraphicsPath RoundRect(float x, float y, float w, float h, float r = 0.3F, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
        {
            GraphicsPath tempRoundRect = null;
            float d = Math.Min(w, h) * r;
            var xw = x + w;
            var yh = y + h;
            tempRoundRect = new GraphicsPath();
            if (TL)
            {
                tempRoundRect.AddArc(x, y, d, d, 180, 90);
            }
            else
            {
                tempRoundRect.AddLine(x, y, x, y);
            }
            if (TR)
            {
                tempRoundRect.AddArc(xw - d, y, d, d, 270, 90);
            }
            else
            {
                tempRoundRect.AddLine(xw, y, xw, y);
            }
            if (BR)
            {
                tempRoundRect.AddArc(xw - d, yh - d, d, d, 0, 90);
            }
            else
            {
                tempRoundRect.AddLine(xw, yh, xw, yh);
            }
            if (BL)
            {
                tempRoundRect.AddArc(x, yh - d, d, d, 90, 90);
            }
            else
            {
                tempRoundRect.AddLine(x, yh, x, yh);
            }
            tempRoundRect.CloseFigure();
            return tempRoundRect;
        }
    }
    internal enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    #endregion


    public class VisualStudioContainer : ContainerControl
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            _Form = System.Windows.Forms.Form.ActiveForm;
        }

        #region Declarations
        private bool _AllowClose = true;
        private bool _AllowMinimize = true;
        private bool _AllowMaximize = true;
        private int _FontSize = 12;
        private bool _ShowIcon = true;
        private MouseState State = MouseState.None;
        private int MouseXLoc;
        private int MouseYLoc;
        private bool CaptureMovement = false;
        private const int MoveHeight = 35;
        private Point MouseP = new Point(0, 0);
        private Color _FontColour = Color.FromArgb(153, 153, 153);
        private Color _BaseColour = Color.FromArgb(45, 45, 48);
        private Color _IconColour = Color.FromArgb(255, 255, 255);
        private Color _ControlBoxColours = Color.FromArgb(248, 248, 248);
        private Color _BorderColour = Color.FromArgb(15, 15, 18);
        private Color _HoverColour = Color.FromArgb(63, 63, 65);
        private Color _PressedColour = Color.FromArgb(0, 122, 204);
        private Font _Font = new Font("Microsoft Sans Serif", 9);
        public enum __IconStyle
        {
            VSIcon,
            FormIcon
        }
        private __IconStyle _IconStyle = __IconStyle.FormIcon;
        public enum __FormOrWhole
        {
            WholeApplication,
            Form
        }
        private __FormOrWhole _FormOrWhole = __FormOrWhole.WholeApplication;
        private System.Windows.Forms.Form _Form;
        #endregion

        #region Properties

        [Category("Control")]
        public __FormOrWhole FormOrWhole
        {
            get
            {
                return _FormOrWhole;
            }
            set
            {
                _FormOrWhole = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public System.Windows.Forms.Form Form
        {
            get
            {
                return _Form;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {
                    _Form = value;
                }

                Invalidate();
            }
        }

        [Category("Control")]
        public __IconStyle IconStyle
        {
            get
            {
                return _IconStyle;
            }
            set
            {
                _IconStyle = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int FontSize
        {
            get
            {
                return _FontSize;
            }
            set
            {
                _FontSize = value;
            }
        }

        [Category("Control")]
        public bool AllowMinimize
        {
            get
            {
                return _AllowMinimize;
            }
            set
            {
                _AllowMinimize = value;
            }
        }

        [Category("Control")]
        public bool AllowMaximize
        {
            get
            {
                return _AllowMaximize;
            }
            set
            {
                _AllowMaximize = value;
            }
        }

        [Category("Control")]
        public bool ShowIcon
        {
            get
            {
                return _ShowIcon;
            }
            set
            {
                _ShowIcon = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool AllowClose
        {
            get
            {
                return _AllowClose;
            }
            set
            {
                _AllowClose = value;
            }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
            }
        }

        [Category("Colours")]
        public Color HoverColour
        {
            get
            {
                return _HoverColour;
            }
            set
            {
                _HoverColour = value;
            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
            }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get
            {
                return _FontColour;
            }
            set
            {
                _FontColour = value;
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CaptureMovement = false;
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseXLoc = e.Location.X;
            MouseYLoc = e.Location.Y;
            Invalidate();
            if (CaptureMovement)
            {
                Parent.Location = MousePosition - (Size)MouseP;
            }
            if (e.Y > 26)
            {
                Cursor = Cursors.Arrow;
            }
            else
            {
                Cursor = Cursors.Hand;
            }
        }

        private delegate void _InvokeForm(MouseEventArgs e);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (MouseXLoc > Width - 30 && MouseXLoc < Width && MouseYLoc < 26)
            {
                if (_AllowClose)
                {
                    if (_FormOrWhole == __FormOrWhole.Form)
                    {
                        if (_Form == null)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            if (_Form.InvokeRequired)
                            {
                                _Form.Invoke(new _InvokeForm(OnMouseDown), e);
                            }
                            else
                            {
                                _Form.Close();
                            }
                        }

                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else if (MouseXLoc > Width - 60 && MouseXLoc < Width - 30 && MouseYLoc < 26)
            {
                if (_AllowMaximize)
                {
                    switch (FindForm().WindowState)
                    {
                        case FormWindowState.Maximized:
                            FindForm().WindowState = FormWindowState.Normal;
                            break;
                        case FormWindowState.Normal:
                            FindForm().WindowState = FormWindowState.Maximized;
                            break;
                    }
                }
            }
            else if (MouseXLoc > Width - 90 && MouseXLoc < Width - 60 && MouseYLoc < 26)
            {
                if (_AllowMinimize)
                {
                    switch (FindForm().WindowState)
                    {
                        case FormWindowState.Normal:
                            FindForm().WindowState = FormWindowState.Minimized;
                            break;
                        case FormWindowState.Maximized:
                            FindForm().WindowState = FormWindowState.Minimized;
                            break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left && (new Rectangle(0, 0, Width - 90, MoveHeight)).Contains(e.Location))
            {
                CaptureMovement = true;
                MouseP = e.Location;
            }
            else if (e.Button == MouseButtons.Left && (new Rectangle(Width - 90, 22, 75, 13)).Contains(e.Location))
            {
                CaptureMovement = true;
                MouseP = e.Location;
            }
            else if (e.Button == MouseButtons.Left && (new Rectangle(Width - 15, 0, 15, MoveHeight)).Contains(e.Location))
            {
                CaptureMovement = true;
                MouseP = e.Location;
            }
            else
            {
                Focus();
            }
            State = MouseState.Down;
            Invalidate();
        }
        #endregion

        #region Draw Control

        public VisualStudioContainer()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = _BaseColour;
            this.Dock = DockStyle.Fill;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.AllowTransparency = false;
            ParentForm.TransparencyKey = Color.Fuchsia;
            ParentForm.FindForm().StartPosition = FormStartPosition.CenterParent;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        private Point[] Points1 = {
        new Point(9, 11),
        new Point(16, 17)
    };
        private Point[] Points2 = {
        new Point(9, 22),
        new Point(16, 17)
    };
        private Point[] Points3 = {
        new Point(16, 17),
        new Point(26, 7)
    };
        private Point[] Points4 = {
        new Point(16, 17),
        new Point(25, 26)
    };

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
            G.DrawRectangle(new Pen(_BorderColour), new Rectangle(0, 0, Width, Height));
            switch (State)
            {
                case MouseState.Over:
                    if (MouseXLoc > Width - 30 && MouseXLoc < Width && MouseYLoc < 26)
                    {
                        G.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(Width - 30, 1, 29, 25));
                    }
                    else if (MouseXLoc > Width - 60 && MouseXLoc < Width - 30 && MouseYLoc < 26)
                    {
                        G.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(Width - 60, 1, 30, 25));
                    }
                    else if (MouseXLoc > Width - 90 && MouseXLoc < Width - 60 && MouseYLoc < 26)
                    {
                        G.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(Width - 90, 1, 30, 25));
                    }
                    break;
            }
            //'Close Button
            G.DrawLine(new Pen(_ControlBoxColours, 2F), Width - 20, 10, Width - 12, 18);
            G.DrawLine(new Pen(_ControlBoxColours, 2F), Width - 20, 18, Width - 12, 10);
            //'Minimize Button
            G.FillRectangle(new SolidBrush(_ControlBoxColours), Width - 79, 17, 8, 2);
            //'Maximize Button
            if (FindForm().WindowState == FormWindowState.Normal)
            {
                G.DrawLine(new Pen(_ControlBoxColours), Width - 49, 18, Width - 40, 18);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 49, 18, Width - 49, 10);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 40, 18, Width - 40, 10);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 49, 10, Width - 40, 10);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 49, 11, Width - 40, 11);
            }
            else if (FindForm().WindowState == FormWindowState.Maximized)
            {
                G.DrawLine(new Pen(_ControlBoxColours), Width - 48, 16, Width - 39, 16);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 48, 16, Width - 48, 8);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 39, 16, Width - 39, 8);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 48, 8, Width - 39, 8);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 48, 9, Width - 39, 9);
                G.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(Width - 51, 12, 9, 8));
                G.DrawLine(new Pen(_ControlBoxColours), Width - 51, 20, Width - 42, 20);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 51, 20, Width - 51, 12);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 42, 20, Width - 42, 12);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 51, 12, Width - 42, 12);
                G.DrawLine(new Pen(_ControlBoxColours), Width - 51, 13, Width - 42, 13);
            }
            if (_ShowIcon)
            {
                switch (_IconStyle)
                {
                    case __IconStyle.FormIcon:
                        G.DrawIcon(FindForm().Icon, new Rectangle(6, 6, 22, 22));
                        G.DrawString(Text, _Font, new SolidBrush(_FontColour), new RectangleF(37F, 0F, Width - 110, 32F), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        break;
                    default:
                        G.DrawLines(new Pen(_IconColour, 3F), Points1);
                        G.DrawLines(new Pen(_IconColour, 3F), Points2);
                        G.DrawLines(new Pen(_IconColour, 4F), Points3);
                        G.DrawLines(new Pen(_IconColour, 4F), Points4);
                        G.DrawLine(new Pen(_IconColour, 3F), new Point(9, 11), new Point(9, 22));
                        G.DrawLine(new Pen(_IconColour, 4F), 26, 6, 26, 28);
                        G.DrawString(Text, _Font, new SolidBrush(_FontColour), new RectangleF(37F, 0F, Width - 110, 32F), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        break;
                }
            }
            else
            {
                G.DrawString(Text, _Font, new SolidBrush(_FontColour), new RectangleF(5F, 0F, Width - 110, 30F), new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
            }
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }
    

}
