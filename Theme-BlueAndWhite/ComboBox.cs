// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.BlueWhite
{

    public class BaWGUIComboBox : ComboBox
    {
        #region " Declarations "
        private GraphicsPath Side;
        private GraphicsPath Button;
        private GraphicsPath Arrow1;
        private GraphicsPath Arrow2;
        private LinearGradientBrush SideGB;
        private LinearGradientBrush ButtonOGB;
        private LinearGradientBrush ButtonGB;
        private Rectangle R1;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;

        private StringFormat CSF = new StringFormat { LineAlignment = StringAlignment.Center };
        #endregion
        private int _StartIndex = 0;

        #region " Properties "
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
        #endregion

        public BaWGUIComboBox()
        {
            DrawItem += DrawItm;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Font = new Font("Arial", 12);
            ForeColor = Color.Black;
            ItemHeight = 39;
            StartIndex = 0;

            P1 = new Pen(Color.FromArgb(180, 180, 180));
            P3 = new Pen(Color.FromArgb(110, 170, 230));
            P4 = new Pen(Color.FromArgb(50, 130, 215));
            B1 = new SolidBrush(Color.FromArgb(100, 130, 160));
            B2 = new SolidBrush(Color.FromArgb(114, 114, 114));
            B3 = new SolidBrush(Color.FromArgb(246, 247, 250));
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Side = new GraphicsPath();
                Button = new GraphicsPath();
                Arrow1 = new GraphicsPath();
                Arrow2 = new GraphicsPath();

                ButtonOGB = new LinearGradientBrush(new Rectangle(Width - 51, 0, Width, Height), Color.FromArgb(125, 180, 235), Color.FromArgb(45, 125, 200), 90);
                ButtonGB = new LinearGradientBrush(new Rectangle(Width - 50, 0, Width, Height), Color.FromArgb(175, 215, 240), Color.FromArgb(70, 145, 215), 90);
                SideGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 50, Height), Color.FromArgb(253, 253, 253), Color.FromArgb(223, 223, 223), 90);

                R1 = new Rectangle(12, 0, Width, Height);

                P2 = new Pen(ButtonOGB);


                var _with1 = Side;
                _with1.AddArc(0, 0, 10, 10, 180, 90);
                _with1.AddLine(Width - 50, 0, Width - 50, Height - 1);
                _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
                _with1.CloseFigure();
                var _with2 = Button;
                _with2.AddLine(Width - 51, Height - 1, Width - 51, 0);
                _with2.AddArc(Width - 11, 0, 10, 10, -90, 90);
                _with2.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
                _with2.CloseFigure();
                var _with3 = Arrow1;
                _with3.AddLine(Width - 35, 21, Width - 19, 21);
                _with3.AddLine(Width - 19, 21, Width - 27, 11);
                _with3.CloseFigure();
                var _with4 = Arrow2;
                _with4.AddLine(Width - 35, 26, Width - 19, 26);
                _with4.AddLine(Width - 19, 26, Width - 27, 36);
                _with4.CloseFigure();
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with5 = e.Graphics;
            _with5.SmoothingMode = SmoothingMode.HighQuality;

            _with5.FillPath(SideGB, Side);
            _with5.DrawPath(P1, Side);

            _with5.FillPath(ButtonGB, Button);
            _with5.DrawPath(P2, Button);

            _with5.FillPath(B1, Arrow1);
            _with5.FillPath(B1, Arrow2);

            _with5.DrawString(Text, Font, B2, R1, CSF);

            base.OnPaint(e);
        }

        private void DrawItm(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();

            LinearGradientBrush NormalGB = new LinearGradientBrush(e.Bounds, Color.FromArgb(251, 251, 251), Color.FromArgb(237, 237, 237), 90);
            LinearGradientBrush OverGB = new LinearGradientBrush(e.Bounds, Color.FromArgb(155, 200, 240), Color.FromArgb(75, 144, 225), 90);


            var _with6 = e.Graphics;
            _with6.SmoothingMode = SmoothingMode.HighQuality;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                _with6.FillRectangle(OverGB, e.Bounds);
                _with6.DrawLine(P3, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Y);
                _with6.DrawLine(P4, e.Bounds.X, e.Bounds.Y + 38, e.Bounds.Width - 1, e.Bounds.Y + 38);

                _with6.DrawString(Text, Font, Brushes.DarkSlateGray, new Rectangle(e.Bounds.X + 12, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), CSF);
                _with6.DrawString(Text, Font, B3, new Rectangle(e.Bounds.X + 12, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), CSF);
            }
            else
            {
                _with6.FillRectangle(NormalGB, e.Bounds);
                _with6.DrawLine(P1, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Y);

                _with6.DrawString(base.GetItemText(base.Items[e.Index]), Font, B2, new Rectangle(e.Bounds.X + 12, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), CSF);
            }
        }
    }


}


