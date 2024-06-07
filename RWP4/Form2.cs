using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WpfControlLibrary1;

namespace RWP4
{
    public partial class Form2 : Form
    {
        double shift = 0.1;
        bool IsPressed = false;
        public List<Formula> formulaList = new List<Formula>() { new Formula1(), new Formula2(), new Formula3(), new Formula4(), new Formula5() };
        WpfControlLibrary1.UserControl1 uc;
        public double f1X = -5;
        public double f2X = 5;
        public double deltaf1 = 0;
        public double deltaf2 = 0;
        public int IndexOfSelectedFunction;
        public int index1;
        public int index2;
        public Form2()
        {
            InitializeComponent();
            trackBar1.Minimum = -50;
            trackBar1.Maximum = 50;
            trackBar1.Value = 0;
            trackBar1.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int Steps = (int)((2 * 4) / shift) + 1;
            double[,] pos1 = new double[Steps, Steps];
            Random rnd = new Random();
            index1 = rnd.Next(0, formulaList.Count());
            while (true)
            {
                index2 = rnd.Next(0, formulaList.Count());
                if (index2 != index1)
                    break;
            }
            for (int z = 0; z < Steps; z++)
            {
                for (int x = 0; x < Steps; x++)
                {
                    double xPos = -4 + x * shift;
                    double zPos = -4 + z * shift;
                    pos1[z, x] = formulaList[index1].Calc(xPos, zPos);
                }
            }
            double[,] pos2 = new double[Steps, Steps];
            for (int z = 0; z < Steps; z++)
            {
                for (int x = 0; x < Steps; x++)
                {
                    double xPos = -4 + x * shift;
                    double zPos = -4 + z * shift;
                    pos2[z, x] = formulaList[index2].Calc(xPos, zPos);
                }
            }
            Steps = (int)((2 * 9) / shift) + 1;
            double[,] pos = new double[Steps, Steps];
            for (int z = 0; z < Steps; z++)
            {
                for (int x = 0; x < Steps; x++)
                {
                    double xPos = -9 + x * shift;
                    double zPos = -9 + z * shift;
                    if (((xPos >= -9 + deltaf1) && (xPos <= -1 + deltaf1) && (zPos >= -4) && (zPos <= 4)) || ((xPos >= 1 + deltaf2) && (xPos <= 9 + deltaf2) && (zPos >= -4) && (zPos <= 4)))
                    {
                        if ((1 + deltaf2 <= -1 + deltaf1) && (xPos <= -1 + deltaf1) && (xPos >= 1 + deltaf2) && (9 + deltaf2 >= -9 + deltaf1))
                        {
                            pos[z, x] = formulaList[index1].Calc(xPos + 5 - deltaf1, zPos) + formulaList[index2].Calc(xPos - 5 - deltaf2, zPos);
                        }
                        else if ((xPos >= -9 + deltaf1) && (xPos <= -1 + deltaf1) && (zPos >= -4) && (zPos <= 4))
                        {
                            pos[z, x] = formulaList[index1].Calc(xPos + 5 - deltaf1, zPos);
                        }
                        else if ((xPos >= 1 + deltaf2) && (xPos <= 9 + deltaf2) && (zPos >= -4) && (zPos <= 4))
                        {
                            pos[z, x] = formulaList[index2].Calc(xPos - 5 - deltaf2, zPos);
                        }
                    }
                    else
                    {
                        pos[z, x] = 0;
                    }
                }
            }
            uc = new WpfControlLibrary1.UserControl1(pos1, pos2, pos, f1X, f2X);
            elementHost1.Dock = DockStyle.Fill;
            elementHost1.Child = uc;
            uc.cam_theta = 0;
            uc.cam_phi = 0;
            uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
            uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
            uc.MouseDown += Uc_MouseDown;
            uc.MouseMove += Uc_MouseMove;
            uc.MouseUp += Uc_MouseUp;
            uc.MouseWheel += Uc_MouseWheel;
        }

        private void Uc_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            uc.cam_radius -= e.Delta / 60;
            if (uc.cam_radius < 5)
                uc.cam_radius = 5;
            if (uc.cam_radius > 100)
                uc.cam_radius = 100;
            double cam_x = uc.cam_radius * Math.Cos(uc.cam_phi) * Math.Sin(uc.cam_theta);
            double cam_y = uc.cam_radius * Math.Sin(uc.cam_phi);
            double cam_z = uc.cam_radius * Math.Cos(uc.cam_phi) * Math.Cos(uc.cam_theta);
            uc.myPCamera.Position = new Point3D(cam_x, cam_y, cam_z);
            uc.myPCamera.LookDirection = new Vector3D(-cam_x, -cam_y, -cam_z);
        }

