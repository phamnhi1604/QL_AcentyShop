ALTER TABLE HoaDon
ADD IdDonHang bigint,
FOREIGN KEY (IdDonHang) REFERENCES DonHang(IdDonHang)


go 


alter table sanpham
add barcode varchar(225)