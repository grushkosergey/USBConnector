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
            this._buttonExit = new System.Windows.Forms.Button();
            this._buttonOpenKompas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._buttonBuild = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkDefault = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TypeUSB = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BodyColor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.CorpusDepth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CorpusWidth = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CorpusHeight = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NumberOfPins = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.WireLength = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMetres = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BodyHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BodyDepth = new System.Windows.Forms.TextBox();
            this.BodyWidth = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonExit
            // 
            resources.ApplyResources(this._buttonExit, "_buttonExit");
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // _buttonOpenKompas
            // 
            resources.ApplyResources(this._buttonOpenKompas, "_buttonOpenKompas");
            this._buttonOpenKompas.Name = "_buttonOpenKompas";
            this._buttonOpenKompas.UseVisualStyleBackColor = true;
            this._buttonOpenKompas.Click += new System.EventHandler(this.buttonOpenKompas_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._buttonBuild);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.linkDefault);
            this.groupBox1.Controls.Add(this._buttonExit);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this._buttonOpenKompas);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _buttonBuild
            // 
            resources.ApplyResources(this._buttonBuild, "_buttonBuild");
            this._buttonBuild.Name = "_buttonBuild";
            this._buttonBuild.UseVisualStyleBackColor = true;
            this._buttonBuild.Click += new System.EventHandler(this._buttonBuild_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KURS.Properties.Resources.USB;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // linkDefault
            // 
            resources.ApplyResources(this.linkDefault, "linkDefault");
            this.linkDefault.Name = "linkDefault";
            this.linkDefault.TabStop = true;
            this.linkDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDefault_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TypeUSB);
            this.groupBox5.Controls.Add(this.label18);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // TypeUSB
            // 
            this.TypeUSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeUSB.FormattingEnabled = true;
            resources.ApplyResources(this.TypeUSB, "TypeUSB");
            this.TypeUSB.Name = "TypeUSB";
            this.TypeUSB.SelectedIndexChanged += new System.EventHandler(this.TypeUSB_SelectedIndexChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BodyColor);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.CorpusDepth);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.CorpusWidth);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.CorpusHeight);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // BodyColor
            // 
            this.BodyColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BodyColor.FormattingEnabled = true;
            resources.ApplyResources(this.BodyColor, "BodyColor");
            this.BodyColor.Name = "BodyColor";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // CorpusDepth
            // 
            resources.ApplyResources(this.CorpusDepth, "CorpusDepth");
            this.CorpusDepth.Name = "CorpusDepth";
            this.CorpusDepth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.CorpusDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // CorpusWidth
            // 
            resources.ApplyResources(this.CorpusWidth, "CorpusWidth");
            this.CorpusWidth.Name = "CorpusWidth";
            this.CorpusWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.CorpusWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
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
            // CorpusHeight
            // 
            resources.ApplyResources(this.CorpusHeight, "CorpusHeight");
            this.CorpusHeight.Name = "CorpusHeight";
            this.CorpusHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.CorpusHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NumberOfPins);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.WireLength);
            this.groupBox3.Controls.Add(this.label28);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // NumberOfPins
            // 
            resources.ApplyResources(this.NumberOfPins, "NumberOfPins");
            this.NumberOfPins.Name = "NumberOfPins";
            this.NumberOfPins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.NumberOfPins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Pins);
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
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // WireLength
            // 
            resources.ApplyResources(this.WireLength, "WireLength");
            this.WireLength.Name = "WireLength";
            this.WireLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.WireLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelMetres);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BodyHeight);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BodyDepth);
            this.groupBox2.Controls.Add(this.BodyWidth);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
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
            // BodyHeight
            // 
            resources.ApplyResources(this.BodyHeight, "BodyHeight");
            this.BodyHeight.Name = "BodyHeight";
            this.BodyHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BodyHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BodyDepth
            // 
            resources.ApplyResources(this.BodyDepth, "BodyDepth");
            this.BodyDepth.Name = "BodyDepth";
            this.BodyDepth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BodyDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // BodyWidth
            // 
            this.BodyWidth.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.BodyWidth, "BodyWidth");
            this.BodyWidth.Name = "BodyWidth";
            this.BodyWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.BodyWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Size = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonExit;
        private System.Windows.Forms.Button _buttonOpenKompas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox WireLength;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BodyDepth;
        private System.Windows.Forms.TextBox BodyHeight;
        private System.Windows.Forms.TextBox BodyWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox CorpusDepth;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox TypeUSB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CorpusWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox CorpusHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMetres;
        private System.Windows.Forms.Button _buttonBuild;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkDefault;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BodyColor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox NumberOfPins;
    }
}

