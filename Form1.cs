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
using System.Drawing.Drawing2D;
using System.Threading;

namespace OSMRoadExtract
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private int flag = 0;
        private OSMModel model;
        private bool flags = true;
        private int count = 0;
        private List<PathModel> pathGatherList = new List<PathModel>();
        private List<Pen> pens = new List<Pen>(new Pen[]
            { new Pen(Color.Red, 1)
            ,new Pen(Color.Green, 1)
            ,new Pen(Color.Black,1)
            ,new Pen(Color.Blue, 1)
            ,new Pen(Color.Gold,1)
            });
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 2000;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.label4, "选择绘制路网颜色绘制类型");
            
        }


        /// <summary>
        /// 绘图功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if(flag == 1)
            {
                var lineDictionary = LineCollect.Instance.LineGet(model , flags);
                var lineList = lineDictionary.ToList();
                int t = 0;
                pathGatherList.Clear();
                foreach (var lines in lineList)
                {
                    List<GraphicsPath> paths = new List<GraphicsPath>();
                    if (!lines.Equals(null))
                    {
                        GraphicsPath path = new GraphicsPath();
                        foreach(var line in lines.Value)
                        {
                            path.AddLines(line);
                            Pen nomolPen = new Pen(Color.Red, 1);
                            //string picfile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "star.JPG";
                            //Image image = Image.FromFile(picfile);
                            if (GlobalConstant.POINTFIRSTEND == true)
                            {
                                Pen pen = new Pen(Color.Black, 1);
                                g.DrawEllipse(pen, line[0].X - 2, line[0].Y - 2, 4, 4);
                                g.DrawEllipse(pen, line[line.Length - 1].X - 2, line[line.Length - 1].Y - 2, 4, 4);
                            }
                            //var points = getPointF(line[0]);
                            //g.DrawImage(image, line[0]);
                            ///test
                            //e.Graphics.DrawLines(pen, line.Value);
                            if(GlobalConstant.COLORFUL)
                                g.DrawPath(pens[t++%5], path);
                            else
                                g.DrawPath(nomolPen, path);
                            paths.Add(path);
                        }
                        PathModel pathModel = new PathModel(paths, lines.Key, lines.Value);
                        pathGatherList.Add(pathModel);
                    }
                }
                count++;
                flag = 0;
            }
            
        }

        private PointF[] getPointF(PointF point)
        {
            PointF[] points = new PointF[3];
            points[0] = new PointF(point.X - 10, point.Y - 10);
            points[0] = new PointF(point.X - 10, point.Y + 10);
            points[0] = new PointF(point.X + 10, point.Y - 10);
            return points;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /// <summary>
        /// 点击反馈坐标位置所在道路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int noName = 0;
            Point point = new Point(Cursor.Position.X-105, Cursor.Position.Y-55);
            Pen pen = new Pen(Color.Red, 20);
            foreach (var pathGather in pathGatherList)
            {
                foreach (var path in pathGather.path)
                {
                    if (path.IsOutlineVisible(point, pen))
                    {
                        var name = LineSearchProvider.Instance.GetLineName(model, pathGather.id);
                        if (name != "")
                        {
                            toolTip1.SetToolTip(this.panel1, $"该处为{name}");
                            return;
                        }
                        else
                            noName = 1;
                    }
                }
            }
            if (noName == 1)
                toolTip1.SetToolTip(this.panel1, "路网数据中没有该处的名称");
            else
               toolTip1.Show($"没找到正确道路哟~", this.panel1);

        }
        #region 修正数据选择Check
        /// <summary>
        /// 修正图层按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fixDraw_CheckedChanged(object sender, EventArgs e)
        {
            if(this.fixDraw.Checked == true)
            {
                this.unfixDraw.Checked = false;
                flags =true;
            }
            else
            {
                this.unfixDraw.Checked = true;
                flags = false;
            }
        }

        /// <summary>
        /// 未修正图层按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unfixDraw_CheckedChanged(object sender, EventArgs e)
        {
            if (this.unfixDraw.Checked == true)
            {
                this.fixDraw.Checked = false;
                flags = false;
            }
            else
            {
                this.fixDraw.Checked = true;
                flags = true;
            }
        }
        #endregion


        #region 按钮功能
        /// <summary>
        /// 打开文件按钮功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    List<OSMModel> models = transformXml.TransformXML(filePath);
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

        /// <summary>
        /// 重绘按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                MessageBox.Show("尚未选择绘图路径", "错误!!!");
                return;
            }
            flag = 1;
            this.Invalidate();
            this.Update();
            this.Refresh();
        }
        #endregion


        #region 地图详细显示设置
        /// <summary>
        /// 移除建筑物按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBuilding_CheckedChanged(object sender, EventArgs e)
        {
            if(this.removeBuilding.Checked == true)
            {
                CloseLevelCheck();
                GlobalConstant.REMOVEBUILDING = true;
                GlobalConstant.ONLYROADWAY = false;
                this.allRoad.Checked = false;
            }
            else
            {
                GlobalConstant.REMOVEBUILDING = false;
            }
        }

        /// <summary>
        /// 全部路网按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allRoad_CheckedChanged(object sender, EventArgs e)
        {
            if(this.allRoad.Checked == true)
            {
                CloseLevelCheck();
                this.removeBuilding.Checked = false;
                GlobalConstant.REMOVEBUILDING = false;
                GlobalConstant.ONLYROADWAY = true;
            }
            else
            {
                GlobalConstant.ONLYROADWAY = false;
            }
        }
        #endregion


        #region 细分道路选择Check
        /// <summary>
        /// 主干路按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void primaryWay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.primaryWay.Checked == true)
            {
                CloseRoadBuildingCheck();
                GlobalConstant.PRIMARYWAY = true;
            }
            else
            {
                GlobalConstant.PRIMARYWAY = false;
            }    
        }

        /// <summary>
        /// 次要道路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondaryWay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.secondaryWay.Checked == true)
            {
                CloseRoadBuildingCheck();
                GlobalConstant.SECONDARYWAY = true;
            }
            else
            {
                GlobalConstant.SECONDARYWAY = false;
            }
        }

        /// <summary>
        /// 城市支路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tertiaryWay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tertiaryWay.Checked == true)
            {
                CloseRoadBuildingCheck();
                GlobalConstant.TERTIARYWAY = true;
            }
            else
            {
                GlobalConstant.TERTIARYWAY = false;
            }
        }
        /// <summary>
        /// 居住区道路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void residentialWay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.residentialWay.Checked == true)
            {
                CloseRoadBuildingCheck();
                GlobalConstant.RESIDENTIALWAY = true;
            }
            else
            {
                GlobalConstant.RESIDENTIALWAY = false;
            }
        }
        /// <summary>
        /// 其他道路
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otherWay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.otherWay.Checked == true)
            {
                CloseRoadBuildingCheck();
                GlobalConstant.OTHERWAY = true;
            }
            else
            {
                GlobalConstant.OTHERWAY = false;
            }
        }
        #endregion


        #region check联动变化
        /// <summary>
        /// 关闭建筑物与全部路网
        /// </summary>
        private void CloseRoadBuildingCheck()
        {
            this.allRoad.Checked = false;
            this.removeBuilding.Checked = false;
            GlobalConstant.REMOVEBUILDING = false;
            GlobalConstant.ONLYROADWAY = false;
            MustCheck();
        }
        /// <summary>
        /// 关闭分层
        /// </summary>
        private void CloseLevelCheck()
        {
            GlobalConstant.PRIMARYWAY = false;
            this.primaryWay.Checked = false;
            GlobalConstant.SECONDARYWAY = false;
            this.secondaryWay.Checked = false;
            GlobalConstant.TERTIARYWAY = false;
            this.tertiaryWay.Checked = false;
            GlobalConstant.RESIDENTIALWAY = false;
            this.residentialWay.Checked = false;
            GlobalConstant.OTHERWAY = false;
            this.otherWay.Checked = false;
            MustCheck();
        }
        /// <summary>
        /// 校验画线与点迹
        /// </summary>
        private void MustCheck()
        {
            if(this.pointLocation.Checked == true || this.colorChange.Checked == true)
            {
                if(this.primaryWay.Checked == false&& this.secondaryWay.Checked == false && this.tertiaryWay.Checked == false && this.residentialWay.Checked == false && this.otherWay.Checked == false)
                {
                    MessageBox.Show("尚未选择详细划分路网（如主干道路等）", "错误!!!");
                    this.pointLocation.Checked = false;
                    GlobalConstant.COLORFUL = false;
                    this.colorChange.Checked = false;
                    GlobalConstant.POINTFIRSTEND = false;
                }
            }
        }
        #endregion

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.SetToolTip(this.panel1, $"{Cursor.Position.X.ToString()}+{Cursor.Position.Y.ToString()}");
            //toolTip1.Show($"{Cursor.Position.X.ToString()}+{Cursor.Position.Y.ToString()}", this.panel1);
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void tooltip(object sender, EventArgs e)
        {

        }

        private void colorChange_CheckedChanged(object sender, EventArgs e)
        {
            MustCheck();
            if(this.colorChange.Checked == true)
            {
                GlobalConstant.COLORFUL = true;
            }
            else
            {
                GlobalConstant.COLORFUL = false;
            }
        }

        private void pointLocation_CheckedChanged(object sender, EventArgs e)
        {
            MustCheck();
            if(this.pointLocation.Checked == true)
            {
                GlobalConstant.POINTFIRSTEND=true;
            }
            else
            {
                GlobalConstant.POINTFIRSTEND = false;
            }
        }
    }
}
