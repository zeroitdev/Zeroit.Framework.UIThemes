﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Clarity
{
    public class ClarityListBox : ListBox
    {
        #region "Properties"
        public ClarityListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(22, 22, 22);
            BorderStyle = BorderStyle.None;
            ItemHeight = 15;
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
                CustomPaint();
        }
        public void CustomPaint()
        {
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(1, 1, Width - 3, Height - 3));
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(0, 0, Width - 1, Height - 1));
        }
        #endregion
        #region "Color of Control"
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height + 3));

            if (e.State.ToString().Contains("Selected,"))
            {
                LinearGradientBrush MainBody = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270);
                G.FillRectangle(MainBody, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
                G.DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
                HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
                G.FillRectangle(HeaderHatch, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));

            }
            else
            {
                G.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            }


            try
            {
                G.DrawString(" " + GetItemText(Items[e.Index]), Font, new SolidBrush(Color.FromArgb(100, Color.Black)), e.Bounds.X, e.Bounds.Y);
                G.DrawString(" " + GetItemText(Items[e.Index]), Font, new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds.X, e.Bounds.Y + 1);
            }
            catch
            {
            }
            G.DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(0, 0, Width - 1, Height - 1));
            base.OnDrawItem(e);
        }
        #endregion
    }

}

