using AcentyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcentyShop.ViewModels
{
    public class DonHangVM
    {
        public DonHang DonHang { get; set; }
        public long? TongTien { get; set; }
        public List<ChiTietDonHang> ListChiTietDonHang { get; set; }
    }
}