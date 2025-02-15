### **Wie ist dein Code getrennt?** 🚀  
Dein Code folgt dem **Clean Architecture Prinzip mit CQRS** (Command-Query Responsibility Segregation).  
Lass uns die Rollen der einzelnen Schichten klären!  

---

## **📌 1. Datenbankverbindung – `DB_ECommerceContext` (Persistence Layer)**
**📍 Aufgabe:**  
Die `DB_ECommerceContext`-Klasse stellt die Verbindung zur **MongoDB-Datenbank** her und verwaltet die `Reviews`-Collection.  

👉 **Diese Schicht sorgt für die Kommunikation mit der Datenbank.**  

---
## **📌 2. Datenzugriff – `ReviewRepository` (Data Access Layer)**
**📍 Aufgabe:**  
Das `ReviewRepository` ist die **Schnittstelle zwischen Backend und Datenbank**.  

👉 **Warum?**  
- Trennt die **Datenbank-Logik** von der Geschäftslogik.  
- Wenn du die Datenbank (z. B. von MongoDB auf SQL) wechselst, musst du nur das Repository anpassen.  

**Beispiel:**  
```csharp
public async Task<List<Review>> GetReviewsByProductIdAsync(string productId)
{
    return await _reviews.Find(r => r.ProductId == productId).ToListAsync();
}
```
**📍 Ergebnis:**  
- Die Methode ruft alle Bewertungen für ein bestimmtes Produkt aus der Datenbank ab.  
- Das `Repository` wird von **Queries & Commands (siehe unten) genutzt**, damit Controller und Business-Logik **nicht direkt mit der Datenbank kommunizieren**.  

---
## **📌 3. MediatR – Queries, Commands & Handlers (Application Layer)**  
Jetzt kommen wir zum **CQRS-Pattern (Command Query Responsibility Segregation)**!  

### **🔹 3.1 Was sind Queries und Commands?**
- **Queries (`GetReviewsByProductIdQuery`)** → **Lesen von Daten** (z. B. Bewertungen abrufen)  
- **Commands (`CreateReviewCommand`)** → **Ändern von Daten** (z. B. eine neue Bewertung speichern)  

👉 **Warum getrennt?**  
- Queries dürfen **keine Änderungen an der Datenbank machen**.  
- Commands **ändern Daten, aber geben nichts zurück** außer einer Bestätigung.  

---
### **🔹 3.2 Was ist ein Query? (`GetReviewsByProductIdQuery`)**  
Ein **Query ist eine Anforderung**, um Daten zu lesen.  

```csharp
public class GetReviewsByProductIdQuery : IRequest<List<Review>>
{
    public string ProductId { get; set; }

    public GetReviewsByProductIdQuery(string productId)
    {
        ProductId = productId;
    }
}
```
📍 **Was macht diese Klasse?**  
- Sie **enthält nur die Anfrage** (`ProductId`) – **keine Logik!**  
- Sie wird von **MediatR** an den passenden **Handler** weitergeleitet.  

---
### **🔹 3.3 Was ist ein Command? (`CreateReviewCommand`)**  
Ein **Command ändert die Daten** (z. B. eine neue Bewertung erstellen).  

```csharp
public class CreateReviewCommand : IRequest<Review>
{
    public string ProductId { get; set; }
    public string UserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}
```
📍 **Was macht diese Klasse?**  
- Speichert **die Daten für die neue Bewertung**, die erstellt werden soll.  
- Wird an den passenden **Handler** gesendet.  

---
### **🔹 3.4 Was ist ein Handler? (`GetReviewsByProductIdHandler`)**  
Ein **Handler verarbeitet die Query oder den Command**.  

👉 Der **Query-Handler** ruft die Daten aus dem Repository ab:  
```csharp
public class GetReviewsByProductIdHandler : IRequestHandler<GetReviewsByProductIdQuery, List<Review>>
{
    private readonly ReviewRepository _reviewRepository;

    public GetReviewsByProductIdHandler(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<List<Review>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
    {
        return await _reviewRepository.GetReviewsByProductIdAsync(request.ProductId);
    }
}
```
📍 **Was passiert hier?**  
- **Der Handler empfängt die Query** `GetReviewsByProductIdQuery`.  
- Er **ruft das Repository auf** (`GetReviewsByProductIdAsync`).  
- Die Datenbank gibt die **Liste der Bewertungen** zurück.  

---

### **🔹 3.5 Wie läuft ein Command ab? (`CreateReviewHandler`)**  
Ein Command **erstellt, aktualisiert oder löscht** Daten in der Datenbank.  

```csharp
public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Review>
{
    private readonly ReviewRepository _reviewRepository;

    public CreateReviewHandler(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            ProductId = request.ProductId,
            UserId = request.UserId,
            Rating = request.Rating,
            Comment = request.Comment,
            CreatedAt = DateTime.UtcNow
        };

        await _reviewRepository.CreateReviewAsync(review);
        return review;
    }
}
```
📍 **Was passiert hier?**  
- Der Handler empfängt den **Command** (`CreateReviewCommand`).  
- Eine **neue Bewertung wird erstellt** und an `ReviewRepository.CreateReviewAsync()` übergeben.  
- Die Bewertung wird in MongoDB gespeichert.  

---

## **📌 4. Wie arbeiten alle Schichten zusammen?**  
Hier ist der **komplette Ablauf**, wenn du eine Produktbewertung abrufst (`GET /api/reviews/product/1`):

1️⃣ **Frontend (z. B. React, Angular) oder Postman schickt eine Anfrage**:  
   - `GET /api/reviews/product/1`  

2️⃣ **Controller (`ReviewsController`) empfängt die Anfrage**  
   - Schickt die Anfrage an MediatR → `await _mediator.Send(new GetReviewsByProductIdQuery(productId));`  

3️⃣ **MediatR leitet die Anfrage an den passenden Handler weiter**  
   - `GetReviewsByProductIdHandler.Handle()` wird aufgerufen  

4️⃣ **Handler ruft das Repository auf**  
   - `ReviewRepository.GetReviewsByProductIdAsync()` fragt die Datenbank ab  

5️⃣ **Datenbank (MongoDB) gibt die Bewertungen zurück**  
   - MongoDB liefert eine Liste von Bewertungen für das Produkt  

6️⃣ **Antwort geht zurück zum Frontend**  
   - Die Bewertungen werden an den Client zurückgesendet  

---

## **🚀 Fazit**
### **📌 Wofür brauche ich diese Architektur?**
✔ **Sauberer Code** → Jede Schicht hat eine klare Aufgabe.  
✔ **Leicht testbar** → Die Schichten können einzeln getestet werden.  
✔ **Erweiterbar** → Wenn sich die Datenbank ändert, muss nur das Repository angepasst werden.  
✔ **Trennung von Daten und Logik** → Controller müssen sich nicht um Datenbank-Abfragen kümmern.  

**Dein Code folgt dem CQRS-Pattern mit MediatR, was eine skalierbare und saubere Struktur bietet.** 🚀🔥  

Macht das für dich Sinn? 😃
