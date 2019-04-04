// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Loyal
{

    enum MouseState
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    [ToolboxItem(false)]
    public class LoyalTheme : ContainerControl
    {

        #region " Back End "

        #region " Enums "

        public enum ControlsAlign
        {
            Left = 0,
            Right = 2
        }

        public enum TextAlign
        {
            Left = 0,
            Center = 1,
            Right = 2
        }

        #endregion

        #region " Declarations "
        private bool _Down = false;
        private int _Header = 47;
        private Point _MousePoint;
        #endregion
        private StringFormat _ControlsFormat = new StringFormat { LineAlignment = StringAlignment.Center };

        #region " Properties "

        private Color _HeaderColor = Color.Aqua;
        [Category("Header Settings")]
        public Color HeaderColor
        {
            get { return _HeaderColor; }
            set
            {
                _HeaderColor = value;
                Invalidate();
            }
        }
        
        //Alignments
        private ControlsAlign _ControlsAlignment = ControlsAlign.Right;
        [Category("Header Settings")]
        public ControlsAlign ControlsAlignment
        {
            get { return _ControlsAlignment; }
            set
            {
                _ControlsAlignment = value;
                Invalidate();
            }
        }

        private TextAlign _TextAlignment = TextAlign.Center;
        [Category("Header Settings")]
        public TextAlign TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        //Header Size
        private int _HeaderSize = 30;
        [Category("Header Settings")]
        public int HeaderSize
        {
            get { return _HeaderSize; }
            set
            {
                _HeaderSize = value;
                Invalidate();
            }
        }


        //Show Controls
        private bool _ShowClose;
        [Category("Header Settings")]
        public bool ShowClose
        {
            get { return _ShowClose; }
            set
            {
                _ShowClose = value;
                Invalidate();
            }
        }

        private bool _ShowMinimize;
        [Category("Header Settings")]
        public bool ShowMinimize
        {
            get { return _ShowMinimize; }
            set
            {
                _ShowMinimize = value;
                Invalidate();
            }
        }

        private bool _ShowMaximize;
        [Category("Header Settings")]
        public bool ShowMaximize
        {
            get { return _ShowMaximize; }
            set
            {
                _ShowMaximize = value;
                Invalidate();
            }
        }

        #endregion

        #region " Mouse States "

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            switch (ControlsAlignment)
            {
                case ControlsAlign.Right:
                    //_ShowClose
                    if (_ShowClose == true)
                    {
                        if (new Rectangle(Width - 23, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                        {
                            Application.Exit();
                        }
                    }

                    //_ShowMinimize
                    if (_ShowMinimize == true)
                    {
                        if (_ShowMaximize == true)
                        {

                            if (_ShowClose == true)
                            {
                                if (new Rectangle(Width - 58, (((_HeaderSize + 2) - 18) / 2), 17, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }

                            }
                            else
                            {
                                if (new Rectangle(Width - 41, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (_ShowClose == true)
                            {
                                if (new Rectangle(Width - 41, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }
                            }
                            else
                            {
                                if (new Rectangle(Width - 23, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }
                            }
                        }
                    }
                    
                    //_ShowMaximize
                    if (_ShowMaximize == true)
                    {

                        if (_ShowClose == true)
                        {
                            if (new Rectangle(Width - 41, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                            {
                                if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Normal;
                                    Refresh();
                                }
                                else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                                    Refresh();
                                }
                                return;
                            }

                        }
                        else
                        {
                            if (new Rectangle(Width - 23, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                            {
                                if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Normal;
                                    Refresh();
                                }
                                else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                                    Refresh();
                                }
                                return;
                            }
                        }
                    }

                    break;
                case ControlsAlign.Left:
                    //_ShowClose
                    if (_ShowClose == true)
                    {
                        if (new Rectangle(4, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                        {
                            Application.Exit();
                        }
                    }

                    //_ShowMinimize
                    if (_ShowMinimize == true)
                    {
                        if (_ShowMaximize == true)
                        {

                            if (_ShowClose == true)
                            {
                                if (new Rectangle(40, (((_HeaderSize + 2) - 18) / 2), 17, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }

                            }
                            else
                            {
                                if (new Rectangle(22, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (_ShowClose == true)
                            {
                                if (new Rectangle(22, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }
                            }
                            else
                            {
                                if (new Rectangle(4, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                                    return;
                                }
                            }
                        }
                    }

                    //_ShowMaximize
                    if (_ShowMaximize == true)
                    {

                        if (_ShowClose == true)
                        {
                            if (new Rectangle(22, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                            {
                                if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Normal;
                                    Refresh();
                                }
                                else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                                    Refresh();
                                }
                                return;
                            }

                        }
                        else
                        {
                            if (new Rectangle(4, (((_HeaderSize + 2) - 18) / 2), 18, 18).Contains(e.Location))
                            {
                                if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Normal;
                                    Refresh();
                                }
                                else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                                {
                                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                                    Refresh();
                                }
                                return;
                            }
                        }
                    }
                    break;
            }

            if (e.Y < _Header && e.Button == MouseButtons.Left)
            {
                _Down = true;
                _MousePoint = new Point(e.Location.X, e.Location.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _Down = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_Down == true)
            {
                ParentForm.Location = new Point(MousePosition.X - _MousePoint.X, MousePosition.Y - _MousePoint.Y);
            }
        }

        #endregion
        
        #region " Misc "
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Fill;
            ParentForm.TransparencyKey = Color.Fuchsia;
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(31, 31, 31);
            Invalidate();
        }

        #endregion

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            var _with1 = G;
            StringFormat _StringF = new StringFormat { LineAlignment = StringAlignment.Center };
            _with1.Clear(Color.FromArgb(31, 31, 31));
            _with1.FillRectangle(new SolidBrush(_HeaderColor), new Rectangle(0, 0, Width, 5));
            _with1.FillRectangle(new SolidBrush(Color.FromArgb(34, 34, 34)), new Rectangle(0, 5, Width, _HeaderSize));
            _with1.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), new Point(0, _HeaderSize + 5), new Point(Width, _HeaderSize + 5));
            _with1.DrawLine(new Pen(Color.FromArgb(24, 24, 24)), new Point(0, _HeaderSize + 6), new Point(Width, _HeaderSize + 6));
            _with1.DrawLine(Pens.Fuchsia, new Point(0, 0), new Point(0, 2));
            _with1.DrawLine(Pens.Fuchsia, new Point(0, 0), new Point(2, 0));
            _with1.DrawLine(Pens.Fuchsia, new Point(Width - 1, 0), new Point(Width - 1, 2));
            _with1.DrawLine(Pens.Fuchsia, new Point(Width - 1, 0), new Point(Width - 3, 0));
            if (_ControlsAlignment == ControlsAlign.Right)
            {
                if (_ShowClose == true)
                {
                    _with1.DrawString("r", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                }
                if (_ShowMinimize == true)
                {
                    if (_ShowMaximize == true)
                    {
                        if (_ShowClose == true)
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 57, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                    else
                    {
                        if (_ShowClose == true)
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                }
                if (_ShowMaximize == true)
                {
                    if (_ShowClose == true)
                    {
                        if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        {
                            _with1.DrawString("1", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                        {
                            _with1.DrawString("2", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 41, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                    else
                    {
                        if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        {
                            _with1.DrawString("1", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                        {
                            _with1.DrawString("2", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                }
            }
            if (_ControlsAlignment == ControlsAlign.Left)
            {
                if (_ShowClose == true)
                {
                    _with1.DrawString("r", new Font("Marlett", 11), Brushes.White, new RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat);
                }
                if (_ShowMinimize == true)
                {
                    if (_ShowMaximize == true)
                    {
                        if (_ShowClose == true)
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(41, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                    else
                    {
                        if (_ShowClose == true)
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else
                        {
                            G.DrawString("0", new Font("Marlett", 11), Brushes.White, new RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                }
                if (_ShowMaximize == true)
                {
                    if (_ShowClose == true)
                    {
                        if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        {
                            _with1.DrawString("1", new Font("Marlett", 11), Brushes.White, new RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                        {
                            _with1.DrawString("2", new Font("Marlett", 11), Brushes.White, new RectangleF(23, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                    else
                    {
                        if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        {
                            _with1.DrawString("1", new Font("Marlett", 11), Brushes.White, new RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                        else if (Parent.FindForm().WindowState == FormWindowState.Normal)
                        {
                            _with1.DrawString("2", new Font("Marlett", 11), Brushes.White, new RectangleF(5, 5, 23, _HeaderSize + 3), _ControlsFormat);
                        }
                    }
                }
            }
            switch (_TextAlignment)
            {
                case TextAlign.Center:
                    _StringF.Alignment = StringAlignment.Center;
                    _with1.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(0, 5, Width, _HeaderSize), _StringF);

                    break;
                case TextAlign.Left:
                    _with1.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(10, 5, Width, _HeaderSize), _StringF);

                    break;
                case TextAlign.Right:
                    int _TextLength = TextRenderer.MeasureText(Text, new Font("Arial", 9)).Width + 10;
                    _with1.DrawString(Text, new Font("Arial", 9), Brushes.White, new RectangleF(Width - _TextLength, 5, Width, _HeaderSize), _StringF);
                    break;
            }
        }
    }
    

}


