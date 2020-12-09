using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Linq;
using TSP;
using System.Collections.Generic;

namespace WindowsTSP
{
    public partial class EdgeClassificationForm : Form
    {
        private readonly PlaneTSP MyTSP;
        private readonly PaintManagement MyPM;

        private bool graph, hulls, spanTree, expSpanTree, sol, inHulls, betweenHulls, overHulls, final, tour, test;
        private bool eliminated;

        //Image related
        private Bitmap MyImage;
        private Tuple<int, int> MyScale;
        private int ptScale;
        private int cPointSize;
        private int w, h;

        public EdgeClassificationForm(PlaneTSP tsp, PaintManagement pm)
        {
            InitializeComponent();
            MyTSP = tsp;
            MyPM = pm;

            cPointSize = (int)numericUpDown1.Value;
        }

        private void EdgeClassificationForm_Load(object sender, EventArgs e)
        {
            
        }
        private void PictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path that is drawn onto the event PictureBox.
            label1.Text = e.Location.ToString();
        }

        private void BtnCanvasColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                MyPM.CanvasColor = cd.Color;
                pictureBox1.BackColor = MyPM.CanvasColor;
            }
        }
        private void BtnPenColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                MyPM.MyPen.Dispose();
                MyPM.MyPen = new Pen(cd.Color);
                MyPM.MyBrush.Dispose();
                MyPM.MyBrush = new SolidBrush(cd.Color);
                EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
            }
        }

        private void ChkBoxHullsSpanTree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxHullsSpanTree.Text == "Convex Hulls")
            {
                if (chkBoxHullsSpanTree.Checked) { hulls = true; }
                else { hulls = false; }
            }
            if (chkBoxHullsSpanTree.Text == "Spanning Tree")
            {
                if (chkBoxHullsSpanTree.Checked) { spanTree = true; }
                else { spanTree = false; }
            }

            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }

        private void CmbBoxHulls1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxHulls1.SelectedIndex == MyTSP.ConvexHulls.Count) { btnHullColor1.Enabled = false; } else { btnHullColor1.Enabled = true; }
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        private void BtnHullColor1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                int indx = cmbBoxHulls1.SelectedIndex;
                MyPM.MyBrushes[indx] = new SolidBrush(cd.Color);
                MyPM.MyPens[indx] = new Pen(cd.Color);
                EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
            }
        }
        private void CmbBoxHulls2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxHulls2.SelectedIndex == MyTSP.ConvexHulls.Count) { btnHullColor2.Enabled = false; } else { btnHullColor2.Enabled = true; }
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        private void BtnHullColor2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                int indx = cmbBoxHulls2.SelectedIndex;
                MyPM.MyBrushes[indx] = new SolidBrush(cd.Color);
                MyPM.MyPens[indx] = new Pen(cd.Color);
                EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
            }
        }

        private void EdgeClassificationForm_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
            }
            
        }
        private void EdgeClassificationForm_ResizeEnd(object sender, EventArgs e)
        {
            w = pictureBox1.Width - 5;
            h = pictureBox1.Height - 0;
            MyImage = null;
            MyImage = new Bitmap(w, h);
            Scale(MyTSP.WidthRange() + 1, MyTSP.HeightRange() + 1, w, h);
            ptScale = Math.Max((Math.Max(w, h) - Math.Min(w, h)) / MyTSP.Graph.NumberNodes, 1);

            if (cPointSize <= (int)numericUpDown1.Value)
            {
                if (graph) { InternDrawGraph(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (hulls) { InternDrawHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (spanTree) { InternDrawSpanningTree(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (expSpanTree) { InternDrawExpandSpanningTree(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (sol) { InternDrawSolution(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (inHulls) { InternDrawInsideHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (betweenHulls) { InternDrawBetweenHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (overHulls) { InternDrawOverHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (final) { InternDrawFinal(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (tour) { InternDrawTour(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (test) { InternDrawTest(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
            }
            else
            {
                if (graph) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawGraph(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (hulls) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (spanTree) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawSpanningTree(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (expSpanTree) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawExpandSpanningTree(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (sol) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawSolution(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (inHulls) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawInsideHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (betweenHulls) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawBetweenHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (overHulls) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawOverHulls(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (final) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawFinal(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (tour) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawTour(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
                if (test) { DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, true); InternDrawTest(); DrawPoints(chkBoxCentroid.Checked, chkBoxAxis.Checked, false); }
            }

            pictureBox1.Image = MyImage;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            EdgeClassificationForm_ResizeEnd(sender, e);
        }
        private void ChkBoxCentroid_CheckedChanged(object sender, EventArgs e)
        {
            EdgeClassificationForm_ResizeEnd(sender, e);
        }
        private void ChkBoxAxis_CheckedChanged(object sender, EventArgs e)
        {
            EdgeClassificationForm_ResizeEnd(sender, e);
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

        public void DrawGraph()
        {
            graph = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawHulls()
        {
            hulls = true;

            chkBoxHullsSpanTree.Visible = true;
            chkBoxHullsSpanTree.Text = "Spanning Tree";

            grpBoxHulls.Visible = true;

            cmbBoxHulls1.Visible = true;
            btnHullColor1.Visible = true;

            cmbBoxHulls2.Visible = false;
            btnHullColor2.Visible = false;

            for (int i = 0; i < MyTSP.ConvexHulls.Count; ++i)
            {
                cmbBoxHulls1.Items.Add(i);
                //cmbBoxHulls2.Items.Add(i);
            }
            cmbBoxHulls1.Items.Add("All");
            cmbBoxHulls1.SelectedIndex = MyTSP.ConvexHulls.Count;

            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawSpanningTree()
        {
            spanTree = true;
            chkBoxHullsSpanTree.Text = "Convex Hulls";
            chkBoxHullsSpanTree.Visible = true;
            
            for (int i = 0; i < MyTSP.ConvexHulls.Count; ++i)
            {
                cmbBoxHulls1.Items.Add(i);
            }
            cmbBoxHulls1.Items.Add("All");
            cmbBoxHulls1.SelectedIndex = MyTSP.ConvexHulls.Count;

            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawExpandSpanningTree()
        {
            expSpanTree = true;
            chkBoxHullsSpanTree.Text = "Convex Hulls";
            chkBoxHullsSpanTree.Visible = true;

            grpBoxHulls.Visible = true;

            cmbBoxHulls1.Visible = true;
            btnHullColor1.Visible = true;

            for (int i = 0; i < MyTSP.ConvexHulls.Count; ++i)
            {
                cmbBoxHulls1.Items.Add(i);
                cmbBoxHulls2.Items.Add(i);
            }
            cmbBoxHulls1.SelectedIndex = 0;
            cmbBoxHulls2.SelectedIndex = 1;

            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawSolution()
        {
            sol = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawInsideHulls()
        {
            inHulls = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawBetweenHulls()
        {
            betweenHulls = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawOverHulls()
        {
            overHulls = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawFinal(bool eliminated)
        {
            final = true;
            this.eliminated = eliminated;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawTour()
        {
            tour = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
        }
        public void DrawTest()
        {
            test = true;
            EdgeClassificationForm_ResizeEnd(this, EventArgs.Empty);
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
            lblNumEdges.Text = string.Format("{0}", n);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * n / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)n / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double) n / MyTSP.Graph.NumberNodes);
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
            if (cmbBoxHulls1.SelectedIndex == n)
            {
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
            }
            else
            {
                int i = cmbBoxHulls1.SelectedIndex;
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
                if (expSpanTree)
                {
                    i = cmbBoxHulls2.SelectedIndex;
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
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / MyTSP.Graph.NumberEdges);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
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
                    if (edg.Attributes.HasAlternative) { grph.DrawLine(Pens.Aquamarine, pt0, pt1); }
                    else { grph.DrawLine(MyPM.MyPen, pt0, pt1); }
                    
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
        }
        private void InternDrawExpandSpanningTree()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;
            int cnt = 0;

            if (chkBoxHullsSpanTree.Checked)
            {
                string key;
                int indx1, indx2;

                indx1 = Math.Min(cmbBoxHulls1.SelectedIndex, cmbBoxHulls2.SelectedIndex);
                indx2 = Math.Max(cmbBoxHulls1.SelectedIndex, cmbBoxHulls2.SelectedIndex);
                if (indx1 != indx2)
                {
                    key = string.Format("{0}-{1}", indx1, indx2);
                    EdgeContainer eST = MyTSP.HullsSpanningTrees[key];
                    n = eST.Count;
                    for (int i = 0; i < n; i++)
                    {
                        var edg = MyTSP.Graph.GetEdge(eST.GetEdge(i));
                        pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                        pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                        grph.DrawLine(MyPM.MyPen, pt0, pt1);
                        cnt++;
                    }
                }
            }
            else
            {
                // take uniques
                List<int> edges = new List<int>();
                foreach (EdgeContainer eST in MyTSP.HullsSpanningTrees.Values)
                {
                    n = eST.Count;
                    for (int i = 0; i < n; i++) { if (!edges.Contains(eST.GetEdge(i))) { edges.Add(eST.GetEdge(i)); } }
                }

                foreach ( int e in edges)
                {
                    var edg = MyTSP.Graph.GetEdge(e);
                    if (edg.Active)
                    { 
                        pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                        pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                        grph.DrawLine(MyPM.MyPen, pt0, pt1);
                        cnt++;
                    }
                }
            }
            
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / MyTSP.Graph.NumberEdges);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
        }
        private void InternDrawSolution()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;

            n = MyTSP.Solution.Count;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(MyTSP.Solution.GetEdge(i));
                pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                grph.DrawLine(MyPM.MyPen, pt0, pt1);
            }
            lblNumEdges.Text = string.Format("{0}", n);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * n / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)n / MyTSP.Graph.NumberEdges);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)n / MyTSP.Graph.NumberNodes);
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
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
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
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    max = p.ConvexHull;
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    if (p.ConvexHull > max) { max = p.ConvexHull; }
                    grph.DrawLine(MyPM.MyPens[max], pt0, pt1); //Draw a line
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
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
                    p = MyTSP.Graph.GetNode(edg.Node1).Attributes;
                    pt0 = GetNewPoint(p);
                    max = p.ConvexHull;
                    p = MyTSP.Graph.GetNode(edg.Node2).Attributes;
                    pt1 = GetNewPoint(p);
                    if (p.ConvexHull > max) { max = p.ConvexHull; }
                    grph.DrawLine(MyPM.MyPens[max], pt0, pt1); //Draw a line
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
        }
        private void InternDrawFinal()
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
                if ((!eliminated && edg.Active) || (eliminated && !edg.Active))
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
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
        }
        private void InternDrawTour()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;
            int cnt = 0;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsTour)
                {
                    pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                    pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                    grph.DrawLine(MyPM.MyPen, pt0, pt1); //Draw a line
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
        }
        private void InternDrawTest()
        {
            Graphics grph = Graphics.FromImage(MyImage);
            int n;
            Point pt0, pt1;
            int cnt = 0;

            n = MyTSP.Graph.NumberEdges;
            for (int i = 0; i < n; i++)
            {
                var edg = MyTSP.Graph.GetEdge(i);
                if (edg.Attributes.IsWrongElimination)
                {
                    pt0 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node1).Attributes);
                    pt1 = GetNewPoint(MyTSP.Graph.GetNode(edg.Node2).Attributes);
                    //Draw a line
                    if (edg.Attributes.IsCrossingSpanningEdge) { grph.DrawLine(Pens.Red, pt0, pt1); }
                    else if (edg.Attributes.IsHullSpanningEdge && edg.Attributes.IsCrossingHullSpanningEdge) { grph.DrawLine(Pens.Red, pt0, pt1); }
                    //else if (edg.Attributes.IsIntersectOwnConvexHull) { grph.DrawLine(Pens.Yellow, pt0, pt1); }

                    else if (edg.Attributes.IsConvexHull) { grph.DrawLine(Pens.Green, pt0, pt1); }
                    
                    else if (edg.Attributes.IsOverConvexHull && edg.Attributes.IsCrossingHullSpanningEdge) { grph.DrawLine(Pens.Blue, pt0, pt1); }
                    else if (edg.Attributes.IsOverConvexHull && edg.Attributes.IsIntersectOwnConvexHull) { grph.DrawLine(Pens.Aqua, pt0, pt1); }
                    else if (edg.Attributes.IsOverConvexHull) { grph.DrawLine(Pens.Teal, pt0, pt1); }

                    else if (edg.Attributes.IsInsideConvexHull && edg.Attributes.IsCrossingHullSpanningEdge) { grph.DrawLine(Pens.Violet, pt0, pt1); }
                    else if (edg.Attributes.IsInsideConvexHull ) { grph.DrawLine(Pens.DarkMagenta, pt0, pt1); }
                    
                    else if (edg.Attributes.IsBetweenConvexHulls) { grph.DrawLine(Pens.Orange, pt0, pt1); }
                    else if (edg.Attributes.IsSpanningEdge) { grph.DrawLine(Pens.SandyBrown, pt0, pt1); }
                    else if (edg.Attributes.IsHullSpanningEdge) { grph.DrawLine(Pens.Brown, pt0, pt1); }

                    else { grph.DrawLine(MyPM.MyPen, pt0, pt1); }
                    cnt++;
                }
            }
            lblNumEdges.Text = string.Format("{0}", cnt);
            lblEdgesPerNode.Text = string.Format("{0:F2}", (double)2 * cnt / MyTSP.Graph.NumberNodes);
            lblEdgeTotalRatio.Text = string.Format("{0:P2}", (double)cnt / n);
            lblEdgeNodeRatio.Text = string.Format("{0:F2}", (double)cnt / MyTSP.Graph.NumberNodes);
        }
        //*****************
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Point GetNewPoint(NodeTSP p)
        {
            return new Point((int)(10 + ((p.X - MyTSP.RefCorner().X) / MyTSP.PointMagnitude * MyScale.Item1)),
                h - 15 - (int)((p.Y - MyTSP.RefCorner().Y) / MyTSP.PointMagnitude * MyScale.Item2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Scale(double originalWidth, double originalHeight, double newWidth, double newHeight)
        {
            int scaleWidth = Math.Max((int)Math.Floor(newWidth / originalWidth), 1);
            int scaleHeight = Math.Max((int)Math.Floor(newHeight / originalHeight), 1);

            MyScale = Tuple.Create(scaleWidth, scaleHeight);
        }
    }
}
