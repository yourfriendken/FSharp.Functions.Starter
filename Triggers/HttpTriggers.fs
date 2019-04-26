namespace App

open Microsoft.Azure.WebJobs
open System.Net.Http
open Models
open HttpHelpers

module HttpTriggers =
    [<FunctionName("Ping")>]
    let ping ([<HttpTrigger(Route = "ping")>] req : HttpRequestMessage) =
        JsonOkResponse { Name = "Pong!"; Description = "This route is used to test if the app is running" }
