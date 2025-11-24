# Dự án Mã nguồn mở

---

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