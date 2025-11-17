-- ===== BẢNG CHÍNH =====
CREATE TABLE dbo.PHONG(
  PhongId   INT IDENTITY(1,1) PRIMARY KEY,
  SoPhong   VARCHAR(10) NOT NULL UNIQUE,
  GhiChu    NVARCHAR(200) NULL
);

CREATE TABLE dbo.KHACHHANG(
  KhachHangId INT IDENTITY(1,1) PRIMARY KEY,
  HoTen       NVARCHAR(100) NOT NULL,
  DienThoai   NVARCHAR(20) NULL,
  Email       NVARCHAR(100) NULL,
  CCCD        NVARCHAR(20) NULL,
  DiaChi      NVARCHAR(200) NULL
);

CREATE TABLE dbo.DICHVU(
  DichVuId    INT IDENTITY(1,1) PRIMARY KEY,
  TenDichVu   NVARCHAR(100) NOT NULL,
  DonVi       NVARCHAR(20) NULL,
  MoTa        NVARCHAR(200) NULL
);

CREATE TABLE dbo.BANGGIADICHVU(
  BangGiaId   INT IDENTITY(1,1) PRIMARY KEY,
  DichVuId    INT NOT NULL REFERENCES dbo.DICHVU(DichVuId) ON DELETE CASCADE,
  DonGia      DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
  HieuLucTu   DATETIME2(0)  NOT NULL,
  HieuLucDen  DATETIME2(0)  NULL
);
CREATE INDEX IX_BGDV_DV_TU_DEN ON dbo.BANGGIADICHVU(DichVuId, HieuLucTu, HieuLucDen);

CREATE TABLE dbo.SUDUNGDICHVU(
  SuDungId    INT IDENTITY(1,1) PRIMARY KEY,
  PhongId     INT NOT NULL REFERENCES dbo.PHONG(PhongId),
  KhachHangId INT NULL REFERENCES dbo.KHACHHANG(KhachHangId),
  DichVuId    INT NOT NULL REFERENCES dbo.DICHVU(DichVuId),
  ThoiDiem    DATETIME2(0) NOT NULL,
  SoLuong     DECIMAL(18,2) NOT NULL CONSTRAINT DF_SoLuong DEFAULT(1),
  DonGia      DECIMAL(18,2) NOT NULL,
  ThanhTien   AS (ROUND(SoLuong * DonGia, 0)),
  GhiChu      NVARCHAR(200) NULL
);
GO

-- ===== HÀM LẤY ĐƠN GIÁ HIỆU LỰC =====
CREATE OR ALTER FUNCTION dbo.fn_GetPriceAt(@DichVuId INT, @ThoiDiem DATETIME2(0))
RETURNS DECIMAL(18,2)
AS
BEGIN
  DECLARE @Gia DECIMAL(18,2);
  SELECT TOP(1) @Gia = DonGia
  FROM dbo.BANGGIADICHVU
  WHERE DichVuId=@DichVuId AND HieuLucTu<=@ThoiDiem
        AND (HieuLucDen IS NULL OR HieuLucDen>@ThoiDiem)
  ORDER BY HieuLucTu DESC;
  RETURN @Gia;
END
GO

-- ===== GIÁ: CHỐNG CHỒNG CHÉO =====
CREATE OR ALTER PROCEDURE dbo.usp_Price_Insert
  @DichVuId INT, @DonGia DECIMAL(18,2),
  @HieuLucTu DATETIME2(0), @HieuLucDen DATETIME2(0)=NULL
AS
BEGIN
  SET NOCOUNT ON;
  IF EXISTS (
    SELECT 1 FROM dbo.BANGGIADICHVU
    WHERE DichVuId=@DichVuId
      AND (HieuLucDen IS NULL OR @HieuLucTu < HieuLucDen)
      AND (@HieuLucDen IS NULL OR HieuLucTu < @HieuLucDen)
  )
  BEGIN RAISERROR(N'Khoảng hiệu lực bị chồng chéo.',16,1); RETURN; END

  INSERT dbo.BANGGIADICHVU(DichVuId,DonGia,HieuLucTu,HieuLucDen)
  VALUES(@DichVuId,@DonGia,@HieuLucTu,@HieuLucDen);
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_Price_Update
  @BangGiaId INT, @DonGia DECIMAL(18,2),
  @HieuLucTu DATETIME2(0), @HieuLucDen DATETIME2(0)=NULL
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @DichVuId INT=(SELECT DichVuId FROM dbo.BANGGIADICHVU WHERE BangGiaId=@BangGiaId);
  IF @DichVuId IS NULL BEGIN RAISERROR(N'Không tìm thấy bản ghi.',16,1); RETURN; END;

  IF EXISTS (
    SELECT 1 FROM dbo.BANGGIADICHVU
    WHERE DichVuId=@DichVuId AND BangGiaId<>@BangGiaId
      AND (HieuLucDen IS NULL OR @HieuLucTu < HieuLucDen)
      AND (@HieuLucDen IS NULL OR HieuLucTu < @HieuLucDen)
  ) BEGIN RAISERROR(N'Khoảng hiệu lực bị chồng chéo.',16,1); RETURN; END

  UPDATE dbo.BANGGIADICHVU
  SET DonGia=@DonGia, HieuLucTu=@HieuLucTu, HieuLucDen=@HieuLucDen
  WHERE BangGiaId=@BangGiaId;
