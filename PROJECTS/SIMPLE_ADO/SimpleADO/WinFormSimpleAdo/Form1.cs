using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleADO;
using System.Data.SqlClient;

namespace WinFormSimpleAdo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sqlConn = DbAccess.GetConnection();
            SqlTransaction tra;
            tra = sqlConn.BeginTransaction();

            var sqlPara = new List<SqlParameter>();
            sqlPara.Add(new SqlParameter("Name", txtName.Text));
            sqlPara.Add(new SqlParameter("Email", txtEmail.Text));
            sqlPara.Add(new SqlParameter("RegDate", DateTime.Today));

            try
            {
                DbAccess.Update(@"insert into StudentBasic(Name,Email,RegDate) 
            values(@Name,@Email,@RegDate);", sqlPara, sqlConn, tra);

                tra.Commit();
            }
            catch (Exception)
            {

                tra.Rollback();
            }

        }
    }
}
