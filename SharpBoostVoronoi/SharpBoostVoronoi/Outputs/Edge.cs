﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBoostVoronoi.Output
{
    public class Edge
    {
        /// <summary>
        /// The index of the start vertex of this segment.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// The index of the end vertex of this segment.
        /// </summary>
        public int End { get; set; }

        /// <summary>
        /// The index of the input geometry around which the cell is built.
        /// </summary>
        public int SiteIndex{ get; set; }

        /// <summary>
        /// True is the edge is a primary edge, False otherwise.
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// True is a segment is a line, false if the segment is an arc.
        /// </summary>
        public bool IsLinear { get; set; }

        /// <summary>
        /// True if the edge is delimited by two known vertices, False otherwise.
        /// </summary>
        public bool IsFinite{ get; set; }

        /// <summary>
        /// The index of the cell associated with this segment
        /// </summary>
        public int Cell { get; set; }

        /// <summary>
        /// The index of the twin cell associated with this segment
        /// </summary>
        public int Twin { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="t">A tuple returned by the CLR wrapper.</param>
        public Edge(Tuple<int, int, int, int, Tuple<bool, bool, bool, int, int>> t)
        {
            Start = t.Item2;
            End = t.Item3;
            SiteIndex = t.Item4;
            IsPrimary = t.Item5.Item1;
            IsLinear = t.Item5.Item2;
            IsFinite = t.Item5.Item3;
            Cell = t.Item5.Item4;
            Twin = t.Item5.Item5;
        }

    }
}
