# Room Status Management - Implementation Guide

## Overview
This implementation adds comprehensive room status management to the hotel service management system (Quản lý dịch vụ khách sạn).

## Features Implemented

### 1. Database Schema Changes
- Added `TrangThai` column to `PHONG` table
- Migration script is idempotent (safe to run multiple times)
- Default value: 0 (Trống/Vacant)

### 2. Room Status Values
| Value | Vietnamese | English |
|-------|-----------|---------|
| 0 | Trống | Vacant |
| 1 | Đang ở | Occupied |
| 2 | Giữ chỗ | Reserved |
| 3 | Sắp trả | Checkout Soon |
| 4 | Phòng sạch | Clean |
| 5 | Phòng bẩn | Dirty |
| 6 | Đang sửa | Under Repair |

### 3. Safe Database Operations
The code handles both scenarios:
- ✅ Database **with** TrangThai column (normal operation)
- ✅ Database **without** TrangThai column (backward compatible, defaults to 0)

This ensures the application won't crash if the migration hasn't been run yet.

## Installation Steps

### Step 1: Run Database Migration
Execute the migration script on your SQL Server:

```sql
-- File: docs/migrations/2025-11-17_add_trangthai.sql
USE QLDVKhachSan;
GO

IF COL_LENGTH('dbo.PHONG', 'TrangThai') IS NULL
BEGIN
    ALTER TABLE dbo.PHONG
    ADD TrangThai TINYINT NOT NULL DEFAULT(0);
    PRINT 'TrangThai column added successfully.';
END
ELSE
BEGIN
    PRINT 'TrangThai column already exists. Skipping migration.';
END
GO
```

### Step 2: Build and Deploy
1. Open solution in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application

## Usage

### frmCatalog - Room Management
1. Open "Danh mục" from menu or sidebar
2. Navigate to "Phòng" tab
3. Use the new "Trạng thái" dropdown to select room status
4. Status is saved when adding or updating rooms

**Keyboard Shortcuts:**
- `Ctrl+N`: New (clear form)
- `Ctrl+A`: Add room
- `Ctrl+U`: Update room
- `Del`: Delete room
- `F5`: Refresh list

### frmMain - Room Board View
- Room status is automatically displayed with color coding
- Filter by status using the dropdown
- Search by room number using the text box
- Click "Làm mới" to refresh the view
- Changes made in frmCatalog are reflected immediately

### Status Color Coding
- **Trống (Vacant)**: Light green
- **Đang ở (Occupied)**: Light blue
- **Giữ chỗ (Reserved)**: Light orange
- **Sắp trả (Checkout Soon)**: Light pink
- **Phòng sạch (Clean)**: Light teal
- **Phòng bẩn (Dirty)**: Light purple
- **Đang sửa (Repair)**: Light gray

## Code Architecture

### Data Layer (`Data/Repos.cs`)
```csharp
public static class RoomRepo
{
    public static readonly string[] ROOM_STATUSES = { ... };
    
    // Safe methods that work with or without TrangThai column
    public static DataTable List();
    public static void Add(string soPhong, string ghiChu, int trangThai);
    public static void Update(int id, string soPhong, string ghiChu, int trangThai);
}
```

### Presentation Layer
- **frmCatalog**: CRUD operations with status selection
- **frmMain**: Display rooms with real-time status
- **RoomTile**: Individual room display component with color coding

### Synchronization
When rooms are added/updated/deleted in frmCatalog, the frmMain room board is automatically refreshed if it's open.

## Technical Details

### Backward Compatibility
- Old method signatures are preserved:
  - `RoomRepo.Add(soPhong, ghiChu)` still works
  - `RoomRepo.Update(id, soPhong, ghiChu)` still works
- New overloads accept status parameter:
  - `RoomRepo.Add(soPhong, ghiChu, trangThai)`
  - `RoomRepo.Update(id, soPhong, ghiChu, trangThai)`

### SQL Safety
All SQL operations check for column existence using `COL_LENGTH()`:
```sql
IF COL_LENGTH('PHONG', 'TrangThai') IS NOT NULL
    -- Use TrangThai column
ELSE
    -- Fall back to operation without TrangThai
```

### Performance Optimizations
- DoubleBuffered enabled on DataGridView and FlowLayoutPanel
- Single Paint handler registration in RoomTile
- Efficient filtering in room board

## Testing

### Test Scenarios
1. ✅ **Without migration**: App runs without errors, status defaults to "Trống"
2. ✅ **After migration**: Status is saved and displayed correctly
3. ✅ **CRUD operations**: Add, update, delete rooms with status
4. ✅ **Synchronization**: Changes in frmCatalog reflect in frmMain
5. ✅ **Keyboard shortcuts**: All shortcuts work as expected
6. ✅ **Filtering**: Filter by status and search by room number

## Troubleshooting

### Issue: "Invalid column name 'TrangThai'"
**Solution**: Run the migration script (Step 1 above)

### Issue: Status not saving
**Check**: Ensure migration was successful by running:
```sql
SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'PHONG' AND COLUMN_NAME = 'TrangThai'
```

### Issue: frmMain not refreshing after CRUD
**Check**: Ensure frmMain is open when performing CRUD operations in frmCatalog

## Files Modified

### New Files
- `docs/migrations/2025-11-17_add_trangthai.sql` - Database migration
- `.gitignore` - Git ignore rules

### Modified Files
- `Data/Repos.cs` - Safe status handling, ROOM_STATUSES constant
- `frmCatalog.Designer.cs` - Added status ComboBox
- `frmCatalog.cs` - Status CRUD, keyboard shortcuts, refresh logic
- `frmMain.cs` - Real status display, public RefreshRoomBoard()
- `Controls/RoomTile.cs` - Fixed Paint handler registration

## Future Enhancements

Possible improvements:
1. Add status change history tracking
2. Add bulk status update
3. Add status-based reporting
4. Add automatic status transitions (e.g., Occupied → Dirty after checkout)
5. Add status change notifications

## Support

For issues or questions, please contact the development team or refer to the main project documentation.
