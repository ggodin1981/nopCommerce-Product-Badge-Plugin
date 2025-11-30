# 🏷️ Product Badge Plugin  
### Custom nopCommerce 4.90.2 Plugin for Dynamic Product Labels

A fully functional nopCommerce plugin that allows store owners to display **custom product badges** (e.g., **HOT**, **SALE**, **NEW**, **Limited Stock**) on the storefront.  
This project demonstrates advanced plugin development and serves as a sample **portfolio project** showcasing nopCommerce, .NET, and modular architecture skills.

---

## 📌 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Architecture Highlights](#architecture-highlights)
- [Screenshots](#screenshots)
- [License](#license)

---

## 📖 Overview

The **Product Badge Plugin** extends nopCommerce by adding a new system for displaying dynamic badges on products in both:

- **Product listing pages** (category, search results)  
- **Product details pages**

Badges are fully configurable from the admin area and are rendered via a dedicated **ViewComponent** integrated into the theme.

This plugin was built as a **professional portfolio example** to demonstrate:

- Custom plugin architecture  
- FluentMigrator mapping  
- Admin configuration pages  
- Custom database entities  
- ViewComponent-based frontend modifications  
- Integration with nopCommerce events & DI  

---

## 🚀 Features

### ✔️ Custom Database Table  
Created via FluentMigrator (`ProductBadgeRecord`) storing:

- `ProductId`  
- `BadgeText`  
- `BadgeColor`  
- `IsActive`  

---

### ✔️ Admin Configuration UI  
Accessible from:

```
Admin → Configuration → Product Badge
```

Includes:

- Enable / disable plugin  
- Default badge color  
- Badge listing (extendable to CRUD)

---

### ✔️ Storefront Badge Rendering  
Badges appear on:

- Product List (Category/Search)  
- Product Details  

Rendered via:

- **ProductBadgeViewComponent**  
- **Public view (`PublicInfo.cshtml`)**  

---

### ✔️ Admin Menu Integration

Adds a menu item under:

```
Configuration → Product Badge
```

Using an **AdminMenuCreatedEvent** consumer.

---

### ✔️ Service Layer & Dependency Injection

Implements:

- `IProductBadgeService`  
- `ProductBadgeService`  

Registered via `INopStartup`.

---

### ✔️ nopCommerce Best Practices

Follows official patterns:

- Migrations  
- Mapping  
- Repositories  
- Dependency Injection  
- Settings  
- Admin Controllers  
- ViewComponents  
- Theme Extension  

---

## 🛠️ Technology Stack

- **nopCommerce 4.90.2**
- **.NET 9.0**
- **C#**
- **FluentMigrator**
- **Razor Views & ViewComponents**
- **nopCommerce IRepository pattern**
- **Admin event consumers**
- **Dependency Injection (`INopStartup`)**

---

## 📦 Installation

### 1. Copy Plugin Folder  
Place the plugin folder into your nopCommerce project:

```
/src/Plugins/Nop.Plugin.Misc.ProductBadge/
```

### 2. Build the Solution  

In Visual Studio:

```
Build → Rebuild Solution
```

Output DLLs will be generated into:

```
/Presentation/Nop.Web/Plugins/Misc.ProductBadge/
```

### 3. Install the Plugin  
Go to:

```
Admin → Configuration → Local Plugins
```

Click:

- **Reload Plugins**  
- **Install**  
- **Configure**  

---

## ⚙️ Configuration

After installation, navigate to:

```
Admin → Configuration → Product Badge
```

Available settings:

- Enable plugin  
- Set default badge color  
- View badges (extendable to CRUD)

---

## 🎯 Usage

1. Add badge records (via SQL or extended admin UI)  
2. Badge will appear automatically on:
   - Product listing pages  
   - Product details pages  

Badges are rendered using:

```csharp
@await Component.InvokeAsync("ProductBadge", new { productId = Model.Id })
```

Inserted inside:

```
/Views/Catalog/_ProductBox.cshtml
/Views/Product/ProductDetails.cshtml
```

---

## 📁 Project Structure

```
Nop.Plugin.Misc.ProductBadge
│── Components/
│    └── ProductBadgeViewComponent.cs
│── Controllers/
│── Data/
│    └── ProductBadgeRecord.cs
│── Mapping/
│    └── ProductBadgeRecordBuilder.cs
│── Migrations/
│    └── SchemaMigration.cs
│── Models/
│── Services/
│    ├── IProductBadgeService.cs
│    └── ProductBadgeService.cs
│── Views/
│    ├── ProductBadgeAdmin/Configure.cshtml
│    └── ProductBadge/PublicInfo.cshtml
│── Infrastructure/
│    └── AdminMenuConsumer.cs
│── ProductBadgePlugin.cs
│── ProductBadgeSettings.cs
│── plugin.json
```

---

## 🧩 Architecture Highlights

### 🟦 Database Layer
- FluentMigrator  
- `NopEntityBuilder<>` mapping  
- Repository pattern (`IRepository`)  

### 🟩 Service Layer
Handles reading + writing badge data.

### 🟨 Admin UI
MVC controller + Razor view for plugin settings.

### 🟧 Frontend Rendering
ViewComponent injected into theme views.

### 🟥 Event Handling
Custom admin menu integration.


## 📜 License

**MIT License** – feel free to use or modify for your own projects.
