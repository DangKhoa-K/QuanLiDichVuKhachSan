using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLiDichVuKhachSan.Data
{
    public static class Db
    {
        // Đặt đúng tên DB của bạn
        public static string ConnStr =
            @"Data Source=DESKTOP-1BC5UNC\SQLEXPRESS;Initial Catalog=QLDVKhachSan;Integrated Security=True;";

        public static DataTable GetTable(string sqlOrProc, CommandType type, params SqlParameter[] ps)
        {
            using (var con = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sqlOrProc, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = type;
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Exec(string sqlOrProc, CommandType type, params SqlParameter[] ps)
        {
            using (var con = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sqlOrProc, con))
            {
                cmd.CommandType = type;
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sqlOrProc, CommandType type, params SqlParameter[] ps)
        {
            using (var con = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sqlOrProc, con))
            {
                cmd.CommandType = type;
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}