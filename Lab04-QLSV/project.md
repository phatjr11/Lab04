# Đặc tả Dự án: Lab04-QLSV

## 1. Tổng quan Dự án
- **Tên dự án**: Lab04-QLSV
- **Loại ứng dụng**: Windows Forms Application (.NET Framework)
- **Mục đích**: Ứng dụng quản lý sinh viên và khoa (Faculty).
- **Ngôn ngữ lập trình**: C#

## 2. Công nghệ sử dụng
- **Target Framework**: .NET Framework 4.7.2
- **Data Access Layer (ORM)**: Entity Framework 6.2.0
- **Cơ sở dữ liệu**: SQL Server (LocalDB/SQLEXPRESS)
  - Connection String: `StudentContextDB` kết nối đến database `QuanLySinhVien`.

## 3. Cấu trúc Dự án

### Thư mục và File chính
- `Lab04-QLSV.csproj`: File cấu hình dự án chính.
- `Program.cs`: Điểm khởi chạy ứng dụng (Entry Point).
- `App.config`: Chứa cấu hình kết nối CSDL (Connection Strings).

### Models (Entity Framework Classes)
File nằm trong thư mục `Models/`:
- `StudentContextDB.cs`: `DbContext` chính, quản lý kết nối và các `DbSet`.
- `Student.cs`: Entity đại diện cho sinh viên.
- `Faculty.cs`: Entity đại diện cho khoa.

### Forms (Giao diện người dùng)
- `frmQLSV`: Form chính (khả năng cao là form quản lý danh sách sinh viên).
- `frmAddStudent`: Form thêm mới sinh viên? (tên file gợi ý).
- `frmFaculty`: Form quản lý khoa.
- `frmSearch`: Form tìm kiếm.

## 4. Thiết kế CSDL (Schema)

### Bảng: Faculty
- **FacultyID** (`int`, PK): Mã khoa.
- **FacultyName** (`string`, length 100, Required): Tên khoa.
- **TotalProfessor** (`int?`): Tổng số giáo sư (nullable).
- **Students** (`ICollection<Student>`): Danh sách sinh viên thuộc khoa (Quan hệ 1-n).

### Bảng: Student
- **StudentID** (`string`, length 10, PK): Mã số sinh viên.
- **FullName** (`string`, length 100, Required): Họ tên sinh viên.
- **AverageScore** (`double`): Điểm trung bình.
- **FacultyID** (`int?`, FK): Mã khoa (liên kết với bảng Faculty).
- **Faculty** (`Faculty`): Object tham chiếu đến khoa tương ứng.

## 5. Cấu hình Database
- `App.config` định nghĩa chuỗi kết nối `StudentContextDB` trỏ tới `10PC496\SQLEXPRESS` với database `QuanLySinhVien`.
