--               ..................CREATING THE TABLES...................
create table CUSTOMER (
    customerID int primary key identity(1,1),
    name varchar(254) ,
    password varchar(254) ,
    email varchar(100) unique 
);


create table PRODUCT (
    productID int primary key identity(1,1),
    productName varchar(255) ,
    price decimal(10, 2) ,
    image varbinary(max)
);


create table [ORDER] (
    orderID int primary key identity(1,1),
    orderPrice decimal(10, 2),
    status char(50),
    CID int,
    date date ,
    foreign key (CID) references CUSTOMER(customerID)
);


create table PAYMENT (
    paymentID int primary key identity(1,1),
    paymentMethod char(50),
    status char(50),
    OID int,
    foreign key (OID) references [ORDER](orderID)
);


create table SHIPPING (
    shippingID int primary key identity(1,1),
    shippingAddress char(255) ,
    shippingStatus char(50),
    OID int,
    foreign key (OID) references [ORDER](orderID)
);


create table Order_Product (
    orderID int,
    productID int,
    primary key (orderID, productID),
    foreign key (orderID) references [ORDER](orderID),
    foreign key (productID) references PRODUCT(productID)
);



create table CustomerAdds (
    CID int,
    addreses char(255),
    primary key (CID),
    foreign key (CID) references CUSTOMER(customerID)
);

--                  ...................INSERTING DATA........................


insert into PRODUCT(productName, price, image)
values ('macbook', 999.99, 
       (select * from openrowset(bulk 'f:\mac.jpg', single_blob) as ImageData)
	   );


insert into CUSTOMER (name, password, email)
values
('Ahmed Ali', 'GG123', 'ahmad.ali@example.com'),
('Fatima Al-Zahra', 'aa123', 'fatima.alsarah@example.com'),
('Yousef Mohammed', 'bb123', 'yousef.mohammed@example.com'),
('Maryam Hussein', 'dd123', 'maryam.hussein@example.com');


insert into CustomerAdds (CID, addreses)
values
(1, 'El-Maadi, Cairo, 11431'),
(2, 'Heliopolis, Cairo, 11757'),
(3, 'Nasr City, Cairo, 11371'),
(4, 'Mohandessin, Giza, 12611');


--                 ........................READ DATA......................

select * from CUSTOMER
where email = 'ahmad.ali@example.com';


--                 ....................UPDATING DATA......................

update CUSTOMER
set name = 'Ahmed Ali', 
    password = 'newpassword123', 
    email = 'ahmed.ali@example.com'
where email = 'ahmad.ali@example.com';

--                   ....................DELETE ROW...................... 


delete from CUSTOMER
where email = 'ahmed.ali@example.com';
