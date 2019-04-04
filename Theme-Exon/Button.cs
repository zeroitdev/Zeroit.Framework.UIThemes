// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.EightBall
{

    public class EightBallButton : Control
{



        #region Image Designer

        #region Include in paint method

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        //                                                                                             //                                                                     
        //         ------------------------Add this to the Paint Method ------------------------       //
        //                                                                                             //
        // Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
        //                                                                                             //
        // PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
        //                                                                                             //
        // if ((Image == null))                                                                        //
        //     {                                                                                       //
        //         G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        // else                                                                                        //
        //      {                                                                                      //
        //         G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
        //          G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        //                                                                                             //
        /////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
        private Image _Image;
        private Size _ImageSize;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        private StringAlignment _TextAlignment = StringAlignment.Center;

        #endregion

        #region Include in Public Properties
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region Include in Private Methods
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion
        #endregion
        
        public enum MouseState
    {
        None,
        Over,
        Down
    }


    private MouseState State;
    private Timer withEventsField_animTimer = new Timer { Interval = 25 };
    private Timer animTimer
    {
        get { return withEventsField_animTimer; }
        set
        {
            if (withEventsField_animTimer != null)
            {
                withEventsField_animTimer.Tick -= animTimer_Tick;
            }
            withEventsField_animTimer = value;
            if (withEventsField_animTimer != null)
            {
                withEventsField_animTimer.Tick += animTimer_Tick;
            }
        }
    }
    private bool glowIncreasing;

    private int glow;
    private bool _animated;
    public bool Animation
    {
        get { return _animated; }
        set
        {
            _animated = value;
            Invalidate();
        }
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    public EightBallButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        Font = new Font("Segoe UI", 9);
        BackColor = Color.Gray;
        ForeColor = Color.WhiteSmoke;
        Size = new Size(120, 40);
        Cursor = Cursors.Hand;
        Animation = true;
        State = MouseState.None;
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.Clear(Parent.BackColor);
        g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
                                                                                                        //
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
                                                                                                        //
            

        Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
        GraphicsPath mainPath = Drawing.RoundRect(mainRect, 6);

        LinearGradientBrush bgBrush = new LinearGradientBrush(mainRect, BackColor, Color.FromArgb(40, 40, 40), 90f);
        g.FillPath(bgBrush, mainPath);
        if (State == MouseState.Down)
        {
            g.FillPath(new SolidBrush(Color.FromArgb(25, Color.White)), mainPath);

                if ((Image == null))                                                                        //
                {                                                                                       //
                    //g.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                    //{                                                                               //
                    //    Alignment = _TextAlignment,                                                 //
                    //    LineAlignment = StringAlignment.Center                                      //
                    //});                                                                             //
                }                                                                                      //
                else                                                                                        //
                {                                                                                      //
                    g.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                    //g.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
                    //{                                                                               //
                    //    Alignment = _TextAlignment,                                                 //
                    //    LineAlignment = StringAlignment.Center                                      //
                    //});                                                                             //
                }
            }
        else if (State == MouseState.Over)
        {
            if (_animated)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(glow, Color.White)), mainPath);

                    if ((Image == null))                                                                        //
                    {                                                                                       //
                                                                                                          //    LineAlignment = StringAlignment.Center                                      //
                                                                                                            //});                                                                             //
                    }                                                                                      //
                    else                                                                                        //
                    {                                                                                      //
                        g.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                                                                                                          //});                                                                             //
                    }
                }
            else
            {
                g.FillPath(new SolidBrush(Color.FromArgb(12, Color.White)), mainPath);

                    if ((Image == null))                                                                        //
                    {                                                                                       //
                                                                                                            //g.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                                                                                                            //{                                                                               //
                                                                                                            //    Alignment = _TextAlignment,                                                 //
                                                                                                            //    LineAlignment = StringAlignment.Center                                      //
                                                                                                            //});                                                                             //
                    }                                                                                      //
                    else                                                                                        //
                    {                                                                                      //
                        g.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                                                                                                          //    LineAlignment = StringAlignment.Center                                      //
                                                                                                           //});                                                                             //
                    }
                }
        }
        else
        {
            if (_animated)
                {

                    if ((Image == null))                                                                        
                    {                                                                                       
                                                                                                                                                 //
                                                                                                                                                                                         //
                    }                                                                                      
                    else                                                                                        
                    {
                        g.FillPath(new SolidBrush(Color.FromArgb(glow, Color.White)), mainPath);
                        g.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              
                                                                                                                                                                                       //
                    }
                }
                
        }

        int textX = 0;
        int textY = 0;
        textX = ((Width - 1) / 2) - Convert.ToInt32((g.MeasureString(Text, Font).Width / 2));
        textY = ((Height - 1) / 2) - Convert.ToInt32((g.MeasureString(Text, Font).Height / 2));
        Drawing.ShadowedString(g, Text, Font, new SolidBrush(ForeColor), new Point(textX, textY));

        g.DrawPath(new Pen(Color.FromArgb(60, 60, 60)), mainPath);

    }

    private void animTimer_Tick(object sender, System.EventArgs e)
    {
        if (glowIncreasing)
        {
            if (glow < 16)
            {
                glow += 2;
            }
            else
            {
                animTimer.Enabled = false;
            }
        }
        else
        {
            if (glow > 0)
            {
                glow -= 2;
            }
            else
            {
                animTimer.Enabled = false;
            }
        }
        Invalidate();
    }

    protected override void OnMouseEnter(System.EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Over;
        if (_animated)
        {
            glowIncreasing = true;
            animTimer.Enabled = true;
        }
        Invalidate();
    }

    protected override void OnMouseLeave(System.EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        if (_animated)
        {
            glowIncreasing = false;
            animTimer.Enabled = true;
        }
        Invalidate();
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = MouseState.Down;
        Invalidate();
    }

    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = MouseState.Over;
        Invalidate();
    }

}

}

