# Event Venue Management

## Project Description

This monolithic architecture project aims for fast development, completing the initial version in just 4 hours. The backend of the application can retrieve a JSON list of venues and events. Users have the ability to view all events related to a selected venue, year, and month. The application utilizes .NET 6 with C# and incorporates caching (Memory Cache) to enhance performance in case the data source is unreliable.

## Features
*	Retrieve a list of venues and events
*	View events associated with a specific venue, year, and month
*	Detailed information about each event

## Technologies Used
*	.NET 6
*	C#
*	Memory Cache for caching data
*	Auto Mapper for efficient data mapping

## How to Install and Run the Project
1.	Clone the repository to your local machine.
2.	Build the project.
3.	Test the APIs using Swagger.
 
## AWS Lambda Endpoints
*	Get all data from the source: [Link](https://dy2t2lv56sjuukafecrzvlbyue0aaixj.lambda-url.us-east-1.on.aws/EventVenue/GetEventVenueList)
*	Get all venues: [Link](https://dy2t2lv56sjuukafecrzvlbyue0aaixj.lambda-url.us-east-1.on.aws/EventVenue/GetVenueList)
*	Get all events related to a venue, year, and month: [Link](https://dy2t2lv56sjuukafecrzvlbyue0aaixj.lambda-url.us-east-1.on.aws/EventVenue/GetEventList)
```
	Parameters:
{ 
	"venueId": 919,
	"selectedDate": "2022-06-23" 
}
```
*	Get information about a specific event: [Link](https://dy2t2lv56sjuukafecrzvlbyue0aaixj.lambda-url.us-east-1.on.aws/EventVenue/GetEvent/10000)
```
    Parameter:
	{eventId}
```

## User Interface with React
The next phase of the project involves creating a user interface using React. This will provide a dynamic and interactive front-end for users to seamlessly interact with the application.

## Keep it Up-to-Date
This README file will be regularly updated. Make sure to check back for the latest information.

