-- Alle Datenbankeinträge löschen
-- ! Reihenfolge beachten ! (sonst Konflikte afgrund der Fremdschlüssel)

DELETE FROM Payments;
DELETE FROM Shipments;
DELETE FROM Products_Orders;
DELETE FROM Orders;
DELETE FROM Customers;
DELETE FROM Products_Categories;
DELETE FROM Products;
DELETE FROM Categories;