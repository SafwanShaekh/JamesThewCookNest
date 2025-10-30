# JamesThewCookNest

**JamesThewCookNest** is a full-featured web application built using **ASP.NET Core MVC** and **SQL Server**. The platform allows Chef James Thew to showcase his recipes, cooking tips, and contests while engaging a global community of users who can explore, contribute, and interact with culinary content.

This project serves as a comprehensive **recipe management and community engagement platform**, providing a seamless experience for both the chef (admin) and users (members and guests).

---

## 🧩 **Key Features**

### **1. User Authentication & Membership**

* Secure login and registration system with role-based access (Admin, Member, Guest).
* Membership plans:

  * Monthly subscription: $10
  * Yearly subscription: $100
* Membership access control for premium recipes and tips.
* Password reset and email verification.

### **2. Recipe & Tips Management**

* Admin and users can **upload recipes and tips**, with ingredients, preparation steps, and images.
* Mark recipes/tips as **Free** or **Members-only**.
* Users can **view, edit, or delete** their own posts.
* Powerful **search and filter functionality** (by category, cuisine, popularity).

### **3. Contests & Announcements**

* Admin (Chef James) can **create cooking contests** and manage submissions.
* Users can **participate** by submitting recipes or tips for contests.
* Admin can **review entries and announce winners**.
* Announcement board for **latest contests, winners, and news**.

### **4. Feedback System**

* Users can submit feedback on recipes or tips.
* Admin can view and manage feedback for improving content quality.

### **5. Public Pages & FAQs**

* Home page featuring Chef James’ bio, featured recipes, and contests.
* Static pages: About, Contact, and FAQ sections.
* Fully **responsive design** for desktop and mobile users.

### **6. Admin Dashboard**

* Centralized dashboard for managing users, recipes, contests, tips, feedback, and announcements.
* View statistics: number of members, recipes uploaded, active contests, and feedback received.

---

## 🛠 **Technology Stack**

* **Frontend:** ASP.NET Core MVC, HTML5, CSS3, Bootstrap
* **Backend:** C#, Entity Framework Core
* **Database:** SQL Server
* **Version Control:** Git & GitHub
* **Payment Integration:** Dummy simulation for subscription plans

---

## 📂 **Project Structure**

```
/Controllers
/Models
/Views
/wwwroot
/Data
/Services
```

* MVC architecture ensures separation of concerns and maintainable code.
* Each module is independent: Authentication, Recipes/Tips, Contests, Feedback, and Admin Dashboard.

---

## 🚀 **Getting Started**

1. Clone the repository:

```bash
git clone https://github.com/your-username/JamesThewCookNest.git
```

2. Open the project in **Visual Studio 2022**.
3. Restore NuGet packages.
4. Update **appsettings.json** with your SQL Server connection string.
5. Run **EF Core migrations** to create the database.
6. Build and run the project.

