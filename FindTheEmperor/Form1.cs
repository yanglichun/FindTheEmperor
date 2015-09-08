using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        TextBox t = new TextBox();
        
        public Form1()
        {
            InitializeComponent();
        }

        public string byYear(int year) 
        {

            string connstr = "SELECT Dynasty,Name as huangdi,start,[end],shihao FROM Emperor WHERE Start <= " + year + " AND [End] >= " + year;
           return connstr;
        }

        public string byName(string name)
        {

            string connstr = "SELECT Dynasty,Name as huangdi,start,[end],shihao FROM Emperor WHERE name like '%" + name + "%' ORDER BY Start ASC";
            return connstr;
        }
        public string byDynasty(string dyn) 
        {
            string connstr = "SELECT Dynasty,Name as huangdi,start,[end],shihao FROM Emperor WHERE Dynasty like '%" + dyn + "%'";
            return connstr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string conn1 = "Data Source=YANGLICHUN;Initial Catalog=Emperor;user id=sa;password=19930405;Integrated Security=True";
            
            SqlConnection conn = new SqlConnection(conn1);
            DataSet ds = new DataSet();
            string t1 =this.textBox1.Text;
          if (comboBox1.SelectedIndex == 0)
         {
             try
             {
                 int t2 = Convert.ToInt32(t1);
                 if (t2 < -221 || t2 > 1912)
                 {
                     MessageBox.Show("请输入正确的数字！");
                 }
                 SqlDataAdapter sda=new SqlDataAdapter(byYear(t2),conn);
                 sda.Fill(ds);
                 
             }
             catch {
                 MessageBox.Show("请输入正确的数字！");
                 return;
             }
          }
          else if (comboBox1.SelectedIndex == 1)
          {
              SqlDataAdapter sda = new SqlDataAdapter(byName(t1), conn);
              sda.Fill(ds);
          }
          else if (comboBox1.SelectedIndex == 2)
          {
              SqlDataAdapter sda = new SqlDataAdapter(byDynasty(t1), conn);
              sda.Fill(ds); 
            }
            
            //conn.Open();
          dataGridView1.DataSource = ds.Tables[0];
            //listBox1.Items.Add("朝代\n姓名\n谥号\n生\n死\n登基\n退位\n年号\n介绍");
            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        //if(dr[6].ToString()||dr[7].ToString()!=null)
            //        try
            //        {
            //            int s = 1;
            //            int sev = Convert.ToInt32(dr[7]);
            //            int six = Convert.ToInt32(dr[6]);
            //            int r = sev - six;
            //            //MessageBox.Show(r.ToString());
            //            if (r == 0)
            //            {
            //                s = 1;
            //            }
            //            else
            //            {
            //                s = (Convert.ToInt32(dr[7].ToString()) - Convert.ToInt32(dr[6].ToString()));
            //            }
            //            //MessageBox.Show(dr[0] + dr[2].ToString() + dr[3] + dr[4] + dr[5]);
            //            //string s= dr[9].ToString() + dr[1]+ dr[2] + dr[3] + dr[4] + dr[5]+dr[6]+dr[7]+dr[8];
            //            listBox1.Items.Add(string.Format("{0}\t皇帝:{1}\t登基:{2}年\t退位:{3}年\t在位约:{4}年",
            //            dr[1].ToString(),
            //            dr[2].ToString(),
            //            dr[6].ToString(),
            //            dr[7].ToString(), s.ToString()));
            //        }
            //        catch
            //        {
            //            listBox1.Items.Add(string.Format("{0}\t皇帝:{1}\t登基:xx{2}年\t退位:xx{3}年\t在位约:0年",
            //                dr[1].ToString(),
            //                dr[2].ToString(),
            //                dr[6].ToString(),
            //                dr[7].ToString()));
            //        }
            //    }
            //}
            //else { MessageBox.Show("没有找到噢~~~"); }
            ////try
            ////{
            ////    MessageBox.Show(cmd.ExecuteScalar().ToString());
            ////}
            ////catch { MessageBox.Show("额~暂时没找到哦- -"); }
            //conn.Close();
        }

       
    }
}
