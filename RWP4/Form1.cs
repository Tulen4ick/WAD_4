using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using WpfControlLibrary1;

namespace RWP4
{
    public partial class Form1 : Form
    {
        double alpha = 1;
        bool IsPressed = false;
        int NowTabIndex = 0;
        double shift = 0.1;
        public List<Formula> formulaList = new List<Formula>() { new Formula1(), new Formula2(), new Formula3(), new Formula4(), new Formula5() };
        WpfControlLibrary1.UserControl1 uc;
        public Form1()
        {
            InitializeComponent();
            tabControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int Steps = (int)((2 * 4) / shift) + 1;
            double[,] pos = new double[Steps, Steps];
            for (int z = 0; z < Steps; z++)
            {
                for(int x = 0; x < Steps; x++)
                {
                    double xPos = -4 + x * shift;
                    double zPos = -4 + z * shift;
                    pos[z, x] = formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos);
                }
            }
            uc = new WpfControlLibrary1.UserControl1(pos);
            elementHost1.Dock = DockStyle.Fill;
            elementHost1.Child = uc;
            uc.MouseDown += Uc_MouseDown;
            uc.MouseMove += Uc_MouseMove;
            uc.MouseUp += Uc_MouseUp;
            uc.MouseWheel += Uc_MouseWheel;
            

        }

