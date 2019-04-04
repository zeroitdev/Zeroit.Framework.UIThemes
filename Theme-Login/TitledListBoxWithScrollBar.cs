// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TitledListBoxWithScrollBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInTitledListBoxWBuiltInScrollBar : Control
    {

        #region "Declarations"

        private List<LogInListBoxItem> _Items = new List<LogInListBoxItem>();
        private readonly List<LogInListBoxItem> _SelectedItems = new List<LogInListBoxItem>();
        private bool _MultiSelect = true;
        private int ItemHeight = 24;
        private readonly LogInVerticalScrollBar VerticalScrollbar;
        private Color _BaseColour = Color.FromArgb(55, 55, 55);
        private Color _SelectedItemColour = Color.FromArgb(50, 50, 50);
        private Color _NonSelectedItemColour = Color.FromArgb(47, 47, 47);
        private Color _TitleAreaColour = Color.FromArgb(42, 42, 42);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _TextColour = Color.FromArgb(255, 255, 255);

        private int _SelectedHeight = 1;
        #endregion

        #region "Properties"

        [Category("Colours")]
        public Color TitleAreaColour
        {
            get { return _TitleAreaColour; }
            set { _TitleAreaColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Control")]
        public int SelectedHeight
        {
            get { return _SelectedHeight; }
            set
            {
                if (value < 1)
                {
                    _SelectedHeight = Height;
                }
                else
                {
                    _SelectedHeight = value;
                }
                InvalidateScroll();
            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color SelectedItemColour
        {
            get { return _SelectedItemColour; }
            set { _SelectedItemColour = value; }
        }

        [Category("Colours")]
        public Color NonSelectedItemColour
        {
            get { return _NonSelectedItemColour; }
            set { _NonSelectedItemColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }


        private void HandleScroll(object sender)
        {
            Invalidate();
        }

        private void InvalidateScroll()
        {
            Debug.Print(Convert.ToString(Height));
            if (Convert.ToInt32(Math.Round((float)((_Items.Count) * ItemHeight) / _SelectedHeight)) < Convert.ToDouble((((_Items.Count) * ItemHeight) / _SelectedHeight)))
            {
                VerticalScrollbar._Maximum = Convert.ToInt32(Math.Ceiling((float)((_Items.Count) * ItemHeight) / _SelectedHeight));
            }
            else if (Convert.ToInt32(Math.Round((float)((_Items.Count) * ItemHeight) / _SelectedHeight)) == 0)
            {
                VerticalScrollbar._Maximum = 1;
            }
            else
            {
                VerticalScrollbar._Maximum = Convert.ToInt32(Math.Round((float)((_Items.Count) * ItemHeight) / _SelectedHeight));
            }
            Invalidate();
        }

        private void InvalidateLayout()
        {
            VerticalScrollbar.Location = new Point(Width - VerticalScrollbar.Width - 2, 2);
            VerticalScrollbar.Size = new Size(18, Height - 4);
            Invalidate();
        }

        public class LogInListBoxItem
        {
            public string Text { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public LogInListBoxItem[] Items
        {
            get { return _Items.ToArray(); }
            set
            {
                _Items = new List<LogInListBoxItem>(value);
                Invalidate();
                InvalidateScroll();
            }
        }

        public LogInListBoxItem[] SelectedItems
        {
            get { return _SelectedItems.ToArray(); }
        }

        public bool MultiSelect
        {
            get { return _MultiSelect; }
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

        public override Font Font
        {
            get { return base.Font; }
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
            LogInListBoxItem Item = new LogInListBoxItem();
            Item.Text = Items;
            _Items.Add(Item);
            Invalidate();
            InvalidateScroll();
        }

        public void AddItems(string[] Items)
        {
            foreach (String I_loopVariable in Items)
            {
                string I = I_loopVariable;
                LogInListBoxItem Item = new LogInListBoxItem();
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

        public void RemoveItem(LogInListBoxItem item)
        {
            _Items.Remove(item);
            Invalidate();
            InvalidateScroll();
        }

        public void RemoveItems(LogInListBoxItem[] items)
        {
            foreach (LogInListBoxItem I in items)
            {
                _Items.Remove(I);
            }
            Invalidate();
            InvalidateScroll();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
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

                int Index = ((e.Y + Offset) / ItemHeight);

                if (Index > _Items.Count - 1)
                    Index = -1;


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
                    Debug.Print(Convert.ToString(_SelectedItems[0].Text));
                }

                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int Move = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (2 / 2));
            int Value = Math.Max(Math.Min(VerticalScrollbar.Value + Move, VerticalScrollbar.Maximum), VerticalScrollbar.Minimum);
            VerticalScrollbar.Value = Value;
            base.OnMouseWheel(e);
        }

        #endregion

        #region "Draw Control"

        public LogInTitledListBoxWBuiltInScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            VerticalScrollbar = new LogInVerticalScrollBar();
            VerticalScrollbar.SmallChange = 1;
            VerticalScrollbar.LargeChange = 1;
            VerticalScrollbar.Scroll += HandleScroll;
            VerticalScrollbar.MouseDown += Vertical_MouseDown;
            Controls.Add(VerticalScrollbar);
            InvalidateLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            var _with30 = G;
            _with30.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with30.SmoothingMode = SmoothingMode.HighQuality;
            _with30.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with30.Clear(_BaseColour);
            LogInListBoxItem AllItems = null;
            int Offset = Convert.ToInt32(VerticalScrollbar.Value * (VerticalScrollbar.Maximum + (Height - (ItemHeight))));
            int StartIndex = 0;
            if (Offset == 0)
                StartIndex = 0;
            else
                StartIndex = Convert.ToInt32(Offset / ItemHeight / VerticalScrollbar.Maximum);
            int EndIndex = Math.Min(StartIndex + (Height / ItemHeight), _Items.Count - 1);

            for (int I = StartIndex; I <= _Items.Count - 1; I++)
            {
                AllItems = Items[I];
                int Y = (ItemHeight + (I * ItemHeight) + 1 - Offset) + Convert.ToInt32((ItemHeight / 2) - 8);
                if (_SelectedItems.Contains(AllItems))
                {
                    _with30.FillRectangle(new SolidBrush(_SelectedItemColour), new Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1));
                }
                else
                {
                    _with30.FillRectangle(new SolidBrush(_NonSelectedItemColour), new Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width - 19, ItemHeight - 1));
                }
                _with30.DrawLine(new Pen(_BorderColour), 0, (ItemHeight + (I * ItemHeight) + 1 - Offset) + ItemHeight - 1, Width - 18, (ItemHeight + (I * ItemHeight) + 1 - Offset) + ItemHeight - 1);
                _with30.DrawString(AllItems.Text, new Font("Segoe UI", 8), new SolidBrush(_TextColour), 9, Y);
                _with30.ResetClip();
            }
            _with30.FillRectangle(new SolidBrush(_TitleAreaColour), new Rectangle(0, 0, Width, ItemHeight));
            _with30.DrawRectangle(new Pen(Color.FromArgb(35, 35, 35)), 1, 1, Width - 3, ItemHeight - 2);
            _with30.DrawString(Text, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(_TextColour), new Rectangle(0, 0, Width, ItemHeight + 2), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            _with30.DrawRectangle(new Pen(Color.FromArgb(35, 35, 35), 2), 1, 0, Width - 2, Height - 1);
            _with30.DrawLine(new Pen(_BorderColour), 0, ItemHeight, Width, ItemHeight);
            _with30.DrawLine(new Pen(_BorderColour, 2), VerticalScrollbar.Location.X - 1, 0, VerticalScrollbar.Location.X - 1, Height);
            _with30.InterpolationMode = (InterpolationMode)7;
        }

        #endregion

    }

}


