namespace KURS
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOpenKompas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkDefault = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BodyHeight = new System.Windows.Forms.TextBox();
            this.BodyWidth = new System.Windows.Forms.TextBox();
            this.BodyDepth = new System.Windows.Forms.TextBox();
            this.AngleRadius = new System.Windows.Forms.TextBox();
            this.BodyColor = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMetres = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BackRadius = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MBType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MainButtonWidth = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MainButtonHeight = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.CameraSideSize = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.LockButtonWidth = new System.Windows.Forms.TextBox();
            this.LockButtonHeight = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.VolumeButtonWidth = new System.Windows.Forms.TextBox();
            this.VolumeButtonHeight = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.DynamicsWidth = new System.Windows.Forms.TextBox();
            this.DynamicsHeight = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOpenKompas
            // 
            resources.ApplyResources(this.buttonOpenKompas, "buttonOpenKompas");
            this.buttonOpenKompas.Name = "buttonOpenKompas";
            this.buttonOpenKompas.UseVisualStyleBackColor = true;
            this.buttonOpenKompas.Click += new System.EventHandler(this.buttonOpenKompas_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkDefault);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox8);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // linkDefault
            // 
            resources.ApplyResources(this.linkDefault, "linkDefault");
            this.linkDefault.Name = "linkDefault";
            this.linkDefault.TabStop = true;
            this.linkDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDefault_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BodyHeight);
            this.groupBox2.Controls.Add(this.BodyWidth);
            this.groupBox2.Controls.Add(this.BodyDepth);
            this.groupBox2.Controls.Add(this.AngleRadius);
            this.groupBox2.Controls.Add(this.BodyColor);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelMetres);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // BodyHeight
            // 
            resources.ApplyResources(this.BodyHeight, "BodyHeight");
            this.BodyHeight.Name = "BodyHeight";
            this.BodyHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BodyHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // BodyWidth
            // 
            this.BodyWidth.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.BodyWidth, "BodyWidth");
            this.BodyWidth.Name = "BodyWidth";
            this.BodyWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BodyWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // BodyDepth
            // 
            resources.ApplyResources(this.BodyDepth, "BodyDepth");
            this.BodyDepth.Name = "BodyDepth";
            this.BodyDepth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BodyDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // AngleRadius
            // 
            resources.ApplyResources(this.AngleRadius, "AngleRadius");
            this.AngleRadius.Name = "AngleRadius";
            this.AngleRadius.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.AngleRadius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // BodyColor
            // 
            this.BodyColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BodyColor.FormattingEnabled = true;
            resources.ApplyResources(this.BodyColor, "BodyColor");
            this.BodyColor.Name = "BodyColor";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // labelMetres
            // 
            resources.ApplyResources(this.labelMetres, "labelMetres");
            this.labelMetres.Name = "labelMetres";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.BackRadius);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // BackRadius
            // 
            resources.ApplyResources(this.BackRadius, "BackRadius");
            this.BackRadius.Name = "BackRadius";
            this.BackRadius.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BackRadius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MBType);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.MainButtonWidth);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.MainButtonHeight);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // MBType
            // 
            this.MBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MBType.FormattingEnabled = true;
            resources.ApplyResources(this.MBType, "MBType");
            this.MBType.Items.AddRange(new object[] {
            resources.GetString("MBType.Items"),
            resources.GetString("MBType.Items1")});
            this.MBType.Name = "MBType";
            this.MBType.SelectedIndexChanged += new System.EventHandler(this.MBType_TextChanged);
            this.MBType.TextChanged += new System.EventHandler(this.MBType_TextChanged);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // MainButtonWidth
            // 
            resources.ApplyResources(this.MainButtonWidth, "MainButtonWidth");
            this.MainButtonWidth.Name = "MainButtonWidth";
            this.MainButtonWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.MainButtonWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // MainButtonHeight
            // 
            resources.ApplyResources(this.MainButtonHeight, "MainButtonHeight");
            this.MainButtonHeight.Name = "MainButtonHeight";
            this.MainButtonHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.MainButtonHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CType);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.CameraSideSize);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label17);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // CType
            // 
            this.CType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CType.FormattingEnabled = true;
            this.CType.Items.AddRange(new object[] {
            resources.GetString("CType.Items"),
            resources.GetString("CType.Items1")});
            resources.ApplyResources(this.CType, "CType");
            this.CType.Name = "CType";
            this.CType.SelectedIndexChanged += new System.EventHandler(this.CType_SelectedIndexChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // CameraSideSize
            // 
            resources.ApplyResources(this.CameraSideSize, "CameraSideSize");
            this.CameraSideSize.Name = "CameraSideSize";
            this.CameraSideSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.CameraSideSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.LockButtonWidth);
            this.groupBox6.Controls.Add(this.LockButtonHeight);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label21);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // LockButtonWidth
            // 
            resources.ApplyResources(this.LockButtonWidth, "LockButtonWidth");
            this.LockButtonWidth.Name = "LockButtonWidth";
            this.LockButtonWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.LockButtonWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // LockButtonHeight
            // 
            resources.ApplyResources(this.LockButtonHeight, "LockButtonHeight");
            this.LockButtonHeight.Name = "LockButtonHeight";
            this.LockButtonHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.LockButtonHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.VolumeButtonWidth);
            this.groupBox7.Controls.Add(this.VolumeButtonHeight);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label26);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // VolumeButtonWidth
            // 
            resources.ApplyResources(this.VolumeButtonWidth, "VolumeButtonWidth");
            this.VolumeButtonWidth.Name = "VolumeButtonWidth";
            this.VolumeButtonWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.VolumeButtonWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // VolumeButtonHeight
            // 
            resources.ApplyResources(this.VolumeButtonHeight, "VolumeButtonHeight");
            this.VolumeButtonHeight.Name = "VolumeButtonHeight";
            this.VolumeButtonHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.VolumeButtonHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.DynamicsWidth);
            this.groupBox8.Controls.Add(this.DynamicsHeight);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.label30);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // DynamicsWidth
            // 
            resources.ApplyResources(this.DynamicsWidth, "DynamicsWidth");
            this.DynamicsWidth.Name = "DynamicsWidth";
            this.DynamicsWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.DynamicsWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // DynamicsHeight
            // 
            resources.ApplyResources(this.DynamicsHeight, "DynamicsHeight");
            this.DynamicsHeight.Name = "DynamicsHeight";
            this.DynamicsHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.DynamicsHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // buttonBuild
            // 
            resources.ApplyResources(this.buttonBuild, "buttonBuild");
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KURS.Properties.Resources.USB;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenKompas);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOpenKompas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox BackRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AngleRadius;
        private System.Windows.Forms.TextBox BodyDepth;
        private System.Windows.Forms.TextBox BodyHeight;
        private System.Windows.Forms.TextBox BodyWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox DynamicsWidth;
        private System.Windows.Forms.TextBox DynamicsHeight;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox VolumeButtonWidth;
        private System.Windows.Forms.TextBox VolumeButtonHeight;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox LockButtonWidth;
        private System.Windows.Forms.TextBox LockButtonHeight;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox CType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox CameraSideSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox MBType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox MainButtonWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox MainButtonHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMetres;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkDefault;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox BodyColor;
    }
}

