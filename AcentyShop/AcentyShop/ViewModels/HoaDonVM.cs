using AcentyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcentyShop.ViewModels
{
    public class HoaDonVM
    {
        public HoaDon HoaDon { get; set; }
        public long? TongTien { get; set; }
        public List<ChiTietHoaDon> ListChiTietHoaDon { get; set; }
    }
}