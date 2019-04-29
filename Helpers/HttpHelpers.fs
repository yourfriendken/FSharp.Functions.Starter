namespace App

open System.Net.Http
open System.Text
open System.Net

open Newtonsoft.Json
open Microsoft.AspNetCore.WebUtilities

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

    let getQueryParameters (request: HttpRequestMessage) =
        QueryHelpers.ParseQuery request.RequestUri.Query

    let getQueryParam (request: HttpRequestMessage) name =
        let query = getQueryParameters request
        let param =
            if query.ContainsKey(name)
            then query.[name].ToString() |> Some
            else None
        param
    
    let getQueryParamAsString (request: HttpRequestMessage) name =
        match getQueryParam request name with
        | None -> ""
        | Some(v) -> v
       