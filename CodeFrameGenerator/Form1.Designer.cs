namespace CodeFrameGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Question = new System.Windows.Forms.TextBox();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_Functions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_GenerateVariablesForScanf = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Question
            // 
            this.textBox_Question.Location = new System.Drawing.Point(12, 65);
            this.textBox_Question.MaxLength = 327670;
            this.textBox_Question.Multiline = true;
            this.textBox_Question.Name = "textBox_Question";
            this.textBox_Question.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Question.Size = new System.Drawing.Size(362, 421);
            this.textBox_Question.TabIndex = 0;
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(12, 512);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(362, 47);
            this.btn_Generate.TabIndex = 1;
            this.btn_Generate.Text = "生成";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(426, 65);
            this.textBox_Result.MaxLength = 327670;
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Result.Size = new System.Drawing.Size(443, 421);
            this.textBox_Result.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "结果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "在这里粘贴题目描述";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1283, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 576);
            this.button1.TabIndex = 5;
            this.button1.Text = "打赏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 512);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(443, 47);
            this.button2.TabIndex = 6;
            this.button2.Text = "使用说明";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listBox_Functions);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox_GenerateVariablesForScanf);
            this.groupBox1.Location = new System.Drawing.Point(905, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 460);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "附加函数";
            // 
            // listBox_Functions
            // 
            this.listBox_Functions.FormattingEnabled = true;
            this.listBox_Functions.ItemHeight = 16;
            this.listBox_Functions.Location = new System.Drawing.Point(7, 202);
            this.listBox_Functions.Name = "listBox_Functions";
            this.listBox_Functions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Functions.Size = new System.Drawing.Size(314, 244);
            this.listBox_Functions.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "可以快速更改变量名。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "提示:CB中选中变量名,按Alt+N进入Code Refactoring";
            // 
            // checkBox_GenerateVariablesForScanf
            // 
            this.checkBox_GenerateVariablesForScanf.AutoSize = true;
            this.checkBox_GenerateVariablesForScanf.Location = new System.Drawing.Point(7, 39);
            this.checkBox_GenerateVariablesForScanf.Name = "checkBox_GenerateVariablesForScanf";
            this.checkBox_GenerateVariablesForScanf.Size = new System.Drawing.Size(114, 21);
            this.checkBox_GenerateVariablesForScanf.TabIndex = 0;
            this.checkBox_GenerateVariablesForScanf.Text = "自动生成变量";
            this.checkBox_GenerateVariablesForScanf.UseVisualStyleBackColor = true;
            this.checkBox_GenerateVariablesForScanf.CheckedChanged += new System.EventHandler(this.checkBox_GenerateVariablesForScanf_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(915, 512);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(311, 47);
            this.button3.TabIndex = 8;
            this.button3.Text = "加载附加函数库";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1332, 589);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.textBox_Question);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "C语言mooc练习题代码框架生成器v2.0 -20181031 By 李开新";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Question;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_GenerateVariablesForScanf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_Functions;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button3;
    }
}

