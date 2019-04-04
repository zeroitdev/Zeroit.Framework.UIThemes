// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDiskComboBox : ComboBox
    {

        #region " Variables"

        private int W;
        private int H;
        private int _StartIndex = 0;
        private int x;
        private int y;

        private bool _LightTheme;
        #endregion

        #region " Properties"

        #region " Mouse States"

        private MouseState State = MouseState.None;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
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
            x = e.Location.X;
            y = e.Location.Y;
            Invalidate();
            if (e.X < Width - 41)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Hand;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            Invalidate();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Invalidate();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Invalidate();
        }

        #endregion

        #region " Colors"

        [Category("Colors")]
        public Color HoverColor
        {
            get { return _HoverColor; }
            set { _HoverColor = value; }
        }

        #endregion

        public bool LightTheme
        {
            get { return _LightTheme; }
            set { _LightTheme = value; }
        }

        private int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        public void DrawItem_(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = (SmoothingMode)2;
            e.Graphics.PixelOffsetMode = (PixelOffsetMode)2;
            e.Graphics.TextRenderingHint = (TextRenderingHint)5;
            e.Graphics.InterpolationMode = (InterpolationMode)7;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //-- Selected item
                e.Graphics.FillRectangle(new SolidBrush(_HoverColor), e.Bounds);
            }
            else
            {
                //-- Not Selected
                e.Graphics.FillRectangle(new SolidBrush(_BaseColor), e.Bounds);
            }

            //-- Text
            e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), new Font("Segoe UI", 8), Brushes.White, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));


            e.Graphics.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 18;
        }

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(25, 27, 29);
        private Color _BGColor = Color.FromArgb(45, 47, 49);

        private Color _HoverColor = Color.FromArgb(35, 168, 109);
        #endregion

        public MetroDiskComboBox()
        {
            DrawItem += DrawItem_;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(45, 45, 48);
            ForeColor = Color.White;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Cursor = Cursors.Hand;
            StartIndex = 0;
            ItemHeight = 18;
            Font = new Font("Segoe UI", 8, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_LightTheme)
            {
                _BaseColor = Color.FromArgb(200, 200, 200);
                _BGColor = Color.FromArgb(250, 250, 250);
                _HoverColor = Color.FromArgb(150, 150, 150);
                ForeColor = Color.FromArgb(20, 20, 20);
            }
            else
            {
                _BaseColor = Color.FromArgb(25, 25, 25);
                _BGColor = Color.FromArgb(40, 40, 40);
                _HoverColor = Color.FromArgb(80, 80, 80);
                ForeColor = Color.FromArgb(100, 100, 100);
            }
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Button = new Rectangle(Convert.ToInt32(W - 40), 0, W, H);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();

            var _with13 = G;
            _with13.Clear(Color.FromArgb(45, 45, 48));
            _with13.SmoothingMode = (SmoothingMode)2;
            _with13.PixelOffsetMode = (PixelOffsetMode)2;
            _with13.TextRenderingHint = (TextRenderingHint)5;

            //-- Base
            _with13.FillRectangle(new SolidBrush(_BGColor), Base);

            //-- Button
            GP.Reset();
            GP.AddRectangle(Button);
            _with13.SetClip(GP);
            _with13.FillRectangle(new SolidBrush(_BaseColor), Button);
            _with13.ResetClip();

            //-- Lines
            _with13.DrawLine(Pens.White, W - 10, 6, W - 30, 6);
            _with13.DrawLine(Pens.White, W - 10, 12, W - 30, 12);
            _with13.DrawLine(Pens.White, W - 10, 18, W - 30, 18);

            //-- Text
            _with13.DrawString(Text, Font, Brushes.White, new Point(4, 6), NearSF);

            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}