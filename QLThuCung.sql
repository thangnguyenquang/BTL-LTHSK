create database QuanLyThuCung

create table tblTaikhoan(
	sMaNV varchar(10) primary key,
	sMatKhau varchar(10)
	constraint FK_TaiKhoan_NhanVien
	FOREIGN KEY(sMaNV) REFERENCES tblNhanVien(sMaNV),
)

create table tblNhanVien
(
	sMaNV varchar(10) not null primary key ,
	sTenNV nvarchar(50) not null,
	sGioitinh nvarchar(5) not null,
	sDiaChi nvarchar(100) not null,
	dNgaySinh date not null,
	sSDT varchar(20) not null,
)

create table tblKhachHang
(
	sMaKH varchar(10) not null primary key, 
	sTenKH nvarchar(50) not null,
	dNgaySinh date not null,
	sDiaChi nvarchar(100) not null,
	sSDT varchar(20) not null
)

create table tblMatHang
(
	sMaMH varchar(10) not null primary key ,
	sTenMH nvarchar(50) not null,
	sMaLH varchar(10) not null,
	iSoLuong int not null,
	fGiaTien float not null

	CONSTRAINT FK_MatHang_LoaiMatHang
	FOREIGN KEY(sMaLH) REFERENCES tblLoaiMatHang(sMaLH),
)

create table tblLoaiMatHang(
	sMaLH varchar(10) not null primary key ,
	sTenLH nvarchar(50),
)

create table tblHoaDon
(
	sMaHD varchar(255) not null primary key,
	dNgayLap datetime not null,
	sMaNV varchar(10) not null,
	sMaKH varchar(10) not null,
	fTongTien float not null,

	CONSTRAINT FK_HoaDon_NhanVien 
	FOREIGN KEY(sMaNV) REFERENCES tblNhanVien(sMaNV),

	CONSTRAINT FK_HoaDon_KhachHang 
	FOREIGN KEY(sMaKH) REFERENCES tblKhachHang(sMaKH)
)

create table tblCTHoaDon
(
	sMaHD varchar(255) not null,
	sMaMH varchar(10) NOT NULL,
	fSLMH int, --số lượng mặt hàng
	fThanhTien float,
	fGiamGia float,

	CONSTRAINT FK_HD_CTHD
	FOREIGN KEY(sMaHD) REFERENCES tblHoaDon(sMaHD),

	CONSTRAINT PK_CTHD PRIMARY KEY(sMaHD,sMaMH),

	CONSTRAINT FK_CTHD_MatHang
	FOREIGN KEY(sMaMH) REFERENCES tblMatHang(sMaMH),
)



create proc pr_themKhachHang (@maKH varchar(10), @tenKH nvarchar(50), @ngaySinh date, @diaChi nvarchar(100), @SDT varchar(20))
as
begin
	insert into tblKhachHang 
	values(@maKH,  @tenKH, @ngaySinh, @diaChi, @SDT)
end

create proc pr_SuaKhachHang (@maKH varchar(10), @tenKH nvarchar(50), @ngaySinh date, @diaChi nvarchar(100), @SDT varchar(20))
as
begin
	update tblKhachHang 
	set sTenKH = @tenKH, dNgaySinh = @ngaySinh, sDiaChi = @diaChi, sSDT = @SDT
	where iMaKH = @maKH
end


--Nhân viên
create proc pr_themNhanVien (@maNV varchar(10), @tenNV nvarchar(50), @gioiTinh nvarchar(5), @diaChi nvarchar(100), @ngaySinh date, @SDT varchar(20))
as
begin
	insert into tblNhanVien 
	values(@maNV, @tenNV, @gioiTinh, @diaChi, @ngaySinh, @SDT)
end

create proc pr_SuaNhanVien (@maNV varchar(10), @tenNV nvarchar(50), @gioiTinh nvarchar(5), @diaChi nvarchar(100), @ngaySinh date, @SDT varchar(20))
as
begin
	update tblNhanVien 
	set sTenNV = @tenNV, @gioiTinh = sGioiTinh, sDiaChi = @diaChi, dNgaySinh = @ngaySinh, sSDT = @SDT
	where sMaNV = @maNV
end

--Loại mặt hàng
create proc pr_themLoaiMatHang(@maLH varchar(10), @tenLH nvarchar(10))
as
begin
	insert into tblLoaiMatHang
	values (@maLH, @tenLH)
end

create proc pr_suaLoaiMatHang(@maLH varchar(10), @tenLH nvarchar(10))
as
begin
	update tblLoaiMatHang
	set sTenLH = @tenLH
	where sMaLH = @maLH
end

--Mặt hàng
create proc pr_themMatHang (@maMH varchar(10), @tenMH nvarchar(50), @maLH varchar(10), @soLuong int, @giaTien float )
as
begin
	insert into tblMatHang 
	values(@maMH, @tenMH, @maLH, @soLuong, @giaTien)
end

create proc pr_suaMatHang (@maMH varchar(10), @tenMH nvarchar(50), @maLH varchar(10), @soLuong int, @giaTien float )
as
begin
	update tblMatHang 
	set sTenMH = @tenMH, sMaLH = @maLH, iSoLuong = @soLuong, fGiaTien = @giaTien
	where sMaMH = @maMH
