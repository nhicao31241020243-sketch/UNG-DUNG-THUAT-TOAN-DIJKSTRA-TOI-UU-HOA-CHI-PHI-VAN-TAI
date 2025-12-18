using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Location> Locations = new List<Location>();
        SetUpGraph g = new SetUpGraph();
        private void Form1_Load(object creator, EventArgs e) //Goi ten cac dia diem va set vi tri
        {
            Location dongNai = new Location("Đồng Nai", "A", 560, 95);
            Location tpHCM = new Location("TP.Hồ Chí Minh", "B", 490, 150);
            Location tayNinh = new Location("Tây Ninh", "C", 420, 160);
            Location dongThap = new Location("Đồng Tháp", "D", 350, 220);
            Location vinhLong = new Location("Vĩnh Long", "E", 420, 280);
            Location anGiang = new Location("An Giang", "F", 250, 280);
            Location tpCanTho = new Location("TP.Cần Thơ", "G", 350, 290);
            Location caMau = new Location("Cà Mau", "H", 260, 350);

            Locations.Add(dongNai);
            Locations.Add(tpHCM);
            Locations.Add(tayNinh);
            Locations.Add(dongThap);
            Locations.Add(vinhLong);
            Locations.Add(anGiang);
            Locations.Add(tpCanTho);
            Locations.Add(caMau);

            cbSource.Items.Add("Đồng Nai");
            cbSource.Items.Add("TP.Hồ Chí Minh");
            cbSource.Items.Add("Tây Ninh");
            cbSource.Items.Add("Đồng Tháp");
            cbSource.Items.Add("Vĩnh Long");
            cbSource.Items.Add("An Giang");
            cbSource.Items.Add("TP.Cần Thơ");
            cbSource.Items.Add("Cà Mau");

            cbDestination.Items.Add("Đồng Nai");
            cbDestination.Items.Add("TP.Hồ Chí Minh");
            cbDestination.Items.Add("Tây Ninh");
            cbDestination.Items.Add("Đồng Tháp");
            cbDestination.Items.Add("Vĩnh Long");
            cbDestination.Items.Add("An Giang");
            cbDestination.Items.Add("TP.Cần Thơ");
            cbDestination.Items.Add("Cà Mau");

            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Locations.Count; i++)
            {
                lvListProvinces.Items.Add(Locations[i].getPointName());
                lvListProvinces.Items[i].SubItems.Add(Locations[i].getName());
                g.listPoint.Add(Locations[i].getPoint());
                g.InsertVertex(Locations[i].getName());
            }
            // ====== TP. HỒ CHÍ MINH (3 cạnh gần nhất) ======
            g.InsertEdge("TP.Hồ Chí Minh", "Đồng Nai", 40);
            g.InsertEdge("TP.Hồ Chí Minh", "Tây Ninh", 95);
            g.InsertEdge("TP.Hồ Chí Minh", "Vĩnh Long", 135);

            // ====== ĐỒNG NAI ======
            g.InsertEdge("Đồng Nai", "Tây Ninh", 180);
            g.InsertEdge("Đồng Nai", "Vĩnh Long", 190);
            g.InsertEdge("Đồng Nai", "Đồng Tháp", 220);
            g.InsertEdge("Đồng Nai", "TP.Cần Thơ", 230);

            // ====== TÂY NINH ======
            g.InsertEdge("Tây Ninh", "Đồng Tháp", 250);
            g.InsertEdge("Tây Ninh", "An Giang", 265);

            // ====== ĐỒNG THÁP ======
            g.InsertEdge("Đồng Tháp", "Vĩnh Long", 70);
            g.InsertEdge("Đồng Tháp", "An Giang", 100);
            g.InsertEdge("Đồng Tháp", "TP.Cần Thơ", 30);
            g.InsertEdge("Đồng Tháp", "Cà Mau", 210);

            // ====== VĨNH LONG ======
            g.InsertEdge("Vĩnh Long", "TP.Cần Thơ", 40);
            g.InsertEdge("Vĩnh Long", "An Giang", 180);

            // ====== AN GIANG ======
            g.InsertEdge("An Giang", "TP.Cần Thơ", 110);

            // ====== TP. CẦN THƠ ======
            g.InsertEdge("TP.Cần Thơ", "Cà Mau", 220);

        }
        //Vẽ bản đồ ra Panel
        private void southMap_Paint(object creator, PaintEventArgs e)
        {
            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Locations.Count; i++)
            {
                SolidBrush brush = new SolidBrush(Color.SeaGreen);
                Brush pointName = new SolidBrush(Color.White);
                graph.FillEllipse(brush, Locations[i].getPoint().X - 3, Locations[i].getPoint().Y - 2, 18, 18);
                graph.DrawString(Locations[i].getPointName(), new Font("Arial", 8), pointName, Locations[i].getPoint().X, Locations[i].getPoint().Y);
            }
            DrawLine();
        }

        private void DrawLine() // Noi cac tuyen duong co the di duoc va da tinh toan chi phi
        {
            // ====== TP. HỒ CHÍ MINH (3 đường) ======
            DrawLine("TP.Hồ Chí Minh", "Đồng Nai");
            DrawLine("TP.Hồ Chí Minh", "Tây Ninh");
            DrawLine("TP.Hồ Chí Minh", "Vĩnh Long");

            // ====== ĐỒNG NAI ======
            DrawLine("Đồng Nai", "Tây Ninh");
            DrawLine("Đồng Nai", "Vĩnh Long");
            DrawLine("Đồng Nai", "Đồng Tháp");
            DrawLine("Đồng Nai", "TP.Cần Thơ");

            // ====== TÂY NINH ======
            DrawLine("Tây Ninh", "Đồng Tháp");
            DrawLine("Tây Ninh", "An Giang");

            // ====== ĐỒNG THÁP ======
            DrawLine("Đồng Tháp", "Vĩnh Long");
            DrawLine("Đồng Tháp", "An Giang");
            DrawLine("Đồng Tháp", "TP.Cần Thơ");
            DrawLine("Đồng Tháp", "Cà Mau");

            // ====== VĨNH LONG ======
            DrawLine("Vĩnh Long", "TP.Cần Thơ");
            DrawLine("Vĩnh Long", "An Giang");

            // ====== AN GIANG ======
            DrawLine("An Giang", "TP.Cần Thơ");

            // ====== TP. CẦN THƠ ======
            DrawLine("TP.Cần Thơ", "Cà Mau");

        }
        private void DrawLine(string a, string b)
        {
            Graphics graph = southMap.CreateGraphics();
            int x = g.GetIndex(a);
            int y = g.GetIndex(b);
            Pen p = new Pen(Color.Black, 2);
            Point point1 = new Point(g.listPoint[x].X, g.listPoint[x].Y);
            Point point2 = new Point(g.listPoint[y].X, g.listPoint[y].Y);
            graph.DrawLine(p, point1, point2);
            graph.DrawString($"{g.adj[x, y]}", new Font("Fira Code", 10), Brushes.Black, new Point((point1.X + point2.X) / 2 - 8, (point1.Y + point2.Y) / 2 + 8));
        }
        private void cbSource_SelectedIndexChanged(object creator, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                southMap.Controls.Clear();
                southMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbKM.Clear();
                tbLiter.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.FindPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(),tbKM,tbLiter, tbCost, tbPath, tbTime);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
            if (cbSource.SelectedIndex == cbDestination.SelectedIndex)
            {
                MessageBox.Show("Unresponsive\n Starting point must not be the same as destination !", "Notify!");
            }
        }
        private void cbDestination_SelectedIndexChanged(object creator, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                southMap.Controls.Clear();
                southMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbKM.Clear();
                tbLiter.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.FindPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(),tbKM ,tbLiter, tbCost, tbPath, tbTime);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
            if (cbSource.SelectedIndex == cbDestination.SelectedIndex)
            {
                MessageBox.Show("Unresponsive\n Starting point must not be the same as destination !", "Notify!");
            }    
        }
        //Vẽ lại đường đi ngắn nhất
        private void DrawPathLine(int i)
        {
            Graphics graph = southMap.CreateGraphics();
            Pen p = new Pen(Color.Aqua, 2);
            Point point1 = new Point(g.pathIndex[i].X, g.pathIndex[i].Y);
            Point point2 = new Point(g.pathIndex[i + 1].X, g.pathIndex[i + 1].Y);
            graph.DrawLine(p, point1, point2);
        }

    }
}
