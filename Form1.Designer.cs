
namespace OSMRoadExtract
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fixDraw = new System.Windows.Forms.CheckBox();
            this.unfixDraw = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.allRoad = new System.Windows.Forms.CheckBox();
            this.removeBuilding = new System.Windows.Forms.CheckBox();
            this.primaryWay = new System.Windows.Forms.CheckBox();
            this.secondaryWay = new System.Windows.Forms.CheckBox();
            this.tertiaryWay = new System.Windows.Forms.CheckBox();
            this.residentialWay = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.otherWay = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(100, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1905, 1008);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 852);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // fixDraw
            // 
            this.fixDraw.AutoSize = true;
            this.fixDraw.Checked = true;
            this.fixDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fixDraw.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.fixDraw.FlatAppearance.BorderSize = 0;
            this.fixDraw.Location = new System.Drawing.Point(1, 75);
            this.fixDraw.Name = "fixDraw";
            this.fixDraw.Size = new System.Drawing.Size(89, 19);
            this.fixDraw.TabIndex = 2;
            this.fixDraw.Text = "修正图层";
            this.fixDraw.UseVisualStyleBackColor = true;
            this.fixDraw.CheckedChanged += new System.EventHandler(this.fixDraw_CheckedChanged);
            // 
            // unfixDraw
            // 
            this.unfixDraw.AutoSize = true;
            this.unfixDraw.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.unfixDraw.FlatAppearance.BorderSize = 0;
            this.unfixDraw.Location = new System.Drawing.Point(1, 100);
            this.unfixDraw.Name = "unfixDraw";
            this.unfixDraw.Size = new System.Drawing.Size(104, 19);
            this.unfixDraw.TabIndex = 3;
            this.unfixDraw.Text = "未修正图层";
            this.unfixDraw.UseVisualStyleBackColor = true;
            this.unfixDraw.CheckedChanged += new System.EventHandler(this.unfixDraw_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 649);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "重绘";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // allRoad
            // 
            this.allRoad.AutoSize = true;
            this.allRoad.Location = new System.Drawing.Point(1, 150);
            this.allRoad.Name = "allRoad";
            this.allRoad.Size = new System.Drawing.Size(89, 19);
            this.allRoad.TabIndex = 5;
            this.allRoad.Text = "所有路网";
            this.allRoad.UseVisualStyleBackColor = true;
            this.allRoad.CheckedChanged += new System.EventHandler(this.allRoad_CheckedChanged);
            // 
            // removeBuilding
            // 
            this.removeBuilding.AutoSize = true;
            this.removeBuilding.Location = new System.Drawing.Point(1, 175);
            this.removeBuilding.Name = "removeBuilding";
            this.removeBuilding.Size = new System.Drawing.Size(104, 19);
            this.removeBuilding.TabIndex = 0;
            this.removeBuilding.Text = "过滤建筑物";
            this.removeBuilding.UseVisualStyleBackColor = true;
            this.removeBuilding.CheckedChanged += new System.EventHandler(this.removeBuilding_CheckedChanged);
            // 
            // primaryWay
            // 
            this.primaryWay.AutoSize = true;
            this.primaryWay.Location = new System.Drawing.Point(1, 225);
            this.primaryWay.Name = "primaryWay";
            this.primaryWay.Size = new System.Drawing.Size(89, 19);
            this.primaryWay.TabIndex = 6;
            this.primaryWay.Text = "主干道路";
            this.primaryWay.UseVisualStyleBackColor = true;
            this.primaryWay.CheckedChanged += new System.EventHandler(this.primaryWay_CheckedChanged);
            // 
            // secondaryWay
            // 
            this.secondaryWay.AutoSize = true;
            this.secondaryWay.Location = new System.Drawing.Point(1, 250);
            this.secondaryWay.Name = "secondaryWay";
            this.secondaryWay.Size = new System.Drawing.Size(89, 19);
            this.secondaryWay.TabIndex = 7;
            this.secondaryWay.Text = "次要道路";
            this.secondaryWay.UseVisualStyleBackColor = false;
            this.secondaryWay.CheckedChanged += new System.EventHandler(this.secondaryWay_CheckedChanged);
            // 
            // tertiaryWay
            // 
            this.tertiaryWay.AutoSize = true;
            this.tertiaryWay.Location = new System.Drawing.Point(1, 275);
            this.tertiaryWay.Name = "tertiaryWay";
            this.tertiaryWay.Size = new System.Drawing.Size(89, 19);
            this.tertiaryWay.TabIndex = 8;
            this.tertiaryWay.Text = "城市支路";
            this.tertiaryWay.UseVisualStyleBackColor = true;
            this.tertiaryWay.CheckedChanged += new System.EventHandler(this.tertiaryWay_CheckedChanged);
            // 
            // residentialWay
            // 
            this.residentialWay.AutoSize = true;
            this.residentialWay.Location = new System.Drawing.Point(1, 300);
            this.residentialWay.Name = "residentialWay";
            this.residentialWay.Size = new System.Drawing.Size(104, 19);
            this.residentialWay.TabIndex = 9;
            this.residentialWay.Text = "居住区道路";
            this.residentialWay.UseVisualStyleBackColor = true;
            this.residentialWay.CheckedChanged += new System.EventHandler(this.residentialWay_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "细分路网类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "数据修正图层";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "地图展示类型";
            // 
            // otherWay
            // 
            this.otherWay.AutoSize = true;
            this.otherWay.Location = new System.Drawing.Point(1, 325);
            this.otherWay.Name = "otherWay";
            this.otherWay.Size = new System.Drawing.Size(89, 19);
            this.otherWay.TabIndex = 13;
            this.otherWay.Text = "其他道路";
            this.otherWay.UseVisualStyleBackColor = true;
            this.otherWay.CheckedChanged += new System.EventHandler(this.otherWay_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "颜色划分";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            this.label4.MouseHover += new System.EventHandler(this.tooltip);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2004, 1000);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.otherWay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.residentialWay);
            this.Controls.Add(this.tertiaryWay);
            this.Controls.Add(this.secondaryWay);
            this.Controls.Add(this.primaryWay);
            this.Controls.Add(this.removeBuilding);
            this.Controls.Add(this.allRoad);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.unfixDraw);
            this.Controls.Add(this.fixDraw);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "路网构建系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox fixDraw;
        private System.Windows.Forms.CheckBox unfixDraw;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox allRoad;
        private System.Windows.Forms.CheckBox removeBuilding;
        private System.Windows.Forms.CheckBox primaryWay;
        private System.Windows.Forms.CheckBox secondaryWay;
        private System.Windows.Forms.CheckBox tertiaryWay;
        private System.Windows.Forms.CheckBox residentialWay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox otherWay;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

