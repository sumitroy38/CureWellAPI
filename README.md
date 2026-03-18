# CureWellAPI - Hospital Management Web API

This is the backend API for the CureWell Hospital Management application. It is built with ASP.NET Core and connects to a SQL Server database to manage doctors, specializations, and surgeries.

---

## What This API Does

The API exposes endpoints that the Angular frontend uses to:

- Fetch all doctors and specializations from the database
- Add and update doctor records
- Delete a doctor from the system
- Fetch surgeries scheduled for today
- Update the time of a scheduled surgery

---

## Tech Stack

- ASP.NET Core (.NET 10)
- C#
- Microsoft.Data.SqlClient for database access
- SQL Server (Express)
- ADO.NET for raw database queries

---

## Project Structure

```
CureWellAPI/
  Controllers/
    HomeController.cs      - All API endpoints
  Models/
    Doctor.cs              - Doctor model
    Specialization.cs      - Specialization model
    DoctorSpecialization.cs - DoctorSpecialization model
    Surgery.cs             - Surgery model
  CureWellRepository.cs    - All database operations
  Program.cs               - App configuration and CORS setup
```

---

## Database Design

The API connects to a SQL Server database called CureWell with four tables:

**Doctor**
- DoctorID (INT, Primary Key, starts from 1001)
- DoctorName (VARCHAR 25)

**Specialization**
- SpecializationCode (CHAR 3, Primary Key)
- SpecializationName (VARCHAR 20)

**DoctorSpecialization**
- DoctorID + SpecializationCode (Composite Primary Key)
- SpecializationDate (DATE)

**Surgery**
- SurgeryID (INT, Primary Key, starts from 5000)
- DoctorID (INT)
- SurgeryDate (DATE)
- StartTime (DECIMAL 4,2)
- EndTime (DECIMAL 4,2)
- SurgeryCategory (CHAR 3)

---

## API Endpoints

All endpoints are available under `/api/Home/`

| Action | Method | Route | Description |
|---|---|---|---|
| GetDoctors | GET | /api/Home/GetDoctors | Returns all doctors |
| GetSpecializations | GET | /api/Home/GetSpecializations | Returns all specializations |
| GetAllSurgeryTypeForToday | GET | /api/Home/GetAllSurgeryTypeForToday | Returns today's surgeries |
| AddDoctor | POST | /api/Home/AddDoctor | Adds a new doctor |
| UpdateDoctorDetails | PUT | /api/Home/UpdateDoctorDetails | Updates a doctor's name |
| UpdateSurgery | PUT | /api/Home/UpdateSurgery | Updates surgery start and end time |
| DeleteDoctor | DELETE | /api/Home/DeleteDoctor/{id} | Deletes a doctor |

---

## Getting Started Locally

**Requirements:**
- Visual Studio 2022 or later
- SQL Server Express
- .NET 10 SDK

**Step 1 - Clone the repository:**
```
git clone https://github.com/sumitroy38/CureWellAPI.git
```

**Step 2 - Set up the database:**

Open SQL Server Management Studio and run the following:

```sql
CREATE DATABASE CureWell;
GO

USE CureWell;

CREATE TABLE Doctor (
    DoctorID INT IDENTITY(1001, 1) PRIMARY KEY,
    DoctorName VARCHAR(25) NOT NULL
);

CREATE TABLE Specialization (
    SpecializationCode CHAR(3) PRIMARY KEY,
    SpecializationName VARCHAR(20) NOT NULL
);

CREATE TABLE DoctorSpecialization (
    DoctorID INT,
    SpecializationCode CHAR(3),
    SpecializationDate DATE NOT NULL,
    PRIMARY KEY (DoctorID, SpecializationCode),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
    FOREIGN KEY (SpecializationCode) REFERENCES Specialization(SpecializationCode)
);

CREATE TABLE Surgery (
    SurgeryID INT IDENTITY(5000, 1) PRIMARY KEY,
    DoctorID INT,
    SurgeryDate DATE NOT NULL,
    StartTime DECIMAL(4,2) NOT NULL,
    EndTime DECIMAL(4,2) NOT NULL,
    SurgeryCategory CHAR(3),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
    FOREIGN KEY (SurgeryCategory) REFERENCES Specialization(SpecializationCode)
);
```

**Step 3 - Insert sample data:**

```sql
USE CureWell;

INSERT INTO Doctor (DoctorName) VALUES ('Albert');
INSERT INTO Doctor (DoctorName) VALUES ('Olivia');
INSERT INTO Doctor (DoctorName) VALUES ('Susan');

INSERT INTO Specialization VALUES ('GYN', 'Gynecologist');
INSERT INTO Specialization VALUES ('CAR', 'Cardiologist');
INSERT INTO Specialization VALUES ('ANE', 'Anesthesiologist');

INSERT INTO DoctorSpecialization VALUES (1001, 'ANE', '2010-01-01');
INSERT INTO DoctorSpecialization VALUES (1002, 'CAR', '2010-01-01');
INSERT INTO DoctorSpecialization VALUES (1003, 'CAR', '2010-01-01');

INSERT INTO Surgery (DoctorID, SurgeryDate, StartTime, EndTime, SurgeryCategory)
VALUES (1001, CAST(GETDATE() AS DATE), 9.00, 14.00, 'ANE');
```

**Step 4 - Open the project in Visual Studio and press F5 to run**

The API will start at `https://localhost:7288`

**Step 5 - Accept the SSL certificate in your browser:**
```
https://localhost:7288/api/Home/GetDoctors
```

---

## CORS

The API is configured to allow requests from any origin so the Angular frontend can communicate with it without issues.

---

## Frontend Repository

The Angular frontend for this project is available here:
https://github.com/sumitroy38/CureWell
