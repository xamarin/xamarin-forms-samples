using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace CustomRenderer.Droid
{
    public class AutoFitTextureView : TextureView
    {
        int mRatioWidth = 0;
        int mRatioHeight = 0;
        readonly object locker = new object();

        public AutoFitTextureView(Context context) : this(context, null)
        {
        }

        public AutoFitTextureView(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public AutoFitTextureView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        protected AutoFitTextureView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public void SetAspectRatio(int width, int height)
        {
            if (width == 0 || height == 0)
            {
                throw new ArgumentException("Size can't be negative.");
            }

            mRatioWidth = width;
            mRatioHeight = height;
            RequestLayout();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            int width = MeasureSpec.GetSize(widthMeasureSpec);
            int height = MeasureSpec.GetSize(heightMeasureSpec);

            if (mRatioWidth == 0 || mRatioHeight == 0)
            {
                SetMeasuredDimension(width, height);
            }
            else
            {
                if (width < (float)height * mRatioWidth / mRatioHeight)
                {
                    SetMeasuredDimension(width, width * mRatioHeight / mRatioWidth);
                }
                else
                {
                    SetMeasuredDimension(height * mRatioWidth / mRatioHeight, height);
                }
            }
        }

        public void ClearCanvas(Android.Graphics.Color color)
        {
            using var canvas = LockCanvas(null);
            lock (locker)
            {
                try
                {
                    canvas.DrawColor(color);
                }
                finally
                {
                    UnlockCanvasAndPost(canvas);
                }
                Invalidate();
            }
        }
    }
}
