/*==============================================================*/
/* DBMS name:      MySQL 4.0                                    */
/* Created on:     10/20/2018 12:11:22 PM                       */
/*==============================================================*/


/*==============================================================*/
/* Table: HOC SINH SINH VIEN                                    */
/*==============================================================*/
create table HOCSINHSINHVIEN
(
    MANHANKHAU                          char(9),
    MSSV                                varchar(10),
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
    MANHANKHAU          char(9),
    SOCMND              char(9),
    DANTOC              varchar(20),
    GIOITINH            varchar(10),
    HOCHIEU             varchar(20),
    HOTEN               varchar(20),
    MADINHDANH          varchar(20),
    NOISINH             text,
    NGAYSINH            date,
    NGUYENQUAN          text,
    QUOCTICH            varchar(20),
    SDT                 char(10),
    TONGIAO             varchar(20),
    NOICAP              text,
    NGAYCAP             text,

    primary key (SOCMND)
);


/*==============================================================*/
/* Table:   TAM VANG                                            */
/*==============================================================*/
create table TAMVANG
(
    MANHANKHAU              char(9),
    NOITHUONGTRUTAMTRU      text,
    NGAYBATDAUTAMVANG       date,
    THOIGIANKETTHUCTAMVANG  date,
    LYDO                    text,
    NOIDEN                  text
);

/*==============================================================*/
/* Table: SO HO KHAU                                            */
/*==============================================================*/
create table SOHOKHAU
(
    SOSOHOKHAU              char(13),
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
    MANHAKHAU               char(9),
    DIACHITHUONGTRU         text
);

/*==============================================================*/
/* Table: SO TAM TRU                                            */
/*==============================================================*/
create table SOTAMTRU
(
    MANHANHKHAU             char(9),
    CHOOHIENNAY             text,
    TUNGAY                  date,
    DENNGAY                 date,
    LYDO                    text   
);

/*==============================================================*/
/* Table: NHAN KHAU THUONG TRU                                  */
/*==============================================================*/
create table NHANKHAUTHUONGTRU
(
    MANHANKHAU              char(9),
    NOITHUONGTRUTAMTRU      text,
    DIACHIHIENTAI           text,
    TRINHDOHOCVAN           text,
    TRINHDOCHUYENMON        text,
    BIETTIENGDANTOC         text,
    TRINHDONGOAINGU         text,
    NGHENGHIEP              text,
    NOILAMVIEC              text,
    QUANHEVOICHUHO          text,
    LACHUHO                 text
);

/*==============================================================*/
/* Table: CAN BO                                                */
/*==============================================================*/
create table CANBO
(
    MACANBO                 varchar(10),
    TENDANGNHAP             varchar(20),
    MATKHAU                 varchar(40),

    primary key (MACANBO)
);

/*==============================================================*/
/* Table: TIEU SU                                               */
/*==============================================================*/
create table TIEUSU
(
    MANHANKHAU              char(9),
    THOIGIANBATDAU          date,
    THOIGIANKETTHUC         date,
    CHOO                    text,
    NGHENGHIEP              text,
    NOILAMVIEC              text
);

/*==============================================================*/
/* Table: TIEN AN TIEN SU                                       */
/*==============================================================*/
create table TIENANTIENSU
(
    MANHANHKHAU             char(9),
    BANAN                   text,
    TOIDANH                 text,
    HINHPHAT                text,
    NGAYPHAT                date,
    GHICHU                  text
);

/*==============================================================*/
/* Table: ADMIN                                                 */
/*==============================================================*/
create table ADMIN1
(
    MACANBO                 char(9),
    MABAOMAT                text,
    primary key (MACANBO)
);

/*==============================================================*/
/*==============================================================*/
/* Table: Đảm bảo dạng chuẩn 3                                  */
/*==============================================================*/
/*==============================================================*/

/*==============================================================*/
/* Table: DAN TOC                                               */
/*==============================================================*/
create table DANTOC
(
    MADANTOC                char(9),
    TENDANTOC               text,

    primary key (MADANTOC)
);

/*==============================================================*/
/* Table: TON GIAO                                              */
/*==============================================================*/
create table TONGIAO
(
    MATONGIAO               char(9),
    TENTONGIAO              text,

    primary key (MATONGIAO)
);

/*==============================================================*/
/* Table: TRINHDO                                               */
/*==============================================================*/
create table TRINHDO
(
    MATRINHDO               char(9),
    TENTRINHDO              text,
    primary key (MATRINHDO)
);

/*==============================================================*/
/* Table: QUAN HE                                               */
/*==============================================================*/
create table QUANHE
(
    MAQUANHE                char(9),
    TENQUANHE               text,

    primary key (MAQUANHE)
);