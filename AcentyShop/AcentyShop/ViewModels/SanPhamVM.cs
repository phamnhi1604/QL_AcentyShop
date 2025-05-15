using AcentyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcentyShop.ViewModels
{
    public class SanPhamVM
    {
        public SanPham SanPham { get; set; }
        public long? Gia { get; set; }
        public SanPhamVM() { }
    }
}