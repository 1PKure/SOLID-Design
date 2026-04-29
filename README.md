# SOLID Design - Console Application

## 📌 Description

This project is a console-based application that simulates an order management system.  
It was developed to demonstrate the application of SOLID principles and multiple design patterns in a clear and structured way.

The system allows creating different types of orders, applying discount strategies, and notifying observers when the order status changes.

---

## 🧱 Design Patterns Used

- **Factory Method**  
  Used to create different types of orders (Coffee, Cake, Combo) through specific factories.

- **Composite**  
  Allows handling both simple orders and combo orders uniformly.

- **Strategy**  
  Used to apply different discount logics dynamically (Membership, Volume, No Discount).

- **Observer**  
  Notifies customers and employees when the order status changes.

---

## ⚙️ How to Run

1. Open the executable located in the provided ZIP file.
2. Run the `.exe` file.
3. Use the console menu to interact with the system.

---

## 📂 Project Structure
/Factories
/Models
/Observers
/Services
/Strategies
Program.cs


---

## 🧠 Example Usage (Pseudocode)

START

Create OrderManager

Show menu options:
    1. Create coffee order
    2. Create cake order
    3. Create combo order
    4. Show orders
    5. Apply membership discount
    6. Apply volume discount
    7. Mark order as ready
    8. Exit

IF user chooses to create coffee:
    factory = CoffeeOrderFactory
    OrderManager creates order using factory
    OrderManager adds CustomerObserver and EmployeeObserver
    Order is stored in the system

IF user chooses to create cake:
    factory = CakeOrderFactory
    OrderManager creates order using factory
    Observers are attached
    Order is stored

IF user chooses to create combo:
    factory = ComboOrderFactory
    ComboOrder is created
    Add Coffee SimpleOrder to combo
    Add Cake SimpleOrder to combo
    Observers are attached
    Order is stored

IF user chooses membership discount:
    Select order
    Set MembershipDiscountStrategy
    Recalculate final price

IF user chooses volume discount:
    Select order
    Set VolumeDiscountStrategy
    Apply discount only if conditions are met

IF user chooses to show orders:
    Display all orders with:
        - Name
        - Base price
        - Final price
        - Status

IF user marks order as ready:
    Change status to Ready
    Notify CustomerObserver
    Notify EmployeeObserver

END
---

📊 Class Diagram

The class diagram is available in the /Docs folder.

📄 Documentation
Google Docs: [https://docs.google.com/document/d/1HTTxnppQZ9qFSPXVoXSAcQ97lWh4YdmEn5o8K6q3Hok/edit?usp=sharing]

👨‍💻 Author

Matias Pulido


---
