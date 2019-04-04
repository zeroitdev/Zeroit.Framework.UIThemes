// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RichTextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  RichTextBox 

    [DefaultEvent("TextChanged")]
    public class iTalkRichTextBox : Control
    {
        #region  Variables 

        public RichTextBox iTalkRTB = new RichTextBox();
        private bool _ReadOnly;
        private bool _WordWrap;
        private bool _AutoWordSelection;
        private GraphicsPath Shape;

        #endregion
        #region  Properties 

        public override string Text
        {
            get
            {
                return iTalkRTB.Text;
            }
            set
            {
                iTalkRTB.Text = value;
                Invalidate();
            }
        }
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.ReadOnly = value;
                }
            }
        }
        public bool WordWrap
        {
            get
            {
                return _WordWrap;
            }
            set
            {
                _WordWrap = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.WordWrap = value;
                }
            }
        }
        public bool AutoWordSelection
        {
            get
            {
                return _AutoWordSelection;
            }
            set
            {
                _AutoWordSelection = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.AutoWordSelection = value;
                }
            }
        }
        #endregion
        #region  EventArgs 

        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            iTalkRTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            iTalkRTB.Font = Font;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            iTalkRTB.Size = new Size(Width - 13, Height - 11);
        }


        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();
        }

        public void _TextChanged(object sender, EventArgs e)
        {
            iTalkRTB.Text = Text;
        }

        #endregion

        public void AddRichTextBox()
        {
            iTalkRTB.BackColor = Color.White;
            iTalkRTB.Size = new Size(Width - 10, 100);
            iTalkRTB.Location = new Point(7, 5);
            iTalkRTB.Text = string.Empty;
            iTalkRTB.BorderStyle = BorderStyle.None;
            iTalkRTB.Font = new Font("Tahoma", 10);
            iTalkRTB.Multiline = true;
        }

        public iTalkRichTextBox() : base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddRichTextBox();
            Controls.Add(iTalkRTB);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Text = null;
            Font = new Font("Tahoma", 10);
            Size = new Size(150, 100);
            WordWrap = true;
            AutoWordSelection = false;
            DoubleBuffered = true;
            SubscribeToEvents();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.Clear(Color.Transparent); // Set control background to transparent
            G.FillPath(Brushes.White, Shape); // Draw RTB background
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), Shape); // Draw border

            G.Dispose();
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            B.Dispose();
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            base.TextChanged += _TextChanged;
        }

    }

    #endregion
}