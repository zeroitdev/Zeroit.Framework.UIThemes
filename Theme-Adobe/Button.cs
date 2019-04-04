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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Adobe
{

    public class AdobeButton : ThemeControl154
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
        
        #region " Properties "

        private bool alt;
	public bool Alternate {
		get { return alt; }
		set { alt = value; }
	}

	#endregion

	public AdobeButton()
	{
		BackColor = Color.FromArgb(51, 51, 51);
	}

	protected override void ColorHook()
	{
		//Void
	}

	protected override void PaintHook()
	{
		G.Clear(Color.FromArgb(102, 102, 102));

            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
                                                                                                        //
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
                                                                                                        //
            

            int gC = 15;
		Color _text = Color.White;
		Color C1 = default(Color);
		Color C2 = default(Color);
		Color C3 = default(Color);
		Color C4 = default(Color);

		switch (Alternate) {
			case true:
				C1 = Color.FromArgb(255, 209, 51);
				C2 = Color.FromArgb(255, 165, 13);
				C3 = Color.FromArgb(255, 195, 13);
				C4 = Color.FromArgb(255, 163, 0);
				break;
			case false:
				C1 = Color.FromArgb(105, 105, 105);
				C2 = Color.FromArgb(56, 56, 56);
				C3 = Color.FromArgb(73, 73, 73);
				C4 = Color.FromArgb(48, 48, 48);
				break;
		}

		DrawGradient(C1, C2, 0, 0, Width, Height, 90);
		DrawGradient(C3, C4, 1, 1, Width - 2, Height - 2, 90);

		switch (State) {
			case MouseState.None:
				break;
			//NULL
			case MouseState.Over:
				switch (Alternate) {
					case true:
						_text = Color.Black;
						break;
				}
				gC = 5;
				break;
			case MouseState.Down:
				switch (Alternate) {
					case true:
						_text = Color.White;
						break;
				}
				gC = 10;
				break;
		}

		for (int i = 1; i <= 5; i++) {
			G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(Convert.ToInt32(255 / (i * gC)), Color.White))), new Rectangle(i, i, Width - 2 - (i * 2), Height - 2 - (i * 2)));
		}

		DrawBorders(Pens.Black);
		DrawText(ConversionFunctions.ConvertToBrush(Color.FromArgb(180, Color.Black)), HorizontalAlignment.Center, 0, 2);
		DrawText(ConversionFunctions.ConvertToBrush(_text), HorizontalAlignment.Center, -1, 1);

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
}

}
