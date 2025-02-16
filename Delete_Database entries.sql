-- Delete all database entries
-- ! Pay attention to the order! (otherwise conflicts due to the foreign keys)

DELETE FROM Payments;
DELETE FROM Shipments;
DELETE FROM Products_Orders;
DELETE FROM Orders;
DELETE FROM Customers;
DELETE FROM Products_Categories;
DELETE FROM Products;
DELETE FROM Categories;
