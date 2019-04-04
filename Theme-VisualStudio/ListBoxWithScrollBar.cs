// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ListBoxWithScrollBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    public class VisualStudioListBoxWBuiltInScrollBar : Control
    {
        #region Declarations

        private List<VSListBoxItem> _Items = new List<VSListBoxItem>();
        private readonly List<VSListBoxItem> _SelectedItems = new List<VSListBoxItem>();
        private bool _MultiSelect = true;
        private int ItemHeight = 24;
        private VisualStudioVerticalScrollBar VerticalScrollbar;
        private Color _BaseColour = Color.FromArgb(37, 37, 38);
        private Color _NonSelectedItemColour = Color.FromArgb(62, 62, 64);
        private Color _SelectedItemColour = Color.FromArgb(47, 47, 47);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _FontColour = Color.FromArgb(199, 199, 199);
        private int _SelectedWidth = 1;
        private int _SelectedHeight = 1;
        private bool _DontShowInnerScrollbarBorder = false;
        private bool _ShowWholeInnerBorder = true;

        #endregion

        #region Properties

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
        public Color SelectedItemColour
        {
            get
            {
                return _SelectedItemColour;
            }
            set
            {
                _SelectedItemColour = value;
            }
        }

        [Category("Colours")]
        public Color NonSelectedItemColour
        {
            get
            {
                return _NonSelectedItemColour;
            }
            set
            {
                _NonSelectedItemColour = value;
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

        [Category("Control")]
        public int SelectedHeight
        {
            get
            {
                return _SelectedHeight;
            }
        }

        [Category("Control")]
        public int SelectedWidth
        {
            get
            {
                return _SelectedWidth;
            }
        }

        [Category("Control")]
        public bool DontShowInnerScrollbarBorder
        {
            get
            {
                return _DontShowInnerScrollbarBorder;
            }
            set
            {
                _DontShowInnerScrollbarBorder = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool ShowWholeInnerBorder
        {
            get
            {
                return _ShowWholeInnerBorder;
            }
            set
            {
                _ShowWholeInnerBorder = value;
                Invalidate();
            }
        }

        [Category("Control"), System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public VSListBoxItem[] Items
        {
            get
            {
                return _Items.ToArray();
            }
            set
            {
                _Items = new List<VSListBoxItem>(value);
                Invalidate();
                InvalidateScroll();
            }
        }

        [Category("Control")]
        public VSListBoxItem[] SelectedItems
        {
            get
            {
                return _SelectedItems.ToArray();
            }
        }

        [Category("Control")]
        public bool MultiSelect
        {
            get
            {
                return _MultiSelect;
            }
            set
            {
                _MultiSelect = value;

                if (_SelectedItems.Count > 1)
                {
                    _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);
                }

                Invalidate();
            }
        }

        private void HandleScroll(object sender)
        {
            Invalidate();
        }

        private void InvalidateScroll()
        {
            if (Convert.ToInt32(Math.Round(((_Items.Count) * ItemHeight) / (double)_SelectedHeight)) < Convert.ToDouble((((_Items.Count) * ItemHeight) / (double)_SelectedHeight)))
            {
                VerticalScrollbar._Maximum = Convert.ToInt32(Math.Ceiling(((_Items.Count) * ItemHeight) / (double)_SelectedHeight));
            }
            else if (Convert.ToInt32(Math.Round(((_Items.Count) * ItemHeight) / (double)_SelectedHeight)) == 0)
            {
                VerticalScrollbar._Maximum = 1;
            }
            else
            {
                VerticalScrollbar._Maximum = Convert.ToInt32(Math.Round(((_Items.Count) * ItemHeight) / (double)_SelectedHeight));
            }
            Invalidate();
        }

        private void InvalidateLayout()
        {
            VerticalScrollbar.Location = new Point(Width - VerticalScrollbar.Width - 2, 2);
            VerticalScrollbar.Size = new Size(18, Height - 4);
            Invalidate();
        }

        public class VSListBoxItem
        {
            public string Text { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                ItemHeight = Convert.ToInt32(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height);
                if (VerticalScrollbar != null)
                {
                    VerticalScrollbar._SmallChange = 1;
                    VerticalScrollbar._LargeChange = 1;
                }
                base.Font = value;
                InvalidateLayout();
            }
        }

        public void AddItem(string Items)
        {
            VSListBoxItem Item = new VSListBoxItem();
            Item.Text = Items;
            _Items.Add(Item);
            Invalidate();
            InvalidateScroll();
        }

        public void AddItems(string[] Items)
        {
            foreach (var I in Items)
            {
                VSListBoxItem Item = new VSListBoxItem();
                Item.Text = I;
                _Items.Add(Item);
            }
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItemAt(int index)
        {
            _Items.RemoveAt(index);
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItem(VSListBoxItem item)
        {
            _Items.Remove(item);
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItems(VSListBoxItem[] items)
        {
            foreach (VSListBoxItem I in items)
            {
                _Items.Remove(I);
            }
            Invalidate();
            InvalidateScroll();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _SelectedWidth = Width;
            _SelectedHeight = Height;
            InvalidateScroll();
            InvalidateLayout();
            base.OnSizeChanged(e);
        }

        private void Vertical_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                int Offset = Convert.ToInt32(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))));
                int Index = Convert.ToInt32(Math.Truncate((decimal)(e.Y + Offset) / ItemHeight));
                if (Index > _Items.Count - 1)
                {
                    Index = -1;
                }
                if (!(Index == -1))
                {
                    if (ModifierKeys == Keys.Control && _MultiSelect)
                    {
                        if (_SelectedItems.Contains(_Items[Index]))
                        {
                            _SelectedItems.Remove(_Items[Index]);
                        }
                        else
                        {
                            _SelectedItems.Add(_Items[Index]);
                        }
                    }
                    else
                    {
                        _SelectedItems.Clear();
                        _SelectedItems.Add(_Items[Index]);
                    }
                }
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int Move = -((e.Delta * Convert.ToInt32(Math.Truncate((decimal)(SystemInformation.MouseWheelScrollLines / 120))) * (2 / 2)));
            int Value = Math.Max(Math.Min(VerticalScrollbar.Value + Move, VerticalScrollbar.Maximum), VerticalScrollbar.Minimum);
            VerticalScrollbar.Value = Value;
            base.OnMouseWheel(e);
        }

        #endregion

        #region Draw Control

        public VisualStudioListBoxWBuiltInScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            VerticalScrollbar = new VisualStudioVerticalScrollBar();
            VerticalScrollbar._SmallChange = 1;
            VerticalScrollbar._LargeChange = 1;
            VerticalScrollbar.Scroll += HandleScroll;
            VerticalScrollbar.MouseDown += Vertical_MouseDown;
            Controls.Add(VerticalScrollbar);
            InvalidateLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            var G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(_BaseColour);
            VSListBoxItem AllItems = null;
            int Offset = Convert.ToInt32(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))));
            int StartIndex = 0;
            if (Offset == 0)
            {
                StartIndex = 0;
            }
            else
            {
                StartIndex = Convert.ToInt32(Offset / ItemHeight / VerticalScrollbar.Maximum);
            }
            int EndIndex = Math.Min(StartIndex + Convert.ToInt32(Math.Truncate((double)(Height / ItemHeight))), _Items.Count - 1);
            if (!_DontShowInnerScrollbarBorder && !_ShowWholeInnerBorder)
            {
                G.DrawLine(new Pen(_BorderColour, 2F), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height);
            }
            for (int I = StartIndex; I < _Items.Count; I++)
            {
                AllItems = Items[I];
                int Y = ((I * ItemHeight) + 1 - Offset) + Convert.ToInt32((ItemHeight / 2.0) - 8);
                if (_SelectedItems.Contains(AllItems))
                {
                    G.FillRectangle(new SolidBrush(_SelectedItemColour), new Rectangle(0, (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1));
                }
                else
                {
                    G.FillRectangle(new SolidBrush(_NonSelectedItemColour), new Rectangle(0, (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1));
                }
                G.DrawLine(new Pen(_BorderColour), 0, ((I * ItemHeight) + 1 - Offset) + ItemHeight - 1, Width - 18, ((I * ItemHeight) + 1 - Offset) + ItemHeight - 1);
                if (G.MeasureString(AllItems.Text, new Font("Segoe UI", 8)).Width > (_SelectedWidth) - 30)
                {
                    G.DrawString(AllItems.Text, new Font("Segoe UI", 8), new SolidBrush(_FontColour), new Rectangle(7, Y, Width - 35, 15));
                    G.DrawString("...", new Font("Segoe UI", 8), new SolidBrush(_FontColour), new Rectangle(Width - 32, Y, 15, 15));
                }
                else
                {
                    G.DrawString(AllItems.Text, new Font("Segoe UI", 8), new SolidBrush(_FontColour), new Rectangle(7, Y, Width - 34, Y + 10));
                }
                G.ResetClip();
            }
            G.DrawRectangle(new Pen(Color.FromArgb(35, 35, 35), 2F), 1, 1, Width - 2, Height - 2);
            G.InterpolationMode = (InterpolationMode)7;
            if (_ShowWholeInnerBorder)
            {
                G.DrawLine(new Pen(_BorderColour, 2F), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height);
            }
        }

        #endregion

    }
}
