
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using SmartElevator.services;

namespace SmartElevator
{
    public static class ElevatorFunctions
    {
        // This is an example function to show how to get params from the query string or event body
        [FunctionName("MyName")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Example of getting a query parameter
            string name = req.Query["name"];

            // Example of getting the data from the JSON POST body
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            // Example of accessing a field from the body
            // Note the '?.', which means it will only get 'name' if 'data' is not null
            // Without it, it data were null, we'd get a NullPointerException
            // More info: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }

        [FunctionName("TriggerElevator")]
        public static IActionResult TriggerEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Elevator/Trigger")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request."); // TODO update logging

            string elevatorNumber = ElevatorService.AssignElevator();
            ElevatorService.SendElevatorNotification(elevatorNumber);

            return new OkResult();
        }

        [FunctionName("AssignElevator")]
        public static IActionResult AssignElevatorEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Elevator/Assign")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request."); // TODO update logging

            string elevatorNumber = ElevatorService.AssignElevator();

            return new OkObjectResult(elevatorNumber);
        }

        [FunctionName("SendElevatorNotification")]
        public static IActionResult SendNotificationEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Elevator/SendNotification")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request."); // TODO update logging

            // Placeholder - get from query string
            string elevatorNumber = req.Query["elevatorNumber"];

            ElevatorService.SendElevatorNotification(elevatorNumber);

            return new OkResult();
        }
    }
}
