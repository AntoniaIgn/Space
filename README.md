# Space Shuttle Launch Weather Analysis
This C# (.NET Core) Console Application analyzes weather conditions for space shuttle launches across various spaceports. The application calculates the best date for launching at each spaceport based on specific weather criteria and determines the optimal combination of date and location for the launch. Additionally, it generates a CSV report summarizing the best launch dates for each spaceport and sends this report via email.

# Features
Input Parameters: The application accepts input parameters including the folder name containing weather forecast files, sender email address, password, and receiver email address.
Weather Criteria: The weather conditions for a successful space shuttle launch include temperature between 1 and 32 degrees Celsius, wind speed no more than 11m/s, humidity less than 55%, no precipitation, no lightning, and no cumulus or nimbus clouds.
Launch Analysis: The application calculates the best launch date for each spaceport and determines the optimal combination of date and location.
CSV Report Generation: It generates a CSV report named "LaunchAnalysisReport.csv" containing the best launch date for each spaceport.
Multilingual Support: The application supports English and German languages with the ability to change the language.
Customizable Weather Criteria: Users can enter weather criteria as input parameters, allowing flexibility in analyzing weather conditions.
Email Notification: The application sends the generated CSV report to the specified email address, with the best launch combination included in the email body.

# Installation
Clone the repository to your local machine.
Open the project in Visual Studio or any compatible IDE.
Build the project to ensure all dependencies are resolved.
Run the application and provide the required input parameters.

# Usage
Launch the application.
Enter the folder name containing weather forecast files.
Provide the sender email address and password for SMTP authentication.
Enter the receiver email address.
Optionally, customize weather criteria if needed.
Run the analysis.
Check the generated "LaunchAnalysisReport.csv" file for the best launch dates.
Check your email for the detailed launch analysis report.

# Contributing
Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request.
