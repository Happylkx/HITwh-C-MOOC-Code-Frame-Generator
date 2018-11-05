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
using System.Xml.Linq;
using CodeFrameGenerator;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace CodeFrameGenerator
{
    public partial class Form1 : Form
    {
        private CodeFrameGenerator gen=new CodeFrameGenerator();
        string strAbout = "请将题目中的描述文字(不包括示例及示例代码！)粘贴进左边文本框中，在右侧选择框中选中题目需要用到的函数，点击生成，文本框中会自动生成代码框架。目前支持提取printf() , scanf()" +
                " gets() 以及自定义函数及其原型。不保证结果一定正确!";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAdditionalFunctionList(Properties.Resources.FunctionsSource);
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            List<int> SelectedIndices = new List<int>();//附加函数中选中的项
            
            ListBox.SelectedIndexCollection sic=listBox_Functions.SelectedIndices;
            for(int i=0; i<sic.Count;i++)
            {
                SelectedIndices.Add(sic[i]);
            }//转换成List

            textBox_Result.Text = gen.Generate(textBox_Question.Text,SelectedIndices);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmMoney().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = strAbout;

        }

        private void checkBox_GenerateVariablesForScanf_CheckedChanged(object sender, EventArgs e)
        {
            gen.GenerateVariablesForScanf = checkBox_GenerateVariablesForScanf.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string s = File.ReadAllText(openFileDialog.FileName);
                    listBox_Functions.Items.Clear();
                    LoadAdditionalFunctionList(s);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                LoadAdditionalFunctionList(Properties.Resources.FunctionsSource);//恢复使用内置函数库
            }
        }
        private void LoadAdditionalFunctionList(string str)
        {
            gen.ParseAdditionalFunctionXML(str);
            foreach (CodeFrameGenerator.AdditionalFunction af in gen.AdditionalFunctionList)//读取附加函数列表
            {
                listBox_Functions.Items.Add(af.FunctionName);
            }
        }
    }
}
