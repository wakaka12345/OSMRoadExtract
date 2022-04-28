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
        public Graphics g;
        public int flag = 0;
        public OSMModel model;
        public bool flags = true;
        public int count = 0;
        List<GraphicsPath> paths = new List<GraphicsPath>();
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
            if(flag == 1)
            {
                var lineDictionary = LineCollect.Instance.LineGet(model , flags);
                var lineList = lineDictionary.ToList();
                paths.Clear();
                foreach (var lines in lineList)
                {
                    if (!lines.Equals(null))
                    {
                        GraphicsPath path = new GraphicsPath();
                        foreach(var line in lines.Value)
                        {
                            path.AddLines(line);
                            Pen pen = new Pen(Color.Red , 1);
                            ///test
                            
                            //e.Graphics.DrawLines(pen, line.Value);
                            g.DrawPath(pen, path);
                            paths.Add(path);
                        }
                    }
                }
                count++;
                flag = 0;
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /// <summary>
        /// 点击反馈坐标位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Point point = new Point(Cursor.Position.X-105, Cursor.Position.Y-55);
            Pen pen = new Pen(Color.Red, 20);
            foreach (var path in paths)
            {
                if (path.IsOutlineVisible(point, pen))
                {
                    toolTip1.Show($"{Cursor.Position.X.ToString()}+{Cursor.Position.Y.ToString()}", this.panel1);
                    return;
                }
            }
            toolTip1.Show($"没找到{Cursor.Position.X.ToString()}+{Cursor.Position.Y.ToString()}", this.panel1);

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
    }
}
