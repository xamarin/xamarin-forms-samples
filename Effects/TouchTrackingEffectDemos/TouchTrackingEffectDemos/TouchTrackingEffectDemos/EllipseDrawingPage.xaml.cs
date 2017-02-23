using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace TouchTrackingEffectDemos
{
    public partial class EllipseDrawingPage : ContentPage
    {
        Dictionary<long, EllipseDrawingFigure> inProgressFigures = new Dictionary<long, EllipseDrawingFigure>();
        List<EllipseDrawingFigure> completedFigures = new List<EllipseDrawingFigure>();
        Dictionary<long, EllipseDrawingFigure> draggingFigures = new Dictionary<long, EllipseDrawingFigure>();

        Random random = new Random();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Fill
        };

        public EllipseDrawingPage()
        {
            InitializeComponent();
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            completedFigures.Clear();
            canvasView.InvalidateSurface();
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    bool isDragOperation = false;

                    // Loop through the completed figures
                    foreach (EllipseDrawingFigure fig in completedFigures.Reverse<EllipseDrawingFigure>())
                    {
                        // Check if the finger is touching one of the ellipses
                        if (fig.IsInEllipse(ConvertToPixel(args.Location)))
                        {
                            // Tentatively assume this is a dragging operation
                            isDragOperation = true;

                            // Loop through all the figures currently being dragged
                            foreach (EllipseDrawingFigure draggedFigure in draggingFigures.Values)
                            {
                                // If there's a match, we'll need to dig deeper
                                if (fig == draggedFigure)
                                {
                                    isDragOperation = false;
                                    break;
                                }
                            }

                            if (isDragOperation)
                            {
                                fig.LastFingerLocation = args.Location;
                                draggingFigures.Add(args.Id, fig);
                                break;
                            }
                        }
                    }

                    if (isDragOperation)
                    {
                        // Move the dragged ellipse to the end of completedFigures so it's drawn on top
                        EllipseDrawingFigure fig = draggingFigures[args.Id];
                        completedFigures.Remove(fig);
                        completedFigures.Add(fig);
                    }
                    else // start making a new ellipse
                    {
                        // Random bytes for random color
                        byte[] buffer = new byte[4];
                        random.NextBytes(buffer);

                        EllipseDrawingFigure figure = new EllipseDrawingFigure
                        {
                            Color = new SKColor(buffer[0], buffer[1], buffer[2], buffer[3]),
                            StartPoint = ConvertToPixel(args.Location),
                            EndPoint = ConvertToPixel(args.Location)
                        };
                        inProgressFigures.Add(args.Id, figure);
                    }
                    canvasView.InvalidateSurface();
                    break;

                case TouchActionType.Moved:
                    if (draggingFigures.ContainsKey(args.Id))
                    {
                        EllipseDrawingFigure figure = draggingFigures[args.Id];
                        SKRect rect = figure.Rectangle;
                        rect.Offset(ConvertToPixel(new Point(args.Location.X - figure.LastFingerLocation.X,
                                                             args.Location.Y - figure.LastFingerLocation.Y)));
                        figure.Rectangle = rect;
                        figure.LastFingerLocation = args.Location;
                    }
                    else if (inProgressFigures.ContainsKey(args.Id))
                    {
                        EllipseDrawingFigure figure = inProgressFigures[args.Id];
                        figure.EndPoint = ConvertToPixel(args.Location);
                    }
                    canvasView.InvalidateSurface();
                    break;

                case TouchActionType.Released:
                    if (draggingFigures.ContainsKey(args.Id))
                    {
                        draggingFigures.Remove(args.Id);
                    }
                    else if (inProgressFigures.ContainsKey(args.Id))
                    {
                        EllipseDrawingFigure figure = inProgressFigures[args.Id];
                        figure.EndPoint = ConvertToPixel(args.Location);
                        completedFigures.Add(figure);
                        inProgressFigures.Remove(args.Id);
                    }
                    canvasView.InvalidateSurface();
                    break;

                case TouchActionType.Cancelled:
                    if (draggingFigures.ContainsKey(args.Id))
                    {
                        draggingFigures.Remove(args.Id);
                    }
                    if (inProgressFigures.ContainsKey(args.Id))
                    {
                        inProgressFigures.Remove(args.Id);
                    }
                    canvasView.InvalidateSurface();
                    break;
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();

            foreach (EllipseDrawingFigure figure in completedFigures)
            {
                paint.Color = figure.Color;
                canvas.DrawOval(figure.Rectangle, paint);
            }
            foreach (EllipseDrawingFigure figure in inProgressFigures.Values)
            {
                paint.Color = figure.Color;
                canvas.DrawOval(figure.Rectangle, paint);
            }
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }
    }
}
