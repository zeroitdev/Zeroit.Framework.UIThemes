// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Dialog.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{

    public class MetroDiskDialogSkin : ContainerControl
    {

        #region " Variables"

        private int W;
        private int H;
        private bool Cap = false;
        private bool _HeaderMaximize = false;
        private Point MousePoint = new Point(0, 0);
        private int MoveHeight = 50;
        private Color _MDcolor;
        private string _text = "MetroDisk by SilverMachine";
        private Font _Font = new Font("tahoma", 7);
        #endregion
        private Font __Font = new Font("Segoe UI", 18, FontStyle.Bold);

        #region " Properties"

        #region " Colors"

        [Category("Colors")]
        public Color HeaderColor
        {
            get { return _HeaderColor; }
            set { _HeaderColor = value; }
        }
        [Category("Colors")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }
        [Category("Colors")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }
        [Category("Colors")]
        public Color FlatColor
        {
            get { return _FlatColor; }
            set { _FlatColor = value; }
        }

        #endregion

        #region " Options"

        [Category("Options")]
        public bool HeaderMaximize
        {
            get { return _HeaderMaximize; }
            set { _HeaderMaximize = value; }
        }

        #endregion

        public Color MDColor
        {
            get { return _MDcolor; }
            set { _MDcolor = value; }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MousePoint = e.Location;
            }
        }

        private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (HeaderMaximize)
            {
                if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Normal)
                    {
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                        Parent.FindForm().Refresh();
                    }
                    else if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                    {
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                        Parent.FindForm().Refresh();
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MousePoint.X, MousePosition.Y - MousePoint.Y);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.AllowTransparency = false;
            ParentForm.TransparencyKey = Color.Fuchsia;
            ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        #endregion

        #region " Colors"

        #region " Dark Colors"

        private Color _HeaderColor = Color.FromArgb(60, 200, 80);
        private Color _BaseColor = Color.FromArgb(60, 70, 73);
        private Color _BorderColor = Color.FromArgb(53, 58, 60);

        private Color TextColor = Color.FromArgb(234, 234, 234);
        #endregion

        #region " Light Colors"

        private Color _HeaderLight = Color.FromArgb(171, 171, 172);
        private Color _BaseLight = Color.FromArgb(196, 199, 200);

        public Color TextLight = Color.FromArgb(45, 47, 49);
        #endregion

        #endregion

        public MetroDiskDialogSkin()
        {
            MouseDoubleClick += FormSkin_MouseDoubleClick;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            _MDcolor = Color.FromArgb(45, 150, 45);
            DoubleBuffered = true;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 12);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _HeaderColor = Color.FromArgb(255, 255, 255);
            _BaseColor = Color.FromArgb(255, 255, 255);
            _BorderColor = Color.FromArgb(245, 245, 245);

            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width;
            H = Height;
            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Header = new Rectangle(0, 0, W, 40);

            var _with20 = G;
            _with20.SmoothingMode = (SmoothingMode)2;
            _with20.PixelOffsetMode = (PixelOffsetMode)2;
            _with20.TextRenderingHint = (TextRenderingHint)5;
            _with20.Clear(BackColor);

            //-- Base
            _with20.FillRectangle(new SolidBrush(_BaseColor), Base);

            //-- Header
            _with20.FillRectangle(new SolidBrush(_HeaderColor), Header);

            //-- Logo
            _with20.DrawString(Text, __Font, new SolidBrush(Color.Black), new Rectangle(20, 20, W, H), NearSF);
            _with20.DrawString(_text, _Font, new SolidBrush(Color.DimGray), new Rectangle(W - 120, H - 15, W, H), NearSF);
            _with20.FillRectangle(new SolidBrush(_MDcolor), new Rectangle(20, 15, 150, 5));

            //-- Border
            _with20.DrawRectangle(new Pen(_BorderColor), Base);

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }

}