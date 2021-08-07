CREATE DATABASE ProjectGladiator
USE ProjectGladiator

/*DROP TABLE Consumer
DROP TABLE EMICard
DROP TABLE Product
DROP TABLE PurchaseRecord
DROP TABLE AdminControl
DROP TABLE LoginTable*/

CREATE TABLE Consumer(
	cid int IDENTITY(10000,1) PRIMARY KEY,
	userId AS 'UID' + RIGHT(CAST(cid AS VARCHAR(8)), 8) UNIQUE,
	cName varchar(50) NOT NULL,
	DOB date NOT NULL,
	emailId varchar(50) UNIQUE NOT NULL,
	phoneNumber varchar(10) NOT NULL,
	userName varchar(20) UNIQUE NOT NULL,
	cAddress varchar(100) NOT NULL,
	cPassword varchar(20) NOT NULL,
	cardType varchar(15) NOT NULL,
	bankName varchar(20) NOT NULL,
	accNo varchar(30) UNIQUE NOT NULL,
	ifscCode varchar(30) NOT NULL,
	isVerfied bit DEFAULT 0
)


CREATE TABLE EMICard(
	eid int IDENTITY(20000,1) PRIMARY KEY,
	cardNo AS 'CDN' + RIGHT(CAST(eid AS VARCHAR(8)), 8) UNIQUE,
	userId int,
	validityPeriod date,
	accBalance decimal NOT NULL,
	totalCredit varchar(10) NOT NULL,
	CONSTRAINT fk_userId FOREIGN KEY (userId) REFERENCES Consumer(cid)
)

CREATE TABLE Product(
	pid int IDENTITY(30000,1) PRIMARY KEY,
	productId AS 'PRN' + RIGHT(CAST(pid AS VARCHAR(8)), 8) UNIQUE,
	productName varchar(30) NOT NULL,
	prodDetails varchar(500),
	price decimal NOT NULL,
	img varchar(100) NOT NULL
)


CREATE TABLE PurchaseRecord(
	prid int IDENTITY(40000,1) PRIMARY KEY,
	orderId AS 'ODR' + RIGHT(CAST(prid AS VARCHAR(8)), 8) UNIQUE,
	cardNo int,
	productId int,
	userId int,
	DOP date NOT NULL,
	productBalance decimal,
	totalMonthsSelected int,
	CONSTRAINT fk_cdn FOREIGN KEY (cardNo) REFERENCES EMICard(eid),
	CONSTRAINT fk_pid FOREIGN KEY (productId) REFERENCES Product(pid),
	CONSTRAINT fk_uid FOREIGN KEY (userId) REFERENCES Consumer(cid)
)

CREATE TABLE AdminControl(
	aid int IDENTITY(50000,1) PRIMARY KEY,
	userId AS 'AID' + RIGHT(CAST(aid AS VARCHAR(8)), 8) UNIQUE,
	aName varchar(50) NOT NULL,
	userName varchar(20) UNIQUE NOT NULL,
	aPassword varchar(20) NOT NULL,
)

CREATE TABLE LoginTable(
	userName varchar(20) PRIMARY KEY,
	uPassword varchar(20) NOT NULL
)

select * from Consumer
