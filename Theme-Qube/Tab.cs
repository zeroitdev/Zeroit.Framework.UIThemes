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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Qube
{
    public class QubeTabControl : TabControl
    {

        private Color BC = Color.FromArgb(68, 76, 99);
        private Brush UTC = new SolidBrush(Color.FromArgb(125, 146, 166));

        private Brush STC = Brushes.White;
        private SolidBrush BCB;
        private Pen BCP;
        private Rectangle TR;
        private Rectangle InR;
        private Rectangle LR;
        private Rectangle ImR;
        private StringFormat SF = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        private int ICounter = 0;
        public QubeTabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
            SetStyle(ControlStyles.Selectable, false);
            SizeMode = TabSizeMode.Fixed;
            Alignment = TabAlignment.Left;
            ItemSize = new Size(35, 93);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Font = new Font("Verdana", 8);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            BCB = new SolidBrush(BC);
            BCP = new Pen(BC);

            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (!(SelectedIndex == null) && !(SelectedIndex == -1) && !(SelectedIndex > TabPages.Count - 1) && !(TabPages[SelectedIndex].BackColor == Color.Transparent))
            {
                g.Clear(TabPages[SelectedIndex].BackColor);
            }
            else
            {
                g.Clear(Color.White);
            }
            ICounter = 0;
            LR = new Rectangle(0, 0, ItemSize.Height + 3, Height);
            g.FillRectangle(BCB, LR);
            g.DrawRectangle(BCP, LR);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i <= TabCount - 1; i++)
            {
                TR = GetTabRect(i);
                TR = new Rectangle(TR.X, TR.Y, TR.Width - 1, TR.Height);
                if (TabPages[i].Tag != null && !object.ReferenceEquals(TabPages[i].Tag, string.Empty))
                {
                    InR = new Rectangle(TR.X + 10, TR.Y, TR.Width - 10, TR.Height);
                    ICounter += 1;
                }
                else
                {
                    if (i == SelectedIndex)
                    {
                        InR = new Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height);

                        g.DrawString(TabPages[i].Text, Font, STC, InR, SF);

                        if (SelectedImageList != null && SelectedImageList.Images.Count > i - ICounter && SelectedImageList.Images[i - ICounter] != null)
                        {
                            ImR = new Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16);
                            g.DrawImage(SelectedImageList.Images[i - ICounter], ImR);
                        }

                    }
                    else
                    {
                        InR = new Rectangle(TR.X + 36, TR.Y, TR.Width - 36, TR.Height);
                        g.DrawString(TabPages[i].Text, Font, UTC, InR, SF);

                        if (UnselectedImageList != null && UnselectedImageList.Images.Count > i - ICounter && UnselectedImageList.Images[i - ICounter] != null)
                        {
                            ImR = new Rectangle(TR.X + 13, TR.Y + ((TR.Height / 2) - 8), 16, 16);
                            g.DrawImage(UnselectedImageList.Images[i - ICounter], ImR);
                        }

                    }
                }
            }


            g.Dispose();

        }

        private ImageList UnselectedImageList;
        public ImageList ImageList_Unselected
        {
            get { return UnselectedImageList; }
            set
            {
                UnselectedImageList = value;
                if (UnselectedImageList != null && !(UnselectedImageList.ImageSize == new Size(16, 16)))
                {
                    UnselectedImageList.ImageSize = new Size(16, 16);
                }
                Invalidate();
            }
        }

        private ImageList SelectedImageList;
        public ImageList ImageList_Selected
        {
            get { return SelectedImageList; }
            set
            {
                SelectedImageList = value;
                if (SelectedImageList != null && !(SelectedImageList.ImageSize == new Size(16, 16)))
                {
                    SelectedImageList.ImageSize = new Size(16, 16);
                }
                Invalidate();
            }
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if (e.TabPage != null && e.TabPage.Tag != null && !object.ReferenceEquals(e.TabPage.Tag, string.Empty) && !DesignMode)
            {
                e.Cancel = true;
            }
        }

    }

}
