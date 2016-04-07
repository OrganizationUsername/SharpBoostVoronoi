﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpBoostVoronoi.Input;
using boost;
using System.Collections.Generic;
using SharpBoostVoronoi;
using SharpBoostVoronoi.Output;

namespace BoostVoronoiTests
{
    [TestClass]
    public class TestCSharp
    {
        [TestMethod]
        public void TestVerticesCount()
        {
            List<Segment> input = new List<Segment>();
            input.Add(new Segment(0, 0, 0, 10));
            input.Add(new Segment(0, 10, 10, 10));
            input.Add(new Segment(10, 10, 10, 0));
            input.Add(new Segment(10, 0, 0, 0));
            input.Add(new Segment(0, 0, 5, 5));
            input.Add(new Segment(5, 5, 10, 10));

            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();
            foreach (var s in input)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);   
            
            vw.ConstructVoronoi();
            List<Tuple<double, double>> clrVertices = vw.GetVertices();
            
            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var s in input)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);
            bv.Construct();
            List<Vertex> sharpVertices = bv.Vertices;

            //Test that the outputs have the same length
            Assert.AreEqual(clrVertices.Count, sharpVertices.Count);
        }

        [TestMethod]
        public void TestVerticesSequence()
        {
            List<Segment> input = new List<Segment>();
            input.Add(new Segment(0, 0, 0, 10));
            input.Add(new Segment(0, 10, 10, 10));
            input.Add(new Segment(10, 10, 10, 0));
            input.Add(new Segment(10, 0, 0, 0));
            input.Add(new Segment(0, 0, 5, 5));
            input.Add(new Segment(5, 5, 10, 10));

            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();
            foreach (var s in input)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<double, double>> clrVertices = vw.GetVertices();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var s in input)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);
            bv.Construct();
            List<Vertex> sharpVertices = bv.Vertices;

            //Test that the outputs have the same length
            Assert.AreEqual(clrVertices.Count, sharpVertices.Count);

            for (int i = 0; i < sharpVertices.Count; i++)
            {
                Assert.AreEqual(clrVertices[i].Item1, sharpVertices[i].X);
                Assert.AreEqual(clrVertices[i].Item2, sharpVertices[i].Y);
            }
        }

        [TestMethod]
        public void TestEdgesCount()
        {
            List<Segment> input = new List<Segment>();
            input.Add(new Segment(0, 0, 0, 10));
            input.Add(new Segment(0, 10, 10, 10));
            input.Add(new Segment(10, 10, 10, 0));
            input.Add(new Segment(10, 0, 0, 0));
            input.Add(new Segment(0, 0, 5, 5));
            input.Add(new Segment(5, 5, 10, 10));

            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();
            foreach (var s in input)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<int,int,int,int,Tuple<bool,bool,bool, int, int>>> clrEdges = vw.GetEdges();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var s in input)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);
            bv.Construct();
            List<Edge> sharpEdges = bv.Edges;

            //Test that the outputs have the same length
            Assert.AreEqual(clrEdges.Count, sharpEdges.Count);
        }

        [TestMethod]
        public void TestEdgesSequence()
        {
            List<Segment> input = new List<Segment>();
            input.Add(new Segment(0, 0, 0, 10));
            input.Add(new Segment(0, 10, 10, 10));
            input.Add(new Segment(10, 10, 10, 0));
            input.Add(new Segment(10, 0, 0, 0));
            input.Add(new Segment(0, 0, 5, 5));
            input.Add(new Segment(5, 5, 10, 10));

            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();
            foreach (var s in input)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<int, int, int, int, Tuple<bool, bool, bool, int, int>>> clrEdges = vw.GetEdges();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var s in input)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);
            bv.Construct();
            List<Edge> sharpEdges = bv.Edges;

            //Test that the outputs have the same length
            Assert.AreEqual(clrEdges.Count, sharpEdges.Count);

            for (int i = 0; i < clrEdges.Count; i++)
            {
                Assert.AreEqual(clrEdges[i].Item2, sharpEdges[i].Start);
                Assert.AreEqual(clrEdges[i].Item3, sharpEdges[i].End);
            }
        }

        [TestMethod]
        public void TestCellsCount()
        {
            List<Segment> input = new List<Segment>();
            input.Add(new Segment(0, 0, 0, 10));
            input.Add(new Segment(0, 10, 10, 10));
            input.Add(new Segment(10, 10, 10, 0));
            input.Add(new Segment(10, 0, 0, 0));
            input.Add(new Segment(0, 0, 5, 5));
            input.Add(new Segment(5, 5, 10, 10));

            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();
            foreach (var s in input)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<int, int, bool, bool, List<int>, bool, int>> clrCells = vw.GetCells();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var s in input)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);
            bv.Construct();
            List<Cell> sharpCells = bv.Cells;

            //Test that the outputs have the same length
            Assert.AreEqual(clrCells.Count, sharpCells.Count);
        }

        [TestMethod]
        public void TestCellsSequence()
        {
            List<Segment> input = new List<Segment>();
            input.Add(new Segment(0, 0, 0, 10));
            input.Add(new Segment(0, 10, 10, 10));
            input.Add(new Segment(10, 10, 10, 0));
            input.Add(new Segment(10, 0, 0, 0));
            input.Add(new Segment(0, 0, 5, 5));
            input.Add(new Segment(5, 5, 10, 10));

            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();
            foreach (var s in input)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<int, int, bool, bool, List<int>, bool, int>> clrCells = vw.GetCells();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var s in input)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);
            bv.Construct();
            List<Cell> sharpCells = bv.Cells;

            //Test that the outputs have the same length
            Assert.AreEqual(clrCells.Count, sharpCells.Count);

            for (int i = 0; i < clrCells.Count; i++)
            {
                for (int j = 0; j < clrCells[i].Item5.Count; j++)
                {
                    Assert.AreEqual(clrCells[i].Item5[j], sharpCells[i].EdgesIndex[j]);
                }
            }
        }


        [TestMethod]
        public void TestSegmentTwin()
        {
            List<Point> inputPoint = new List<Point>() { new Point(5, 5) };
            List<Segment> inputSegment = new List<Segment>();
            inputSegment.Add(new Segment(0, 0, 0, 10));
            inputSegment.Add(new Segment(0, 10, 10, 10));
            inputSegment.Add(new Segment(10, 10, 10, 0));
            inputSegment.Add(new Segment(10, 0, 0, 0));
            


            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();

            foreach (var p in inputPoint)
                vw.AddPoint(p.X, p.Y);
                
            foreach (var s in inputSegment)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<int, int, bool, bool, List<int>, bool, int>> clrCells = vw.GetCells();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var p in inputPoint)
                bv.AddPoint(p.X, p.Y);
            foreach (var s in inputSegment)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            bv.Construct();
            List<Edge> sharpEdges = bv.Edges;

            //Test twin reciprocity
            for (int i = 0; i < sharpEdges.Count; i++)
            {
                Assert.AreEqual(i, sharpEdges[sharpEdges[i].Twin].Twin);
            }
        }

        [TestMethod]
        public void TestSegmentDicretization()
        {
            List<Point> inputPoint = new List<Point>() { new Point(5, 5) };
            List<Segment> inputSegment = new List<Segment>();
            inputSegment.Add(new Segment(0, 0, 0, 10));
            inputSegment.Add(new Segment(0, 0, 10, 0));
            inputSegment.Add(new Segment(0, 10, 10, 10));
            inputSegment.Add(new Segment(10, 0, 10, 10));
            



            //Build the CLR voronoi
            VoronoiWrapper vw = new VoronoiWrapper();

            foreach (var p in inputPoint)
                vw.AddPoint(p.X, p.Y);

            foreach (var s in inputSegment)
                vw.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            vw.ConstructVoronoi();
            List<Tuple<int, int, bool, bool, List<int>, bool, int>> clrCells = vw.GetCells();

            //Build the C# Voronoi
            BoostVoronoi bv = new BoostVoronoi();
            foreach (var p in inputPoint)
                bv.AddPoint(p.X, p.Y);
            foreach (var s in inputSegment)
                bv.AddSegment(s.Start.X, s.Start.Y, s.End.X, s.End.Y);

            bv.Construct();
            List<Vertex> vertices = bv.Vertices;
            List<Edge> sharpEdges = bv.Edges;

            //Test twin reciprocity
            for (int i = 0; i < sharpEdges.Count; i++)
            {

                Edge testEdge = sharpEdges[2];
                List<Vertex> dvertices = bv.SampleCurvedEdge(testEdge, 0.1);
                //Assert.AreEqual(vertices[testEdge.Start].X.ToString(), 2.92893218813452);
                //Assert.AreEqual(vertices[testEdge.Start].Y, 2.92893218813452);
                //Assert.AreEqual(vertices[testEdge.End].X, 2.92893218813452);
                //Assert.AreEqual(vertices[testEdge.End].Y, 7.07106781186548);
                Assert.AreEqual(dvertices[2].X, 2.5);
                Assert.AreEqual(dvertices[2].Y, 5);
                
                
            }
        }
    }
}
