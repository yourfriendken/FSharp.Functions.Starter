namespace App

open System.Net.Http
open System.Text
open System.Net

open Newtonsoft.Json

module HttpHelpers =
    /// Object to Json
    let internal toJson<'t> (object : 't) =
        JsonConvert.SerializeObject(object)

    let JsonResponse status data =
        let response = new HttpResponseMessage(status)
        response.Content <- new StringContent(data |> toJson, Encoding.UTF8, "application/json")
        response

    let JsonOkResponse content = 
        JsonResponse HttpStatusCode.OK content
