using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Bitmaps
{
    public class LatticeNinePatchPage : ContentPage
    {
        public LatticeNinePatchPage ()
        {
            Title = "Lattice Nine-Patch";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            SKLattice lattice = new SKLattice();
            lattice.XDivs = new int[] { 100, 400 };
            lattice.YDivs = new int[] { 100, 400 };
            lattice.Flags = new SKLatticeFlags[] 
            {
                SKLatticeFlags.Default, SKLatticeFlags.Default, SKLatticeFlags.Default,
                SKLatticeFlags.Default, SKLatticeFlags.Default, SKLatticeFlags.Default,
                SKLatticeFlags.Default, SKLatticeFlags.Default, SKLatticeFlags.Default
            };

            canvas.DrawBitmapLattice(NinePatchDisplayPage.FiveByFiveBitmap, lattice, info.Rect);
        }
    }
}