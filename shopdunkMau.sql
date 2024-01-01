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
  `SoLuong` int NOT NULL,
  `MaSP` varchar(100) NOT NULL,
  `MaDDH` varchar(100) NOT NULL,
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
  `SoLuongMua` int NOT NULL,
  `ThanhTien` float NOT NULL,
  KEY `fk_chitiethoadon_hoadon_idx` (`MaHD`),
  KEY `a_idx` (`MaSP`),
  CONSTRAINT `fk_chitiethoadon_hoadon` FOREIGN KEY (`MaHD`) REFERENCES `hoadon` (`MaHD`),
  CONSTRAINT `fk_chitiethoadon_sanpham` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitiethoadon`
--

LOCK TABLES `chitiethoadon` WRITE;
/*!40000 ALTER TABLE `chitiethoadon` DISABLE KEYS */;
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
  CONSTRAINT `fk_dondathang_nhanvien` FOREIGN KEY (`MaNV`) REFERENCES `nhanvien` (`MaNV`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dondathang`
--

LOCK TABLES `dondathang` WRITE;
/*!40000 ALTER TABLE `dondathang` DISABLE KEYS */;
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
INSERT INTO `khachhang` VALUES ('KH1','Khách hàng 1','Địa chỉ 1','3333333333'),('KH2','Khách hàng 2','Địa chỉ 2','4444444444');
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
INSERT INTO `loai` VALUES ('L1','Điện thoại di động'),('L2','Ốp lưng'),('L3','Tai nghe');
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
INSERT INTO `nhacungcap` VALUES ('NCC1','Samsung Supplier','Địa chỉ A','1111111111'),('NCC2','Apple Accessories','Địa chỉ B','2222222222');
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
INSERT INTO `nhanvien` VALUES ('NV1','admin','admin1','abc123','123','Tra vinh',1),('NV2','nhan vien 1','nhanvien1','abc123','123','Tra vinh',0);
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
INSERT INTO `sanpham` VALUES ('SP1','L1','Samsung Galaxy S21',15000000,50,'Samsung','Việt Nam'),('SP10','L1','Motorola Moto G Power',10000000,60,'Motorola','Mỹ'),('SP11','L1','Nokia 9 PureView',14000000,38,'Nokia','Phần Lan'),('SP12','L1','LG Velvet',11000000,48,'LG','Hàn Quốc'),('SP13','L1','Asus ROG Phone 5',25000000,15,'Asus','Đài Loan'),('SP14','L1','Huawei P50 Pro',24000000,18,'Huawei','Trung Quốc'),('SP15','L1','BlackBerry Key2',8000000,70,'BlackBerry','Canada'),('SP16','L1','HTC U20 5G',16000000,33,'HTC','Đài Loan'),('SP17','L1','ZTE Axon 30 Ultra',20000000,27,'ZTE','Trung Quốc'),('SP18','L1','Lenovo Legion Phone Duel',22000000,23,'Lenovo','Trung Quốc'),('SP19','L1','Meizu 18 Pro',19000000,29,'Meizu','Trung Quốc'),('SP2','L1','iPhone 13',20000000,30,'Apple','Mỹ'),('SP20','L1','Redmi Note 10',7000000,55,'Xiaomi','Trung Quốc'),('SP3','L1','Xiaomi Mi 11',12000000,40,'Xiaomi','Trung Quốc'),('SP4','L1','OnePlus 9',18000000,25,'OnePlus','Ấn Độ'),('SP5','L1','Google Pixel 6',22000000,20,'Google','Mỹ'),('SP6','L1','Sony Xperia 5 II',16000000,35,'Sony','Nhật Bản'),('SP7','L1','Realme GT',13000000,45,'Realme','Trung Quốc'),('SP8','L1','Vivo X70 Pro',19000000,28,'Vivo','Trung Quốc'),('SP9','L1','Oppo Find X3 Pro',17000000,22,'Oppo','Trung Quốc');
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

-- Dump completed on 2024-01-01  9:38:20
