using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Valve.Newtonsoft.Json.Linq;

public static class MuseumBank
{
    static string oauth_consumerKey = "ck_7fadaa800f1910ae41d02859a814bb487a5acb34";
    static string oauth_consumerSecret = "cs_d0580a9960dd425db90bb587b04c569dab73efe8";

    static string vendorsApiString = "/wp-json/wcmp/v1/vendors";
    static string productsApiString = "/wp-json/wc/v3/products";

    public static List<Artist> artists = new List<Artist>();

    public static void CallGet()
    {
        CoroutineUtility.instance.StartCoroutine(GetAllVendors());
    }

    static IEnumerator GetAllVendors()
    {
        var request = CreateGetRequest(vendorsApiString);

        yield return request.SendWebRequest();

        if (request.isNetworkError)
            throw new System.Exception(request.error);
        else
        {
            JArray jsonArray = JArray.Parse(request.downloadHandler.text);
            CreateArtists(jsonArray);   
        }
    }

    static void CreateArtists(JArray jArray)
    {
        foreach(JObject jObject in jArray)
        {
            JObject data = JObject.Parse(jObject.ToString());

            artists.Add(new Artist((int)data["id"], $"{data["first_name"]} {data["last_name"]}", (string)data["shop"]["description"]));
        }

        CoroutineUtility.instance.StartCoroutine(GetAllProductsByVendor());
    }

    static IEnumerator GetAllProductsByVendor()
    {
        foreach (Artist artist in artists)
        {
            var request = CreateGetRequest(productsApiString, new List<string>() { $"vendor={artist.vendorId}"});

            yield return request.SendWebRequest();

            if (request.isNetworkError)
                throw new System.Exception(request.error);
            else
            {
                JArray jsonArray = JArray.Parse(request.downloadHandler.text);
                //CreateArtists(jsonArray);
            }
        }        
    }

    static void CreateArt(JArray jArray)
    {
        foreach (JObject jObject in jArray)
        {
            JObject data = JObject.Parse(jObject.ToString());
            //create new art
            //add it to the list of vendor
            //where product.vendor id = artists.vendor id

            //artists.Add(new Artist((int)data["id"], $"{data["first_name"]} {data["last_name"]}", (string)data["shop"]["description"]));
        }
    }

    static UnityWebRequest CreateGetRequest(string apiString)
    {
        string url = GenerateRequestURL("https://foresightvr.com" + apiString);
        var request = UnityWebRequest.Get(url);
        return request;
    }

    static UnityWebRequest CreateGetRequest(string apiString, List<string> parameters)
    {
        string url = GenerateRequestURL("https://foresightvr.com" + apiString, parameters);
        var request = UnityWebRequest.Get(url);
        return request;
    }

    static string GenerateRequestURL(string in_url, string HTTP_Method = "GET")
    {
        OAuth_CSharp oauth = new OAuth_CSharp(oauth_consumerKey, oauth_consumerSecret);
        string requestURL = oauth.GenerateRequestURL(in_url, HTTP_Method);

        return requestURL;
    }

    static string GenerateRequestURL(string in_url, List<string> parameters, string HTTP_Method = "GET")
    {
        OAuth_CSharp oauth = new OAuth_CSharp(oauth_consumerKey, oauth_consumerSecret);
        string requestURL = oauth.GenerateRequestURL(in_url, HTTP_Method, parameters);

        return requestURL;
    }
}
