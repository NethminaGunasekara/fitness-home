<div align="center">

  <img src="assets/images/preview.png" alt="logo" width="200" height="auto" />
  <h1>Fitness Home</h1>
  
  <p>
     A solution for simplifying operations within a gym environment! 
  </p>
  
  
<!-- Badges -->
<p>
  <img src="https://img.shields.io/github/created-at/NethminaGunasekara/fitness-home" alt="top language" />
  <img src="https://img.shields.io/github/languages/top/NethminaGunasekara/fitness-home" alt="top language" />
  <img src="https://img.shields.io/github/contributors/NethminaGunasekara/fitness-home" alt="contributors" />
  <img src="https://img.shields.io/github/last-commit/NethminaGunasekara/fitness-home" alt="last update" />
  <img src="https://img.shields.io/github/v/release/NethminaGunasekara/fitness-home" alt="website status" />
  <img src="https://img.shields.io/github/license/NethminaGunasekara/fitness-home.svg" alt="license" />
</p>
   
<h4>
    <a href="">Project Report</a>
  <span> · </span>
    <a href="#zap-getting-started">Get Started</a>
  <span> · </span>
    <a href="https://fitnesshome.vercel.app" target="_blank">Documentation</a>
  </h4>
</div>

<br />

<!-- Table of Contents -->

# :notebook_with_decorative_cover: Table of Contents

