// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchTabControl : TabControl
    {
        public Color Color { get; set; }

        public TwitchTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(5, 5);
            foreach (TabPage Page in TabPages)
            {
                Page.BackColor = Color.FromArgb(40, 40, 40);
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.Clear(Color);
            if (DesignMode == true)
            {
                for (int i = 0; i <= TabCount - 1; i++)
                {
                    Rectangle TabRectangle = GetTabRect(i);
                    if (i == SelectedIndex)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(100, 65, 165)), TabRectangle);
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), TabRectangle);
                    }
                }
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
            base.OnPaint(e);
        }
    }
}

