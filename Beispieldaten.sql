USE [E-Commerce];
GO

-- Kategorien
INSERT INTO [dbo].[Categories] (CategoryID, CategoryName) VALUES
('Elektronik'),
('Haushalt'),
('Kleidung'),
('Bücher');

-- Kunden
INSERT INTO [dbo].[Customers] (CustomerID, FirstName, LastName, Address, Birthday, AccountCreated, Email) VALUES
('Max', 'Mustermann', 'Musterstraße 1', '1990-05-15', '2023-06-10', 'max.mustermann@example.com'),
('Maria', 'Schmidt', 'Hauptstraße 12', '1985-08-22', '2022-11-20', 'maria.schmidt@example.com'),
('John', 'Doe', 'Baker Street 221B', '1992-12-05', '2021-09-01', 'john.doe@example.com');

-- Produkte
INSERT INTO [dbo].[Products] (ProductID, ProductName, Price) VALUES
('Laptop    ', 999),
('Mikrowelle', 150),
('Jeans     ', 60),
('Roman     ', 20);

-- Produkt-Kategorien
INSERT INTO [dbo].[Products_Categories] (CategoryID, ProductID) VALUES
(1, 1),  -- Laptop → Elektronik
(2, 2),  -- Mikrowelle → Haushalt
(3, 3),  -- Jeans → Kleidung
(4, 4);  -- Roman → Bücher

-- Bestellungen
INSERT INTO [dbo].[Orders] (OrderID, OrderDate, TotalPrice, CustomerID) VALUES
('2024-01-15', 1209, 1),
('2024-02-01', 80, 2),
('2024-02-05', 60, 3);

-- Produkte in Bestellungen
INSERT INTO [dbo].[Products_Orders] (ProductOrderID, ProductID, OrderID, Quantity, TotalPrice) VALUES
(1, 1, 1, 999),  -- Max kauft 1 Laptop
(2, 1, 1, 150),  -- Max kauft 1 Mikrowelle
(4, 2, 4, 80),   -- Maria kauft 4 Romane
(3, 3, 1, 60);   -- John kauft 1 Jeans

-- Zahlungen
INSERT INTO [dbo].[Payments] (PaymentID, Currency, PaymentMethod, PaymentStatus, PaymentAmount, OrderID, OpenPayment) VALUES
(1, 'EUR', 'Kreditkarte', 'Bezahlt', 1209, 1, 0),
(2, 'EUR', 'PayPal', 'Bezahlt', 80, 2, 0),
(3, 'EUR', 'Rechnung', 'Offen', 60, 3, 60);

-- Versand
INSERT INTO [dbo].[Shipments] (ShipmentID, ShipmentDate, TrackingNumber, DeliveryDate, ShipmentStatus, OrderID) VALUES
('20240201', 'TRK123456', '2024-02-03', 'Geliefert', 1),
('20240203', 'TRK654321', '2024-02-05', 'Geliefert', 2),
('20240205', 'TRK987654', NULL, 'Unterwegs', 3);