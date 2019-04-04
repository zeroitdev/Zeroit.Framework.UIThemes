// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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
    public class EasyProgressBar : Control
    {
        private int m_max = 100;
        private int m_min = 0;
        private int val = 0;

        // Initialize
        public EasyProgressBar()
        {
            base.Size = new Size(150, 15);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(25, 0, 0, 0);
            ForeColor = Color.FromArgb(200, 255, 255, 255);
        }

        // Progress Bar Minimum Value
        public int Min
        {
            get
            {
                return m_min;
            }
            set
            {
                if (value < 0)
                {
                    m_min = 0;
                }
                if (value > m_max)
                {
                    m_min = value;
                    m_min = value;
                }
                if (value < m_min)
                {
                    value = m_min;
                }
                Invalidate();
            }
        }

        // Progress Bar Maximum Value
        public int Max
        {
            get
            {
                return m_max;
            }
            set
            {
                if (value < m_min)
                {
                    m_min = value;
                }
                m_max = value;
                if (value > m_max)
                {
                    value = m_max;
                }
                Invalidate();
            }
        }

        // Progress Bar Current Value
        public int Value
        {
            get
            {
                return val;
            }
            set
            {
                int oldValue = val;
                if (value < m_min)
                {
                    val = m_min;
                }
                else if (value > m_max)
                {
                    val = m_max;
                }
                else
                {
                    val = value;
                }

                float percent = 0F;

                Rectangle newValueRect = new Rectangle(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4);
                Rectangle oldValueRect = new Rectangle(ClientRectangle.X + 2, ClientRectangle.Y + 2, ClientRectangle.Width - 4, ClientRectangle.Height - 4);

                percent = Convert.ToSingle(val - m_min) / Convert.ToSingle(m_max - m_min);
                newValueRect.Width = Convert.ToInt32(Convert.ToSingle(newValueRect.Width) * percent);

                percent = Convert.ToSingle(oldValue - m_min) / Convert.ToSingle(m_max - m_min);
                oldValueRect.Width = Convert.ToInt32(Convert.ToSingle(oldValueRect.Width) * percent);

                Rectangle updateRect = new Rectangle();

                if (newValueRect.Width > oldValueRect.Width)
                {
                    updateRect.X = oldValueRect.Size.Width;
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;
                }
                else
                {
                    updateRect.X = newValueRect.Size.Width;
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;
                }

                updateRect.Height = Height;
                Invalidate(updateRect);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            Graphics g = pevent.Graphics;
            // Progress Bar Background Colour
            g.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(ForeColor);
            float percent = Convert.ToSingle(val - m_min) / Convert.ToSingle(m_max - m_min);
            Rectangle rect = new Rectangle(2, 2, Width - 4, Height - 4);
            rect.Width = Convert.ToInt32(Convert.ToSingle(rect.Width) * percent);

            // Progress Bar ForeColour
            g.FillRectangle(brush, rect);
        }
    }
}
