// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
    public class EasyTheme : ContainerControl
    {
        [DllImportAttribute("user32.dll")]
        public extern static int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public extern static bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        protected sealed override void OnHandleCreated(EventArgs e)
        {
            base.Dock = DockStyle.Fill;
            ForeColor = Color.White;
            base.OnHandleCreated(e);
        }

        private bool _IsParentForm;

        protected bool IsParentForm
        {
            get
            {
                return _IsParentForm;
            }
            set
            {
                _IsParentForm = value;
            }
        }

        private bool _Transparent;
        public bool Transparent
        {
            get
            {
                return _Transparent;
            }
            set
            {
                _Transparent = value;
                if (!IsHandleCreated)
                {
                    return;
                    SetStyle(ControlStyles.Opaque, !value);
                    SetStyle(ControlStyles.SupportsTransparentBackColor, value);
                    Invalidate();
                }
            }
        }

        protected override void OnParentChanged(System.EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent == null)
            {
                return;
                _IsParentForm = Parent is System.Windows.Forms.Form;
            }
            if (_IsParentForm)
            {
                ParentForm.FormBorderStyle = _BorderStyle;
            }
        }

        private FormBorderStyle _BorderStyle;
        public FormBorderStyle BorderStyle
        {
            get
            {
                if (_IsParentForm)
                {
                    return ParentForm.FormBorderStyle;
                }
                else
                {
                    return _BorderStyle;
                }
            }
            set
            {
                _BorderStyle = value;
                if (_IsParentForm)
                {
                    ParentForm.FormBorderStyle = value;
                }
            }
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            g.FillRectangle(new SolidBrush(Color.FromArgb(75, 0, 0, 0)), new Rectangle(-1, -1, Width + 1, 25));
            Image icon = SystemIcons.Application.ToBitmap();
            Size iSize = new Size(16, 16);
            g.DrawImage(icon, 5, 5, 16, 16);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(25, 5), StringFormat.GenericDefault);
            g.Dispose();
        }
    }
    
    
}
