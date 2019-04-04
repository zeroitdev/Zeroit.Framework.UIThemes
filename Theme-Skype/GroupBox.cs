// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Skype
{
    public class SkypeGroupbox : ContainerControl
    {
        private Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }
        public SkypeGroupbox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.White;
            DoubleBuffered = true;
        }
        public int RoundUp(double d)
        {
            if (d.ToString().Contains(","))
            {
                return Convert.ToInt32(d.ToString().Split(Convert.ToChar((",")), ((char)0))) + 1;
            }
            else
            {
                return Convert.ToInt32(d);
            }
        }
        private bool _BottomBar = false;
        public bool BottomBar
        {
            get { return _BottomBar; }
            set
            {
                _BottomBar = value;
                Invalidate();
            }
        }
        private Image _CaptionImage;
        public Image CaptionImage
        {
            get { return _CaptionImage; }
            set
            {
                _CaptionImage = value;
                Invalidate();
            }
        }
        private bool _Caption = false;
        public string CaptionText
        {
            get { return _CaptionText; }
            set
            {
                _CaptionText = value;
                Invalidate();
            }
        }
        private string _CaptionText = "";
        public bool Caption
        {
            get { return _Caption; }
            set
            {
                _Caption = value;
                Invalidate();
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Image Corner_Left_Top = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAIAAAAmkwkpAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADxJREFUGFdj7Nn3/8/vn98+vf35/QtDx84fFYtvT9z84Oqjzwx1q58CWd9//v3//z9D+aKbVx59BrKAAAAObiiiSPYygwAAAABJRU5ErkJggg==");
            Image Corner_Right_Top = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAIAAAAmkwkpAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADlJREFUGFdjLF90k52Th4tPmIWVneHqo88TNz+oWHy7Y+cPhv///3//+RfIr1v9FMQBgiuPPgPVAwCozR/5eeWQ5wAAAABJRU5ErkJggg==");
            Image Corner_Left_Bot = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAIAAAAmkwkpAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAACJJREFUGFdjKF908z8MMNStforgdOz8geD07PsP5APlgeoBWv0poRMgjd8AAAAASUVORK5CYII=");
            Image Corner_Right_Bot = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAIAAAAmkwkpAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAClJREFUGFdj/P//PwMYVCy+xQDkQEDd6qcITsfOHwzli24CxYCsnn3/AWDMI6v3pdX3AAAAAElFTkSuQmCC");

            Image Corner_Left_Bot_New = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAIAAAAmkwkpAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADVJREFUGFdjLF90M9hCXJiXlQEIqpc/mLD5wd3nX4GIoX37N6AkkH/q1geGnn3/gXygPFAIAJkXHaCX6UBVAAAAAElFTkSuQmCC");
            Image Corner_Right_Bot_New = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAQAAAAECAIAAAAmkwkpAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADdJREFUGFdjvPv8KwMDw9vPv9eeeMkA5ADRhM0Pqpc/YDh16wOQVb7oZvv2bwxACigGZPXs+w8AgtEi2UaAmzcAAAAASUVORK5CYII=");

            Image OnePxImg = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAADIAAAATCAIAAABdrcl1AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAEJJREFUSEtjvPv8K8MgBEBnDULEMAjdBIrAUWeRkFpGQ4uUvDUaWqOhRULmIqkkGk1bo2lrNG2RlGVopHg0J5KSEwFcyJWmO09UYwAAAABJRU5ErkJggg==");

            Image CaptionCorner_Left = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAMAAAADCAIAAADZSiLoAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAACdJREFUGFdjXHrm/68f3z69f80w78jXnnU3Vx56zDBh8wMg9evXLwBQYRY9ipWOggAAAABJRU5ErkJggg==");
            Image CaptionCorner_Right = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAMAAAADCAIAAADZSiLoAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAACdJREFUGFdjnLj5AZ+gKBsHF8PKQ4971t2cd+Qrw69fv4CcCZsfAADNdxCJDpD+PwAAAABJRU5ErkJggg==");

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle Body = new Rectangle(4, 25, Width - 9, Height - 30);
            Rectangle Body2 = new Rectangle(0, 0, Width - 1, Height - 1);

            base.OnPaint(e);

            G.Clear(Color.Transparent);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;

            G.DrawImage(Corner_Left_Top, 0, 0, 4, 4);
            G.DrawImage(Corner_Right_Top, Width - 4, 0, 4, 4);

            if (_Caption == true)
            {
                dynamic DrawGradientBrush = new LinearGradientBrush(new Rectangle(0, 2, Width - 1, 29), Color.FromArgb(241, 241, 241), Color.FromArgb(218, 218, 218), 90f);
                G.FillRectangle(DrawGradientBrush, new Rectangle(0, 2, Width - 1, 29));
                G.DrawLine(Pens.White, 1, 1, Width - 1, 1);
                G.DrawImage(CaptionCorner_Left, 0, 0, 3, 3);
                G.DrawImage(CaptionCorner_Right, Width - 3, 0, 3, 3);
                G.DrawLine(new Pen(Color.FromArgb(203, 203, 203)), 0, 31, Width - 1, 31);
                try
                {
                    G.DrawImage(_CaptionImage, 9, 9, 16, 16);
                    G.DrawString(_CaptionText, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(51, 51, 51)), 30, 8);

                }
                catch (Exception ex)
                {
                }
            }

            if (_BottomBar == true)
            {
                for (int i = 0; i <= RoundUp(Width / 50); i++)
                {
                    G.DrawImage(OnePxImg, i * 50, Height - 20);
                }
                G.DrawLine(new Pen(Color.FromArgb(217, 217, 217)), 1, Height - 21, Width - 2, Height - 21);
                G.DrawRectangle(new Pen(Color.FromArgb(119, 162, 217)), 0, 0, Width - 1, Height - 1);
                G.DrawImage(Corner_Left_Bot_New, 0, Height - 4, 4, 4);
                G.DrawImage(Corner_Right_Bot_New, Width - 4, Height - 4, 4, 4);
                G.DrawString(Text, new Font("Arial", 8), new SolidBrush(Color.FromArgb(153, 153, 153)), 4, Height - 17);
            }
            else
            {
                G.DrawImage(Corner_Left_Bot, 0, Height - 4, 4, 4);
                G.DrawImage(Corner_Right_Bot, Width - 4, Height - 4, 4, 4);
                G.DrawRectangle(new Pen(Color.FromArgb(119, 162, 217)), 0, 0, Width - 1, Height - 1);
            }

            B.SetPixel(0, Height - 1, Color.FromArgb(148, 195, 255));
            B.SetPixel(Width - 1, Height - 1, Color.FromArgb(148, 195, 255));
            B.SetPixel(Width - 1, 0, Color.FromArgb(148, 195, 255));
            B.SetPixel(0, 0, Color.FromArgb(148, 195, 255));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

