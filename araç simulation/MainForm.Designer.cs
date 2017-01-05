/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Mert
 * Tarih: 02.02.2015
 * Zaman: 15:36
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
namespace araç_simulation
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.chartBirinciDerece = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.progressBar3 = new System.Windows.Forms.ProgressBar();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.label12 = new System.Windows.Forms.Label();
			this.aquaGauge1 = new AquaControls.AquaGauge();
			this.aquaGauge2 = new AquaControls.AquaGauge();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.araçlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.yolTipiToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
			this.simulasyonToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
			this.haritaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chartBirinciDerece)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// chartBirinciDerece
			// 
			this.chartBirinciDerece.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			chartArea1.Name = "ChartArea1";
			this.chartBirinciDerece.ChartAreas.Add(chartArea1);
			this.chartBirinciDerece.IsSoftShadows = false;
			legend1.Name = "Legend1";
			this.chartBirinciDerece.Legends.Add(legend1);
			resources.ApplyResources(this.chartBirinciDerece, "chartBirinciDerece");
			this.chartBirinciDerece.Name = "chartBirinciDerece";
			this.chartBirinciDerece.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			series1.BorderWidth = 3;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Color = System.Drawing.Color.Black;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series1.YValuesPerPoint = 2;
			this.chartBirinciDerece.Series.Add(series1);
			this.chartBirinciDerece.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.button3, "button3");
			this.button3.Name = "button3";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label21
			// 
			resources.ApplyResources(this.label21, "label21");
			this.label21.Name = "label21";
			// 
			// label22
			// 
			resources.ApplyResources(this.label22, "label22");
			this.label22.Name = "label22";
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.button4, "button4");
			this.button4.Name = "button4";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// label24
			// 
			resources.ApplyResources(this.label24, "label24");
			this.label24.Name = "label24";
			// 
			// progressBar3
			// 
			this.progressBar3.ForeColor = System.Drawing.Color.Red;
			resources.ApplyResources(this.progressBar3, "progressBar3");
			this.progressBar3.MarqueeAnimationSpeed = 0;
			this.progressBar3.Name = "progressBar3";
			this.progressBar3.Step = 1;
			// 
			// progressBar2
			// 
			this.progressBar2.ForeColor = System.Drawing.Color.GreenYellow;
			resources.ApplyResources(this.progressBar2, "progressBar2");
			this.progressBar2.MarqueeAnimationSpeed = 0;
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Step = 1;
			this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.Gold;
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// aquaGauge1
			// 
			this.aquaGauge1.BackColor = System.Drawing.Color.Transparent;
			this.aquaGauge1.DialColor = System.Drawing.Color.Lavender;
			this.aquaGauge1.DialText = "";
			resources.ApplyResources(this.aquaGauge1, "aquaGauge1");
			this.aquaGauge1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.aquaGauge1.Glossiness = 11.36364F;
			this.aquaGauge1.MaxValue = 360F;
			this.aquaGauge1.MinValue = 0F;
			this.aquaGauge1.Name = "aquaGauge1";
			this.aquaGauge1.NoOfDivisions = 8;
			this.aquaGauge1.NoOfSubDivisions = 5;
			this.aquaGauge1.RecommendedValue = 0F;
			this.aquaGauge1.ThresholdPercent = 0F;
			this.aquaGauge1.Value = 0F;
			// 
			// aquaGauge2
			// 
			resources.ApplyResources(this.aquaGauge2, "aquaGauge2");
			this.aquaGauge2.BackColor = System.Drawing.Color.Transparent;
			this.aquaGauge2.DialColor = System.Drawing.Color.Lavender;
			this.aquaGauge2.DialText = "";
			this.aquaGauge2.Glossiness = 11.36364F;
			this.aquaGauge2.MaxValue = 1F;
			this.aquaGauge2.MinValue = 0F;
			this.aquaGauge2.Name = "aquaGauge2";
			this.aquaGauge2.NoOfSubDivisions = 5;
			this.aquaGauge2.RecommendedValue = 0F;
			this.aquaGauge2.ThresholdPercent = 0F;
			this.aquaGauge2.Value = 0F;
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Chartreuse;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.Red;
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// label16
			// 
			resources.ApplyResources(this.label16, "label16");
			this.label16.Name = "label16";
			// 
			// label20
			// 
			resources.ApplyResources(this.label20, "label20");
			this.label20.Name = "label20";
			// 
			// pictureBox1
			// 
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.araçlarToolStripMenuItem,
									this.yolTipiToolStripMenuItem,
									this.simulasyonToolStripMenuItem,
									this.haritaToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// araçlarToolStripMenuItem
			// 
			this.araçlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripComboBox1});
			resources.ApplyResources(this.araçlarToolStripMenuItem, "araçlarToolStripMenuItem");
			this.araçlarToolStripMenuItem.Name = "araçlarToolStripMenuItem";
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			resources.ApplyResources(this.toolStripComboBox1, "toolStripComboBox1");
			this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBox1SelectedIndexChanged);
			// 
			// yolTipiToolStripMenuItem
			// 
			this.yolTipiToolStripMenuItem.AutoCompleteCustomSource.AddRange(new string[] {
									resources.GetString("yolTipiToolStripMenuItem.AutoCompleteCustomSource"),
									resources.GetString("yolTipiToolStripMenuItem.AutoCompleteCustomSource1"),
									resources.GetString("yolTipiToolStripMenuItem.AutoCompleteCustomSource2"),
									resources.GetString("yolTipiToolStripMenuItem.AutoCompleteCustomSource3")});
			this.yolTipiToolStripMenuItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.yolTipiToolStripMenuItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.yolTipiToolStripMenuItem.DropDownWidth = 100;
			resources.ApplyResources(this.yolTipiToolStripMenuItem, "yolTipiToolStripMenuItem");
			this.yolTipiToolStripMenuItem.Items.AddRange(new object[] {
									resources.GetString("yolTipiToolStripMenuItem.Items"),
									resources.GetString("yolTipiToolStripMenuItem.Items1"),
									resources.GetString("yolTipiToolStripMenuItem.Items2"),
									resources.GetString("yolTipiToolStripMenuItem.Items3")});
			this.yolTipiToolStripMenuItem.Name = "yolTipiToolStripMenuItem";
			this.yolTipiToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.YolTipiToolStripMenuItemSelectedIndexChanged);
			// 
			// simulasyonToolStripMenuItem
			// 
			this.simulasyonToolStripMenuItem.AutoCompleteCustomSource.AddRange(new string[] {
									resources.GetString("simulasyonToolStripMenuItem.AutoCompleteCustomSource"),
									resources.GetString("simulasyonToolStripMenuItem.AutoCompleteCustomSource1"),
									resources.GetString("simulasyonToolStripMenuItem.AutoCompleteCustomSource2"),
									resources.GetString("simulasyonToolStripMenuItem.AutoCompleteCustomSource3"),
									resources.GetString("simulasyonToolStripMenuItem.AutoCompleteCustomSource4")});
			this.simulasyonToolStripMenuItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.simulasyonToolStripMenuItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.simulasyonToolStripMenuItem.DropDownWidth = 100;
			resources.ApplyResources(this.simulasyonToolStripMenuItem, "simulasyonToolStripMenuItem");
			this.simulasyonToolStripMenuItem.Items.AddRange(new object[] {
									resources.GetString("simulasyonToolStripMenuItem.Items"),
									resources.GetString("simulasyonToolStripMenuItem.Items1"),
									resources.GetString("simulasyonToolStripMenuItem.Items2"),
									resources.GetString("simulasyonToolStripMenuItem.Items3"),
									resources.GetString("simulasyonToolStripMenuItem.Items4")});
			this.simulasyonToolStripMenuItem.Name = "simulasyonToolStripMenuItem";
			this.simulasyonToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.SimulasyonToolStripMenuItemSelectedIndexChanged);
			// 
			// haritaToolStripMenuItem
			// 
			this.haritaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripComboBox2});
			resources.ApplyResources(this.haritaToolStripMenuItem, "haritaToolStripMenuItem");
			this.haritaToolStripMenuItem.Name = "haritaToolStripMenuItem";
			// 
			// toolStripComboBox2
			// 
			this.toolStripComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.toolStripComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.toolStripComboBox2.Name = "toolStripComboBox2";
			resources.ApplyResources(this.toolStripComboBox2, "toolStripComboBox2");
			this.toolStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBox2SelectedIndexChanged);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// textBox1
			// 
			resources.ApplyResources(this.textBox1, "textBox1");
			this.textBox1.Name = "textBox1";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.aquaGauge2);
			this.Controls.Add(this.aquaGauge1);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.progressBar3);
			this.Controls.Add(this.progressBar2);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.chartBirinciDerece);
			this.Controls.Add(this.menuStrip1);
			this.HelpButton = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseClick);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
			((System.ComponentModel.ISupportInitialize)(this.chartBirinciDerece)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripComboBox yolTipiToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox simulasyonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem haritaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem araçlarToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private AquaControls.AquaGauge aquaGauge2;
		private AquaControls.AquaGauge aquaGauge1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ProgressBar progressBar3;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartBirinciDerece;
		private System.Windows.Forms.Label label3;
		
		
		

		
		
		


		

		
	}
}
