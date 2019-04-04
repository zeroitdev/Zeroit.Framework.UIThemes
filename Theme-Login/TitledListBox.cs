// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TitledListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInTitledListBox : Control
    {

        #region "Variables"

        private ListBox withEventsField_ListB = new ListBox();
        private ListBox ListB
        {
            get { return withEventsField_ListB; }
            set
            {
                if (withEventsField_ListB != null)
                {
                    withEventsField_ListB.DrawItem -= Drawitem;
                }
                withEventsField_ListB = value;
                if (withEventsField_ListB != null)
                {
                    withEventsField_ListB.DrawItem += Drawitem;
                }
            }
        }
        private string[] _Items = { "" };
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _SelectedColour = Color.FromArgb(55, 55, 55);
        private Color _ListBaseColour = Color.FromArgb(47, 47, 47);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);

        private Font _TitleFont = new Font("Segeo UI", 10, FontStyle.Bold);
        #endregion

        #region "Properties"

        [Category("Control")]
        public Font TitleFont
        {
            get { return _TitleFont; }
            set { _TitleFont = value; }
        }

        [Category("Control")]
        public string[] Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                ListB.Items.Clear();
                ListB.Items.AddRange(value);
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color SelectedColour
        {
            get { return _SelectedColour; }
            set { _SelectedColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color ListBaseColour
        {
            get { return _ListBaseColour; }
            set { _ListBaseColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        public string SelectedItem
        {
            get { return Convert.ToString(ListB.SelectedItem); }
        }

        public int SelectedIndex
        {
            get
            {
                int functionReturnValue = 0;
                return ListB.SelectedIndex;
                if (ListB.SelectedIndex < 0)
                    return functionReturnValue;
                return functionReturnValue;
            }
        }

        public void Clear()
        {
            ListB.Items.Clear();
        }

        public void ClearSelected()
        {
            for (int i = (ListB.SelectedItems.Count - 1); i >= 0; i += -1)
            {
                ListB.Items.Remove(ListB.SelectedItems[i]);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(ListB))
            {
                Controls.Add(ListB);
            }
        }

        public void AddRange(object[] items)
        {
            ListB.Items.Remove("");
            ListB.Items.AddRange(items);
        }

        public void AddItem(object item)
        {
            ListB.Items.Remove("");
            ListB.Items.Add(item);
        }

        #endregion

        #region "Draw Control"

        public void Drawitem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();
            var _with17 = e.Graphics;
            _with17.SmoothingMode = SmoothingMode.HighQuality;
            _with17.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with17.InterpolationMode = InterpolationMode.HighQualityBicubic;
            _with17.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if (String.Compare(e.State.ToString(), "Selected,") > 0)
            {
                _with17.FillRectangle(new SolidBrush(_SelectedColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1));
                _with17.DrawString(" " + ListB.Items[e.Index].ToString(), new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
            }
            else
            {
                _with17.FillRectangle(new SolidBrush(_ListBaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                _with17.DrawString(" " + ListB.Items[e.Index].ToString(), new Font("Segoe UI", 8), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
            }
            _with17.Dispose();
        }

        public LogInTitledListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            ListB.DrawMode = DrawMode.OwnerDrawFixed;
            ListB.ScrollAlwaysVisible = false;
            ListB.HorizontalScrollbar = false;
            ListB.BorderStyle = BorderStyle.None;
            ListB.BackColor = BaseColour;
            ListB.Location = new Point(3, 28);
            ListB.Font = new Font("Segoe UI", 8);
            ListB.ItemHeight = 20;
            ListB.Items.Clear();
            ListB.IntegralHeight = false;
            Size = new Size(130, 100);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with18 = G;
            _with18.SmoothingMode = SmoothingMode.HighQuality;
            _with18.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with18.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with18.Clear(BackColor);
            ListB.Size = new Size(Width - 6, Height - 30);
            _with18.FillRectangle(new SolidBrush(BaseColour), Base);
            _with18.DrawRectangle(new Pen((_BorderColour), 3), new Rectangle(0, 0, Width, Height - 1));
            _with18.DrawLine(new Pen((_BorderColour), 2), new Point(0, 27), new Point(Width - 1, 27));
            _with18.DrawString(Text, _TitleFont, new SolidBrush(_TextColour), new Rectangle(2, 5, Width - 5, 20), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            _with18.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


