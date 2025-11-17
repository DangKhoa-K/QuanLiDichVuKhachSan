-- =============================================
-- Migration: Add TrangThai column to PHONG table
-- Date: 2025-11-17
-- Description: Adds room status tracking column with safe idempotent script
-- =============================================

USE QLDVKhachSan;
GO

-- Check if TrangThai column exists before adding
IF COL_LENGTH('dbo.PHONG', 'TrangThai') IS NULL
BEGIN
    PRINT 'Adding TrangThai column to PHONG table...';
    
    ALTER TABLE dbo.PHONG
    ADD TrangThai TINYINT NOT NULL DEFAULT(0);
    
    PRINT 'TrangThai column added successfully.';
    PRINT 'Status values: 0=Trống, 1=Đang ở, 2=Giữ chỗ, 3=Sắp trả, 4=Phòng sạch, 5=Phòng bẩn, 6=Đang sửa';
END
ELSE
BEGIN
    PRINT 'TrangThai column already exists. Skipping migration.';
END
GO
