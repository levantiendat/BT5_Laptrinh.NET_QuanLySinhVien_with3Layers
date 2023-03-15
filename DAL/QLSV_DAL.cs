using _102210247_LeVanTienDat.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _102210247_LeVanTienDat.DAL
{
    public class QLSV_DAL
    {
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> data = new List<SinhVien>();
            string query = "select * from SINHVIEN";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
        public SinhVien GetSVByDataRow(DataRow i)
        {
            return new SinhVien
            {
                MSSV = i["MSSV"].ToString(),
                MALOP = Convert.ToInt32(i["MALOP"].ToString()),
                NGAYSINH = Convert.ToDateTime(i["NGAYSINH"].ToString()),
                GIOITINH = Convert.ToBoolean(i["GIOITINH"].ToString()),
                DIEMTRUNGBINH = Convert.ToDouble(i["DIEMTRUNGBINH"].ToString()),
                ANH = Convert.ToBoolean(i["ANH"].ToString()),
                HOCBA = Convert.ToBoolean(i["HOCBA"].ToString()),
                CCCD = Convert.ToBoolean(i["CCCD"].ToString()),
            };
        }
        public List<LSH> GetAllLSH()
        {
            List<LSH> data = new List<LSH>();
            string query = "select * from LOPSINHHOAT";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(GetLSHByDataRow(i));
            }
            return data;
        }
        public LSH GetLSHByDataRow(DataRow i)
        {
            return new LSH
            {
                ID = Convert.ToInt32(i["ID"].ToString()),
                LOPSH = i["LOPSH"].ToString(),

            };
        }

        public SinhVien GetSVByMSSV(string mssv)
        {

            string query = "Select * from SINHVIEN where MSSV='" + mssv + "'";

            SinhVien data = new SinhVien();
            data = (GetSVByDataRow(DBHelper.Instance.GetRecords(query).Rows[0]));
            return data;
        }
        public int GetClassID(string txt)
        {
            int data;
            string query = "Select * from LOPSINHHOAT where LOPSH='" + txt + "'";
            data = Convert.ToInt32(GetLSHByDataRow(DBHelper.Instance.GetRecords(query).Rows[0]).ID);
            return data;
        }
        public string GetClassName(int id)
        {
            string data;
            string query = "Select * from LOPSINHHOAT where ID=" + id;
            data = GetLSHByDataRow(DBHelper.Instance.GetRecords(query).Rows[0]).LOPSH;
            return data;
        }
        public bool Check(string mssv)
        {
            bool check = false;
            string query = "select * from SINHVIEN";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                if (mssv.CompareTo(i[0]) == 0)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        public void AddSVDAL(SinhVien s)
        {
            SqlParameter MSSV = new SqlParameter("@MSSV", s.MSSV);
            SqlParameter MALOP = new SqlParameter("@MALOP", s.MALOP);
            SqlParameter NGAYSINH = new SqlParameter("@NGAYSINH", s.NGAYSINH);
            SqlParameter GIOITINH = new SqlParameter("@GIOITINH", s.GIOITINH);
            SqlParameter DIEMTRUNGBINH = new SqlParameter("@DIEMTRUNGBINH", s.DIEMTRUNGBINH);
            SqlParameter ANH = new SqlParameter("@ANH", s.ANH);
            SqlParameter HOCBA = new SqlParameter("@HOCBA", s.HOCBA);
            SqlParameter CCCD = new SqlParameter("@CCCD", s.CCCD);
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(MSSV);
            Parameters.Add(MALOP);
            Parameters.Add(NGAYSINH);
            Parameters.Add(GIOITINH);
            Parameters.Add(DIEMTRUNGBINH);
            Parameters.Add(ANH);
            Parameters.Add(HOCBA);
            Parameters.Add(CCCD);
            string query = string.Format("Insert into SINHVIEN Values ({0},{1},{2},{3},{4},{5},{6},{7})"
                , "@MSSV", "@MALOP", "@NGAYSINH", "@GIOITINH", "@DIEMTRUNGBINH", "@ANH", "@HOCBA", "@CCCD");
            DBHelper.Instance.ExecuteDBs(query, Parameters);
        }
        public void UpdateSVDAL(SinhVien s)
        {
            SqlParameter MSSV = new SqlParameter("@MSSV", s.MSSV);
            SqlParameter MALOP = new SqlParameter("@MALOP", s.MALOP);
            SqlParameter NGAYSINH = new SqlParameter("@NGAYSINH", s.NGAYSINH);
            SqlParameter GIOITINH = new SqlParameter("@GIOITINH", s.GIOITINH);
            SqlParameter DIEMTRUNGBINH = new SqlParameter("@DIEMTRUNGBINH", s.DIEMTRUNGBINH);
            SqlParameter ANH = new SqlParameter("@ANH", s.ANH);
            SqlParameter HOCBA = new SqlParameter("@HOCBA", s.HOCBA);
            SqlParameter CCCD = new SqlParameter("@CCCD", s.CCCD);
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(MSSV);
            Parameters.Add(MALOP);
            Parameters.Add(NGAYSINH);
            Parameters.Add(GIOITINH);
            Parameters.Add(DIEMTRUNGBINH);
            Parameters.Add(ANH);
            Parameters.Add(HOCBA);
            Parameters.Add(CCCD);
            string query = string.Format("Update SINHVIEN set  MALOP={1},NGAYSINH={2}, GIOITINH={3}, DIEMTRUNGBINH={4}, ANH={5}, HOCBA={6}, CCCD={7} " +
                "WHERE MSSV={0}", "@MSSV", "@MALOP", "@NGAYSINH", "@GIOITINH", "@DIEMTRUNGBINH", "@ANH", "@HOCBA", "@CCCD");

            DBHelper.Instance.ExecuteDBs(query, Parameters);
        }
        public void DelSVDAL(string MSSV)
        {
            string query = "Delete from SINHVIEN where MSSV ='" + MSSV + "'";
            DBHelper.Instance.ExecuteDBs(query);
        }
    }
}
