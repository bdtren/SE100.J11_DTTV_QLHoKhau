/*==============================================================*/
/* DBMS name:      Quan Ly Ho Khau                              */
/* Created on:     10/20/2018 12:11:22 PM                       */
/*==============================================================*/

/*==============================================================*/
/* Table: NGHE NGHIEP                                           */
/*==============================================================*/
create table NGHENGHIEP
(
    MANGHENGHIEP                       char(9),
    TENNGHENGHIEP                       text,
    primary key (MANGHENGHIEP)
);

/*==============================================================*/
/* Table: HOC SINH SINH VIEN                                    */
/*==============================================================*/
create table HOCSINHSINHVIEN
(
    MSSV                                varchar(10),
    MANGHENGHIEP                        char(9),
    TRUONG                              text,
    DIACHITHUONGTRU                     text,
    THOIGIANBATDAUTAMTRUTHUONGTRU       date,
    THOIGIANKETTHUCTAMTRUTHUONGTRU      date,
    VIPHAM                              text,
    primary key (MSSV)
);

/*==============================================================*/
/* Table: NHAN KHAU                                             */
/*==============================================================*/
create table NHANKHAU
(
    
    MADINHDANH          varchar(20),
    MANGHENGHIEP        char(9),
    HOTEN               varchar(20),
    GIOITINH            varchar(10),
    DANTOC              varchar(20),
    HOCHIEU             varchar(20),
    NGAYCAP             date,
    NGAYSINH            date,
    NGUYENQUAN          text,
    NOICAP              text,
    NOISINH             text,
    QUOCTICH            varchar(20),
    SDT                 char(10),
    TONGIAO             varchar(20),
    
    primary key (MADINHDANH)
);


/*==============================================================*/
/* Table:   TAM VANG                                            */
/*==============================================================*/
create table NHANKHAUTAMVANG
(
    MANHANKHAUTAMVANG       char(9),         
    MANHANKHAUTHUONGTRU     char(9),
    NOITHUONGTRUTAMTRU      text,
    NGAYBATDAUTAMVANG       date,
    THOIGIANKETTHUCTAMVANG  date,
    LYDO                    text,
    NOIDEN                  text,

    primary key (MANHANKHAUTAMVANG)
);

/*==============================================================*/
/* Table: SO HO KHAU                                            */
/*==============================================================*/
create table SOHOKHAU
(
    SOSOHOKHAU              char(13),
    MACHUHO                 char(9),
    DIACHI                  text,
    NGAYCAP                 date,
    SODANGKY                text,

    primary key (SOSOHOKHAU)
);

/*==============================================================*/
/* Table: NHAN KHAU TAM TRU                                     */
/*==============================================================*/
create table NHANKHAUTAMTRU
(
    MANHAKHAUTAMTRU         char(9),
    MADINHDANH              varchar(20),
    DIACHITHUONGTRU         text,
    SOSOTAMTRU              char(9),

    primary key (MANHAKHAUTAMTRU)
);

/*==============================================================*/
/* Table: SO TAM TRU                                            */
/*==============================================================*/
create table SOTAMTRU
(
    SOSOTAMTRU              char(9),
    MACHUHOTAMTRU           char(9),
    CHOOHIENNAY             text,
    TUNGAY                  date,
    DENNGAY                 date,
    LYDO                    text,

    primary key (SOSOTAMTRU)   
);

/*==============================================================*/
/* Table: NHAN KHAU THUONG TRU                                  */
/*==============================================================*/
create table NHANKHAUTHUONGTRU
(
    MANHANKHAUTHUONGTRU     char(9),
    MADINHDANH              varchar(20),
    SOSOHOKHAU              char(13),
    NOITHUONGTRUTAMTRU      text,
    DIACHIHIENTAI           text,
    TRINHDOHOCVAN           text,
    TRINHDOCHUYENMON        text,
    BIETTIENGDANTOC         text,
    TRINHDONGOAINGU         text,
    NOILAMVIEC              text,
    QUANHEVOICHUHO          text,

    primary key (MANHANKHAUTHUONGTRU)
);

/*==============================================================*/
/* Table: CAN BO                                                */
/*==============================================================*/
create table CANBO
(
    MACANBO                 char(9),
    MANHANKHAUTHUONGTRU     char(9),
    TENDANGNHAP             varchar(20),
    MATKHAU                 varchar(40),

    primary key (MACANBO)
);

/*==============================================================*/
/* Table: CAN BO HO TICH                                               */
/*==============================================================*/
create table CANBOHOTICH
(
    MACANBOHOTICH           char(9),
    MACANBO                 char(9),

    primary key (MACANBOHOTICH)
);

/*==============================================================*/
/* Table: TIEU SU                                               */
/*==============================================================*/
create table TIEUSU
(
    MATIEUSU                char(9),
    MADINHDANH              varchar(20),
    THOIGIANBATDAU          date,
    THOIGIANKETTHUC         date,
    CHOO                    text,
    MANGHENGHIEP            char(9),
    NOILAMVIEC              text,

    primary key (MATIEUSU)
);

/*==============================================================*/
/* Table: TIEN AN TIEN SU                                       */
/*==============================================================*/
create table TIENANTIENSU
(
    MATIENANTIENSU          char(9),
    MADINHDANH         		varchar(20),
    BANAN                   text,
    TOIDANH                 text,
    HINHPHAT                text,
    NGAYPHAT                date,
    GHICHU                  text,

    primary key (MATIENANTIENSU)
);

/*==============================================================*/
/* Table: ADMIN                                                 */
/*==============================================================*/
create table ADMIN1
(
    MAADMIN                 char(9),
    MACANBO                 char(9),
    MABAOMAT                text,

    primary key (MAADMIN)
);

/*==============================================================*/
/*==============================================================*/
/* Table: Đảm bảo dạng chuẩn 3                                  */




