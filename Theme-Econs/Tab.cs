﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.Econs.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Econs
{
    public class EconsTabControl : TabControl
    {

        #region " Variables"

        private int W;
        private int H;

        private bool _Theme;
        #endregion

        #region " Properties"

        public bool LightTheme
        {
            get { return _Theme; }
            set { _Theme = value; }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        #region " Colors"

        [Category("Colors")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }

        [Category("Colors")]
        public Color ActiveColor
        {
            get { return _ActiveColor; }
            set { _ActiveColor = value; }
        }

        #endregion

        #endregion

        #region " Colors"

        private Color BGColor = Color.FromArgb(0, 0, 0);
        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _ActiveColor = _FlatColor;
        private Brush _unactive;
        private Brush _active;
        private Color unactive;

        private Color active;
        #endregion

        public EconsTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);

            Font = new Font("Segoe UI", 15);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(140, 40);

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (_Theme == true)
            {
                //light
                BGColor = Color.FromArgb(255, 255, 255);
                _BaseColor = Color.FromArgb(255, 255, 255);
                ActiveColor = Color.FromArgb(225, 225, 225);
                _active = Brushes.Silver;
                _unactive = Brushes.DimGray;
                active = Color.Silver;
                unactive = Color.DimGray;

            }
            else
            {
                //dark
                BGColor = Color.FromArgb(0, 0, 0);
                _BaseColor = Color.FromArgb(0, 0, 0);
                ActiveColor = Color.FromArgb(25, 25, 25);
                _active = Brushes.DimGray;
                _active = Brushes.Silver;
                active = Color.DimGray;
                unactive = Color.Silver;
            }

            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            var _with10 = G;
            _with10.SmoothingMode = (SmoothingMode)2;
            _with10.PixelOffsetMode = (PixelOffsetMode)2;
            _with10.TextRenderingHint = (TextRenderingHint)5;
            _with10.Clear(_BaseColor);

            try
            {
                SelectedTab.BackColor = BGColor;
            }
            catch
            {
            }

            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle Base = new Rectangle(new Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width, GetTabRect(i).Height));
                Rectangle BaseSize = new Rectangle(Base.Location, new Size(Base.Width, Base.Height));

                if (i == SelectedIndex)
                {
                    //-- Base
                    //.FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    //-- Gradiant
                    //.fill
                    //.FillRectangle(New SolidBrush(_ActiveColor), BaseSize)

                    //-- ImageList
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                //-- Image
                                _with10.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                //-- Text
                                _with10.DrawString("      " + "MD" + TabPages[i].Text, Font, _unactive, BaseSize, CenterSF);
                            }
                            else
                            {
                                //-- Text
                                _with10.DrawString(TabPages[i].Text, Font, _active, BaseSize, CenterSF);
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
                        //.DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                        _with10.DrawString(TabPages[i].Text, Font, new SolidBrush(unactive), BaseSize, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                }
                else
                {
                    //-- Base
                    _with10.FillRectangle(new SolidBrush(_BaseColor), BaseSize);

                    //-- ImageList
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                //-- Image
                                _with10.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6));
                                //-- Text
                                _with10.DrawString("      " + TabPages[i].Text, Font, new SolidBrush(Color.White), BaseSize, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                //-- Text
                                _with10.DrawString(TabPages[i].Text, Font, new SolidBrush(active), BaseSize, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
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
                        _with10.DrawString(TabPages[i].Text, Font, new SolidBrush(active), BaseSize, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });


                    }
                }
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }

}