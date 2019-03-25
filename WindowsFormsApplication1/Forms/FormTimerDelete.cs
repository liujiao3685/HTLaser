using Model;
using SQLServerDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms
{
    public partial class FormTimerDelete : Form
    {
        private System.Timers.Timer timer;
        private int Days = 30;
        private bool IsStartTimer = false;

        public FormTimerDelete()
        {
            InitializeComponent();
        }
        private void FormTimerDelete_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                Days = int.Parse(textBox1.Text);

            ServiceResult result = DeleteDataByDay(Days);
        }

        private ServiceResult DeleteDataByDay(int interval, string line = "FRS1")
        {
            ServiceResult result = new ServiceResult();

            try
            {
                //获取服务器当天时间
                string sqlGetSysTime = "SELECT GETDATE()";
                DateTime sysTime = Convert.ToDateTime(SqlHelper.ExecuteScalar(SqlHelper.SQLServerConnectionString, CommandType.Text, sqlGetSysTime));

                //获取数据库中最旧一条数据的插入时间
                string sqlGetLast = "SELECT [TaktStartTime] FROM [T180801].[dbo].[T_Station_TaktTime] WHERE [LineName]=@LineName ORDER BY autoid ASC";
                SqlParameter[] sqlParmGetTime = new SqlParameter[1];
                sqlParmGetTime[0] = new SqlParameter("@LineName", SqlDbType.VarChar, 50);
                sqlParmGetTime[0].Value = line;
                DateTime lastTime = Convert.ToDateTime(SqlHelper.ExecuteScalar(SqlHelper.SQLServerConnectionString, CommandType.Text, sqlGetLast, sqlParmGetTime));

                int curInterval = sysTime.DayOfYear - lastTime.DayOfYear;
                //判断是否到达删除时间
                if (curInterval >= interval)
                {
                    string sqlDelete = "DELETE FROM [T180801].[dbo].[T_Station_TaktTime] WHERE [TaktStartTime]<@DeleteTime";
                    SqlParameter[] sqlParmDelete = new SqlParameter[1];
                    sqlParmDelete[0] = new SqlParameter("@DeleteTime", SqlDbType.DateTime);
                    sqlParmDelete[0].Value = sysTime.AddDays(-interval);
                    int count = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, CommandType.Text, sqlDelete, sqlParmDelete);

                    if (count > 0)
                    {
                        result.IsSuccess = true;
                        result.Msg = string.Format("成功，count:{0}", count);
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Msg = string.Format("失败，count:{0}", count);
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = string.Format("未到达删除时间，当前时间差：{0},设定时间差：{1}，还差：{2}天", curInterval, interval, interval - curInterval);
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("异常：{0}", ex.Message);
            }

            return result;
        }
    }
}
