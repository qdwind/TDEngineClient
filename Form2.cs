using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Entity;

namespace TDEngineClient
{
    public partial class Form2 : Form
    {
        public string Sql { get; set; } = "";

        private Random ran = new Random();


        public Form2(string fields)
        {
            InitializeComponent();
            SetFieldGrid(fields);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GenValuesSql();
            Sql =  GenValuesSql();
            if (Sql.Length > 300000)
            {
                MessageBox.Show("Warning:Text Too Long:" + Sql.Length.ToString());
            }
            this.Close();
        }

        private List<string> GetFieldsFromStr(string str)
        {
            List<string> flist = new List<string>();
            int idx1 = str.LastIndexOf('(')+1;
            int idx2 = str.LastIndexOf(')');
            if (idx2 - idx1 > 1)
            {
                var fstr= str.Substring(idx1, idx2 - idx1);
                flist = fstr.Split(',').ToList();
            }

            return flist;
        }

        private void SetFieldGrid(string fieldStr)
        {
            //初始化dgv,添加枚举下拉列表
            var col_type = dgv1.Columns[1] as DataGridViewComboBoxColumn;
            col_type.Items.Clear();
            foreach (SqlValueDataType item in Enum.GetValues(typeof(SqlValueDataType)))
            {
                col_type.Items.Add(item.ToString());
            }
            var mod_type = dgv1.Columns[2] as DataGridViewComboBoxColumn;
            mod_type.Items.Clear();
            foreach (SqlValueModeType item in Enum.GetValues(typeof(SqlValueModeType)))
            {
                mod_type.Items.Add(item.ToString());
            }

            //读取样例字段值，设置为字段
            var fdlist = GetFieldsFromStr(fieldStr);
            foreach (var fd in fdlist)
            {
                var myField = fd;
                int index = dgv1.Rows.Add();

                dgv1.Rows[index].Cells[2].Value = SqlValueModeType.Random.ToString();
                dgv1.Rows[index].Cells[3].Value = ""; //Min
                dgv1.Rows[index].Cells[4].Value = ""; //Max
                dgv1.Rows[index].Cells[5].Value = ""; //Step
                dgv1.Rows[index].Cells[6].Value = "";


                //根据字段值的格式判断其字段类型
                if (myField.StartsWith("'"))
                {
                    myField  = myField.Substring(1, myField.Length - 2);
                    if (myField.Contains(":"))
                    {
                        dgv1.Rows[index].Cells[1].Value = SqlValueDataType.TimeStamp.ToString();//时间戳型
                        dgv1.Rows[index].Cells[2].Value = SqlValueModeType.Increasing.ToString();
                        dgv1.Rows[index].Cells[5].Value = "60";//默认一分钟
                    }
                    else
                    {
                        dgv1.Rows[index].Cells[1].Value = SqlValueDataType.String.ToString();//字符型
                        dgv1.Rows[index].Cells[2].Value = SqlValueModeType.Fixed.ToString();
                    }
                }
                else if(myField.Contains("."))
                {
                    dgv1.Rows[index].Cells[1].Value = SqlValueDataType.Float.ToString();//浮点型
                    dgv1.Rows[index].Cells[3].Value = float.Parse(myField)-20;
                    dgv1.Rows[index].Cells[4].Value = myField;
                }
                else
                {
                    dgv1.Rows[index].Cells[1].Value = SqlValueDataType.Int.ToString();//整型
                    dgv1.Rows[index].Cells[3].Value = int.Parse(myField)-200;
                    dgv1.Rows[index].Cells[4].Value = myField;
                }

                dgv1.Rows[index].Cells[0].Value = myField;
            }

        }


