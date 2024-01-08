-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: shopdunk
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chitietdondathang`
--

DROP TABLE IF EXISTS `chitietdondathang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietdondathang` (
  `MaSP` varchar(100) NOT NULL,
  `MaDDH` varchar(100) NOT NULL,
  `GiaSP` float NOT NULL,
  `SoLuong` int NOT NULL,
  `ThanhTien` float NOT NULL,
  KEY `fk_chitietdonhang_sanpham_idx` (`MaSP`),
  KEY `fk_chitietdonhang_dondathang_idx` (`MaDDH`),
  CONSTRAINT `fk_chitietdonhang_dondathang` FOREIGN KEY (`MaDDH`) REFERENCES `dondathang` (`MaDDH`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_chitietdonhang_sanpham` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietdondathang`
--

LOCK TABLES `chitietdondathang` WRITE;
/*!40000 ALTER TABLE `chitietdondathang` DISABLE KEYS */;
INSERT INTO `chitietdondathang` VALUES ('SP001','DDH8DC0C761ED966FD',12000000,20,240000000),('SP031','DDH8DC0C765BB58771',7000000,20,140000000),('SP043','DDH8DC0C767C463C79',3000000,50,150000000),('SP050','DDH8DC0C7694E8F17D',300000,50,15000000),('SP040','DDH8DC0C76C44B9D03',3500000,1,3500000),('SP043','DDH8DC0C76C44B9D03',3000000,20,60000000),('SP039','DDH8DC0C76C44B9D03',5000000,20,100000000),('SP036','DDH8DC0C76CCD17BA0',6000000,20,120000000),('SP041','DDH8DC0C76E36C09C6',6500000,10,65000000),('SP043','DDH8DC0C76E36C09C6',3000000,10,30000000),('SP001','DDH8DC0C881BB8C71F',12000000,4,48000000),('SP028','DDH8DC0C881BB8C71F',5000000,4,20000000),('SP001','DDH8DC0C8831E7F277',12000000,7,84000000),('SP043','DDH8DC0CFA5750A7D7',3000000,10,30000000);
/*!40000 ALTER TABLE `chitietdondathang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitiethoadon`
--

DROP TABLE IF EXISTS `chitiethoadon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitiethoadon` (
  `MaSP` varchar(100) NOT NULL,
  `MaHD` varchar(100) NOT NULL,
  `GiaSP` float NOT NULL,
  `SoLuongMua` int NOT NULL,
  `ThanhTien` float NOT NULL,
  KEY `fk_chitiethoadon_hoadon_idx` (`MaHD`),
  KEY `a_idx` (`MaSP`),
  CONSTRAINT `fk_chitiethoadon_hoadon` FOREIGN KEY (`MaHD`) REFERENCES `hoadon` (`MaHD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitiethoadon`
--

LOCK TABLES `chitiethoadon` WRITE;
/*!40000 ALTER TABLE `chitiethoadon` DISABLE KEYS */;
INSERT INTO `chitiethoadon` VALUES ('SP001','HD8DC0C732665669B',12000000,1,12000000),('SP002','HD8DC0C732665669B',10000000,1,10000000),('SP003','HD8DC0C732665669B',9000000,1,9000000),('SP003','HD8DC0C757E380A2D',9000000,1,9000000),('SP002','HD8DC0C757E380A2D',10000000,1,10000000),('SP008','HD8DC0C75969E05CC',6000000,1,6000000),('SP009','HD8DC0C75969E05CC',7500000,1,7500000),('SP014','HD8DC0C75A885DE81',18000000,1,18000000),('SP015','HD8DC0C75A885DE81',12000000,1,12000000),('SP022','HD8DC0C75B3CF7922',9000000,1,9000000),('SP021','HD8DC0C75B3CF7922',9500000,1,9500000),('SP048','HD8DC0C75C2850F1A',50000,1,50000),('SP049','HD8DC0C75C2850F1A',800000,1,800000),('SP049','HD8DC0C75D78A4BBA',800000,1,800000),('SP051','HD8DC0C75D78A4BBA',100000,1,100000),('SP017','HD8DC0C75E9E0DD01',11000000,1,11000000),('SP022','HD8DC0C75E9E0DD01',9000000,1,9000000),('SP022','HD8DC0C75F7737571',9000000,1,9000000),('SP021','HD8DC0C760A54E554',9500000,1,9500000),('SP020','HD8DC0C760A54E554',8000000,1,8000000),('SP001','HD8DC0CB8457AECA4',12000000,1,12000000),('SP010','HD8DC0CB8457AECA4',9000000,1,9000000),('SP014','HD8DC0C71231ASDSA',20000000,1,20000000),('SP021','HD8DC0C7123123122',17500000,1,17500000),('SP001','HD8DC0CF9FFC0CC79',12000000,1,12000000),('SP002','HD8DC0CF9FFC0CC79',10000000,1,10000000),('SP010','HD8DC0D04BB1FE73B',9000000,1,9000000),('SP022','HD8DC0D04BB1FE73B',9000000,2,18000000),('SP010','HD8DC0D04E78C5509',9000000,10,90000000);
/*!40000 ALTER TABLE `chitiethoadon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dondathang`
--

DROP TABLE IF EXISTS `dondathang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dondathang` (
  `MaDDH` varchar(100) NOT NULL,
  `MaNV` varchar(100) NOT NULL,
  `NgayLapDDH` datetime NOT NULL,
  `MaNCC` varchar(100) NOT NULL,
  `TongTien` float NOT NULL,
  PRIMARY KEY (`MaDDH`),
  KEY `fk_dondathang_nhanvien_idx` (`MaNV`),
  KEY `fk_dondathang_nhanvien_idx1` (`MaNCC`),
  CONSTRAINT `fk_dondathang_nhacungcap` FOREIGN KEY (`MaNCC`) REFERENCES `nhacungcap` (`MaNCC`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_dondathang_nhanvien` FOREIGN KEY (`MaNV`) REFERENCES `nhanvien` (`MaNV`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dondathang`
--

LOCK TABLES `dondathang` WRITE;
/*!40000 ALTER TABLE `dondathang` DISABLE KEYS */;
INSERT INTO `dondathang` VALUES ('DDH8DC0C761ED966FD','NV006','2024-01-03 16:07:44','NCC001',240000000),('DDH8DC0C765BB58771','NV006','2024-01-03 16:09:26','NCC004',140000000),('DDH8DC0C767C463C79','NV006','2024-01-03 16:10:21','NCC001',150000000),('DDH8DC0C7694E8F17D','NV006','2024-01-03 16:11:02','NCC004',15000000),('DDH8DC0C76C44B9D03','NV006','2024-01-03 16:12:21','NCC002',163500000),('DDH8DC0C76CCD17BA0','NV006','2024-01-03 16:12:36','NCC001',120000000),('DDH8DC0C76E36C09C6','NV006','2024-01-03 16:13:14','NCC001',95000000),('DDH8DC0C881BB8C71F','NV006','2024-01-03 18:16:29','NCC004',68000000),('DDH8DC0C8831E7F277','NV006','2024-01-03 18:17:07','NCC009',84000000),('DDH8DC0CFA5750A7D7','NV006','2024-01-04 07:54:12','NCC007',30000000);
/*!40000 ALTER TABLE `dondathang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hoadon`
--

DROP TABLE IF EXISTS `hoadon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hoadon` (
  `MaHD` varchar(100) NOT NULL,
  `MaKH` varchar(100) NOT NULL,
  `MaNV` varchar(100) NOT NULL,
  `NgayLapHD` datetime NOT NULL,
  `TongTien` float NOT NULL,
  PRIMARY KEY (`MaHD`),
  KEY `MaKH_idx` (`MaKH`),
  KEY `fk_hoadon_nhanvien_idx` (`MaNV`),
  CONSTRAINT `fk_hoadon_khachhang` FOREIGN KEY (`MaKH`) REFERENCES `khachhang` (`MaKH`),
  CONSTRAINT `fk_hoadon_nhanvien` FOREIGN KEY (`MaNV`) REFERENCES `nhanvien` (`MaNV`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hoadon`
--

LOCK TABLES `hoadon` WRITE;
/*!40000 ALTER TABLE `hoadon` DISABLE KEYS */;
INSERT INTO `hoadon` VALUES ('HD8DC0C7123123122','KH001','NV002','2023-01-03 16:07:09',17500000),('HD8DC0C71231ASDSA','KH006','NV002','2023-12-29 16:07:09',20000000),('HD8DC0C732665669B','KH001','NV006','2024-01-03 15:46:28',31000000),('HD8DC0C757E380A2D','KH001','NV006','2024-01-03 16:03:14',19000000),('HD8DC0C75969E05CC','KH001','NV006','2024-01-03 16:03:55',13500000),('HD8DC0C75A885DE81','KH002','NV006','2024-01-03 16:04:25',30000000),('HD8DC0C75B3CF7922','KH002','NV006','2024-01-03 16:04:44',18500000),('HD8DC0C75C2850F1A','KH002','NV006','2024-01-03 16:05:09',850000),('HD8DC0C75D78A4BBA','KH003','NV006','2024-01-03 16:05:44',900000),('HD8DC0C75E9E0DD01','KH003','NV006','2024-01-03 16:06:15',20000000),('HD8DC0C75F7737571','KH005','NV006','2024-01-03 16:06:38',9000000),('HD8DC0C760A54E554','KH005','NV006','2024-01-03 16:07:09',17500000),('HD8DC0CB8457AECA4','KH8DC0CB84500B3BB','NV006','2024-01-04 00:01:15',21000000),('HD8DC0CF9FFC0CC79','KH001','NV006','2024-01-04 07:51:45',22000000),('HD8DC0D04BB1FE73B','KH8DC0D04BAADE3FE','NV006','2024-01-04 09:08:35',27000000),('HD8DC0D04E78C5509','KH8DC0D04E718487F','NV006','2024-01-04 09:09:49',90000000);
/*!40000 ALTER TABLE `hoadon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `khachhang`
--

DROP TABLE IF EXISTS `khachhang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `khachhang` (
  `MaKH` varchar(100) NOT NULL,
  `TenKH` varchar(255) NOT NULL,
  `DiaChiKH` varchar(255) NOT NULL,
  `SoDienThoaiKH` varchar(100) NOT NULL,
  PRIMARY KEY (`MaKH`),
  UNIQUE KEY `SoDienThoaiKH_UNIQUE` (`SoDienThoaiKH`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `khachhang`
--

LOCK TABLES `khachhang` WRITE;
/*!40000 ALTER TABLE `khachhang` DISABLE KEYS */;
INSERT INTO `khachhang` VALUES ('KH001','Nguyễn Văn A','123 Đường ABC, Quận 1, TP.Hồ Chí Minh','0901234567'),('KH002','Trần Thị B','456 Đường XYZ, Quận 2, TP.Hồ Chí Minh','0912345678'),('KH003','Lê Văn C','789 Đường LMN, Quận 3, TP.Hồ Chí Minh','0923456789'),('KH004','Phạm Thị D','234 Đường DEF, Quận 4, TP.Hồ Chí Minh','0934567890'),('KH005','Hoàng Văn E','567 Đường GHI, Quận 5, TP.Hồ Chí Minh','0945678901'),('KH006','Nguyễn Thị F','890 Đường JKL, Quận 6, TP.Hồ Chí Minh','0956789012'),('KH007','Trần Văn G','345 Đường MNO, Quận 7, TP.Hồ Chí Minh','0967890123'),('KH008','Lê Thị H','678 Đường PQR, Quận 8, TP.Hồ Chí Minh','0978901234'),('KH009','Phạm Văn I','901 Đường STU, Quận 9, TP.Hồ Chí Minh','0989012345'),('KH010','Hoàng Thị K','112 Đường VWX, Quận 10, TP.Hồ Chí Minh','0990123456'),('KH8DC0CB84500B3BB','KHACH HANG ','TRA VINH','21312312'),('KH8DC0D04BAADE3FE','ádasdsa','ádsads','123232'),('KH8DC0D04E718487F','ádsad','ádasdasd','123123');
/*!40000 ALTER TABLE `khachhang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loai`
--

DROP TABLE IF EXISTS `loai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loai` (
  `MaLoai` varchar(100) NOT NULL,
  `TenLoai` varchar(255) NOT NULL,
  PRIMARY KEY (`MaLoai`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loai`
--

LOCK TABLES `loai` WRITE;
/*!40000 ALTER TABLE `loai` DISABLE KEYS */;
INSERT INTO `loai` VALUES ('L001','Điện thoại di động'),('L002','Tablet'),('L003','Smartwatch'),('L004','Tai nghe'),('L005','Phụ kiện điện thoại');
/*!40000 ALTER TABLE `loai` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhacungcap`
--

DROP TABLE IF EXISTS `nhacungcap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhacungcap` (
  `MaNCC` varchar(100) NOT NULL,
  `TenNCC` varchar(255) NOT NULL,
  `DiaChiNCC` varchar(255) NOT NULL,
  `SoDienThoaiNCC` varchar(100) NOT NULL,
  PRIMARY KEY (`MaNCC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhacungcap`
--

LOCK TABLES `nhacungcap` WRITE;
/*!40000 ALTER TABLE `nhacungcap` DISABLE KEYS */;
INSERT INTO `nhacungcap` VALUES ('NCC001','Công ty A','123 Đường ABC, Quận 1, TP.HCM','0123456789'),('NCC002','Công ty B','456 Đường XYZ, Quận 2, TP.HCM','0987654321'),('NCC003','Công ty C','789 Đường LMN, Quận 3, TP.HCM','0111222333'),('NCC004','Công ty D','101 Đường PQR, Quận 4, TP.HCM','0444555666'),('NCC005','Công ty E','202 Đường UVW, Quận 5, TP.HCM','0777888999'),('NCC006','Công ty F','303 Đường HIJ, Quận 6, TP.HCM','0222333444'),('NCC007','Công ty G','404 Đường STU, Quận 7, TP.HCM','0555666777'),('NCC008','Công ty H','505 Đường XYZ, Quận 8, TP.HCM','0888999000'),('NCC009','Công ty I','606 Đường LMN, Quận 9, TP.HCM','0999111222'),('NCC010','Công ty J','707 Đường ABC, Quận 10, TP.HCM','0333444555');
/*!40000 ALTER TABLE `nhacungcap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhanvien`
--

DROP TABLE IF EXISTS `nhanvien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhanvien` (
  `MaNV` varchar(100) NOT NULL,
  `TenNV` varchar(255) NOT NULL,
  `TaiKhoanNV` varchar(255) NOT NULL,
  `MatKhauNV` varchar(255) NOT NULL,
  `SoDienThoaiNV` varchar(255) NOT NULL,
  `DiaChiNV` varchar(255) NOT NULL,
  `LoaiNV` int NOT NULL,
  PRIMARY KEY (`MaNV`),
  UNIQUE KEY `TaiKhoanNV_UNIQUE` (`TaiKhoanNV`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhanvien`
--

LOCK TABLES `nhanvien` WRITE;
/*!40000 ALTER TABLE `nhanvien` DISABLE KEYS */;
INSERT INTO `nhanvien` VALUES ('NV001','Nguyen Van A','nhanvien','nhanvien','123456789','Hanoi',0),('NV002','Tran Thi B','nv002_tk','mk456','987654321','Ho Chi Minh',1),('NV003','Le Van C','nv003_tk','mk789','111222333','Da Nang',0),('NV004','Pham Thi D','nv004_tk','mkabc','444555666','Can Tho',1),('NV005','Hoang Van E','nv005_tk','mklmn','777888999','Hue',0),('NV006','Nguyen Thi F','admin','admin','222333444','Nha Trang',1),('NV007','Trinh Van G','nv007_tk','mkqwe','555666777','Vinh',0),('NV008','Nguyen Van H','nv008_tk','mkxyz','888999000','Quang Ninh',1),('NV009','Le Thi I','nv009_tk','mk123','123123123','Bac Giang',0),('NV010','Pham Van J','nv010_tk','mk456','456456456','Binh Dinh',0);
/*!40000 ALTER TABLE `nhanvien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sanpham`
--

DROP TABLE IF EXISTS `sanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sanpham` (
  `MaSP` varchar(100) NOT NULL,
  `MaLoai` varchar(100) NOT NULL,
  `TenSP` varchar(255) NOT NULL,
  `GiaSP` float NOT NULL,
  `SoLuongTonKho` int NOT NULL,
  `HangSP` varchar(255) NOT NULL,
  `XuatXuSP` varchar(255) NOT NULL,
  `MoTaSP` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`MaSP`),
  KEY `fk_sanpham_loai_idx` (`MaLoai`),
  CONSTRAINT `fk_sanpham_loai` FOREIGN KEY (`MaLoai`) REFERENCES `loai` (`MaLoai`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sanpham`
--

LOCK TABLES `sanpham` WRITE;
/*!40000 ALTER TABLE `sanpham` DISABLE KEYS */;
INSERT INTO `sanpham` VALUES ('SP001','L001','iPhone 13',12000000,78,'Apple','USA','Điện thoại iPhone 13 mới nhất'),('SP002','L001','Samsung Galaxy S21',10000000,37,'Samsung','Hàn Quốc','Điện thoại Samsung Galaxy S21'),('SP003','L001','Google Pixel 6',9000000,28,'Google','Mỹ','Điện thoại Google Pixel 6'),('SP004','L001','iPhone 12',11000000,45,'Apple','USA','Điện thoại iPhone 12'),('SP005','L001','OnePlus 9',9500000,35,'OnePlus','Trung Quốc','Điện thoại OnePlus 9'),('SP006','L001','Xiaomi Mi 11',8000000,25,'Xiaomi','Trung Quốc','Điện thoại Xiaomi Mi 11'),('SP007','L001','iPhone SE (2020)',7000000,40,'Apple','USA','Điện thoại iPhone SE (2020)'),('SP008','L001','Samsung Galaxy A52',6000000,14,'Samsung','Hàn Quốc','Điện thoại Samsung Galaxy A52'),('SP009','L001','Google Pixel 5a',7500000,27,'Google','Mỹ','Điện thoại Google Pixel 5a'),('SP010','L001','iPhone 11',9000000,10,'Apple','USA','Điện thoại iPhone 11'),('SP011','L001','OnePlus Nord 2',8500000,18,'OnePlus','Trung Quốc','Điện thoại OnePlus Nord 2'),('SP012','L001','Xiaomi Redmi Note 10',5000000,12,'Xiaomi','Trung Quốc','Điện thoại Xiaomi Redmi Note 10'),('SP013','L001','Samsung Galaxy S22',15000000,20,'Samsung','Hàn Quốc','Samsung Galaxy S22'),('SP014','L001','iPhone 14',18000000,14,'Apple','USA','iPhone 14'),('SP015','L001','OnePlus 10',12000000,29,'OnePlus','Trung Quốc','OnePlus 10'),('SP016','L001','Google Pixel 7',13000000,25,'Google','Mỹ','Google Pixel 7'),('SP017','L001','Xiaomi Mi 12',11000000,27,'Xiaomi','Trung Quốc','Xiaomi Mi 12'),('SP018','L001','Sony Xperia 5 III',14000000,22,'Sony','Nhật Bản','Sony Xperia 5 III'),('SP019','L001','Huawei P50',10000000,35,'Huawei','Trung Quốc','Huawei P50'),('SP020','L001','LG G8 ThinQ',8000000,39,'LG','Hàn Quốc','LG G8 ThinQ'),('SP021','L001','Motorola Edge 20',9500000,16,'Motorola','Mỹ','Motorola Edge 20'),('SP022','L001','Nokia 9 PureView',9000000,21,'Nokia','Phần Lan','Nokia 9 PureView'),('SP023','L002','iPad Pro 12.9-inch',15000000,20,'Apple','USA','iPad Pro 12.9-inch mới nhất'),('SP024','L002','Samsung Galaxy Tab S7',12000000,15,'Samsung','Hàn Quốc','Samsung Galaxy Tab S7'),('SP025','L002','Microsoft Surface Pro 7',13000000,18,'Microsoft','Mỹ','Microsoft Surface Pro 7'),('SP026','L002','Lenovo Tab P11 Pro',10000000,12,'Lenovo','Trung Quốc','Lenovo Tab P11 Pro'),('SP027','L002','Huawei MatePad Pro',11000000,16,'Huawei','Trung Quốc','Huawei MatePad Pro'),('SP028','L002','Amazon Fire HD 10',5000000,29,'Amazon','Mỹ','Amazon Fire HD 10'),('SP029','L002','Xiaomi Mi Pad 5',9000000,14,'Xiaomi','Trung Quốc','Xiaomi Mi Pad 5'),('SP030','L002','Asus ZenPad 3S 10',8000000,22,'Asus','Đài Loan','Asus ZenPad 3S 10'),('SP031','L002','Sony Xperia Z4 Tablet',7000000,39,'Sony','Nhật Bản','Sony Xperia Z4 Tablet'),('SP032','L002','Google Pixel Slate',9500000,17,'Google','Mỹ','Google Pixel Slate'),('SP033','L003','Apple Watch Series 7',8000000,30,'Apple','USA','Apple Watch Series 7 mới nhất'),('SP034','L003','Samsung Galaxy Watch 4',7000000,25,'Samsung','Hàn Quốc','Samsung Galaxy Watch 4'),('SP035','L003','Fitbit Versa 3',4000000,40,'Fitbit','Mỹ','Fitbit Versa 3'),('SP036','L003','Garmin Venu 2',6000000,55,'Garmin','Mỹ','Garmin Venu 2'),('SP037','L003','Huawei Watch GT 3',5500000,28,'Huawei','Trung Quốc','Huawei Watch GT 3'),('SP038','L003','Amazfit GTR 3',4500000,38,'Amazfit','Trung Quốc','Amazfit GTR 3'),('SP039','L003','Fossil Gen 6',5000000,52,'Fossil','Mỹ','Fossil Gen 6'),('SP040','L003','Xiaomi Mi Watch',3500000,46,'Xiaomi','Trung Quốc','Xiaomi Mi Watch'),('SP041','L003','Sony SmartWatch 4',6500000,32,'Sony','Nhật Bản','Sony SmartWatch 4'),('SP042','L003','Garmin Lily',4800000,20,'Garmin','Mỹ','Garmin Lily'),('SP043','L004','Sony WH-1000XM4',3000000,130,'Sony','Nhật Bản','Tai nghe chống ồn Sony WH-1000XM4'),('SP044','L004','Bose QuietComfort 35 II',2800000,35,'Bose','Mỹ','Tai nghe chống ồn Bose QuietComfort 35 II'),('SP045','L004','AirPods Pro',2500000,50,'Apple','USA','Tai nghe không dây AirPods Pro'),('SP046','L004','JBL Free X',1500000,60,'JBL','Mỹ','Tai nghe không dây JBL Free X'),('SP047','L004','Sennheiser HD 660 S',3500000,30,'Sennheiser','Đức','Tai nghe over-ear Sennheiser HD 660 S'),('SP048','L005','Ốp lưng Silicon',50000,99,'Sony','Nhật Bản','Ốp lưng Silicon dành cho nhiều loại điện thoại'),('SP049','L005','Tai nghe Bluetooth',800000,28,'Sony','Nhật Bản','Tai nghe Bluetooth không dây'),('SP050','L005','Sạc không dây',300000,100,'Samsung','Hàn Quốc','Sạc không dây nhanh'),('SP051','L005','Dây cáp USB-C',100000,79,'Anker','Trung Quốc','Dây cáp USB-C chất lượng cao'),('SP052','L005','Gậy tự sướng Bluetooth',150000,60,'Xiaomi','Trung Quốc','Gậy tự sướng có kết nối Bluetooth');
/*!40000 ALTER TABLE `sanpham` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-08 19:51:25
