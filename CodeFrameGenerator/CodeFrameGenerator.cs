using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace CodeFrameGenerator
{
    public class CodeFrameGenerator
    {
        static string nl = System.Environment.NewLine;

        public bool GenerateVariablesForScanf { get; set; }


        public struct AdditionalFunction//自定义函数结构
        {
            public string FunctionName;
            public string FunctionPrototype;
            public string FunctionCode;
        }
        public List<AdditionalFunction> AdditionalFunctionList = new List<AdditionalFunction>();

        public string Generate(string text)
        {
            return Generate(text, new List<int>());
        }

        public string Generate(string text, List<int> SelectedIndices)
        {
            string result;

            string[] functions = BuildFunctions(text);
            string FunctionPrototypes = functions[0];
            string FunctionDeclaration = functions[1];

            foreach (int index in SelectedIndices)
            {
                FunctionPrototypes += AdditionalFunctionList[index].FunctionPrototype + nl;
                FunctionDeclaration += AdditionalFunctionList[index].FunctionCode + nl;
            }
            result = BuildReferencesCode() + FunctionPrototypes + BuildMainCode(text) + FunctionDeclaration;
            return result;

        }
        /// <summary>
        /// 构建引用部分代码
        /// </summary>
        /// <returns></returns>
        private string BuildReferencesCode()
        {
            string result = "#include <stdlib.h>" + nl +
    "#include <stdio.h>" + nl +
    "#include <math.h>" + nl +
    "#include <string.h>" + nl  + nl;
            return result;
        }
        /// <summary>
        /// 构建主函数代码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string BuildMainCode(string text)
        {
            string result;
            string code_Main_0 = "int main(){" + nl;
            string code_Main_1 = nl + "return 0;" + nl + "}";

            string code_Variables_Declaration = "";
            int num_Variables = 0;
            string[] Variables = new string[26];
            for (int i = 0; i < 26; i++)//为变量池命名
            {
                Variables[i] = ((char)('a' + i)).ToString();
            }

            string InputAndOutput = "";//包括一系列printf 和 scanf

            string[] lines = text.Split(nl.ToCharArray());//将题目分成行的形式
            foreach (string line in lines)
            {
                if (line.Contains('"'))
                {
                    int start = line.IndexOf('"');
                    int length = line.LastIndexOf('"') - start;
                    string quote = line.Substring(start, length + 1);//取出的字符串包含引号
                    if (line.Contains("输出") || line.Contains("提示"))
                    //必须放在前面。有些题目中可能这样写：“提示用户输入”。
                    //包含 “提示”和“输出”一定为printf，但包含“输入“不一定为scanf
                    {
                        int num_Arguments = PercentList(quote).Count;//输出格式符的数量

                        string argumentSpaces = "";
                        for (int i = 1; i <= num_Arguments; i++)
                        {
                            argumentSpaces += " , ";
                        }//连接一系列逗号
                        InputAndOutput += "printf(" + quote + argumentSpaces + ");" + nl;
                    }
                    else if (line.Contains("输入"))
                    {
                        //用scanf输入
                        List<string> arg_list = PercentList(line);
                        string argumentSpaces = "";
                        foreach (string format_str in arg_list)
                        {
                            if (GenerateVariablesForScanf)
                            {


                                if (format_str.StartsWith("%d"))
                                {
                                    code_Variables_Declaration += "int " + Variables[num_Variables] + ";" + nl;
                                }
                                else if (format_str.StartsWith("%c"))
                                {
                                    code_Variables_Declaration += "char " + Variables[num_Variables] + ";" + nl;
                                }
                                else if (format_str.StartsWith("%ld"))
                                {
                                    code_Variables_Declaration += "long " + Variables[num_Variables] + ";" + nl;
                                }
                                else if (format_str.StartsWith("%f"))
                                {
                                    code_Variables_Declaration += "float " + Variables[num_Variables] + ";" + nl;
                                }
                                else if (format_str.StartsWith("%lf"))
                                {
                                    code_Variables_Declaration += "double " + Variables[num_Variables] + ";" + nl;
                                }
                                else if (format_str.StartsWith("%hd"))
                                {
                                    code_Variables_Declaration += "short " + Variables[num_Variables] + ";" + nl;
                                }
                                else if (format_str.StartsWith("%s"))
                                {
                                    code_Variables_Declaration += "char [ ] " + Variables[num_Variables] + ";" + nl;
                                }


                                argumentSpaces += " , &" + Variables[num_Variables];//如果题目要求用数组此处可能有问题
                                num_Variables++;
                            }
                            else
                            {
                                argumentSpaces += " , &";//如果题目要求用数组此处可能有问题 
                            }
                        }
                        InputAndOutput += "scanf(" + quote + argumentSpaces + ");" + nl;

                    }



                }
                //用gets输入
                else if (line.Contains("gets"))
                {
                    if (GenerateVariablesForScanf)
                    {
                        code_Variables_Declaration += "char[ ] " + Variables[num_Variables] + ";" + nl;

                        InputAndOutput += "gets(" + Variables[num_Variables] + ");" + nl;
                        num_Variables++;
                    }
                    else
                    {
                        InputAndOutput += "gets( );" + nl;
                    }

                }

            }
            result = code_Main_0 + code_Variables_Declaration + nl + InputAndOutput + nl + code_Main_1 + nl;
            return result;
        }
        /// <summary>
        /// 构建函数原型及函数定义
        /// </summary>
        /// <param name="str">题干</param>
        /// <returns>[0]中为函数原型，[1]中为函数定义</returns>
        private string[] BuildFunctions(string str)
        {
            string Prototypes = "";
            string Functions = "";
            string[] lines = str.Split(nl.ToCharArray());
            foreach (string line in lines)
            {
                string[] key_Types = { "void", "int", "double", "float",
                                "long","short","char"};//函数声明的开头，用来判断函数的定义
                for (int j = 0; j <= key_Types.Length - 1; j++)
                {
                    int start = line.IndexOf(key_Types[j]);
                    if (start == -1) continue;//若不存在则搜索下一个关键字
                    else
                    {
                        int length = line.LastIndexOf(';') - start;
                        string prototype = line.Substring(start, length);//不取出分号
                        Prototypes += prototype + ";" + nl;

                        Functions += prototype + "{" + nl + nl + "}" + nl;
                        break;//找到之后就不要再继续搜索了，否则会把后面形参当成函数一起输出
                    }

                }
            }
            return new string[] { Prototypes, Functions };
        }

        /// <summary>
        /// 格式字符%的数量
        /// </summary>
        /// <param name="str"></param>
        /// <returns>返回字符串中包含 % 的个数</returns>
        private List<string> PercentList(string str)
        {
            char[] ch = str.ToCharArray();
            List<string> list = new List<string>();
            for (int i = 0; i <= ch.Length - 1; i++)
            {
                if (ch[i] == '%')
                {
                    string temp = ch[i].ToString() + ch[i + 1].ToString() + ch[i + 2].ToString();
                    //即使格式符没有那么长，善良的出题老师总会在后面加上分号，i+2不会访问越界。
                    //就像这样"%d",ch[i+2]是字符"
                    list.Add(temp);
                }
            }
            return list;
        }
        public void ParseAdditionalFunctionXML(string str)
        {
            //AdditionalFunctionList.Clear();
            XDocument xd = XDocument.Parse(str);
            
            XElement xroot = xd.Element("CodePack");
            foreach (XElement eleFunction in xroot.Elements("Code"))
            {
                AdditionalFunction af = new AdditionalFunction();
                af.FunctionName = eleFunction.Element("FunctionName").Value;
                af.FunctionPrototype = eleFunction.Element("FunctionPrototype").Value;
                af.FunctionCode = eleFunction.Element("Content").Value;

                af.FunctionCode = af.FunctionCode.Replace("\n", System.Environment.NewLine);//使换行正常显示
                af.FunctionCode = System.Web.HttpUtility.HtmlDecode(af.FunctionCode);//处理转义字符
                AdditionalFunctionList.Add(af);
            }

        }
    }
}