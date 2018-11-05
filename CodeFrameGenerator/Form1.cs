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
        string strAbout = "�뽫��Ŀ�е���������(������ʾ����ʾ�����룡)ճ��������ı����У����Ҳ�ѡ�����ѡ����Ŀ��Ҫ�õ��ĺ�����������ɣ��ı����л��Զ����ɴ����ܡ�Ŀǰ֧����ȡprintf() , scanf()" +
                " gets() �Լ��Զ��庯������ԭ�͡�����֤���һ����ȷ!";
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
            List<int> SelectedIndices = new List<int>();//���Ӻ�����ѡ�е���
            
            ListBox.SelectedIndexCollection sic=listBox_Functions.SelectedIndices;
            for(int i=0; i<sic.Count;i++)
            {
                SelectedIndices.Add(sic[i]);
            }//ת����List

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
                LoadAdditionalFunctionList(Properties.Resources.FunctionsSource);//�ָ�ʹ�����ú�����
            }
        }
        private void LoadAdditionalFunctionList(string str)
        {
            gen.ParseAdditionalFunctionXML(str);
            foreach (CodeFrameGenerator.AdditionalFunction af in gen.AdditionalFunctionList)//��ȡ���Ӻ����б�
            {
                listBox_Functions.Items.Add(af.FunctionName);
            }
        }
    }
}
