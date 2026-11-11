using System.Data;
using Bai6_1.DAL;
using Bai6_1.DTO;

namespace Bai6_1.BUS
{
    public class SanPhamBUS
    {
        SanPhamDAL dal = new SanPhamDAL();

        public DataTable TimKiemSanPham(string keyword)
        {
            return dal.TimKiemSanPham(keyword);
        }

        public bool ThemSanPham(SanPhamDTO sp)
        {
            return dal.ThemSanPham(sp);
        }

        public bool SuaSanPham(SanPhamDTO sp)
        {
            return dal.SuaSanPham(sp);
        }

        public bool XoaSanPham(string maSP)
        {
            return dal.XoaSanPham(maSP);
        }
    }
}