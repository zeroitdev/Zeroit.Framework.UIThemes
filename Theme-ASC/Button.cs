// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.AdvancedCore
{

    public class ASCButton : Control
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
        

    private Color _glowColor;
	public Color GlowColor {
		get { return _glowColor; }
		set {
			_glowColor = value;
			Invalidate();
		}
	}

	public enum State
	{
		None,
		Over,
		Down
	}


	private State MouseState;
	public ASCButton()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
		Size = new Size(100, 40);
		Font = new Font("Arial", 11);
		Cursor = Cursors.Hand;
		BackColor = Color.FromArgb(5, 30, 70);
		ForeColor = Color.FromArgb(195, 230, 255);
		GlowColor = Color.FromArgb(40, 95, 210);
	}

	protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
	{
		base.OnPaint(e);

		Graphics G = e.Graphics;

		G.SmoothingMode = SmoothingMode.HighQuality;
		G.Clear(Parent.BackColor);

        Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
                                                                                                        //
        PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
                                                                                                        //
            

        int slope = 5;

		Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
		GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);
		G.FillPath(new LinearGradientBrush(mainRect, BackColor, Color.FromArgb(25, Color.Black), 90f), mainPath);
		G.DrawPath(new Pen(Color.FromArgb(BackColor.R / 2, BackColor.G / 2, BackColor.B / 2)), mainPath);

		int glow = 0;
		if (MouseState == State.Over) {
			glow = 200;
		} else if (MouseState == State.Down) {
			glow = 255;
		} else {
			glow = 100;
		}
		G.DrawPath(new Pen(Color.FromArgb(glow, _glowColor)), mainPath);

		int textX = ((Width - 1) / 2) - Convert.ToInt32((G.MeasureString(Text, Font).Width / 2));
		int textY = ((Height - 1) / 2) - Convert.ToInt32((G.MeasureString(Text, Font).Height / 2));
		G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(textX, textY));

        
            if ((Image == null))                                                                        //
            {                                                                                       //
                //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                //{                                                                               //
                //    Alignment = _TextAlignment,                                                 //
                //    LineAlignment = StringAlignment.Center                                      //
                //});                                                                             //
            }                                                                                      //
            else                                                                                        //
            {                                                                                      //
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
                //{                                                                               //
                //    Alignment = _TextAlignment,                                                 //
                //    LineAlignment = StringAlignment.Center                                      //
                //});                                                                             //
            }

        }

	protected override void OnMouseEnter(System.EventArgs e)
	{
		base.OnMouseEnter(e);
		MouseState = State.Over;
		Invalidate();
	}

	protected override void OnMouseLeave(System.EventArgs e)
	{
		base.OnMouseLeave(e);
		MouseState = State.None;
		Invalidate();
	}

	protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseUp(e);
		MouseState = State.Over;
		Invalidate();
	}

	protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
	{
		base.OnMouseDown(e);
		MouseState = State.Down;
		Invalidate();
	}

}

}