namespace App

open Microsoft.Azure.WebJobs

module TimerTriggers =
    // Uncomment to register function - only works with AzureWebJobsStorage set in local.settings.json
    // [<FunctionName("Timer")>] 
    let Timer ([<TimerTrigger("* * * * * *")>] timer:TimerInfo) =
        System.Console.WriteLine(System.DateTime.Now.ToLongTimeString())
    ()