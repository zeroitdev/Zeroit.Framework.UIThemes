// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TabVertical.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeTabControlVertical : TabControl
    {

        #region "Declarations"
        private Color _PressedTabColour = Color.FromArgb(238, 240, 239);
        private Color _HoverColour = Color.FromArgb(230, 230, 230);
        private Color _NormalColour = Color.FromArgb(250, 249, 251);
        private Color _BorderColour = Color.FromArgb(163, 190, 146);
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        #endregion
        private int HoverIndex = -1;

        #region "Colour & Other Properties"
        [Category("Colours")]
        public Color NormalColour
        {
            get { return _NormalColour; }
            set { _NormalColour = value; }
        }
        [Category("Colours")]
        public Color HoverColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }
        [Category("Colours")]
        public Color PressedTabColour
        {
            get { return _PressedTabColour; }
            set { _PressedTabColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }
        #endregion

        #region "Draw Control"
        public ElegantThemeTabControlVertical()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(45, 95);
            Font = new Font("Segoe UI", 9, FontStyle.Bold);
            DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is TabPage)
            {
                foreach (TabPage i in Controls)
                {

                    Controls.Add(i);
                    //i = new TabPage();
                }
                e.Control.BackColor = Color.FromArgb(255, 255, 255);
            }
            base.OnControlAdded(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            for (int I = 0; I <= TabPages.Count - 1; I++)
            {
                if (GetTabRect(I).Contains(e.Location))
                {
                    HoverIndex = I;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoverIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(BackColor);
            try
            {
                SelectedTab.BackColor = _NormalColour;
            }
            catch
            {
            }
            var _with16 = G;
            _with16.FillRectangle(new SolidBrush(_NormalColour), new Rectangle(-2, 0, ItemSize.Height + 4, Height + 22));
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle tabRect1 = new Rectangle(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width - 20, GetTabRect(i).Size.Height - 11);
                if (i == SelectedIndex)
                {
                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width + 10, GetTabRect(i).Size.Height - 11);
                    _with16.FillRectangle(new SolidBrush(_PressedTabColour), new Rectangle(tabRect.X + 1, tabRect.Y + 1, tabRect.Width - 1, tabRect.Height - 2));
                    _with16.DrawRectangle(new Pen(_BorderColour), tabRect);
                    _with16.FillRectangle(new SolidBrush(_BorderColour), GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 1, GetTabRect(i).Location.X + 2, GetTabRect(i).Size.Height - 10);
                    _with16.FillRectangle(new SolidBrush(_BorderColour), GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y + 6, GetTabRect(i).Location.X + 2, GetTabRect(i).Size.Height - 19);
                    _with16.SmoothingMode = SmoothingMode.AntiAlias;
                    _with16.DrawString(TabPages[i].Text, new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(_TextColour), tabRect1, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                else
                {
                    if (HoverIndex == i)
                    {
                        Rectangle x21 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 2), new Size(GetTabRect(i).Width, GetTabRect(i).Height - 11));
                        _with16.FillRectangle(new SolidBrush(_HoverColour), x21);
                    }
                    _with16.DrawString(TabPages[i].Text, new Font("Segoe UI", 9, FontStyle.Regular), new SolidBrush(_TextColour), tabRect1, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });

                }
                _with16.FillRectangle(new SolidBrush(_NormalColour), new Rectangle(97, 0, Width - 97, Height));
                _with16.DrawLine(new Pen((_BorderColour), 1), new Point(96, 0), new Point(96, Height));
            }
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }


}


