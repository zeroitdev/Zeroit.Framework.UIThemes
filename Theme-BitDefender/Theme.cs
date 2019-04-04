// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="BitDefender Theme.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;


namespace Zeroit.Framework.UIThemes.BitDefender
{

    static class Helper
    {

        static internal GraphicsPath RoundRect(Rectangle R, int radius)
        {
            GraphicsPath GP = new GraphicsPath();
            GP.AddArc(R.X, R.Y, radius, radius, 180, 90);
            GP.AddArc(R.Right - radius, R.Y, radius, radius, 270, 90);
            GP.AddArc(R.Right - radius, R.Bottom - radius, radius, radius, 0, 90);
            GP.AddArc(R.X, R.Bottom - radius, radius, radius, 90, 90);
            GP.CloseFigure();
            return GP;
        }

    }


    public class ContainerObjectDisposable : IDisposable
    {

        private List<IDisposable> iList = new List<IDisposable>();
        public void AddObject(IDisposable Obj)
        {
            iList.Add(Obj);
        }
        public void AddObjectRange(IDisposable[] Obj)
        {
            iList.AddRange(Obj);
        }
        #region "IDisposable Support"
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    foreach (IDisposable ObjectDisposable in iList)
                    {
                        ObjectDisposable.Dispose();
#if DEBUG
                        Debug.WriteLine("Dispose : " + ObjectDisposable.ToString());
#endif
                    }
                }

            }
            iList.Clear();
            this.disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }


    
}