        private void Uc_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IsPressed = false;
        }

        private void Uc_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((e.RightButton == MouseButtonState.Pressed) && (IsPressed))
            {
                uc.NewPoint = e.GetPosition(uc);
                double dPhi = (uc.OldPoint.Y - uc.NewPoint.Y) / 400;
                double dTheta = (uc.OldPoint.X - uc.NewPoint.X) / 400;
                Rotation_Of_Camera(-dTheta, dPhi);
                uc.OldPoint = uc.NewPoint;
            }
        }

        private void Uc_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                uc.OldPoint = e.GetPosition(uc);
                IsPressed = true;
            }
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                uc.ClickPoint = e.GetPosition(uc);
                RayMeshGeometry3DHitTestResult hitResult = VisualTreeHelper.HitTest(uc.myViewport3d, uc.ClickPoint) as RayMeshGeometry3DHitTestResult;
                if (hitResult != null)
                {
                    if (hitResult.MeshHit == uc.func1Mesh)
                    {
                        trackBar1.Minimum = 0;
                        trackBar1.Maximum = 100;
                        label1.Text = "0";
                        label2.Text = "10";
                        trackBar1.Enabled = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        trackBar1.Value = (int)(deltaf1 * 10);
                        IndexOfSelectedFunction = 1;
                    }
                    else if (hitResult.MeshHit == uc.func2Mesh)
                    {
                        trackBar1.Minimum = -100;
                        trackBar1.Maximum = 0;
                        label1.Text = "-10";
                        label2.Text = "0";
                        trackBar1.Enabled = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        trackBar1.Value = (int)(deltaf2 * 10);
                        IndexOfSelectedFunction = 2;
                    }
                }
            }
        }
        private void Rotation_Of_Camera(double dTheta, double dPhi)
        {
            uc.cam_theta -= dTheta;
            uc.cam_phi -= dPhi;
            if ((uc.cam_phi < -Math.PI / 2) || (uc.cam_phi > Math.PI / 2))
            {
                if (uc.cam_phi < -Math.PI / 2)
                {
                    uc.cam_phi = -Math.PI / 2;
                }
                else
                {
                    uc.cam_phi = Math.PI / 2;
                }
            }
            double cam_x = uc.cam_radius * Math.Cos(uc.cam_phi) * Math.Sin(uc.cam_theta);
            double cam_y = uc.cam_radius * Math.Sin(uc.cam_phi);
            double cam_z = uc.cam_radius * Math.Cos(uc.cam_phi) * Math.Cos(uc.cam_theta);
            uc.myPCamera.Position = new Point3D(cam_x, cam_y, cam_z);
            uc.myPCamera.LookDirection = new Vector3D(-cam_x, -cam_y, -cam_z);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(IndexOfSelectedFunction == 1)
            {
                deltaf1 = trackBar1.Value / 10;
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos1 = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos1[z, x] = formulaList[index1].Calc(xPos, zPos);
                    }
                }
                double[,] pos2 = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos2[z, x] = formulaList[index2].Calc(xPos, zPos);
                    }
                }
                Steps = (int)((2 * 9) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -9 + x * shift;
                        double zPos = -9 + z * shift;
                        if (((xPos >= -9 + deltaf1) && (xPos <= -1 + deltaf1) && (zPos >= -4) && (zPos <= 4)) || ((xPos >= 1 + deltaf2) && (xPos <= 9 + deltaf2) && (zPos >= -4) && (zPos <= 4)))
                        {
                            if ((1 + deltaf2 <= -1 + deltaf1) && (xPos <= -1 + deltaf1) && (xPos >= 1 + deltaf2) && (9 + deltaf2 >= -9 + deltaf1))
                            {
                                pos[z, x] = formulaList[index1].Calc(xPos + 5 - deltaf1, zPos) + formulaList[index2].Calc(xPos - 5 - deltaf2, zPos);
                            }
                            else if ((xPos >= -9 + deltaf1) && (xPos <= -1 + deltaf1) && (zPos >= -4) && (zPos <= 4))
                            {
                                pos[z, x] = formulaList[index1].Calc(xPos + 5 - deltaf1, zPos);
                            }
                            else if ((xPos >= 1 + deltaf2) && (xPos <= 9 + deltaf2) && (zPos >= -4) && (zPos <= 4))
                            {
                                pos[z, x] = formulaList[index2].Calc(xPos - 5 - deltaf2, zPos);
                            }
                        }
                        else
                        {
                            pos[z, x] = 0;
                        }
                    }
                }
                uc = new WpfControlLibrary1.UserControl1(pos1, pos2, pos, f1X + deltaf1, f2X + deltaf2);
                elementHost1.Dock = DockStyle.Fill;
                elementHost1.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
            }
            else
            {
                deltaf2 = trackBar1.Value / 10;
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos1 = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos1[z, x] = formulaList[index1].Calc(xPos, zPos);
                    }
                }
                double[,] pos2 = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos2[z, x] = formulaList[index2].Calc(xPos, zPos);
                    }
                }
                Steps = (int)((2 * 9) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -9 + x * shift;
                        double zPos = -9 + z * shift;
                        if (((xPos >= -9 + deltaf1) && (xPos <= -1 + deltaf1) && (zPos >= -4) && (zPos <= 4)) || ((xPos >= 1 + deltaf2) && (xPos <= 9 + deltaf2) && (zPos >= -4) && (zPos <= 4)))
                        {
                            if ((1 + deltaf2 <= -1 + deltaf1) && (xPos <= -1 + deltaf1) && (xPos >= 1 + deltaf2) && (9 + deltaf2 >= -9 + deltaf1))
                            {
                                pos[z, x] = formulaList[index1].Calc(xPos + 5 - deltaf1, zPos) + formulaList[index2].Calc(xPos - 5 - deltaf2, zPos);
                            }
                            else if ((xPos >= -9 + deltaf1) && (xPos <= -1 + deltaf1) && (zPos >= -4) && (zPos <= 4))
                            {
                                pos[z, x] = formulaList[index1].Calc(xPos + 5 - deltaf1, zPos);
                            }
                            else if ((xPos >= 1 + deltaf2) && (xPos <= 9 + deltaf2) && (zPos >= -4) && (zPos <= 4))
                            {
                                pos[z, x] = formulaList[index2].Calc(xPos - 5 - deltaf2, zPos);
                            }
                        }
                        else
                        {
                            pos[z, x] = 0;
                        }
                    }
                }
                uc = new WpfControlLibrary1.UserControl1(pos1, pos2, pos, f1X + deltaf1, f2X + deltaf2);
                elementHost1.Dock = DockStyle.Fill;
                elementHost1.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
            }
        }
    }
}
