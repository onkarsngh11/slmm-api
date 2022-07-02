# Smart Lawn Mower Machine API

This Api provides functionality to perform following actions:

`GET` Position - Get current position of the machine

`POST` Move - Moves the machine by one step if coordinate is within the dimensions of garden

`POST` Turn - Turn the machine orientation based on Clockwise/AntiClockwise input provided

`POST` Reset - Resets the machine to `(0,0)` coordinates, sets the orientation to `North` and sets the `length` and `width` of the garden based on provided input

## Running solution locally

1. Clone the solution to desired directory.
2. Update `GardenDimensions` section in appsettings.json if you wish.
3. Simply, run the solution.

## Notes

1. To reset the lawn mower machine on application startup,`BackgroundService` is used to perform this action for which `Microsoft.Extensions.Hosting` is used.
2. Since, there is only one machine, Singleton class for mower looked like an appropriate choice for the solution.
3. All operations are asynchronous to support responsiveness of application.
4. Validation or some processing logic specific to some entity are created in the model itself to segregate responsibility.
5. Service layer is present for all the processing of lawn mower actions.
6. Framework provided DI is used to maintain lifecycle of singleton class or services used.

