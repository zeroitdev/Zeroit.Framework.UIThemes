// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{
    public class MorphicTabControl : TabControl
    {
        private Graphics g;
        private DrawingHelper dh = new DrawingHelper();

        private List<Rectangle> tabRects = new List<Rectangle>();
        private int overTab = -1;

        private Font _tabFont;

        public Font TabFont
        {
            get
            {
                return _tabFont;
            }
            set
            {
                _tabFont = value;
                Invalidate();
            }
        }

        public MorphicTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Size = new Size(500, 300);
            TabFont = new Font(Preferences.FontFamily, 10);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            DrawMode = TabDrawMode.OwnerDrawFixed;
            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(60, 180);

            TabFont = new Font(Preferences.FontFamily, TabFont.Size);

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.Clear(Preferences.BackgroundColor);
            g.SmoothingMode = SmoothingMode.HighQuality;

            tabRects.Clear();

            for (int i = 0; i < TabCount; i++)
            {

                Rectangle baseRect = GetTabRect(i);
                Rectangle tabRect = new Rectangle(baseRect.X + 4, baseRect.Y + 4, baseRect.Width - 8, baseRect.Height - 8);
                tabRects.Add(tabRect);
                GraphicsPath tabPath = dh.RoundRect(tabRect, Preferences.Rounding);

                LinearGradientBrush backBrush = new LinearGradientBrush(tabRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
                g.FillPath(backBrush, tabPath);
                backBrush.Dispose();

                int brushIntensity = 0;

                if (i == SelectedIndex)
                {
                    brushIntensity = 50;
                }
                else if (i == overTab)
                {
                    brushIntensity = 20;
                }

                SolidBrush screenBrush = new SolidBrush(Color.FromArgb(brushIntensity, Preferences.MainColor));
                g.FillPath(screenBrush, tabPath);
                screenBrush.Dispose();

                g.DrawPath(new Pen(Preferences.BorderColor), tabPath);

                int textY = Convert.ToInt32(tabRect.Y + (tabRect.Height / 2.0) - (g.MeasureString(TabPages[i].Text, TabFont).Height / 2.0));
                g.DrawString(TabPages[i].Text, TabFont, new SolidBrush(Preferences.TextColor), 16, textY);

                try
                {
                    TabPages[i].BackColor = Preferences.BackgroundColor;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }


        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            overTab = GetMouseOverTabIndex(e.Location);
            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            overTab = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }

        private int GetMouseOverTabIndex(Point mouseLocation)
        {
            try
            {
                for (int i = 0; i < TabCount; i++)
                {
                    if (tabRects[i].Contains(mouseLocation))
                    {
                        return i;
                    }
                }
            }
            catch
            {
                return -1;
            }
            return -1;
        }

    }
}
