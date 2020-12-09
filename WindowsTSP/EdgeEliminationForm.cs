using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Linq;
using TSP;

namespace WindowsTSP
{
    public partial class EdgeEliminationForm : Form
    {
        private readonly PlaneTSP MyTSP;
        private readonly PaintManagement MyPM;

        //private bool graph, hulls, spanTree, sol, inHulls, betweenHulls, overHulls;
        //private bool crossHull;

        //Image related
        private Bitmap MyImage;
        private Tuple<int, int> MyScale;
        private int ptScale;
        private int cPointSize;
        private int w, h;

        public EdgeEliminationForm(PlaneTSP tsp, PaintManagement pm)
        {
            InitializeComponent();
            MyTSP = tsp;
            MyPM = pm;
            
            cPointSize = (int)numericUpDown1.Value;
        }

        private void EdgeEliminationForm_Load(object sender, EventArgs e)
        {
            //if (rdBtnEliminated.Checked && (betweenHulls || overHulls)) { chkBoxCrossOwnHull.Enabled = true; } else { chkBoxCrossOwnHull.Enabled = false; }
        }

        private void EdgeEliminationForm_ResizeEnd(object sender, EventArgs e)
        {
            w = pictureBox1.Width - 5;
            h = pictureBox1.Height - 0;
            MyImage = null;
            MyImage = new Bitmap(w, h);
            //Scale(MyTSP.RangeX() + 1, MyTSP.RangeY() + 1, w, h);
            ptScale = Math.Max((Math.Max(w, h) - Math.Min(w, h)) / MyTSP.Graph.NumberNodes, 1);

            if (cPointSize <= (int)numericUpDown1.Value)
            {
                //if (graph) { InternDrawGraph(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (hulls) { InternDrawHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (spanTree) { InternDrawSpanningTree(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (sol) { InternDrawSolution(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (inHulls) { InternDrawInsideHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (betweenHulls) { InternDrawBetweenHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (overHulls) { InternDrawOverHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
            }
            else
            {
                //if (graph) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawGraph(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (hulls) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (spanTree) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawSpanningTree(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (sol) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawSolution(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (inHulls) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawInsideHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (betweenHulls) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawBetweenHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
                //if (overHulls) { DrawPoints(chkBoxCentroid.Checked, true); InternDrawOverHulls(); DrawPoints(chkBoxCentroid.Checked, false); }
            }

            pictureBox1.Image = MyImage;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            EdgeEliminationForm_ResizeEnd(sender, e);
        }
        private void ChkBoxCentroid_CheckedChanged(object sender, EventArgs e)
        {
            EdgeEliminationForm_ResizeEnd(sender, e);
        }
        private void RdBtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnAll.Checked) { EdgeEliminationForm_ResizeEnd(sender, e); }
        }
        private void RdBtnEliminated_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdBtnEliminated.Checked && (betweenHulls || overHulls)) { chkBoxCrossOwnHull.Enabled = true; } else { chkBoxCrossOwnHull.Enabled = false; }
        }
        private void ChkBoxCrossOwnHull_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkBoxCrossOwnHull.Checked) { crossHull = true; } else { crossHull = false; }
            //if (betweenHulls || overHulls)
            //{
            //    EdgeEliminationForm_ResizeEnd(this, EventArgs.Empty);
            //}
        }
        //*****************
        private void DrawPoints(bool drawCentroid, bool drawAxis, bool erase)
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt;
            int cSize = (int)numericUpDown1.Value;
            Brush eraseBrush = new SolidBrush(MyPM.CanvasColor);
            Pen erasePen = new Pen(MyPM.CanvasColor);

            n = MyTSP.Graph.NumberNodes;
            for (int i = 0; i < n; i++)
            {
                p = MyTSP.Graph.GetNode(i).Attributes;
                pt = GetNewPoint(p);
                if (erase)
                {
                    grph.FillRectangle(eraseBrush, pt.X, pt.Y, ptScale * (1 + cPointSize), ptScale * (1 + cPointSize));
                }
                else
                {
                    if (MyPM.MyBrushes is null)
                    {
                        grph.FillRectangle(MyPM.MyBrush, pt.X, pt.Y, ptScale * (1 + cSize), ptScale * (1 + cSize));
                    }
                    else
                    {
                        grph.FillRectangle(MyPM.MyBrushes[p.ConvexHull], pt.X, pt.Y, ptScale * (1 + cSize), ptScale * (1 + cSize));
                    }
                }
            }

            p = MyTSP.Centroid;
            pt = GetNewPoint(p);
            if (drawCentroid)
            {
                if (erase)
                {
                    grph.DrawEllipse(erasePen, pt.X, pt.Y, (int)(ptScale * (1.5 + cPointSize)), (int)(ptScale * (1.5 + cPointSize)));
                    grph.FillEllipse(eraseBrush, pt.X, pt.Y, (int)(ptScale * (1.5 + cPointSize)), (int)(ptScale * (1.5 + cPointSize)));
                }
                else
                {
                    grph.DrawEllipse(MyPM.MyPen, pt.X, pt.Y, (int)(ptScale * (1.5 + cSize)), (int)(ptScale * (1.5 + cSize)));
                    grph.FillEllipse(MyPM.MyBrush, pt.X, pt.Y, (int)(ptScale * (1.5 + cSize)), (int)(ptScale * (1.5 + cSize)));
                }
            }

            if (drawAxis)
            {
                if (erase)
                {
                    grph.DrawLine(erasePen, new Point(pt.X, 0), new Point(pt.X, pictureBox1.Height)); //Draw a line
                    grph.DrawLine(erasePen, new Point(0, pt.Y), new Point(pictureBox1.Width, pt.Y)); //Draw a line
                }
                else
                {
                    grph.DrawLine(MyPM.MyPen, new Point(pt.X, 0), new Point(pt.X, pictureBox1.Height)); //Draw a line
                    grph.DrawLine(MyPM.MyPen, new Point(0, pt.Y), new Point(pictureBox1.Width, pt.Y)); //Draw a line
                }
            }
            cPointSize = cSize;
            eraseBrush.Dispose();
            erasePen.Dispose();
        }


        public void DrawHulls()
        {
            //hulls = true;
            EdgeEliminationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawSpanningTree()
        {
            //spanTree = true;
            EdgeEliminationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawInsideHulls()
        {
            //inHulls = true;
            EdgeEliminationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawBetweenHulls()
        {
            //betweenHulls = true;
            EdgeEliminationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawOverHulls()
        {
            //overHulls = true;
            EdgeEliminationForm_ResizeEnd(this, EventArgs.Empty);
        }
        //*****************
        private void InternDrawGraph()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                grph.DrawLine(MyPM.MyPen, pt0, pt1); //Draw a line
            }
            lblNumEdges.Text = string.Format("{0} - {1:P2}", n, (double)n / n);
        }
        private void InternDrawHulls()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;
            int nEdges;
            int eIndx;
            ConvexHull cHull;
            int cnt = 0;

            n = MyTSP.ConvexHulls.Count;
            for (int i = 0; i < n; i++)
            {
                cHull = MyTSP.ConvexHulls[i];
                nEdges = cHull.NumberEdges;

                for (int j = 0; j < nEdges; j++)
                {
                    eIndx = cHull.Edges.ElementAt(j);
                    var edg = MyTSP.Graph.GetEdge(eIndx);
                    pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                    pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                    grph.DrawLine(MyPM.MyPens[i], pt0, pt1); //Draw a line
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0} - {1:P2}", cnt, (double)cnt / MyTSP.Graph.NumberEdges);
        }
        private void InternDrawSpanningTree()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;
            int cnt = 0;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsSpanningEdge)
                {
                    pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                    pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                    grph.DrawLine(MyPM.MyPen, pt0, pt1);
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0} - {1:P2}", cnt, (double)cnt / n);
        }
        private void InternDrawInsideHulls()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int cnt = 0;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsInsideConvexHull)
                {
                    pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    grph.DrawLine(MyPM.MyPens[p.ConvexHull], pt0, pt1); //Draw a line
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0} - {1:P2}", cnt, (double)cnt / n);
        }
        private void InternDrawBetweenHulls()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int max;
            int cnt = 0;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsBetweenConvexHulls)
                {
                    if (rdBtnAll.Checked)
                    {
                        p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                        pt0 = GetNewPoint(p);
                        max = p.ConvexHull;
                        p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                        pt1 = GetNewPoint(p);
                        if (p.ConvexHull > max) { max = p.ConvexHull; }
                        grph.DrawLine(MyPM.MyPens[max], pt0, pt1); //Draw a line
                        cnt++;
                    }
                    //else if ((crossHull && edg.Attributes.IsIntersectOwnConvexHull) || (!crossHull && !edg.Attributes.IsIntersectOwnConvexHull))
                    //{
                    //    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    //    pt0 = GetNewPoint(p);
                    //    max = p.ConvexHull;
                    //    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    //    pt1 = GetNewPoint(p);
                    //    if (p.ConvexHull > max) { max = p.ConvexHull; }
                    //    grph.DrawLine(MyPM.MyPens[max], pt0, pt1); //Draw a line
                    //    cnt++;
                    //}
                }
            }
            lblNumEdges.Text = string.Format("{0} - {1:P2}", cnt, (double)cnt / n);
        }
        private void InternDrawOverHulls()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int max;
            int cnt = 0;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsOverConvexHull)
                {
                    if (rdBtnAll.Checked)
                    {
                        p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                        pt0 = GetNewPoint(p);
                        max = p.ConvexHull;
                        p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                        pt1 = GetNewPoint(p);
                        if (p.ConvexHull > max) { max = p.ConvexHull; }
                        grph.DrawLine(MyPM.MyPens[max], pt0, pt1); //Draw a line
                        cnt++;
                    }
                    //else if ((crossHull && edg.Attributes.IsIntersectOwnConvexHull) || (!crossHull && !edg.Attributes.IsIntersectOwnConvexHull))
                    //{
                    //    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    //    pt0 = GetNewPoint(p);
                    //    max = p.ConvexHull;
                    //    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    //    pt1 = GetNewPoint(p);
                    //    if (p.ConvexHull > max) { max = p.ConvexHull; }
                    //    grph.DrawLine(MyPM.MyPens[max], pt0, pt1); //Draw a line
                    //    cnt++;
                    //}
                }
            }
            lblNumEdges.Text = string.Format("{0} - {1:P2}", cnt, (double)cnt / n);
        }




        private void RuleInsideHulls()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i <= (n - 1); i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsInsideConvexHull)
                {
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);

                    if (rdBtnRemained.Checked && edg.Active) { grph.DrawLine(MyPM.MyPens[p.ConvexHull], pt0, pt1); }
                    if (rdBtnEliminated.Checked && !edg.Active) { grph.DrawLine(MyPM.MyPens[p.ConvexHull], pt0, pt1); }
                }
            }
        }
        private void RuleIntersectOwnHullBH()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int max;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsBetweenConvexHulls)
                {
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    max = p.ConvexHull;
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    if (p.ConvexHull > max) { max = p.ConvexHull; }

                    if (rdBtnRemained.Checked && !edg.Attributes.IsIntersectOwnConvexHull) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                    if (rdBtnEliminated.Checked && edg.Attributes.IsIntersectOwnConvexHull && !edg.Active) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                }
            }
        }
        private void RuleCrossSpanningTreeBH()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int max;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsBetweenConvexHulls)
                {
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    max = p.ConvexHull;
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    if (p.ConvexHull > max) { max = p.ConvexHull; }
                    
                    if (rdBtnRemained.Checked && edg.Active && !edg.Attributes.IsIntersectOwnConvexHull) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                    if (rdBtnEliminated.Checked && !edg.Active && edg.Attributes.IsCrossingSpanningEdge) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                }
            }
        }
        private void RuleIntersectOwnHullOH()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int max;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsIntersectOwnConvexHull && edg.Attributes.IsOverConvexHull)
                {
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    max = p.ConvexHull;
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    if (p.ConvexHull > max) { max = p.ConvexHull; }

                    if (rdBtnRemained.Checked && edg.Active) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                    if (rdBtnEliminated.Checked && !edg.Active) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                }
            }
        }
        private void RuleDistanceOH()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            NodeTSP p;
            Point pt0, pt1;
            int max;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsOverConvexHull && !edg.Attributes.IsIntersectOwnConvexHull)
                {
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    max = p.ConvexHull;
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    if (p.ConvexHull > max) { max = p.ConvexHull; }

                    if (rdBtnRemained.Checked && edg.Active) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                    if (rdBtnEliminated.Checked && !edg.Active) { grph.DrawLine(MyPM.MyPens[max], pt0, pt1); }
                }
            }
        }



        //*****************
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Point GetNewPoint(NodeTSP p)
        {
            return new Point((int)(10 + ((p.X - MyTSP.RefCorner().X) / MyTSP.PointMagnitude * MyScale.Item1)),
                h - 15 - (int)((p.Y - MyTSP.RefCorner().Y) / MyTSP.PointMagnitude * MyScale.Item2));
        }
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void Scale(double origX, double origY, double newX, double newY)
        //{
        //    int scaleX = Math.Max((int)Math.Floor(newX / origX), 1);
        //    int scaleY = Math.Max((int)Math.Floor(newY / origY), 1);

        //    MyScale = Tuple.Create(scaleX, scaleY);
        //}
    }
}