END
GO

-- ===== GHI NHẬN SỬ DỤNG (TỰ CHỐT GIÁ) =====
CREATE OR ALTER PROCEDURE dbo.usp_RecordServiceUsage
  @PhongId INT, @DichVuId INT, @SoLuong DECIMAL(18,2),
  @ThoiDiem DATETIME2(0), @KhachHangId INT=NULL, @GhiChu NVARCHAR(200)=NULL
AS
BEGIN
  SET NOCOUNT ON;
  DECLARE @DonGia DECIMAL(18,2)=dbo.fn_GetPriceAt(@DichVuId,@ThoiDiem);
  IF @DonGia IS NULL BEGIN RAISERROR(N'Chưa có bảng giá hiệu lực tại thời điểm này.',16,1); RETURN; END

  INSERT dbo.SUDUNGDICHVU(PhongId,KhachHangId,DichVuId,ThoiDiem,SoLuong,DonGia,GhiChu)
  VALUES(@PhongId,@KhachHangId,@DichVuId,@ThoiDiem,@SoLuong,@DonGia,@GhiChu);
END
GO

-- ===== TRUY VẤN/BÁO CÁO =====
CREATE OR ALTER PROCEDURE dbo.usp_ListRoomsCustomersByService
  @DichVuId INT, @From DATETIME2(0), @To DATETIME2(0)
AS
BEGIN
  SELECT DISTINCT p.SoPhong, kh.HoTen, kh.DienThoai
  FROM dbo.SUDUNGDICHVU s
  LEFT JOIN dbo.PHONG p ON p.PhongId=s.PhongId
  LEFT JOIN dbo.KHACHHANG kh ON kh.KhachHangId=s.KhachHangId
  WHERE s.DichVuId=@DichVuId AND s.ThoiDiem BETWEEN @From AND @To
  ORDER BY p.SoPhong, kh.HoTen;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_RoomTotal
  @PhongId INT, @From DATETIME2(0), @To DATETIME2(0)
AS
BEGIN
  SELECT s.SuDungId, s.ThoiDiem, dv.TenDichVu, s.SoLuong, s.DonGia, s.ThanhTien
  FROM dbo.SUDUNGDICHVU s
  JOIN dbo.DICHVU dv ON dv.DichVuId=s.DichVuId
  WHERE s.PhongId=@PhongId AND s.ThoiDiem BETWEEN @From AND @To
  ORDER BY s.ThoiDiem;

  SELECT SUM(s.ThanhTien) AS TongTien
  FROM dbo.SUDUNGDICHVU s
  WHERE s.PhongId=@PhongId AND s.ThoiDiem BETWEEN @From AND @To;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_DailyRevenue @Ngay DATE
AS
BEGIN
  SELECT dv.TenDichVu, SUM(s.SoLuong) AS TongSL, SUM(s.ThanhTien) AS DoanhThu
  FROM dbo.SUDUNGDICHVU s
  JOIN dbo.DICHVU dv ON dv.DichVuId=s.DichVuId
  WHERE CAST(s.ThoiDiem AS DATE)=@Ngay
  GROUP BY dv.TenDichVu
  ORDER BY dv.TenDichVu;
END
GO

INSERT PHONG(SoPhong) VALUES('301'),('302'),('401'),('VIP1');
INSERT KHACHHANG(HoTen,DienThoai) VALUES(N'Nguyễn A','0901'),(N'Trần B','0902');
INSERT DICHVU(TenDichVu,DonVi) VALUES(N'Giặt ủi',N'lần'),(N'Nước suối',N'chai'),(N'Massage',N'giờ');

EXEC usp_Price_Insert 1, 20000, '2025-01-01', NULL;
EXEC usp_Price_Insert 2, 10000, '2025-01-01', NULL;
EXEC usp_Price_Insert 3,150000, '2025-01-01', NULL;

EXEC usp_RecordServiceUsage 1, 1, 2, '2025-11-10 09:15', 1, N'Giặt 2 lần';
EXEC usp_RecordServiceUsage 1, 2, 3, '2025-11-10 10:00', 1, N'Nước suối';
EXEC usp_RecordServiceUsage 2, 3, 1, '2025-11-10 20:00', 2, N'Massage';

	SELECT COUNT(*) Phong FROM PHONG;
	SELECT COUNT(*) DichVu FROM DICHVU;
	SELECT COUNT(*) Gia   FROM BANGGIADICHVU;
	SELECT TOP 10 * FROM SUDUNGDICHVU ORDER BY ThoiDiem DESC;



USE QLDVKhachSan;
GO
;WITH floors AS (SELECT n=1 UNION ALL SELECT n+1 FROM floors WHERE n<6),
     nums   AS (SELECT n=1 UNION ALL SELECT n+1 FROM nums   WHERE n<21)
INSERT dbo.PHONG(SoPhong)
SELECT CAST(f.n*100 + nums.n AS nvarchar(20))
FROM floors f CROSS JOIN nums
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.PHONG p
    WHERE p.SoPhong = CAST(f.n*100 + nums.n AS nvarchar(20))
);




