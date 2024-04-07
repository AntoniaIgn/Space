# Space Shuttle Launch Weather Analysis
This C# (.NET Core) Console Application analyzes weather conditions for space shuttle launches across various spaceports. The application calculates the best date for launching at each spaceport based on specific weather criteria and determines the optimal combination of date and location for the launch. Additionally, it generates a CSV report summarizing the best launch dates for each spaceport and sends this report via email.

## Features
+ **Input Parameters**: The application accepts input parameters including the folder name containing weather forecast files, sender email address, password, and receiver email address.
+ **Weather Criteria**: The weather conditions for a successful space shuttle launch include temperature between 1 and 32 degrees Celsius, wind speed no more than 11m/s, humidity less than 55%, no precipitation, no lightning, and no cumulus or nimbus clouds.
+ **Launch Analysis**: The application calculates the best launch date for each spaceport and determines the optimal combination of date and location.
+ **CSV Report Generation**: It generates a CSV report named "LaunchAnalysisReport.csv" containing the best launch date for each spaceport.
+ **Multilingual Support**: The application supports English and German languages with the ability to change the language.
+ **Email Notification**: The application sends the generated CSV report to the specified email address, with the best launch combination included in the email body.

## Installation
1. Clone the repository to your local machine.
2. Open the project in Visual Studio or any compatible IDE.
3. Build the project to ensure all dependencies are resolved.
4. Run the application and provide the required input parameters.

## Usage
1. Launch the application.
2. Enter the folder name containing weather forecast files.
3. Provide the sender email address and password for SMTP authentication.
4. Enter the receiver email address.
5. Check the generated "LaunchAnalysisReport.csv" file for the best launch dates.
6. Check your email for the detailed launch analysis report.

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
