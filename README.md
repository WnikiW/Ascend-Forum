# Ascend Forum 🚀

Ascend Forum is a modern, web-based discussion platform dedicated to the topics of self-improvement, fitness, aesthetics, and personal development. Built with .NET 10+, it provides a clean and focused environment for community engagement, knowledge sharing, and online live support.

---

## 🌟 Project Concept
The core mission of **Ascend Forum** is to create a digital space where users can discuss strategies for "ascending" in various life aspects. From physical training and style to mental health and professional growth, the platform is designed to be a hub for serious self-improvement enthusiasts.

---

## ✨ Key Features
- **Category Management**: Structured organization of discussions into thematic categories.
- **Dynamic Discussions**: Full-featured posting and commenting system.
- **Engagement System**: Interactive reaction system for comments to highlight high-quality contributions.
- **Member Profiles**: Personalized user pages with unique `AscendName` identifiers.
- **Real-time Support**: Integrated live support system powered by **SignalR** for instant assistance.
- **Admin Panel**: Specialized area for administrators to manage categories and oversee the community.
- **Responsive UI**: A modern, clean interface built with **Bootstrap 5** for seamless use across devices.

---

## 🏗️ Architecture and Design Decisions
The project follows a **Clean, N-tier Architecture** pattern, emphasizing the separation of concerns and maintainability.

### **Design Decisions:**
- **Decoupling**: Business logic is abstracted via interfaces (Contracts) to allow for easy swapping of implementations and simplified unit testing.
- **Real-time Communication**: SignalR was chosen for the support system to provide a reactive, low-latency user experience.
- **Sanitization**: All user-generated content is sanitized using `HtmlSanitizer` to prevent XSS attacks.

---

## 📂 Project Structure (Layers)

The solution is divided into four main projects:

| Layer | Project | Description |
| :--- | :--- | :--- |
| **Presentation** | `Ascend-Forum` | ASP.NET Core MVC application. Contains Controllers, Views, Hubs, and static assets. |
| **Business Logic**| `Ascend-Forum.Core` | Contains Service abstractions (`Contracts`) and concrete business logic (`Implementations`). |
| **Infrastructure**| `Ascend-Forum.Infrastructure` | Data access layer. Manages EF Core DbContext, Identity Models, and Database Migrations. |
| **Testing** | `Ascend-Forum.Tests` | Comprehensive unit tests for core services and business logic. |

---

## 🛡️ Validations and Security
- **Server-Side Validation**: Handled by using data annotation and custom server-side validation logic.
- **XSS Protection**: Integrated `HtmlSanitizer` processes all user input that allows HTML.
- **Anti-Forgery**: Global `AutoValidateAntiforgeryTokenAttribute` is applied to all POST/PUT requests.
- **Identity Security**: Configurable password policies and secure authentication using ASP.NET Core Identity.

---

## 🌱 Seeding and Initial Data
The application features an automated seeding mechanism found in `ApplicationsBuilderExtension.cs`:

- **Database Migration**: On startup, the application automatically applies any pending EF Core migrations.
- **Admin Seeding**: A default administrator account is created if it doesn't exist:
  - **Email**: `admin@abv.bg`
  - **Password**: `admin123`
- **Role Management**: Initial roles (Administrator, Member) are automatically populated.

---

## 🧪 Test Coverage
- **Unit Tests**: Focus on service-layer logic.
- **Mocking**: Uses modern mocking frameworks to isolate business logic from infrastructure dependencies.
- **Key Coverage Areas**:
  - Category creation and validation.
  - Commenting logic and reaction processing.
  - Member profile management.

---

## 🚀 Setup and Installation

### **Steps**
1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/Ascend-Forum.git
   ```
2. **Configure Database:**
   Update the `DefaultConnection` string in `Ascend-Forum/appsettings.json` to point to your SQL Server instance.
3. **Apply Migrations:**
   ```bash
   dotnet ef database update --project Ascend-Forum.Infrastructure --startup-project Ascend-Forum
   ```
4. **Run the Application:**
   ```bash
   cd Ascend-Forum/Ascend-Forum
   dotnet run
   ```

---

## 💻 Technologies Used
- **Backend**: C#, .NET 10, ASP.NET Core MVC, SignalR, Entity Framework Core.
- **Frontend**: Razor Views, JavaScript, Bootstrap 5.
- **Database**: SQL Server.
- **Security**: ASP.NET Core Identity, Ganss.Xss (HtmlSanitizer).
- **Testing**: nUnit, Moq.

---