- [:notebook_with_decorative_cover: Table of Contents](#notebook_with_decorative_cover-table-of-contents)
  - [:star2: About the Project](#star2-about-the-project)
    - [:camera: Screenshots](#camera-screenshots)
    - [:space_invader: Tech Stack](#space_invader-tech-stack)
    - [:dart: Features](#dart-features)
    - [:art: Color Reference](#art-color-reference)
    - [:key: Environment Variables](#key-environment-variables)
      - [Steps to Configure Environment Variables](#steps-to-configure-environment-variables)
  - [:zap: Getting Started](#zap-getting-started)
    - [:bangbang: Prerequisites](#bangbang-prerequisites)
    - [:zap: Run Locally](#zap-run-locally)
  - [:grey_question: FAQ](#grey_question-faq)
  - [:handshake: Contact](#handshake-contact)
  - [:gem: Acknowledgments](#gem-acknowledgments)

<!-- About the Project -->

## :star2: About the Project

The "Fitness Home" gym management system is a solution for simplifying operations within a gym environment designed by a group of students of the 17th Batch of the Diploma in Information Technology program at Esoft Metro Campus Gampaha Branch. The objective of this system is to simplify operations within a gym environment by providing a user friendly interaction for members, trainers, and administrators.

<!-- Screenshots -->

### :camera: Screenshots

<div align="center"> 
  <img src="assets/images/splash-screen.jpg" alt="screenshot" />
</div>

<!-- TechStack -->

### :space_invader: Tech Stack

<details>
  <summary>Application</summary>
  <ul>
    <li><a href="https://learn.microsoft.com/en-us/dotnet/csharp" target="_blank">C#</a></li>
    <li><a href="https://learn.microsoft.com/en-us/dotnet/desktop/winforms/overview/?view=netdesktop-8.0" target="_blank">Windows Forms</a></li>
  </ul>
</details>

<details>
  <summary>Documentation Website</summary>
  <ul>
    <li><a href="https://www.typescriptlang.org/" target="_blank">Typescript</a></li>
    <li><a href="https://react.dev/" target="_blank">React</a></li>
    <li><a href="https://nextjs.org/" target="_blank">Next.js</a></li>
  </ul>
</details>

<!-- Features -->

### :dart: Features

- **Automatic Login**: If the user has already logged in earlier, they are directly taken to their dashboard. The application directly takes them into their account as the email and password stored in the `App.config` file from the previous login provide direct access, and they need not authenticate themselves again.

- **New Member Self-Registration**: This facility offered by Fitness Home allows the new members to fill in their registration information, choose a membership plan, and even pay for the membership and admission fees while enrolling.

- **Trainer Functions**: The trainers shall be able to conduct classes, discuss things with the members, and assess the progress of every member in their fitness by setting daily calorie goals, activities, height, and weight metrics.

- **Admin Dashboard**: The system offers a dashboard where all the activities around the gym can be tracked, and profile information reviewed for the administrators.

<!-- Color Reference -->

### :art: Color Reference

| Color            | Hex     |
| ---------------- | ------- |
| Background Color | #0D0D0D |
| Accent Color     | #A1D200 |
| Text Color       | #FFFFFF |

<!-- Env Variables -->

### :key: Environment Variables

To run this project, you need to set up the following configuration in the `App.config` file located in the `fitness-home` directory. This configuration includes database connection settings and user credentials.

#### Steps to Configure Environment Variables

1. **Open the `App.config` file:**

   ```xml
   <?xml version="1.0" encoding="utf-8" ?>
   <configuration>
       <startup>
           <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
       </startup>

       <appSettings>
           <add key="DB_HOST" value="METHSIE\SQLEXPRESS" />
           <add key="DB_USER" value="db_user" />
           <add key="DB_PASS" value="GymApp!23$7" />
           <add key="DB_NAME" value="fitness-home" />
           <add key="USER_EMAIL" value="" />
           <add key="USER_PASSWORD" value="" />
       </appSettings>
   </configuration>

   ```

2. **Set `DB_HOST` to your SQL Server instance** (i.e. Server name used when connecting to the SSMS).

3. **Create a new SQL Server user:**

- Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.
- In Object Explorer, expand your server and navigate to `Security > Logins`.
- Right-click Logins and select New Login.
- Enter the following credentials:
  - Login name: `db_user`
  - Password: `GymApp!23$7`
- Under Server Roles, assign the user the necessary permissions, such as `db_datareader` and `db_datawriter`, to allow read and write access to the database.
- Click OK to create the user.
- Right click on the Server, navigate to `Properties > Security` and ensure SQL Server and Windows Authentication mode is enabled.

By following these steps, you will configure the necessary environment variables for the project to connect to the database and support user authentication.

## :zap: Getting Started

### :bangbang: Prerequisites

To run this project, you need to have the following tools installed:

1. **.NET SDK**  
   Download and install the .NET SDK (version 6.0 or later) from the official .NET website:  
   [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

2. **Visual Studio**

   - Install Visual Studio 2022 (or later) with the **.NET desktop development** workload.
   - You can download Visual Studio from:  
     [https://visualstudio.microsoft.com/downloads](https://visualstudio.microsoft.com/downloads)

3. **SQL Server**

   - Install Microsoft SQL Server (2019 or later) for database management.
   - You can download the **SQL Server Express edition** from:  
     [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

4. **SQL Server Management Studio (SSMS)**
   - Install SSMS to manage your SQL Server instance and execute the initialization script.
   - Download SSMS from:  
     [https://aka.ms/ssmsfullsetup](https://aka.ms/ssmsfullsetup)

Once these prerequisites are installed, you can proceed to clone the project and set up the database.

<!-- Run Locally -->

### :zap: Run Locally

1. Clone the project

```bash
  git clone https://github.com/NethminaGunasekara/fitness-home.git
```

2. Navigate to the project directory

```bash
  cd fitness-home
```

3. Open the solution in Visual Studio (`fitness-home.sln`)
   <br />

4. Set up sample data, including an admin account, a trainer account, and membership plans:

- Open [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
- Connect to your SQL Server instance.
- Execute the SQL script located at `assets/scripts/initialize.sql` by opening and executing it in SSMS. This will create initial test data for the gym management system.

5. Build and Run the Application

- In Visual Studio, go to "Build > Build Solution" or press `Ctrl+Shift+B` to build the solution.
- Click Start or press F5 to run the application.

<!-- FAQ -->

## :grey_question: FAQ

- **Is this project complete?**

  - Although we have completed the member dashboard and member registration, there are still many features to develop within the admin and trainer dashboards of our gym management system. These will be added progressively through our team's collaborative efforts.

<!-- Contact -->

## :handshake: Contact

- Shanuka Ravishan - [@.shanu.\_a.](https://www.instagram.com/.shanu._a.?igsh=MXhseWN2YjgwaDg2YQ==) - shanukaravishan01@gmail.com
- Nethmina Gunasekara - [@nethminagunasekara](https://www.instagram.com/nethminagunasekara/profilecard/?igsh=MXNpZHM3eGNpNnV2MQ==) - nethminagunasekara01@gmail.com

<!-- Acknowledgments -->

## :gem: Acknowledgments

We are grateful to all the following resources and libraries that contributed in making this project possible:

- [SVG Repo](https://www.svgrepo.com) - For providing high quality SVG icons featured in the UI.
- [Awesome README Template by Louis3797](https://github.com/Louis3797/awesome-readme-template) - For the creative layout and design of README’s template.
