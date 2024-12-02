

---

# **PaySummary_DayForce**

## **Table of Contents**
1. [Overview](#overview)  
2. [Features](#features)  
3. [Technology Stack](#technology-stack)  
4. [Project Structure](#project-structure)  
5. [Setup Instructions](#setup-instructions)  
6. [Usage](#usage)  
7. [Methodology](#methodology)  
8. [Error Handling](#error-handling)  
9. [Future Enhancements](#future-enhancements)  
10. [Contributing](#contributing)  
11. [License](#license)  

---

## **Overview**
The **PaySummary_DayForce** application processes employee timecard data to generate summaries of total hours worked and total earnings for employees. It uses a timecard input and a rate table to compute accurate summaries based on job type, department, and pay rates, considering various earnings codes like *Regular*, *Overtime*, and *Double Time*.

### **Objective**
To automate and simplify payroll summaries, making the process efficient, scalable, and reliable.

---

## **Features**
- **Employee Pay Summary**: Generates total hours and pay summaries by earnings code.  
- **Rate Table Lookup**: Determines the applicable pay rate for employees based on job, department, and date ranges.  
- **Error Handling**: Handles invalid input and logging for debugging.  
- **Configurable Multipliers**: Allows easy modification of pay rate multipliers (e.g., overtime, double-time).  
- **Scalability**: Supports processing large datasets efficiently.  

---

## **Technology Stack**
- **Programming Language**: C#  
- **Framework**: .NET Core  
- **Database**: In-memory lists for demo (can integrate with SQL/NoSQL for production).  
- **Logging**: Microsoft.Extensions.Logging  

---

## **Project Structure**
```plaintext
PaySummary_DayForce/
├── Controllers/
│   └── PaySummaryController.cs      # Handles API requests
├── Models/
│   ├── Timecard_Record.cs           # Defines structure of timecard input
│   ├── Rate_Table_Row.cs            # Defines structure of rate table
│   ├── Pay_Summary_Record.cs        # Defines structure of output
├── Services/
│   └── PaySummaryService.cs         # Core logic for summary computation
├── Config/
│   └── ConfigSettings.cs            # Contains configurable multipliers
├── Program.cs                       # Main application entry point
├── README.md                        # Project documentation
└── appsettings.json                 # Configuration file (e.g., logging)
```

---

## **Setup Instructions**

### Prerequisites
1. Install [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later).  
2. Install a code editor (e.g., [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)).  

### Installation
1. Clone the repository:  
   ```bash
   git clone https://github.com/Meekdavid/PaySummary_DayForce.git
   cd PaySummary_DayForce
   ```
2. Restore dependencies:  
   ```bash
   dotnet restore
   ```
3. Build the project:  
   ```bash
   dotnet build
   ```

---

## **Usage**
### Running the Application
1. Run the application:  
   ```bash
   dotnet run
   ```
2. Use the API to generate pay summaries.

### Sample Input
#### Timecard Data:
```json
[
    { "Employee_Name": "Kyle James", "Employee_Number": "110011", "Hours": 40, "Rate": 18.75, "Earnings_Code": "Regular", "Job_Worked": "Laborer", "Dept_Worked": "001", "Date_Worked": "2024-01-15", "Bonus": 0 },
    { "Employee_Name": "Kyle James", "Employee_Number": "110011", "Hours": 8, "Rate": 18.75, "Earnings_Code": "Overtime", "Job_Worked": "Laborer", "Dept_Worked": "001", "Date_Worked": "2024-01-16", "Bonus": 0 }
]
```

#### Rate Table:
```json
[
    { "Job": "Laborer", "Dept": "001", "Hourly_Rate": 18.75, "Effective_Start": "2024-01-01", "Effective_End": "2024-12-31" }
]
```

---

## **Methodology**
1. **Input Validation**: The application validates the timecard and rate table inputs.
2. **Grouping**: Employee records are grouped by `Employee_Number`, and `Earnings_Code`, `Job_Worked` and `Dept_Worked`.
3. **Rate Lookup**: The highest applicable rate is selected from the rate table or provided rate.
4. **Calculations**:
   - **Total Hours**: Summed for each group.
   - **Total Pay**: Calculated as `(Hours * Rate * Multiplier) + Bonus`.
5. **Output**: Returns a list of pay summary records for each employee and earnings code.

---

## **Error Handling**
- Logs exceptions and errors using the built-in .NET logging framework.
- Validates inputs to prevent runtime errors.
- Gracefully handles missing rates by falling back to the employee's default rate.

---

## **Future Enhancements**
- **Database Integration**: Use SQL Server or NoSQL for scalable data storage.  
- **UI Integration**: Build a web interface for users to upload timecards and view summaries.  
- **Export Feature**: Allow summaries to be exported to CSV or Excel.  
- **Localization**: Support for multiple languages and currency formats.  

---

## **Contributing**
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a feature branch:  
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:  
   ```bash
   git commit -m "Add feature"
   ```
4. Push to your fork and submit a pull request.

---

## **License**


---

