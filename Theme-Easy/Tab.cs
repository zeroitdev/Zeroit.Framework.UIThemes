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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Easy
{
    public class EasyTabs : TabControl
    {
        // Initialize
        public EasyTabs()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Dock = DockStyle.Bottom;
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(100, 20);
        }

        // Tabs Back Color Property
        private Color m_Backcolor = Color.Empty;
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                if (m_Backcolor.Equals(Color.Empty))
                {
                    if (Parent == null)
                    {
                        return Control.DefaultBackColor;
                    }
                    else
                    {
                        return Parent.BackColor;
                    }
                }
                return m_Backcolor;
            }
            set
            {
                if (m_Backcolor.Equals(value))
                {
                    return;
                }
                m_Backcolor = value;
                Invalidate();
                base.OnBackColorChanged(EventArgs.Empty);
            }
        }

        public bool ShouldSerializeBackColor()
        {
            return !(m_Backcolor.Equals(Color.Empty));
        }

        public override void ResetBackColor()
        {
            m_Backcolor = Color.Empty;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(BackColor);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Apply Colouring To Each Tab Page
            for (int i = 0; i < TabPages.Count; i++)
            {
                Rectangle rect = GetTabRect(i);
                Rectangle r = new Rectangle(GetTabRect(i).X + 10, GetTabRect(i).Y + 3, 100, 20);
                if (SelectedTab == TabPages[i])
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(75, 0, 0, 0)), rect);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), rect);
                }

                // Draw Tab Page Text
                g.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), (Rectangle)r);
                TabPages[i].UseVisualStyleBackColor = false;
            }
        }
    }
}
