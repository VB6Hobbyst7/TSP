using System;
using System.Windows.Forms;
using System.Linq;
using TSP;
using System.Collections.Generic;
using PlaneGeometry;

namespace WindowsTSP
{
    public partial class MainForm : Form
    {

        //TSP related
        PlaneTSP MyTSP;
        string FilePath, FileName;

        // Image related
        readonly PaintManagement colorManagement;

        public MainForm()
        {
            InitializeComponent();
            colorManagement = new PaintManagement();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { 
                InitialDirectory= "C:/Users/pauborge/Desktop/TSP/Datasets", 
                Filter = "tsp files (*.tsp)|*.tsp|All files (*.*)|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            { FilePath = ofd.FileName; txtFile.Text = FilePath; FileName = ofd.SafeFileName; btnLoad.Enabled = true; }
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            MyTSP = new PlaneTSP(FilePath, true);

            lblNumNodes.Text = MyTSP.Graph.NumberNodes.ToString();
            lblNumEdges.Text = MyTSP.Graph.NumberEdges.ToString();

            grpBoxGraph.Enabled = true;
            grpBoxModel.Enabled = true;
            grpBoxConvexHulls.Enabled = true;
            grpBoxSpanningTree.Enabled = true;
            grpBoxExpandSpanTree.Enabled = true;
            grpBoxTour.Enabled = true;

        }

        private void BtnShowGraph_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm gForm = new EdgeClassificationForm(MyTSP, colorManagement);
            gForm.DrawGraph();
            gForm.Text = string.Format("{0} - {1}", "All Edges", FileName);
            gForm.Show();
        }

