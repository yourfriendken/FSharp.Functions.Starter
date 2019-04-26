namespace App

open Microsoft.Azure.WebJobs
open System.Net.Http
open Microsoft.Azure.WebJobs.Extensions.Http
open Models
open HttpHelpers

module HttpRoutes =
    [<FunctionName("ping")>]
    let ping ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ping")>] req : HttpRequestMessage) =
        let data =
            { Name = "Ping"
              Description = "This route is used to test if the app is running" }
        JsonOkResponse data
