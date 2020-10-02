using System;

namespace sharpz
{
    public class Segment
    {
        double[] start;
        double[] end;
        public Segment(double[] start, double[] end)
        {
            if (start.GetLength(0) != end.GetLength(0))
            {
                throw new Exception("Starting and ending points has a different dimension.");
            }
            this.start = start;
            this.end = end;
        }

        public double GetSegmentLength()
        {
            int length = this.start.GetLength(0);
            double segmentLength = 0;
            for (int i = 0; i < length; i++)
            {
                segmentLength += Math.Pow(Math.Abs(this.start[i] - this.end[i]), 2);
            }
            return Math.Sqrt(segmentLength);
        }

        public double[] GetMiddlePoint()
        {
            int length = this.start.GetLength(0);
            double[] point = new double[length];
            for (int i = 0; i < length; i++)
            {
                point[i] = (this.start[i] + this.end[i]) / 2;
            }
            return point;
        }

        public void ScaleSegment(int scale)
        {
            int length = this.start.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                this.end[i] = this.end[i] * scale;
            }
        }
    }
}