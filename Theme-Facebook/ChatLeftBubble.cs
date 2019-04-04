// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ChatLeftBubble.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{
    public class FacebookChatLeftBubble : Control
    {

        #region "Declarations"
        private Color _TextColour = Color.FromArgb(65, 73, 80);
        private Color _BorderColour = Color.FromArgb(198, 198, 198);
        private Color _BaseColour = Color.FromArgb(250, 250, 250);
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
        public FacebookChatLeftBubble()
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
            var _with8 = G;
            _with8.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with8.SmoothingMode = SmoothingMode.HighQuality;
            _with8.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with8.Clear(BackColor);
            if (_ShowArrow)
            {
                Rectangle Base = new Rectangle(7, 0, Width - 7, Height - 1);
                Rectangle BorderBase = new Rectangle(8, 0, Width - 8, Height);
                GP = DrawHelpers.RoundRec(Base, 2);
                GP1 = DrawHelpers.RoundRec(BorderBase, 4);
                _with8.FillPath(new SolidBrush(_BaseColour), GP);
                _with8.DrawPath(new Pen(new SolidBrush(_BorderColour)), GP1);
                _with8.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(15, 4, Width - 17, Height - 5));
                if (_ArrowFixed)
                {
                    Point[] p = {
                    new Point(9, 11),
                    new Point(0, 17),
                    new Point(9, 22)
                };
                    _with8.FillPolygon(new SolidBrush(_BaseColour), p);
                    _with8.DrawPolygon(new Pen(new SolidBrush(_BaseColour)), p);
                    _with8.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(8, 11), new Point(0, 17));
                    _with8.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(0, 17), new Point(8, 22));
                }
                else
                {
                    Point[] p = {
                    new Point(9, Height - 19),
                    new Point(0, Height - 25),
                    new Point(9, Height - 30)
                };
                    _with8.FillPolygon(new SolidBrush(_BaseColour), p);
                    _with8.DrawPolygon(new Pen(new SolidBrush(_BaseColour)), p);
                    _with8.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(8, Height - 19), new Point(0, Height - 25));
                    _with8.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(0, Height - 25), new Point(8, Height - 30));
                }
            }
            else
            {
                Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
                Rectangle BorderBase = new Rectangle(0, 0, Width, Height);
                GP = DrawHelpers.RoundRec(Base, 2);
                GP1 = DrawHelpers.RoundRec(BorderBase, 4);
                _with8.FillPath(new SolidBrush(_BaseColour), GP);
                _with8.DrawPath(new Pen(new SolidBrush(_BorderColour)), GP1);
                _with8.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(6, 4, Width - 17, Height - 5));
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

