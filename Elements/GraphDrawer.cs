using System;
using System.Collections.Generic;
using System.Drawing;

namespace SystemUsageBar.Elements
{
    internal class GraphDrawer
    {
        private Queue<float> _readings;

        public Color Color { get; set; }

        private int _maxReadings = 100;

        public int MaxReadings
        {
            get { return _maxReadings; }
            set
            {
                if (value != _maxReadings)
                {
                    _maxReadings = value;
                    ResizeReadings();
                }
            }
        }

        public float? MaxValue { get; set; }

        private float? _autoMax;

        public void AddReading(float reading)
        {
            if (reading < 0)
            {
                reading = 0;
            }

            if (_readings == null)
            {
                _readings = new Queue<float>(MaxReadings);
                for (int i = 0; i < MaxReadings; i++)
                {
                    _readings.Enqueue(0.0f);
                }
            }

            if (!MaxValue.HasValue && (_autoMax == null || _autoMax.Value < reading))
            {
                _autoMax = reading;
            }

            _readings.Enqueue(reading);
            float dequeued = _readings.Dequeue();

            if (_autoMax.HasValue && _autoMax.Value >= dequeued)
            {
                _autoMax = null;
            }
        }

        public void ResizeReadings()
        {
            if (_readings != null)
            {
                Queue<float> newReadings = new Queue<float>(MaxReadings);
                int nCount = MaxReadings - _readings.Count;
                for (int i = 0; i < nCount; i++)
                {
                    newReadings.Enqueue(0.0f);
                }

                foreach (float val in _readings)
                {
                    if (nCount >= 0)
                    {
                        newReadings.Enqueue(val);
                    }
                    nCount++;
                    if (nCount >= MaxReadings)
                    {
                        break;
                    }
                }

                _readings = newReadings;
            }

            _autoMax = null;
        }

        public void Draw(Graphics g, Rectangle rect)
        {
            if (_readings != null)
            {
                PointF[] points = CreateLinePoints(_readings, rect, GetMaxValue());

                if (points.Length > 0)
                { 
                    using (SolidBrush brush = new SolidBrush(Color))
                    using (Pen p = new Pen(brush, 1.0f))
                    {
                        g.DrawLines(p, points);
                        brush.Color = Color.FromArgb(96, Color);
                        g.FillPolygon(brush, points);
                    }
                }
            }
        }

        private float GetMaxValue()
        {
            if (MaxValue.HasValue)
            {
                return MaxValue.Value;
            }
            else if (_autoMax.HasValue)
            {
                return _autoMax.Value;
            }
            else
            {
                float maxValue = 0;
                foreach (float reading in _readings)
                {
                    if (reading > maxValue)
                    {
                        maxValue = reading;
                        _autoMax = maxValue;
                    }
                }

                return maxValue;
            }
        }

        private static PointF[] CreateLinePoints(Queue<float> readings, Rectangle rect, float maxValue)
        {
            int count = readings.Count;
            if (count < 4 || maxValue <= 0)
            {
                return new PointF[0];
            }

            PointF[] points = new PointF[count + 2];
            int i;
            for (i = 0; i < count; i++)
            {
                float value = readings.Dequeue();
                readings.Enqueue(value);

                float x = (rect.Width / (count - 1)) * i;
                x = rect.X + Math.Min(rect.Width, x);

                float y = ((value / maxValue) * rect.Height);
                y = rect.Y + (rect.Height - y);

                points[i] = new PointF(x, y);
            }

            points[count] = new PointF(rect.X + rect.Width, rect.Y + rect.Height + 1);
            points[count + 1] = new PointF(rect.X, rect.Y + rect.Height + 1);

            return points;
        }
    }
}
