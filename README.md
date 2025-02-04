Project Task: Create a Web Application with CRUD Operations and Advanced Database Features
________________________________________
Objective
Develop a web application with the following requirements:
1.	CRUD functionality for 5-6 entities.
2.	Utilize an SQL database to store most of the entities with a variety of relationships (one-to-one, one-to-many, many-to-many).
3.	Implement a MongoDB database to handle a single collection for unstructured or semi-structured data.
4.	Use Redis as a caching layer to optimize performance for frequently accessed data.
________________________________________
Key Deliverables
1. Web Application
  •	Frontend:
    o	Design a user-friendly interface for creating, reading, updating, and deleting records for each entity.
    o	Include forms, tables, and modals for CRUD operations.
    o	Framework: up to student (can be combined with backend: e.g. MVC)
  •	Backend:
    o	Create RESTful APIs endpoints or MVC application to handle CRUD operations for the entities.
    o	Framework: (e.g., Node.js, Python Flask/Django, Java Spring Boot, or .NET).
________________________________________
2. SQL Database
  •	Entities and Relationships:
    o	Model and implement 5-6 entities in the database. Examples:
      1.	Users
      2.	Products
      3.	Orders
      4.	Categories
      5.	Reviews
      6.	Payments
    o	Include the following relationships:
      	One-to-One: Example: User ↔ Profile
      	One-to-Many: Example: User ↔ Orders
      	Many-to-Many: Example: Products ↔ Categories (via a join table).
    o	Use a relational database management system (e.g., PostgreSQL, MySQL, MS SQL).
  •	Features:
    o	Use proper schema design with constraints (primary keys, foreign keys, unique constraints).
    o	Add indexing to optimize performance for frequent queries.
    o	Write at least 5 complex queries (e.g., joins, aggregations) for testing the relationships.
________________________________________
3. MongoDB Collection
  •	Unstructured Data:
    o	Design a MongoDB collection for a specific use case (e.g., storing product reviews, user activity logs, or notifications).
    o	Define a schema for the collection and integrate it with the web app using an ODM (e.g., Mongoose, Mongo Db Driver).
    o	Implement CRUD operations for this collection via the backend APIs.
________________________________________
4. Redis Cache
  •	Caching Layer:
    o	Implement Redis as a caching solution to improve application performance.
    o	Use Redis to cache:
      	Frequently accessed data (e.g., user profiles or product details).
      	Query results from the SQL or MongoDB databases.
    o	Implement cache expiration policies (e.g., TTL) and cache invalidation logic.

