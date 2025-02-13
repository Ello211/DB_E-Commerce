USE [E-Commerce]
GO

-- Insert sample data into Categories table
INSERT INTO [dbo].[Categories] ([CategoryName])
VALUES 
('Electronics'),
('Books'),
('Clothing'),
('Home & Kitchen'),
('Toys & Games');

-- Insert sample data into Customers table
INSERT INTO [dbo].[Customers] ([FirstName], [LastName], [Address], [Birthday], [AccountCreated], [Email])
VALUES 
('John', 'Doe', '123 Main St, Springfield', '1985-05-15', '2023-01-01', 'john.doe@example.com'),
('Jane', 'Smith', '456 Elm St, Shelbyville', '1990-08-22', '2023-02-10', 'jane.smith@example.com'),
('Alice', 'Johnson', '789 Oak St, Capital City', '1988-11-30', '2023-03-05', 'alice.johnson@example.com');

-- Insert sample data into Products table
INSERT INTO [dbo].[Products] ([ProductName], [Price])
VALUES 
('Smartphone X', 799.99),
('Wireless Earbuds', 129.99),
('Programming Book: SQL Basics', 49.99),
('Mens Casual Shirt', 29.99),
('Kitchen Blender', 89.99),
('Board Game: Monopoly', 39.99);

-- Insert sample data into Products_Categories table
INSERT INTO [dbo].[Products_Categories] ([CategoryID], [ProductID])
VALUES 
(1, 1), -- Smartphone X -> Electronics
(1, 2), -- Wireless Earbuds -> Electronics
(2, 3), -- Programming Book: SQL Basics -> Books
(3, 4), -- Mens Casual Shirt -> Clothing
(4, 5), -- Kitchen Blender -> Home & Kitchen
(5, 6); -- Board Game: Monopoly -> Toys & Games

-- Insert sample data into Orders table
INSERT INTO [dbo].[Orders] ([OrderDate], [TotalPrice], [CustomerID])
VALUES 
('2023-10-01', 799.99, 1), -- John Doe orders a Smartphone X
('2023-10-02', 129.99, 2), -- Jane Smith orders Wireless Earbuds
('2023-10-03', 49.99, 3), -- Alice Johnson orders a Programming Book
('2023-10-04', 119.98, 1); -- John Doe orders a Shirt and a Blender

-- Insert sample data into Products_Orders table
INSERT INTO [dbo].[Products_Orders] ([ProductID], [OrderID], [Quantity], [TotalPrice])
VALUES 
(1, 1, 1, 799.99), -- Smartphone X in Order 1
(2, 2, 1, 129.99), -- Wireless Earbuds in Order 2
(3, 3, 1, 49.99),  -- Programming Book in Order 3
(4, 4, 1, 29.99),  -- Mens Casual Shirt in Order 4
(5, 4, 1, 89.99);  -- Kitchen Blender in Order 4

-- Insert sample data into Payments table
INSERT INTO [dbo].[Payments] ([Currency], [PaymentMethod], [PaymentStatus], [PaymentAmount], [OrderID], [OpenPayment])
VALUES 
('USD', 'Credit Card', 'Completed', 799.99, 1, 0), -- Payment for Order 1
('USD', 'PayPal', 'Completed', 129.99, 2, 0),     -- Payment for Order 2
('USD', 'Credit Card', 'Completed', 49.99, 3, 0), -- Payment for Order 3
('USD', 'Debit Card', 'Completed', 119.98, 4, 0); -- Payment for Order 4

-- Insert sample data into Shipments table
INSERT INTO [dbo].[Shipments] ([ShipmentDate], [TrackingNumber], [DeliveryDate], [ShipmentStatus], [OrderID])
VALUES 
(20231001, 'TRK123456789', '2023-10-05', 'Delivered', 1), -- Shipment for Order 1
(20231002, 'TRK987654321', '2023-10-06', 'In Transit', 2), -- Shipment for Order 2
(20231003, 'TRK456789123', '2023-10-07', 'Pending', 3),     -- Shipment for Order 3
(20231004, 'TRK321654987', '2023-10-08', 'Pending', 4);    -- Shipment for Order 4

GO