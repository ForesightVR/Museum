﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Valve.Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System;

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
        Debug.Log("GetAllVendors");

        var request = CreateGetRequest(vendorsApiString);

        yield return request.SendWebRequest();

        if (request.isNetworkError)
            throw new System.Exception(request.error);
        else
        {
            Debug.Log(request.downloadHandler.text);
            JArray jsonArray = JArray.Parse(request.downloadHandler.text);
            CreateArtists(jsonArray);   
        }
    }

    static void CreateArtists(JArray jArray)
    {
        foreach (JObject jObject in jArray)
        {
            JObject data = JObject.Parse(jObject.ToString());
            Artist artist = new Artist((int)data["id"], $"{data["first_name"]} {data["last_name"]}", (string)data["shop"]["description"]);

            string artistImageString = GetImageLink((string)data["shop"]["description"]);
            CoroutineUtility.instance.StartCoroutine(GetImage(artist, artistImageString));

            artists.Add(artist);
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
                CreateArt(jsonArray, artist);
                //CreateArtists(jsonArray);
            }
        }        
    }

    static void CreateArt(JArray jArray, Artist artist)
    {
        Debug.Log("Creating Art...");
        foreach (JObject jObject in jArray)
        {
            JObject data = JObject.Parse(jObject.ToString());

            if (artist.vendorId == 0)
            {
                Debug.LogError("There was no matching vendor for " + data["name"].ToString());
            }
            //create new art
            //add it to the list of vendor

            var intList = data["variations"]?.Select(x => (int)x).ToList() ?? new List<int>();


            string tag = (string)data["tags"][0]["name"];
            Debug.Log("Cause: " + tag);

            Art art = new Art((int)data["id"], new List<int>(intList), data["name"].ToString(), StripHTML(data["description"].ToString()), tag);

            CoroutineUtility.instance.StartCoroutine(GetImage(art, (string)data["images"][0]["src"]));
            artist.artPieces.Add(art);
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

    static IEnumerator GetImage(Artist artist, string imagePath)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imagePath);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            artist.artistImage = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }

    static IEnumerator GetImage(Art art, string imagePath)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imagePath);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            art.artImage = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }

    static string GetImageLink(string data)
    {
        string searchCharacters = "src=\"";

        var searchCharIndex = data.IndexOf(searchCharacters);

        string imageLink = "";

        if (searchCharIndex > 0)
        {
            imageLink = ParseHTMLAttribute(searchCharIndex + searchCharacters.Length, data);
        }
        else
        {
            imageLink = "";  //we could have a link to a default image if their description doesn't have an iamge
            Debug.Log("No Image Found!");
        }

        return imageLink;
    }
    static string ParseHTMLAttribute(int startingIndex, string htmlString)
    {
        var endingIndex = htmlString.IndexOf('"', startingIndex);

        return htmlString.Substring(startingIndex, endingIndex - startingIndex);
    }
    static string StripHTML(string input)
    {
        return Regex.Replace(input, "<.*?>", String.Empty);
    }
}