        private void Uc_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            uc.cam_radius -= e.Delta / 60;
            if(uc.cam_radius < 5)
                uc.cam_radius = 5;
            if(uc.cam_radius > 50)
                uc.cam_radius = 50;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if(NowTabIndex == 1)
                {
                    elementHost2.Child = null;
                }else if(NowTabIndex == 2)
                {
                    elementHost3.Child = null;
                }
                else if (NowTabIndex == 3)
                {
                    elementHost4.Child = null;
                }
                else if (NowTabIndex == 4)
                {
                    elementHost5.Child = null;
                }
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos[z, x] = formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos);
                    }
                }
                elementHost1.Dock = DockStyle.Fill;
                uc = new WpfControlLibrary1.UserControl1(pos);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
                elementHost1.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                NowTabIndex = tabControl1.SelectedIndex;
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                if (NowTabIndex == 0)
                {
                    elementHost1.Child = null;
                }
                else if (NowTabIndex == 2)
                {
                    elementHost3.Child = null;
                }
                else if (NowTabIndex == 3)
                {
                    elementHost4.Child = null;
                }
                else if (NowTabIndex == 4)
                {
                    elementHost5.Child = null;
                }
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos[z, x] = formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos);
                    }
                }
                elementHost2.Dock = DockStyle.Fill;
                uc = new WpfControlLibrary1.UserControl1(pos);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
                elementHost2.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                NowTabIndex = tabControl1.SelectedIndex;
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                if (NowTabIndex == 0)
                {
                    elementHost1.Child = null;
                }
                else if (NowTabIndex == 1)
                {
                    elementHost2.Child = null;
                }
                else if (NowTabIndex == 3)
                {
                    elementHost4.Child = null;
                }
                else if (NowTabIndex == 4)
                {
                    elementHost5.Child = null;
                }
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos[z, x] = formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos);
                    }
                }
                elementHost3.Dock = DockStyle.Fill;
                uc = new WpfControlLibrary1.UserControl1(pos);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
                elementHost3.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                NowTabIndex = tabControl1.SelectedIndex;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                if (NowTabIndex == 0)
                {
                    elementHost1.Child = null;
                }
                else if (NowTabIndex == 1)
                {
                    elementHost2.Child = null;
                }
                else if (NowTabIndex == 2)
                {
                    elementHost3.Child = null;
                }
                else if (NowTabIndex == 4)
                {
                    elementHost5.Child = null;
                }
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos[z, x] = formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos);
                    }
                }
                elementHost4.Dock = DockStyle.Fill;
                uc = new WpfControlLibrary1.UserControl1(pos);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
                elementHost4.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                NowTabIndex = tabControl1.SelectedIndex;
            }
            else if( tabControl1.SelectedIndex == 4)
            {
                if (NowTabIndex == 0)
                {
                    elementHost1.Child = null;
                }
                else if (NowTabIndex == 1)
                {
                    elementHost2.Child = null;
                }
                else if (NowTabIndex == 2)
                {
                    elementHost3.Child = null;
                }
                else if (NowTabIndex == 3)
                {
                    elementHost4.Child = null;
                }
                int Steps = (int)((2 * 4) / shift) + 1;
                double[,] pos = new double[Steps, Steps];
                for (int z = 0; z < Steps; z++)
                {
                    for (int x = 0; x < Steps; x++)
                    {
                        double xPos = -4 + x * shift;
                        double zPos = -4 + z * shift;
                        pos[z, x] = formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos);
                    }
                }
                elementHost5.Dock = DockStyle.Fill;
                uc = new WpfControlLibrary1.UserControl1(pos);
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
                elementHost5.Child = uc;
                uc.cam_theta = 0;
                uc.cam_phi = 0;
                uc.myPCamera.Position = new Point3D(0, 0, uc.cam_radius);
                uc.myPCamera.LookDirection = new Vector3D(0, 0, -uc.cam_radius);
                NowTabIndex = tabControl1.SelectedIndex;
            }
        }

        private void Morph_Click(object sender, EventArgs e)
        {
            timer1.Start();
            alpha = 1;
            Morph.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nextIndex = tabControl1.SelectedIndex + 1;
            if (nextIndex == formulaList.Count())
            {
                nextIndex = 0;
            }
            int Steps = (int)((2 * 4) / shift) + 1;
            double[,] pos = new double[Steps, Steps];
            for (int z = 0; z < Steps; z++)
            {
                for (int x = 0; x < Steps; x++)
                {
                    double xPos = -4 + x * shift;
                    double zPos = -4 + z * shift;
                    pos[z, x] = alpha * formulaList[tabControl1.SelectedIndex].Calc(xPos, zPos) + (1-alpha)* formulaList[nextIndex].Calc(xPos, zPos);
                }
            }
            uc = new WpfControlLibrary1.UserControl1(pos);
            if(tabControl1.SelectedIndex == 0)
            {
                elementHost1.Child = null;
                elementHost1.Child = uc;
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                elementHost2.Child = null;
                elementHost2.Child = uc;
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                elementHost3.Child = null;
                elementHost3.Child = uc;
            }
            else if(tabControl1.SelectedIndex == 3)
            {
                elementHost4.Child = null;
                elementHost4.Child = uc;
            }
            else if( tabControl1.SelectedIndex == 4)
            {
                elementHost5.Child = null;
                elementHost5.Child = uc;
            }
            uc.cam_theta = Math.PI / 4;
            uc.cam_phi = Math.PI / 4;
            double cam_x = uc.cam_radius * Math.Cos(uc.cam_phi) * Math.Sin(uc.cam_theta);
            double cam_y = uc.cam_radius * Math.Sin(uc.cam_phi);
            double cam_z = uc.cam_radius * Math.Cos(uc.cam_phi) * Math.Cos(uc.cam_theta);
            uc.myPCamera.Position = new Point3D(cam_x, cam_y, cam_z);
            uc.myPCamera.LookDirection = new Vector3D(-cam_x, -cam_y, -cam_z);
            alpha -= 0.05;
            if(alpha < 0)
            {
                timer1.Stop();
                Morph.Enabled = true;
                uc.MouseDown += Uc_MouseDown;
                uc.MouseMove += Uc_MouseMove;
                uc.MouseUp += Uc_MouseUp;
                uc.MouseWheel += Uc_MouseWheel;
            }
        }

        private void Combination_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2
            {
                Owner = this
            };
            f2.Show();
        }
    }
}
