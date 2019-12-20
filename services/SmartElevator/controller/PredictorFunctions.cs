
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
    public static class PredictorFunctions
    {
        [FunctionName("TriggerPredictor")]
        public static IActionResult TriggerEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Predictor/Trigger")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request."); // TODO update logging

            int floorNumber = PredictorService.PredictFloor();
            PredictorService.SendPredictionNotification(floorNumber);

            return new OkResult();
        }

        [FunctionName("PredictFloor")]
        public static IActionResult PredictFloorEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Predictor/PredictFloor")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request."); // TODO update logging

            int floorNumber = PredictorService.PredictFloor();

            return new OkObjectResult(floorNumber);
        }

        [FunctionName("SendPredictorNotification")]
        public static IActionResult SendNotificationEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Predictor/SendNotification")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request."); // TODO update logging

            // Placeholder - get from query string
            string floorNumber = req.Query["floorNumber"];

            PredictorService.SendPredictionNotification(int.Parse(floorNumber));

            return new OkResult();
        }
    }
}
