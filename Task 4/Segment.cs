using System;
using System.Collections.Generic;

namespace sharpz
{
    public class Segment
    {
        private List<double> start;
        private List<double> end;
        public Segment(List<double> start, List<double> end)
        {
            if (start.Count != end.Count)
            {
                throw new Exception("Starting and ending points has a different dimension.");
            }
            this.start = start;
            this.end = end;
        }

        public List<double> middlePoint
        {
            get
            {
                int length = this.start.Count;
                List<double> point = new List<double>();
                for (int i = 0; i < length; i++)
                {
                    point.Add((this.start[i] + this.end[i]) / 2);
                }
                return point;
            }
        }

        public Segment ScaleSegment(int scale)
        {
            int length = this.start.Count;
            for (int i = 0; i < length; i++)
            {
                this.end[i] = this.end[i] * scale;
            }
            return this;
        }

        public double segmentLength
        {
            get
            {
                int length = this.start.Count;
                double segmentLength = 0;
                for (int i = 0; i < length; i++)
                {
                    segmentLength += Math.Pow((this.start[i] - this.end[i]), 2);
                }
                return Math.Sqrt(segmentLength);
            }
        }

        public List<Double> startingPoint
        {
            get
            {
                return this.start;
            }
        }

        public List<Double> endingPoint
        {
            get
            {
                return this.end;
            }
        }
    }
}