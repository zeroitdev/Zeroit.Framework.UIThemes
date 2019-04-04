// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ChatRightBubble.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{
    public class FacebookChatRightBubble : Control
    {
        #region "Declarations"
        private Color _TextColour = Color.FromArgb(65, 73, 80);
        private Color _BorderColour = Color.FromArgb(163, 182, 208);
        private Color _BaseColour = Color.FromArgb(214, 231, 254);
        private bool _ShowArrow = true;
        #endregion
        private bool _ArrowFixed = true;

        #region "Colour & Other Properties"
        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }
        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        [Category("Misc")]
        public bool ShowArrow
        {
            get { return _ShowArrow; }
            set { _ShowArrow = value; }
        }
        [Category("Misc")]
        public bool ArrowFixed
        {
            get { return _ArrowFixed; }
            set { _ArrowFixed = value; }
        }
        //--Need to sort out
        #region ""
        //Private _Multiline As Boolean
        //<Category("Options")>
        //Property Multiline() As Boolean
        //    Get
        //        Return _Multiline
        //    End Get
        //    Set(ByVal value As Boolean)
        //        _Multiline = value
        //        If TB IsNot Nothing Then
        //            TB.Multiline = value

        //            If value Then
        //                TB.Height = Height - 11
        //            Else
        //                Height = TB.Height + 11
        //            End If

        //        End If
        //    End Set
        //End Property
        //<Category("Options")>
        //Overrides Property Text As String
        //    Get
        //        Return MyBase.Text
        //    End Get
        //    Set(ByVal value As String)
        //        MyBase.Text = value
        //        If TB IsNot Nothing Then
        //            TB.Text = value
        //        End If
        //    End Set
        //End Property
        //<Category("Options")>
        //Overrides Property Font As Font
        //    Get
        //        Return MyBase.Font
        //    End Get
        //    Set(ByVal value As Font)
        //        MyBase.Font = value
        //        If TB IsNot Nothing Then
        //            TB.Font = value
        //            TB.Location = New Point(3, 5)
        //            TB.Width = Width - 6

        //            If Not _Multiline Then
        //                Height = TB.Height + 11
        //            End If
        //        End If
        //    End Set
        //End Property
        #endregion

        #endregion

        #region "Draw Control"
        public FacebookChatRightBubble()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(135, 32);
            BackColor = Color.Transparent;
            Font = new Font("Klavika", 9);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            dynamic GP = default(GraphicsPath);
            GraphicsPath GP1 = new GraphicsPath();
            var _with7 = G;
            _with7.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with7.SmoothingMode = SmoothingMode.HighQuality;
            _with7.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with7.Clear(BackColor);
            if (_ShowArrow)
            {
                Rectangle Base = new Rectangle(0, 0, Width - 8, Height - 1);
                Rectangle BorderBase = new Rectangle(0, 0, Width - 7, Height);
                GP = DrawHelpers.RoundRec(Base, 2);
                GP1 = DrawHelpers.RoundRec(BorderBase, 4);
                _with7.FillPath(new SolidBrush(_BaseColour), GP);
                _with7.DrawPath(new Pen(new SolidBrush(_BorderColour)), GP1);
                _with7.DrawString(Text, Font, new SolidBrush(_TextColour), (new Rectangle(6, 4, Width - 15, Height)));
                if (_ArrowFixed)
                {
                    Point[] p = {
                    new Point(Width - 8, 11),
                    new Point(Width, 17),
                    new Point(Width - 8, 22)
                };
                    _with7.FillPolygon(new SolidBrush(_BaseColour), p);
                    _with7.DrawPolygon(new Pen(new SolidBrush(_BaseColour)), p);
                    _with7.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(Width - 7, 11), new Point(Width, 17));
                    _with7.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(Width, 17), new Point(Width - 7, 22));
                }
                else
                {
                    Point[] p = {
                    new Point(Width - 8, Height - 19),
                    new Point(Width, Height - 25),
                    new Point(Width - 8, Height - 30)
                };
                    _with7.FillPolygon(new SolidBrush(_BaseColour), p);
                    _with7.DrawPolygon(new Pen(new SolidBrush(_BaseColour)), p);
                    _with7.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(Width - 7, Height - 19), new Point(Width, Height - 25));
                    _with7.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(Width, Height - 25), new Point(Width - 7, Height - 30));
                }
            }
            else
            {
                Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
                Rectangle BorderBase = new Rectangle(0, 0, Width, Height);
                GP = DrawHelpers.RoundRec(Base, 2);
                GP1 = DrawHelpers.RoundRec(BorderBase, 4);
                _with7.FillPath(new SolidBrush(_BaseColour), GP);
                _with7.DrawPath(new Pen(new SolidBrush(_BorderColour)), GP1);
                _with7.DrawString(Text, Font, new SolidBrush(_TextColour), (new Rectangle(6, 4, Width - 10, Height)));
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }


}

