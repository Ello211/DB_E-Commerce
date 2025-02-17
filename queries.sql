-- total revenue by each customer 
SELECT 
    c.CustomerID,
    c.FirstName,
    c.LastName,
    SUM(p.PaymentAmount) AS TotalRevenue
FROM 
    dbo.Customers c
JOIN 
    dbo.Orders o ON c.CustomerID = o.CustomerID
JOIN 
    dbo.Payments p ON o.OrderID = p.OrderID
GROUP BY 
    c.CustomerID, c.FirstName, c.LastName
ORDER BY 
    TotalRevenue DESC;


-- all products with their categories and the number of times they were ordered
SELECT 
    p.ProductID,
    p.ProductName,
    cat.CategoryName,
    COUNT(po.ProductID) AS TotalOrders
FROM 
    dbo.Products p
JOIN 
    dbo.Products_Categories pc ON p.ProductID = pc.ProductID
JOIN 
    dbo.Categories cat ON pc.CategoryID = cat.CategoryID
LEFT JOIN 
    dbo.Products_Orders po ON p.ProductID = po.ProductID
GROUP BY 
    p.ProductID, p.ProductName, cat.CategoryName
ORDER BY 
    TotalOrders DESC;

-- total revenue by category
SELECT 
    cat.CategoryID,
    cat.CategoryName,
    SUM(po.TotalPrice) AS TotalRevenue
FROM 
    dbo.Categories cat
JOIN 
    dbo.Products_Categories pc ON cat.CategoryID = pc.CategoryID
JOIN 
    dbo.Products p ON pc.ProductID = p.ProductID
JOIN 
    dbo.Products_Orders po ON p.ProductID = po.ProductID
GROUP BY 
    cat.CategoryID, cat.CategoryName
ORDER BY 
    TotalRevenue DESC;


-- average order value for each customer
SELECT 
    c.CustomerID,
    c.FirstName,
    c.LastName,
    AVG(o.TotalPrice) AS AverageOrderValue
FROM 
    dbo.Customers c
JOIN 
    dbo.Orders o ON c.CustomerID = o.CustomerID
GROUP BY 
    c.CustomerID, c.FirstName, c.LastName
ORDER BY 
    AverageOrderValue DESC;


-- orders with their payment and shipments
SELECT 
    o.OrderID,
    o.OrderDate,
    o.TotalPrice,
    p.PaymentStatus,
    s.ShipmentStatus,
    s.TrackingNumber,
    s.DeliveryDate
FROM 
    dbo.Orders o
JOIN 
    dbo.Payments p ON o.OrderID = p.OrderID
JOIN 
    dbo.Shipments s ON o.OrderID = s.OrderID
ORDER BY 
    o.OrderDate DESC;
