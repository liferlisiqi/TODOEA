﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
namespace TOS
{
    public partial class Form1 : Form
    {
        ArrayList allSolution = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void readDataBTN_Click(object sender, EventArgs e)
        {
            DateTime beginTime = System.DateTime.Now;
            SqlConnection conn = new SqlConnection("Data Source=USER-20160720BD;" +
                "Initial Catalog=MO-benchmark-AP;Integrated Security=True");
            DataTable dt = new DataTable();
            string sql = "select sum,makespan,cv from [3-8-11]";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Solution solution = new Solution();
                solution.ob1 = Convert.ToDouble(dt.Rows[i][0].ToString());
                solution.ob2 = Convert.ToDouble(dt.Rows[i][1].ToString());
                solution.ob3 = Convert.ToDouble(dt.Rows[i][2].ToString());
                allSolution.Add(solution);
            }

            DateTime endTime = System.DateTime.Now;
            readDataBox.Text = (endTime - beginTime).TotalSeconds.ToString();
            MessageBox.Show("ok");
        }


    }
}