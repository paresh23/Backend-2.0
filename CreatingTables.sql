CREATE DATABASE ProjectGladiator
USE ProjectGladiator

/*DROP TABLE Consumer
DROP TABLE EMICard
DROP TABLE Product
DROP TABLE PurchaseRecord
DROP TABLE AdminControl
DROP TABLE LoginTable*/

DELETE FROM Consumer
DELETE FROM LoginTable

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

ALTER TABLE Consumer ADD CONSTRAINT U_phoneNo UNIQUE (phoneNumber);  --RUN THIS!!!!

CREATE TABLE EMICard(
	eid int IDENTITY(20000,1) PRIMARY KEY,
	cardNo AS 'CDN' + RIGHT(CAST(eid AS VARCHAR(8)), 8) UNIQUE,
	userId int,
	validityPeriod date,
	accBalance decimal NOT NULL,
	totalCredit varchar(10) NOT NULL,
	CONSTRAINT fk_userId FOREIGN KEY (userId) REFERENCES Consumer(cid)
)

INSERT INTO EMICard VALUES (10002, (convert(date,'18-06-22', 5)), 100000.0, 100000.00)

select * from EMICard

CREATE TABLE Product(
	pid int IDENTITY(30000,1) PRIMARY KEY,
	productId AS 'PRN' + RIGHT(CAST(pid AS VARCHAR(8)), 8) UNIQUE,
	productName varchar(30) NOT NULL,
	prodDetails varchar(500),
	price decimal NOT NULL,
	img varchar(100) NOT NULL
)

insert into Product(productName,prodDetails,price,img) values('Samsung Galaxy A42 5G','On the next-generation mobile data network, the power of 5G fast speeds change the way you experience and share content—from super-smooth gaming and streaming, to ultra-fast sharing and downloading. Upgrade to the Galaxy A42 5G and speed up your smartphone experience.',54000,'assets/images/1.png')
insert into Product(productName,prodDetails,price,img) values('Samsung Galaxy Watch 3','The watch that watches out for you. Galaxy Watch3 combines smartphone-level productivity and leading health technology in one premium and classic device. Our most advanced Galaxy watch yet, Galaxy Watch3 helps you effortlessly manage your life and health — putting your well-being in your hands.',34990,'assets/images/2.jpg')
insert into Product(productName,prodDetails,price,img) values('Sennheiser HD 400s Over-Ear','Renowned Sennheiser sound quality for a unique listening experience. Built-in microphone and remote for call and music control. Closed-back around-ear headphones reduce unwanted background noise for your comfort. Lightweight, foldable headphones for easy on-the-go storage',3999,'assets/images/3.jpg')
insert into Product(productName,prodDetails,price,img) values('Realme Buds Wireless','The concept of minimalism is the key to design the aesthetic wireless earbuds. They are made from premium metal and skin-friendly silica gel for your comfort. realme distinctive logo and the classic black-yellow blocking make you stand-out in the crowd. There are also orange and green earbuds for your choice.',1599,'assets/images/4.jpg')
insert into Product(productName,prodDetails,price,img) values('BOAT Airdopes 131','Sleek. Comfortable. Stylish. And a Splash of Incredible Colours. Bring alive your favourite sounds with these true wireless earbuds. Equipped with 13mm drivers for the magical boAt signature sound. Designed for supreme ease with Insta Wake N’ Pair technology that auto connects the moment it’s out of the case and Type C Charging. ',1999,'assets/images/5.jpg')
insert into Product(productName,prodDetails,price,img) values('Fossil Gen 4 Smartwatch','From making instant secure payments to keeping track of your fitness, as well as, smartphone activities, the Fossil Gen 4 Explorist HR Smartwatch will assist you in most of your daily tasks. This smart wristwear features an Untethered GPS, Google Pay app, and a Heart-rate Tracker to help you do a number of tasks effortlessly and efficiently.',15950,'assets/images/6.jpg')
insert into Product(productName,prodDetails,price,img) values('JBL Flip 4 Bluetooth Speaker','JBL Flip 4 is the next generation in the award-winning Flip series; it is a portable Bluetooth speaker that delivers surprisingly powerful stereo sound. This compact speaker is powered by a 3000mAh rechargeable Li-ion battery that offers up to 12 hours of continuous, high-quality audio playtime.',8050,'assets/images/7.jpg')
insert into Product(productName,prodDetails,price,img) values('Echo Dot (4th Gen) ','Echo Dot is a smart speaker that can be operated by voice - even from a distance. Alexa can speak both English & Hindi, and new features are added automatically. Echo Dot (4th Gen) has a new spherical design and improved bass performance compared to Echo Dot (3rd Gen). Hands-free music control: Stream millions of songs in your favorite language from.',3490,'assets/images/8.jpg')
insert into Product(productName,prodDetails,price,img) values('OnePlus 9','The smartphone is powered by Qualcomm SM8350 Snapdragon 888 Octa-core and it comes with 6.55 inches Fluid AMOLED screen. The resolution of the screen is 1080 x 2400 pixels while it is protected by Corning Gorilla Glass.The device is pack with 8 GB and 12 GB RAM while the internal storage is 128 GB and 512 GB.',49990,'assets/images/9.jpg')
insert into Product(productName,prodDetails,price,img) values('Amazon Kindle','Purpose-built for reading with a 167 ppi glare-free display that reads like real paper, even in direct sunlight. Adjustable brightness lets you read comfortably—indoors and outdoors, day and night. Unlike a tablet, a single battery charge lasts weeks, not hours. 8GB of storage means thousands of titles on hand all in a compact size',6790,'assets/images/10.jpg')

select * from Product

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

select * from PurchaseRecord

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
select * from LoginTable


