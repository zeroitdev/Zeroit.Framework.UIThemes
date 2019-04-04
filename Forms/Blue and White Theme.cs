// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-19-2019
// ***********************************************************************
// <copyright file="Blue and White Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Form.UIThemes.BlueWhite
{

    
    
    public class BaWGUIThemeContainer : ContainerControl
    {
        #region " Declarations "
        private bool OverCls;
        private bool OverMax;
        private bool OverMin;
        private Font XF;
        private Font PF;
        private Font MF;
        private GraphicsPath Base;
        private GraphicsPath Header;
        private LinearGradientBrush BaseGB;
        private LinearGradientBrush HeaderGB;
        private LinearGradientBrush HeaderOutlineGB;
        private LinearGradientBrush ButtonOuterGB;
        private LinearGradientBrush ButtonInnerGB;
        private LinearGradientBrush ButtonOInnerGB;
        private Rectangle R1;
        private Rectangle R2;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;

        private StringFormat CSF = new StringFormat { Alignment = StringAlignment.Center };
        #endregion

        private bool _DrawButtonStrings = true;

        #region " Properties "
        [Category("Drawing")]
        public bool DrawButtonStrings
        {
            get { return _DrawButtonStrings; }
            set { _DrawButtonStrings = value; }
        }
        #endregion

        public BaWGUIThemeContainer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            BackColor = Color.White;
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
            Font = new Font("Arial", 12, FontStyle.Bold);
            XF = new Font("Tahoma", 12);
            PF = new Font("Arial", 16);
            MF = new Font("Arial", 20);

            P1 = new Pen(Color.FromArgb(128, 128, 128));
            // P2 is in the OnSizeChanged event.
            P3 = new Pen(Color.FromArgb(180, 217, 246));
            B1 = new SolidBrush(Color.FromArgb(58, 118, 181));
            B2 = new SolidBrush(Color.FromArgb(71, 132, 191));
            B3 = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
        }

        protected override void CreateHandle()
        {
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
            if (Parent.FindForm().TransparencyKey == null)
                Parent.FindForm().TransparencyKey = Color.Fuchsia;

            base.CreateHandle();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (OverMin)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (OverMax)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (OverCls)
                {
                    Parent.FindForm().Close();
                }
                else
                {
                    if (new Rectangle(Parent.FindForm().Location.X, Parent.FindForm().Location.Y, Width, 50).IntersectsWith(new Rectangle(MousePosition.X, MousePosition.Y, 1, 1)) && !(Parent.FindForm().WindowState == FormWindowState.Maximized))
                    {
                        Capture = false;
                        Message M = Message.Create(Parent.FindForm().Handle, 161, new IntPtr(2), IntPtr.Zero);
                        DefWndProc(ref M);
                    }
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Location.X >= 33 && e.Location.Y >= 19 && e.Location.X <= 120 && e.Location.Y <= 37)
            {
                if (e.Location.X >= 33 && e.Location.X <= 51)
                {
                    OverCls = true;
                    Invalidate();
                }
                else
                {
                    OverCls = false;
                    Invalidate();
                }

                if (e.Location.X >= 104)
                {
                    OverMax = true;
                    Invalidate();
                }
                else
                {
                    OverMax = false;
                    Invalidate();
                }

                if (e.Location.X >= 68 && e.Location.X <= 86)
                {
                    OverMin = true;
                    Invalidate();
                }
                else
                {
                    OverMin = false;
                    Invalidate();
                }
            }
            else
            {
                OverMin = false;
                OverMax = false;
                OverCls = false;
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Base = new GraphicsPath();
                Header = new GraphicsPath();

                R1 = new Rectangle(-1, Convert.ToInt32((50 - Font.Size) / 2 - 1), Width, Height);
                R2 = new Rectangle(0, Convert.ToInt32((50 - Font.Size) / 2 - 2), Width, Height);

                BaseGB = new LinearGradientBrush(new Rectangle(0, 50, Width, Height), Color.FromArgb(236, 236, 236), Color.FromArgb(232, 232, 232), 90);
                HeaderGB = new LinearGradientBrush(new Rectangle(0, 0, Width, 50), Color.FromArgb(161, 207, 243), Color.FromArgb(80, 152, 222), 90);
                HeaderOutlineGB = new LinearGradientBrush(new Rectangle(0, 0, Width, 50), Color.FromArgb(102, 167, 227), Color.FromArgb(52, 130, 202), -90);
                ButtonOuterGB = new LinearGradientBrush(new Rectangle(0, 15, 25, 25), Color.FromArgb(89, 158, 228), Color.FromArgb(150, 202, 241), 90);
                ButtonInnerGB = new LinearGradientBrush(new Rectangle(0, 20, 16, 16), Color.FromArgb(185, 211, 239), Color.FromArgb(145, 191, 238), 90);
                ButtonOInnerGB = new LinearGradientBrush(new Rectangle(0, 22, 16, 16), Color.FromArgb(94, 163, 215), Color.FromArgb(13, 67, 141), 90);

                P2 = new Pen(HeaderOutlineGB);


                var _with1 = Base;
                _with1.AddLine(Width - 1, 50, Width - 1, Height - 11);
                _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
                _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
                _with1.AddLine(0, Height - 11, 0, 50);

                var _with2 = Header;
                _with2.AddArc(0, 0, 10, 10, 180, 90);
                _with2.AddArc(Width - 11, 0, 10, 10, -90, 90);
                _with2.AddLine(Width - 1, 50, 0, 50);
                _with2.AddLine(0, 50, 0, 5);
                Invalidate();
            }

            Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with3 = e.Graphics;
            _with3.SmoothingMode = SmoothingMode.HighQuality;
            _with3.Clear(Parent.FindForm().TransparencyKey);

            // Base & Header
            _with3.FillPath(BaseGB, Base);
            _with3.DrawPath(P1, Base);

            _with3.FillPath(HeaderGB, Header);
            _with3.DrawPath(P2, Header);
            _with3.DrawLine(P3, 4, 1, Width - 5, 1);
            // Little header shine


            // Buttons
            if (OverCls)
            {
                _with3.FillEllipse(ButtonOuterGB, 30, 15, 25, 25);
                _with3.FillEllipse(B1, 33, 19, 18, 18);
                _with3.FillEllipse(ButtonOInnerGB, 34, 21, 16, 16);
                if (_DrawButtonStrings)
                    _with3.DrawString("x", XF, B3, 36, 17);
            }
            else
            {
                _with3.FillEllipse(ButtonOuterGB, 30, 15, 25, 25);
                _with3.FillEllipse(B2, 33, 19, 18, 18);
                _with3.FillEllipse(ButtonInnerGB, 34, 19, 16, 16);
            }

            if (OverMax)
            {
                _with3.FillEllipse(ButtonOuterGB, 100, 15, 25, 25);
                _with3.FillEllipse(B1, 103, 19, 18, 18);
                _with3.FillEllipse(ButtonOInnerGB, 104, 21, 16, 16);
                if (_DrawButtonStrings)
                    _with3.DrawString("+", PF, B3, 102, 17);
            }
            else
            {
                _with3.FillEllipse(ButtonOuterGB, 100, 15, 25, 25);
                _with3.FillEllipse(B2, 103, 19, 18, 18);
                _with3.FillEllipse(ButtonInnerGB, 104, 19, 16, 16);
            }

            if (OverMin)
            {
                _with3.FillEllipse(ButtonOuterGB, 65, 15, 25, 25);
                _with3.FillEllipse(B1, 68, 19, 18, 18);
                _with3.FillEllipse(ButtonOInnerGB, 69, 21, 16, 16);
                if (_DrawButtonStrings)
                    _with3.DrawString("-", MF, B3, 69, 10);
            }
            else
            {
                _with3.FillEllipse(ButtonOuterGB, 65, 15, 25, 25);
                _with3.FillEllipse(B2, 68, 19, 18, 18);
                _with3.FillEllipse(ButtonInnerGB, 69, 19, 16, 16);
            }


            _with3.DrawString(Text, Font, Brushes.DarkSlateGray, R1, CSF);
            _with3.DrawString(Text, Font, Brushes.WhiteSmoke, R2, CSF);

            base.OnPaint(e);
        }





    }


    

}


