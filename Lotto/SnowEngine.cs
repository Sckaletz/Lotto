using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;

namespace Lotto
{
    public class SnowEngine
    {
        private readonly List<SnowInfo> flakes = new List<SnowInfo>();
        private readonly List<string> flakeImages = new List<string>();

        private int minStartingSpeed = 3;
        private int maxStartingSpeed = 10;
        private int minHorizontalSpeed = 1;
        private int maxHorizontalSpeed = 3;
        private int maxFlakes = 0;
        private Canvas canvas = null;

        private int minRadius = 5;
        public int MinRadius
        {
            get { return minRadius; }
            set { maxRadius = value; }
        }

        private int maxRadius = 30;
        public int MaxRadius
        {
            get { return maxRadius; }
            set { maxRadius = value; }
        }

        private ushort snowCoverage = 10;
        public ushort SnowCoverage
        {
            get { return snowCoverage; }
            set
            {
                if (value > 50 || value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Maximum coverage 100 and minumum 1");
                }
                snowCoverage = value;
            }
        }

        private double verticalSpeedRatio = 0.05;
        public double VerticalSpeedRatio
        {
            get { return verticalSpeedRatio; }
            set { verticalSpeedRatio = value; }
        }

        private double horizontalSpeedRatio = 0.08;
        public double HorizontalSpeedRatio
        {
            get { return horizontalSpeedRatio; }
            set { horizontalSpeedRatio = value; }
        }
        public bool IsWorking { get; private set; }
        public SnowEngine(Canvas canvas, params string[] flakeImages)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException("canvas", "Canvas can't be null");
            }
            if (flakeImages == null || flakeImages.Length == 0)
            {
                throw new ArgumentException("Flakes images can't be empty", "flakeImages");
            }

            this.canvas = canvas;
            canvas.IsHitTestVisible = false;
            canvas.SizeChanged += canvas_SizeChanged;
            this.flakeImages.AddRange(flakeImages);
        }

        private void canvas_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            RecalcMaxFlakes();
            SetFlakes(true);
        }
        public void Start()
        {
            IsWorking = true;
            RecalcMaxFlakes();
            SetFlakes(true);
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }
        public void Stop()
        {
            IsWorking = false;
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            ClearSnow();
        }
        private void RecalcMaxFlakes()
        {
            double flakesInCanvas = canvas.ActualHeight * canvas.ActualWidth / (maxRadius * maxRadius);

            maxFlakes = (int)(flakesInCanvas * SnowCoverage / 100);
        }
        private static BitmapImage CreateImage(string path)
        {
            BitmapImage imgTemp = new BitmapImage();

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path can't be empty", "path");
            }

            try
            {
                if (!path.StartsWith("pack://") && !File.Exists(path))
                {
                    return null;
                }
            }
            catch { }
            imgTemp.BeginInit();
            imgTemp.CacheOption = BitmapCacheOption.OnLoad;
            imgTemp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            imgTemp.UriSource = new Uri(path);
            imgTemp.EndInit();
            if (imgTemp.CanFreeze)
            {
                imgTemp.Freeze();
            }
            return imgTemp;
        }
        private void SetFlakes(bool top = false)
        {
            int halfCanvasWidth = (int)canvas.ActualWidth / 2;
            Random rand = new Random();
            Image flake = null;
            SnowInfo info = null;

            for (int i = flakes.Count; i < maxFlakes; i++)
            {
                flake = new Image();
                flake.Source = CreateImage(flakeImages[rand.Next(0, flakeImages.Count)]);
                flake.Stretch = Stretch.Uniform;

                info = new SnowInfo(flake, verticalSpeedRatio * rand.Next(minStartingSpeed, maxStartingSpeed), rand.Next(minRadius, maxRadius));

                Canvas.SetLeft(flake, halfCanvasWidth + rand.Next(-halfCanvasWidth, halfCanvasWidth));
                if (!top)
                {
                    Canvas.SetTop(flake, rand.Next(0, (int)canvas.ActualHeight));
                }
                else
                {
                    Canvas.SetTop(flake, -info.Radius * 2);
                }
                canvas.Children.Add(flake);

                info.VelocityX = rand.Next(minHorizontalSpeed, maxHorizontalSpeed);
                flakes.Add(info);
            }
        }
        private void ClearSnow()
        {
            for (int i = flakes.Count - 1; i >= 0; i--)
            {
                canvas.Children.Remove(flakes[i].Flake);
                flakes[i].Flake = null;
                flakes.RemoveAt(i);
            }
        }
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            Random random = new Random();
            SnowInfo info = null;
            double left = 0;
            double top = 0;

            if (!IsWorking)
            {
                return;
            }

            if (flakes.Count < maxFlakes)
            {
                SetFlakes(true);
                return;
            }

            for (int i = flakes.Count - 1; i >= 0; i--)
            {
                info = flakes[i];
                left = Canvas.GetLeft(info.Flake);
                top = Canvas.GetTop(info.Flake);

                flakes[i].VelocityX += .5 * HorizontalSpeedRatio;

                Canvas.SetLeft(flakes[i].Flake, left + Math.Cos(flakes[i].VelocityX));
                Canvas.SetTop(info.Flake, top + 1 * info.VelocityY);

                if (top >= (canvas.ActualHeight + info.Radius * 2))
                {
                    flakes.Remove(info);
                    canvas.Children.Remove(info.Flake);
                }
            }
        }
    }
}