        private string GenValuesSql()
        {
            //获取所有字段属性设置
            var flist = new List<SqlValueItem>();

            for ( int i=0;i< dgv1.RowCount;i++)
            {
                var item = new SqlValueItem();
                item.Text = dgv1.Rows[i].Cells[0].Value.ToString();
                item.DataType = (SqlValueDataType)Enum.Parse(typeof(SqlValueDataType), dgv1.Rows[i].Cells[1].Value.ToString());
                item.Mode = (SqlValueModeType)Enum.Parse(typeof(SqlValueModeType), dgv1.Rows[i].Cells[2].Value.ToString());
                item.Min = dgv1.Rows[i].Cells[3].Value.ToString();
                item.Max = dgv1.Rows[i].Cells[4].Value.ToString();
                item.Step = dgv1.Rows[i].Cells[5].Value.ToString();
                var sels = dgv1.Rows[i].Cells[6].Value.ToString();
                if (sels.Length > 0)
                {
                    item.SelectList =sels.Split(',').ToList();
                }
                flist.Add(item);
            }
            if (flist.Count == 0) return "";


            //按属性生成values记录行
            var sb = new StringBuilder();
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                var valueList = new List<string>();
                //设置每个字段
                foreach (var f in flist)
                {
                    string value="";
                    if (f.Mode == SqlValueModeType.Fixed) //固定值
                    {
                        value = f.Text;
                    }
                    else if(f.Mode == SqlValueModeType.Random) //随机方式生成随机数据
                    {
                        value = GetRandomValue(f);
                    }
                    else if(f.Mode == SqlValueModeType.Increasing) //增长值
                    {
                        value = GetIncreasingValue(f, i);
                    }
                   
                    if (f.DataType == SqlValueDataType.String || f.DataType == SqlValueDataType.TimeStamp)
                    {
                        value = "'" + value + "'";
                    }
                    valueList.Add(value);
                }
                sb.Append($"({string.Join(",", valueList)})");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成随机数值
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private string GetRandomValue(SqlValueItem src)
        {
            var value = "";
            if (src.SelectList.Count > 0)
            {
                value = src.SelectList[ran.Next(src.SelectList.Count)];
            }
            else
            {
                if (src.DataType == SqlValueDataType.Int)
                {
                    if (int.TryParse(src.Min, out int min) && int.TryParse(src.Max, out int max))
                    {
                        value = ran.Next(min, max).ToString();
                    }
                    else
                    {
                        value = ran.Next(100).ToString();
                    }
                }
                else if (src.DataType == SqlValueDataType.Float)
                {
                    var len = src.Text.Length - src.Text.IndexOf(".")-1;
                    if (float.TryParse(src.Min, out float min) && float.TryParse(src.Max, out float max))
                    {
                        value = Math.Round(ran.NextDouble() * (max - min) + min, len).ToString();
                    }
                    else
                    {
                        value = Math.Round(ran.NextDouble(),len).ToString();
                    }
                }
                else if (src.DataType == SqlValueDataType.String)
                {
                    value = src.Text + ran.Next().ToString();
                }
                else if (src.DataType == SqlValueDataType.TimeStamp)
                {
                    value = DateTime.Now.AddSeconds(-ran.Next()).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            return value;
        }

        /// <summary>
        /// 生成增长值
        /// </summary>
        /// <param name="src"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public string GetIncreasingValue(SqlValueItem src,int num)
        {
            var value = "";


            if (src.DataType == SqlValueDataType.Int)
            {
                if (int.TryParse(src.Min, out int min) && int.TryParse(src.Step, out int step))
                {
                    value = (min + step * num).ToString();
                }
            }
            else if (src.DataType == SqlValueDataType.Float)
            {
                if (float.TryParse(src.Min, out float min) && float.TryParse(src.Step, out float step))
                {
                    value = (min + step * num).ToString();
                }
            }
            else if (src.DataType == SqlValueDataType.TimeStamp)
            {
                if (DateTime.TryParse(src.Text, out DateTime dt) && int.TryParse(src.Step, out int step))
                {
                    value = dt.AddSeconds(step * num).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            return value;
        }




    }
}