        private void BtnWriteModel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "lp files (*.lp)|*.lp" };
            if (sfd.ShowDialog() == DialogResult.OK) { MyTSP.WriteLP(sfd.FileName); }
        }
        private void BtnReadSolution_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "sol files (*.sol)|*.sol|All files (*.*)|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MyTSP.ReadSolution(ofd.FileName);
                btnComponents.Enabled = true;
                btnShowSolution.Enabled = true;
            }
        }
        private void BtnComponents_Click(object sender, EventArgs e)
        {
            MyTSP.ComputeCycles();
            lblNumComponents.Text = string.Format("{0}", MyTSP.ConnectedCompnents.Count);
            if (MyTSP.ConnectedCompnents.Count == 1) { btnSaveTour.Enabled = true; }
        }
        private void BtnShowSolution_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm gForm = new EdgeClassificationForm(MyTSP, colorManagement);
            gForm.DrawSolution();
            gForm.Text = string.Format("{0} - {1}", "Solution", FileName);
            gForm.Show();
        }

        private void BtnComputeConvexHulls_Click(object sender, EventArgs e)
        {
            MyTSP.ComputeConvexHulls(chkBoxAddBoundary.Checked);
            lblNumConvexHulls.Text = MyTSP.ConvexHulls.Count().ToString();
            btnShowConvexHulls.Enabled = true;
            colorManagement.GenerateColors(MyTSP.ConvexHulls.Count, false);
        }
        private void BtnShowConvexHulls_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm gForm = new EdgeClassificationForm(MyTSP, colorManagement);
            gForm.DrawHulls();
            gForm.Text = string.Format("{0} - {1}", "Convex Hulls", FileName);
            gForm.Show();
        }

        private void BtnComputeSpanningTree_Click(object sender, EventArgs e)
        {
            MyTSP.ComputeSpanningTree(chkBoxSpanTreeAlternatives.Checked);
            btnComputeExpandSpanningTree.Enabled = true;
            btnShowSpanningTree.Enabled = true;
            grpBoxEdges.Enabled = true;
        }
        private void BtnShowSpanningTree_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm gForm = new EdgeClassificationForm(MyTSP, colorManagement);
            gForm.DrawSpanningTree();
            gForm.Text = string.Format("{0} - {1}", "Spanning Tree", FileName);
            gForm.Show();
        }

        private void BtnExpandSpanningTree_Click(object sender, EventArgs e)
        {
            MyTSP.ComputeHullsSpanningTrees(true); //chkBoxCleanExpandSpanTree.Checked,
            btnShowExpandSpanningTree.Enabled = true;
        }
        private void BtnShowExpandSpanningTree_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm gForm = new EdgeClassificationForm(MyTSP, colorManagement);
            gForm.DrawExpandSpanningTree();
            gForm.Text = string.Format("{0} - {1}", "Expand Spanning Tree", FileName);
            gForm.Show();
        }

        private void BtnClassify_Click(object sender, EventArgs e)
        {
            MyTSP.ClassifyEdges();
            rdBtnInsideHulls.Enabled = true;
            rdBtnBetweenHulls.Enabled = true;
            rdBtnOverHulls.Enabled = true;
            rdBtnInsideHulls.Checked = true;
            btnShowClassification.Enabled = true;
            grpBoxElimination.Enabled = true;
        }
        private void RdBtnInsideHulls_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void RdBtnBetweenHulls_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void RdBtnOverHulls_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void BtnShowClassification_Click(object sender, EventArgs e)
        {
            if (rdBtnInsideHulls.Checked)
            {
                EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
                {
                    Text = string.Format("{0} - {1}", "Inside Convex Hulls", FileName)
                };
                cForm.DrawInsideHulls();
                cForm.Show();
            }
            else if (rdBtnBetweenHulls.Checked)
            {
                EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
                {
                    Text = string.Format("{0} - {1}", "Between Convex Hulls", FileName)
                };
                cForm.DrawBetweenHulls();
                cForm.Show();
            }
            else if (rdBtnOverHulls.Checked)
            {
                EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
                {
                    Text = string.Format("{0} - {1}", "Over Convex Hulls", FileName)
                };
                cForm.DrawOverHulls();
                cForm.Show();
            }
        }

        private void BtnEdgeElimination_Click(object sender, EventArgs e)
        {
            MyTSP.RunEdgeElimination();
            rdBtnEliminatedBetweenHulls.Enabled = true;
            rdBtnEliminatedOverHulls.Enabled = true;
            rdBtnEliminatedConvexHulls.Enabled = true;
            rdBtnEliminatedBetweenHulls.Checked = true;
            btnShowElimination.Enabled = true;
            grpBoxFinal.Enabled = true;
        }
        private void RdBtnEliminatedBetweenHulls_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void RdBtnEliminatedOverHulls_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void RdBtnEliminatedConvexHulls_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void BtnShowElimination_Click(object sender, EventArgs e)
        {
            if (rdBtnEliminatedBetweenHulls.Checked)
            {
                //EdgeEliminationForm eForm = new EdgeEliminationForm(MyTSP)
                //{
                //    Text = "Between Convex Hulls"
                //};
                //eForm.DrawInsideHulls();
                //eForm.Show();
            }
            else if (rdBtnEliminatedOverHulls.Checked)
            {
                //EdgeEliminationForm eForm = new EdgeEliminationForm(MyTSP)
                //{
                //    Text = "Over Convex Hulls"
                //};
                //eForm.DrawBetweenHulls();
                //eForm.Show();
            }
            else if (rdBtnEliminatedConvexHulls.Checked)
            {
                //EdgeEliminationForm eForm = new EdgeEliminationForm(MyTSP)
                //{
                //    Text = "Convex Hulls"
                //};
                //eForm.DrawOverHulls();
                //eForm.Show();
            }
        }

        private void BtnUploadTour_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "C:/Users/pauborge/Desktop/TSP/Datasets",
                Filter = "tour files (*.tour)|*.tour|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MyTSP.LoadTour(ofd.FileName);
                btnShowTour.Enabled = true;
            }
        }
        private void BtnShowTour_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
            {
                Text = string.Format("{0} - {1}", "Tour", FileName)
            };
            cForm.DrawTour();
            cForm.Show();
        }
        private void BtnSaveTour_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = "C:/Users/pauborge/Desktop/TSP/Datasets",
                Filter = "tour files (*.tour)|*.tour|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MyTSP.SaveTour(sfd.FileName);
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if(btnShowElimination.Enabled && btnShowTour.Enabled)
            {
                MyTSP.TestElimination();
                btnShowTest.Enabled = true;
            }
        }

        private void BtnShowTest_Click(object sender, EventArgs e)
        {
            EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
            {
                Text = string.Format("{0} - {1}", "Elimination Test", FileName)
            };
            cForm.DrawTest();
            cForm.Show();
        }

        private void BtnShowFinal_Click(object sender, EventArgs e)
        {
            if (rdBtnEliminated.Checked)
            {
                EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
                {
                    Text = string.Format("{0} - {1}", "Eliminated", FileName)
                };
                cForm.DrawFinal(true);
                cForm.Show();
            }
            if (rdBtnRemained.Checked)
            {
                EdgeClassificationForm cForm = new EdgeClassificationForm(MyTSP, colorManagement)
                {
                    Text = string.Format("{0} - {1}", "Remained", FileName)
                };
                cForm.DrawFinal(false);
                cForm.Show();
            }
        }
    }
}
