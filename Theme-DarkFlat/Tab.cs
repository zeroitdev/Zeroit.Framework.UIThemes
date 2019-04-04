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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.DarkFlat
{
    public class DarkFlatTabControl : TabControl
    {
        #region  Variables

        private int W;
        private int H;

        #endregion

        #region  Properties

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        #region  Colors

        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return _BaseColor;
            }
            set
            {
                _BaseColor = value;
            }
        }

        [Category("Colors")]
        public Color ActiveColor
        {
            get
            {
                return _ActiveColor;
            }
            set
            {
                _ActiveColor = value;
            }
        }

        #endregion

        #endregion

        #region  Colors

        private Color BGColor = Color.FromArgb(50, 50, 50);
        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _ActiveColor = Color.FromArgb(0, 170, 220);

        #endregion

        public DarkFlatTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);

            Font = new Font("Segoe UI", 10);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 40);
        }

        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.OnTabIndexChanged(e);
            SelectedTab.BackColor = BGColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(_BaseColor);

            

            for (var i = 0; i < TabCount; i++)
            {
                Rectangle Base = new Rectangle(new Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                Rectangle BaseSize = new Rectangle(Base.Location, new Size(Base.Width, Base.Height));

                if (i == SelectedIndex)
                {
                    //-- Base
                    Helpers.G.FillRectangle(new SolidBrush(_BaseColor), BaseSize);

                    //-- Gradiant
                    //.fill
                    Helpers.G.FillRectangle(new SolidBrush(_ActiveColor), BaseSize);

                    //-- ImageList
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                //-- Image
                                Helpers.G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                //-- Text
                                Helpers.G.DrawString("      " + TabPages[i].Text, Font, Brushes.White, BaseSize, Helpers.CenterSF);
                            }
                            else
                            {
                                //-- Text
                                Helpers.G.DrawString(TabPages[i].Text, Font, Brushes.White, BaseSize, Helpers.CenterSF);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else
                    {
                        //-- Text
                        Helpers.G.DrawString(TabPages[i].Text, Font, Brushes.White, BaseSize, Helpers.CenterSF);
                    }
                }
                else
                {
                    //-- Base
                    Helpers.G.FillRectangle(new SolidBrush(_BaseColor), BaseSize);

                    //-- ImageList
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                //-- Image
                                Helpers.G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                //-- Text
                                Helpers.G.DrawString("      " + TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                            }
                            else
                            {
                                //-- Text
                                Helpers.G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else
                    {
                        //-- Text
                        Helpers.G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    }
                }
            }

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }

    }

}



