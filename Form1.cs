using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSMRoadExtract.XMLtransform;
using OSMRoadExtract.Model;
using OSMRoadExtract.Provider;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OSMRoadExtract
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public int flag = 0;
        public OSMModel model;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定义一个文件打开控件
            OpenFileDialog ofd = new OpenFileDialog();
            //设置打开对话框的初始目录，默认目录为exe运行文件所在的路径
            ofd.InitialDirectory = Application.StartupPath;
            //设置打开对话框的标题
            ofd.Title = "请选择要打开的文件";
            //设置打开对话框可以多选
            ofd.Multiselect = true;
            //设置对话框打开的文件类型
            ofd.Filter = "地图信息|*.osm";
            //设置文件对话框当前选定的筛选器的索引
            ofd.FilterIndex = 2;
            //设置对话框是否记忆之前打开的目录
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                //获取用户选择的文件完整路径
                string filePath = ofd.FileName;
                Console.WriteLine(filePath);
                //获取对话框中所选文件的文件名和扩展名，文件名不包括路径
                string fileName = ofd.SafeFileName;
                if (!string.IsNullOrEmpty(filePath))
                {
                    CoreTransform transformXml = new CoreTransform();
                    Console.WriteLine(filePath);
                    List<OSMModel>models = transformXml.TransformXML(filePath);
                    if (models.Count() > 0)
                    {
                        Console.WriteLine("!!!!");
                        model = models[0];
                        flag = 1;
                        this.Invalidate();
                        this.Update();
                        this.Refresh();
                    }
                    
                }
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = panel1.CreateGraphics();
            Console.WriteLine("Start");
            if(flag == 1)
            {
                var lineDictionary = LineCollect.Instance.LineGet(model);
                var lineList = lineDictionary.ToList();
                foreach (var lines in lineList)
                {
                    if (!lines.Equals(null))
                    {
                        Console.WriteLine("ADD");
                        GraphicsPath path = new GraphicsPath();
                        foreach(var line in lines.Value)
                        {
                            path.AddLines(line);
                            Pen pen = new Pen(Color.Red, 3);
                            //e.Graphics.DrawLines(pen, line.Value);
                            e.Graphics.DrawPath(pen, path);
                        }
                    } 
                }
                flag = 0;
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine(Cursor.Position.X.ToString()+Cursor.Position.Y.ToString());
            
        }
    }
}
