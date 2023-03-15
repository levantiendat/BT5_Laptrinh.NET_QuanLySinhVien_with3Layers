using _102210247_LeVanTienDat.DAL;
using _102210247_LeVanTienDat.DTO;
using System;
using System.Collections.Generic;

namespace _102210247_LeVanTienDat.BLL
{
    internal class QLSV_BLL
    {
        public List<CBBItems> GetCBBItem()
        {
            List<CBBItems> data = new List<CBBItems>();
            data.Add(new CBBItems { Value = "0", Text = "All" });
            QLSV_DAL dal = new QLSV_DAL();
            foreach (LSH i in dal.GetAllLSH())
            {
                data.Add(new CBBItems
                {
                    Value = i.ID.ToString(),
                    Text = i.LOPSH.ToString()
                });
            }
            return data;
        }
        public List<CBBItems> GetCBBItem1()
        {
            List<CBBItems> data = new List<CBBItems>();

            QLSV_DAL dal = new QLSV_DAL();
            foreach (LSH i in dal.GetAllLSH())
            {
                data.Add(new CBBItems
                {
                    Value = i.ID.ToString(),
                    Text = i.LOPSH.ToString()
                });
            }
            return data;
        }
        public List<SinhVien> GetSVBySearch(string lopsh, string txt)
        {
            List<SinhVien> data1 = new List<SinhVien>();
            if (lopsh == "All")
            {
                data1 = GetSVByIDLop(0);
            }
            else
            {
                data1 = GetSVByIDLop(GetIDClass(lopsh));
            }
            List<SinhVien> data = new List<SinhVien>();


            foreach (SinhVien i in data1)
            {
                if (i.MSSV.CompareTo(txt) == 0 || txt == "")
                {
                    data.Add(i);
                }
            }


            return data;
        }
        public List<SinhVien> GetSVByIDLop(int ID)
        {
            List<SinhVien> data = new List<SinhVien>();
            QLSV_DAL dal = new QLSV_DAL();
            if (ID == 0)
            {
                data = dal.GetAllSV();
            }
            else
            {
                foreach (SinhVien i in dal.GetAllSV())
                {
                    if (i.MALOP == ID)
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public SinhVien GetSVByMSSV(string mssv)
        {
            SinhVien sv = new SinhVien();
            QLSV_DAL dal = new QLSV_DAL();
            sv = dal.GetSVByMSSV(mssv);
            return sv;
        }
        public int GetIDClass(string lop)
        {
            QLSV_DAL dal = new QLSV_DAL();
            return dal.GetClassID(lop);
        }
        public string GetClassName(int id)
        {
            QLSV_DAL dal = new QLSV_DAL();
            return dal.GetClassName(id);
        }
        public bool Check(string mssv)
        {
            QLSV_DAL dal = new QLSV_DAL();
            return dal.Check(mssv);
        }
        public void SyncDB(SinhVien sv)
        {
            if (Check(sv.MSSV))
            {
                UpdateSVBLL(sv);
            }
            else
            {
                AddSVBLL(sv);
            }
        }
        public void AddSVBLL(SinhVien s)
        {
            QLSV_DAL dal = new QLSV_DAL();
            dal.AddSVDAL(s);
        }
        public void DelSVBLL(List<string> del)
        {
            foreach (string s in del)
            {
                QLSV_DAL dal = new QLSV_DAL();
                dal.DelSVDAL(s);
            }
        }
        public void UpdateSVBLL(SinhVien s)
        {
            QLSV_DAL dal = new QLSV_DAL();
            dal.UpdateSVDAL(s);
        }
        public List<SinhVien> ListSVDGV(List<string> li)
        {
            List<SinhVien> data = new List<SinhVien>();
            foreach (string s in li)
            {
                QLSV_DAL dal = new QLSV_DAL();
                foreach (SinhVien j in dal.GetAllSV())
                {
                    if (j.MSSV == s)
                    {
                        data.Add(j);
                    }
                }
            }
            return data;
        }
        public List<SinhVien> sort(string lopsh, string txt)
        {
            List<SinhVien> data = new List<SinhVien>();
            if (lopsh == "All")
            {
                data = GetSVByIDLop(0);
            }
            else
            {
                data = GetSVByIDLop(GetIDClass(lopsh));
            }
            if (txt == "MSSV")
            {
                for (int i = 0; i < data.Count - 1; i++)
                {
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        if (data[i].MSSV.CompareTo(data[j].MSSV) > 0)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }
                    }
                }
            }
            else if (txt == "MALOP")
            {
                for (int i = 0; i < data.Count - 1; i++)
                {
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        if (data[i].MALOP > data[j].MALOP)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }
                    }
                }
            }
            else if (txt == "NGAYSINH")
            {
                for (int i = 0; i < data.Count - 1; i++)
                {
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        if (DateTime.Compare(data[i].NGAYSINH, data[j].NGAYSINH) > 0)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < data.Count - 1; i++)
                {
                    for (int j = i + 1; j < data.Count; j++)
                    {
                        if (data[i].DIEMTRUNGBINH < data[j].DIEMTRUNGBINH)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = data[i];
                            data[i] = data[j];
                            data[j] = tmp;
                        }
                    }
                }
            }


            return data;
        }
    }
}
