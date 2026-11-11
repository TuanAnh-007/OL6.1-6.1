using System;
using System.Data;
using Bai6_1.DAL;

namespace Bai6_1.BUS
{
    public class ThongKeBUS
    {
        ThongKeDAL dal = new ThongKeDAL();

        public decimal TinhTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return dal.TinhTongDoanhThu(tuNgay, denNgay);
        }

        public DataTable LayTop5SanPhamBanChay()
        {
            return dal.LayTop5SanPhamBanChay();
        }
    }
}