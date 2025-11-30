# Dự án Mã nguồn mở

---

## Giới Thiệu
### 1. Cấu trúc thư mục dự án
#### - Chỉ cần quan tâm file `src`
#### - Chi tiết các project con
- Application - viết các API
- Core - để cấu hình Entities
- EntityFrameworkCore - quản lý DbContext
- Migrator - quản lý migration
- Web.Core - quản lý về Authentication & Author
- Web.Host - cấu hình dự án
- Web.Mvc - lưu trữ frontend dự án (quan trọng)

## 1. Trước khi bắt đầu chạy (Bắt buộc)

- Net 9 SDK


## 1. Add migrations
```bash
dotnet tool run dotnet-ef migrations add InitialTable \
    -p src/G7.Foss.EntityFrameworkCore/G7.Foss.EntityFrameworkCore.csproj \
    -s src/G7.Foss.Migrator/G7.Foss.Migrator.csproj

```

## 2. Update database
```bash
dotnet tool run dotnet-ef database update \
    -p src/G7.Foss.EntityFrameworkCore/G7.Foss.EntityFrameworkCore.csproj \
    -s src/G7.Foss.Migrator/G7.Foss.Migrator.csproj

```

## 3. Run
```bash
dotnet build
```

## 4. Chạy các thư viện node của mã nguồn mở
Truy cập vào thư mục chứa project frontend (/src/G7.Foss.Web.Mvc)
```bash
cd src/G7.Foss.Web.Mvc
```
Install các thư viện node được cấu hình trong package-lock.json
```bash
npm install # Lưu ý phải cài npm (tự cài)
```
Sau khi cài xong các thư viện hiện có cần chuyển các thư viện đó vào 1 thư mục chung wwwroot
```bash
npm install gulp --save-dev # Cài đặt gulp đã nhé
```
```bash
npx gulp build
```
## 5. Sau khi đã cài xong và cấu hình được framework mã nguồn mở Abp trên máy thì AE chạy thôi (nhớ `cd` quay lại gốc của dự án)

## 6. Sau khi chạy xong thì nó sẽ hiện lên trang có https://localhost:44312/ thì đăng nhập với 

- Tên đăng nhập: admin
- Password: 123qwe
