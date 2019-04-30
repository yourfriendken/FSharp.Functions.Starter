namespace Tests 

open Xunit
open App
open HttpHelpers
open System.Net
open System.Net.Http
open Xunit
open System
open Microsoft.Extensions.Primitives
open Xunit

module HttpHelperTests = 
    
    [<Fact>]
    let ``Test JsonResponse`` () =
        let resposne = JsonResponse HttpStatusCode.Ambiguous "test"
        Assert.Equal(resposne.StatusCode, HttpStatusCode.Ambiguous)
    
    [<Fact>]
    let ``Test JsonOkResponse`` () =
        let resposne = JsonOkResponse "test"
        Assert.Equal(resposne.StatusCode, HttpStatusCode.OK)

    [<Fact>]
    let ``Test getQueryParameters`` () =
        let req = new HttpRequestMessage(HttpMethod.Get, "http://test.com?name=Joe")
        let queryParams = getQueryParameters req
        Assert.True(queryParams.ContainsKey("name"))
        Assert.True(queryParams.ContainsValue("Joe" |> StringValues))
        Assert.False(queryParams.ContainsValue("Jill" |> StringValues))

    [<Fact>]
    let ``Test getQueryParam`` () =
        let req = new HttpRequestMessage(HttpMethod.Get, "http://test.com?name=Joe")
        let name = getQueryParam req "name"
        Assert.Equal(Some("Joe"),name)
        let foo = getQueryParam req "foo"
        Assert.Equal(None,foo)

    
    [<Fact>]    
    let ``Test getQueryParamAsString`` () =
        let req = new HttpRequestMessage(HttpMethod.Get, "http://test.com?name=Joe")
        let name = getQueryParamAsString req "name"
        Assert.Equal("Joe",name)
        let foo = getQueryParamAsString req "foo"
        Assert.Equal("",foo)