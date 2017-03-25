using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WinApi.Structures
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int left_, int top_, int right_, int bottom_)
        {
            Left = left_;
            Top = top_;
            Right = right_;
            Bottom = bottom_;
        }

        public int Height { get { return Bottom - Top; } }
        public int Width { get { return Right - Left; } }
        public System.Drawing.Size Size { get { return new System.Drawing.Size(Width, Height); } }

        public System.Drawing.Point Location { get { return new System.Drawing.Point(Left, Top); } }

        // Handy method for converting to a System.Drawing.Rectangle
        public System.Drawing.Rectangle ToRectangle()
        { return System.Drawing.Rectangle.FromLTRB(Left, Top, Right, Bottom); }

        public static RECT FromRectangle(System.Drawing.Rectangle rectangle)
        {
            return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        }

        public override int GetHashCode()
        {
            return Left ^ ((Top << 13) | (Top >> 0x13))
              ^ ((Width << 0x1a) | (Width >> 6))
              ^ ((Height << 7) | (Height >> 0x19));
        }

        #region Operator overloads

        public static implicit operator System.Drawing.Rectangle(RECT rect)
        {
            return rect.ToRectangle();
        }

        public static implicit operator RECT(System.Drawing.Rectangle rect)
        {
            return FromRectangle(rect);
        }

        #endregion
    }
}
