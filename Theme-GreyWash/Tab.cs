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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashTabControl : TabControl
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            LightBrush = new SolidBrush(LightColor);
            DarkBrush = new SolidBrush(DarkColor);
        }

        #region  Declarations 
        private Color LightColor = Color.DarkGray;
        private Color DarkColor = Color.LightGray;
        private SolidBrush LightBrush;
        private SolidBrush DarkBrush;
        private SolidBrush NotSelectedColor = new SolidBrush(Color.LightGray);
        private SolidBrush SelectedColor = new SolidBrush(Color.DarkGray);
        #endregion

        public GreywashTabControl()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque), true);
            SetStyle(ControlStyles.Selectable, false);
            Dock = DockStyle.None;
            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(25, 120);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Font = new Font("Segoe UI", 10);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bm = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(DarkColor);

            for (var i = 0; i < TabCount; i++)
            {
                Rectangle TabRectangle = GetTabRect(i);
                if (i == SelectedIndex)
                {
                    g.FillRectangle(LightBrush, TabRectangle);
                    g.FillRectangle(SelectedColor, new Rectangle(TabRectangle.Location.X + 2, TabRectangle.Location.Y + 2, 3, TabRectangle.Height - 4));
                }
                else
                {
                    g.FillRectangle(DarkBrush, TabRectangle);
                    g.FillRectangle(NotSelectedColor, new Rectangle(TabRectangle.Location.X + 2, TabRectangle.Location.Y + 2, 3, TabRectangle.Height - 4));
                }
                g.DrawString(TabPages[i].Text, Font, Brushes.White, TabRectangle, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }

            e.Graphics.DrawImage((Image)bm.Clone(), 0, 0);
            g.Dispose();
            bm.Dispose();
            base.OnPaint(e);
        }

    }

}
