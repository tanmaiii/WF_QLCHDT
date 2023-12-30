using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace WF_QLCHDT
{
    internal class KetNoiMySql
    {
        //mysql
        private MySqlConnection ketNoi;

        private string chuoiKetNoi = "server=localhost;database=shopdunk;uid=root;password=123456789;";

        public KetNoiMySql()
        {
            ketNoi = new MySqlConnection(chuoiKetNoi);
        }
        // Mở kết nối đến cơ sở dữ liệu
        public void MoKetNoi()
        {
            try
            {
                if (ketNoi.State != ConnectionState.Open)
                {
                    ketNoi.Open();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                throw new Exception("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        // Đóng kết nối đến cơ sở dữ liệu
        public void DongKetNoi()
        {
            try
            {
                if (ketNoi.State == ConnectionState.Open)
                {
                    ketNoi.Close();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi đóng kết nối
                throw new Exception("Lỗi đóng kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        // Thực hiện truy vấn SELECT và trả về một DataTable
        public DataTable ThucHienTruyVan(string truyVan)
        {
            using (MySqlConnection ketNoi = new MySqlConnection(chuoiKetNoi))
            {
                MoKetNoi();
                try
                {
                    ketNoi.Open();
                    MySqlCommand lenh = new MySqlCommand(truyVan, ketNoi);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(lenh);
                    DataTable bangDuLieu = new DataTable();
                    adapter.Fill(bangDuLieu);

                    return bangDuLieu;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi truy vấn: " + ex.Message);
                }
                finally
                {
                    DongKetNoi();
                }
            }
        }

        // Thực hiện các lệnh SQL như INSERT, UPDATE, DELETE
        public void ThucHienLenh(string lenhSql)
        {
            MoKetNoi();

            try
            {
                MySqlCommand lenh = new MySqlCommand(lenhSql, ketNoi);
                lenh.ExecuteNonQuery();      
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực hiện lệnh SQL: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

    }
}
