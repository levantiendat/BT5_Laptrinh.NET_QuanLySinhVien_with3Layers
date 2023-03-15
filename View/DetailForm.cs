using _102210247_LeVanTienDat.BLL;
using _102210247_LeVanTienDat.DTO;
using System;
using System.Windows.Forms;

namespace _102210247_LeVanTienDat
{
    public partial class DetailForm : Form
    {
        public delegate void MyDel(string lsh, string txt);
        public MyDel d { get; set; }
        public string MSSV { get; set; }
        public DetailForm(string mssv)
        {
            MSSV = mssv;
            InitializeComponent();
            SetCBB();
            GUI();

        }
        public void SetCBB()
        {
            QLSV_BLL bll = new QLSV_BLL();
            textlopsh.Items.AddRange(bll.GetCBBItem1().ToArray());
        }
        public void GUI()
        {
            if (MSSV != "")
            {
                QLSV_BLL bll = new QLSV_BLL();
                SinhVien sv = new SinhVien();
                sv = bll.GetSVByMSSV(MSSV);
                textname.Text = sv.MSSV.ToString();
                textlopsh.Text = bll.GetClassName(sv.MALOP).ToString();
                textDate.Text = sv.NGAYSINH.ToString();
                textdtb.Text = sv.DIEMTRUNGBINH.ToString();
                if (sv.GIOITINH)
                {
                    nam.Checked = true;
                }
                else
                {
                    nu.Checked = true;
                }
                anh.Checked = sv.ANH;
                hocba.Checked = sv.HOCBA;
                cccd.Checked = sv.CCCD;
                textname.Enabled = false;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            QLSV_BLL bll = new QLSV_BLL();
            sv.MSSV = textname.Text.ToString();
            sv.MALOP = bll.GetIDClass(textlopsh.Text.ToString());
            sv.NGAYSINH = Convert.ToDateTime(textDate.Text.ToString());
            if (nam.Checked)
            {
                sv.GIOITINH = true;
            }
            else { sv.GIOITINH = false; }
            sv.DIEMTRUNGBINH = Convert.ToDouble(textdtb.Text.ToString());
            sv.ANH = Convert.ToBoolean(anh.Checked.ToString());
            sv.HOCBA = Convert.ToBoolean(hocba.Checked.ToString());
            sv.CCCD = Convert.ToBoolean(cccd.Checked.ToString());
            bll.SyncDB(sv);
            d("All", "");
            this.Close();

        }
    }
}