end

--Hóa đơn
--Thêm hóa đơn
create proc pr_themHoaDon(@maHD varchar(255), @ngayLap datetime, @maNV varchar(10), @maKH varchar(10), @tongTien float)
as
begin
	insert into tblHoaDon
	values (@maHD, @ngayLap, @maNV, @maKH, @tongTien) 
end

alter proc pr_themCTHoaDon(@maHD varchar(255), @maMH varchar(10), @SLMH int ,@giamGia float, @thanhTien float)
as
begin
	insert into tblCTHoaDon
	values (@maHD, @maMH, @SLMH, @thanhTien, @giamGia) 
end

--Xóa cả hóa đơn và chi tiết hóa đơn, xóa tất cả
alter proc pr_xoaHD_CTHD (@maHD varchar(255))
as
begin
	delete tblCTHoaDon
	where sMaHD = @maHD
	delete tblHoaDon
	where sMaHD = @maHD
end

--Thủ tục lấy thông tin hóa đơn (phần crystal report in hóa đơn)
create proc pr_HoaDonBanHang (@maHD varchar(255))
as
begin
	select HD.sMaHD, HD.dNgayLap, KH.sTenKH, KH.sDiaChi, KH.sSDT, MH.sTenMH, CTHD.fSLMH, 
	MH.fGiaTien, CTHD.fGiamGia, CTHD.fThanhTien, HD.fTongTien, NV.sTenNV
	from tblHoaDon as HD, tblKhachHang as KH, tblCTHoaDon as CTHD, tblMatHang as MH, tblNhanVien as NV
	where HD.sMaHD = @maHD and HD.sMaHD = CTHD.sMaHD and HD.sMaKH = KH.sMaKH and HD.sMaNV = NV.sMaNV and CTHD.sMaMH = MH.sMaMH
end

exec pr_HoaDonBanHang 'HD3302022154237'

--Thủ tục thống kê doanh thu theo ngày 
create proc pr_DoanhThuTheoNgay(@ngay 

-----------------------------------Trigger xử lý phần hóa đơn---------------------------------------

--Trigger cập nhập số lượng mặt hàng khi thêm mặt hàng vào hóa đơn
create trigger tg_SoLuong_ThemMHHD
on tblCTHoaDon
for insert
as
begin
	declare @soLuongMua int , @maMH varchar(10)
	select @soLuongMua = fSLMH, @maMH = sMaMH from inserted

	update tblMatHang
	set iSoLuong = iSoLuong - @soLuongMua
	where sMaMH = @maMH
end

--Trigger cập nhập số lượng mặt hàng khi xóa mặt hàng khỏi hóa đơn
alter trigger tg_SoLuong_XoaMHHD
on tblCTHoaDon
for delete
as
begin
	declare @soLuongMua int , @maMH varchar(10)
	select @soLuongMua = fSLMH, @maMH = sMaMH from deleted

	update tblMatHang
	set iSoLuong = iSoLuong + @soLuongMua
	where sMaMH = @maMH
end

--Trigger cập nhập lại tổng tiền khi thêm mặt hàng vào hóa đơn
create trigger tg_TongTien_ThemMHHD
on tblCTHoaDon
for insert
as
begin
	DECLARE @maHD varchar(255), @thanhTien float
	select @maHD = sMaHD, @thanhTien = fThanhTien from inserted

	update tblHoaDon
	set fTongTien = fTongTien + @thanhTien
	where sMaHD =@maHD
end

--Trigger cập nhập lại tổng tiền khi xóa mặt hàng khỏi chi tiết hóa đơn
alter trigger tg_TongTien_XoaMHHD
on tblCTHoaDon
for delete
as
begin
	DECLARE @maHD varchar(255), @thanhTien float
	select @maHD = sMaHD, @thanhTien = fThanhTien from deleted

	update tblHoaDon
	set fTongTien = fTongTien - @thanhTien
	where sMaHD =@maHD
end





--Trigger tự động tạo tài khoản khi thêm nhân viên mới
create trigger pr_tuDongThemTaiKhoan
on tblNhanVien
for insert
as
begin
	declare @manv varchar(10) = (select sMaNV from inserted)
		insert into tblTaiKhoan values (@manv,'123456')
end

--ProC check đăng nhập
create proc pr_checkdangnhap
@tentaikhoan varchar(10),
@matkhau varchar(10)
as
begin
	if exists ( select*from tblTaiKhoan 
	inner join tblNhanVien on tblNhanVien.sMaNV = tblTaiKhoan.sMaNV
	where @tentaikhoan = tblTaiKhoan.sMaNV and @matkhau = sMatKhau )
		select 1 as code
	else if exists ( select*from tblTaiKhoan 
	inner join tblNhanVien on tblNhanVien.sMaNV = tblTaiKhoan.sMaNV
	where @tentaikhoan = tblTaiKhoan.sMaNV and @matkhau != sMatKhau )
		select 2 as code
	else select 3 as code
end