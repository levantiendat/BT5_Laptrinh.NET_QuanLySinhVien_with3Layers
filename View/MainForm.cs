using _102210247_LeVanTienDat.BLL;
using _102210247_LeVanTienDat.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _102210247_LeVanTienDat
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            QLSV_BLL bll = new QLSV_BLL();
            lop1.Items.AddRange(bll.GetCBBItem().ToArray());
        }
        public void ShowDGV(string lsh, string txt)
        {
            QLSV_BLL bll = new QLSV_BLL();
            data.DataSource = bll.GetSVBySearch(lsh, txt);
        }

        private void lop1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(((CBBItems)lop1.SelectedItem).Value);
            QLSV_BLL bll = new QLSV_BLL();
            data.DataSource = bll.GetSVByIDLop(ID);
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            DetailForm dtf = new DetailForm("");

            dtf.d += new DetailForm.MyDel(ShowDGV);
            //ShowDGV("All", "");
            dtf.Show();
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count == 1)
            {
                string mssv = data.SelectedRows[0].Cells["MSSV"].Value.ToString();
                DetailForm f = new DetailForm(mssv);
                f.d += new DetailForm.MyDel(ShowDGV);
                f.Show();
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            if (data.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in data.SelectedRows)
                {
                    list.Add(i.Cells["MSSV"].Value.ToString());
                }
                QLSV_BLL f = new QLSV_BLL();
                f.DelSVBLL(list);
                ShowDGV("All", "");
                //ShowDGV(lop1.SelectedItem.ToString(), textsearch.Text);
            }
        }

        private void buttonsort_Click(object sender, EventArgs e)
        {
            string txtsort = sort.SelectedItem.ToString();
            string lopsh = lop1.SelectedItem.ToString();
            QLSV_BLL bll = new QLSV_BLL();
            data.DataSource = bll.sort(lopsh, txtsort);
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            string lopsh = lop1.SelectedItem.ToString();
            string txt = textsearch.Text;
            ShowDGV(lopsh, txt);
        }
    }
}
