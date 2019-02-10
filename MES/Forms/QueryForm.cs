using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MES.UI
{
    public partial class QueryForm : Form
    {
        private FormMain m_main;

        private DataTable m_dataTable;

        private DataTable ProductsTable;

        public QueryForm()
        {
            InitializeComponent();
        }

        public QueryForm(FormMain main)
        {
            InitializeComponent();
            m_main = main;
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            lvProducts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //this.Invoke((MethodInvoker)LoadData);
        }

        private List<ListViewItem> myCache = new List<ListViewItem>();

        private delegate void UpdateUIDelegate();

        private void LoadData()
        {
            ListViewItem item;

            if (this.lvProducts.InvokeRequired)
            {
                //UpdateUIDelegate update = new UpdateUIDelegate(LoadData);
                //this.Invoke(update);
            }
            else
            {
                if (m_main != null && ProductsTable != null)
                {
                    m_dataTable = ProductsTable;
                    lvProducts.Items.Clear();

                    /*
                    for (int i = 0; i < m_dataTable.Columns.Count; i++)
                    {
                        string col = m_dataTable.Columns[i].ToString();
                        lvProducts.Columns[i].Text = col;
                    }*/

                    foreach (DataRow dataRow in m_dataTable.Rows)
                    {
                        item = new ListViewItem(dataRow[0].ToString());

                        string s = dataRow[1].ToString();
                        item.Text = s;

                        for (int i = 2; i < m_dataTable.Columns.Count; i++)
                        {
                            string str = dataRow[i].ToString();
                            item.SubItems.Add(dataRow[i].ToString());
                        }
                        //虚拟加载
                        myCache.Add(item);

                        //正常加载
                        // this.lvProducts.Items.Add(item);
                    }

                    //设置虚拟加载参数
                    lvProducts.VirtualListSize = myCache.Count;
                    lvProducts.Invalidate();
                }
            }
        }

        private void lvProducts_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (myCache != null)
            {
                e.Item = myCache[e.ItemIndex];
            }
        }
    }
}