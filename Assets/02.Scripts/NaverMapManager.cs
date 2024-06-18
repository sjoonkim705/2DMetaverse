using System.Collections;
using System;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NaverMapManager : MonoBehaviour
{

    public RawImage MapImage; // 지도를 표시할 RawImage UI 컴포넌트
    private string clientId = "z9eakirm5f"; // 네이버 클라우드 플랫폼에서 발급받은 클라이언트 ID
    private string clientSecret = "ARdWgU4Kh6mTu2yufyJQyl2J0kMGdb7OWCxVuXuL"; // 네이버 클라우드 플랫폼에서 발급받은 클라이언트 시크릿
    public string startPointKeyword;
    public InputField StartInputField;
    public InputField DestinationInputField;


    public void OnSearchButtonClicked()
    {
        string startPointKeyword = StartInputField.text;
        StartCoroutine(GetMapImage(startPointKeyword));
    }

    IEnumerator GetMapImage(string query)
    {
        string url = "https://naveropenapi.apigw.ntruss.com/map-geocode/v2/geocode?query=" + UnityWebRequest.EscapeURL(query);
        UnityWebRequest searchRequest = UnityWebRequest.Get(url);
        searchRequest.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", clientId);
        searchRequest.SetRequestHeader("X-NCP-APIGW-API-KEY", clientSecret);

        yield return searchRequest.SendWebRequest();

        if (searchRequest.isNetworkError || searchRequest.isHttpError)
        {
            Debug.LogError(searchRequest.error);
        }
        else
        {
            string jsonResponse = searchRequest.downloadHandler.text;
            var responseJson = JsonUtility.FromJson<NaverSearchResponse>(jsonResponse);
            Debug.Log(jsonResponse);

            if (responseJson.addresses.Length > 0)
            {
                string mapUrl = GenerateMapUrl(responseJson.addresses[0].x, responseJson.addresses[0].y);
                Debug.Log(mapUrl);
                StartCoroutine(DownloadMapImage(mapUrl));
            }
        }
    }

    IEnumerator DownloadMapImage(string mapUrl)
    {

        Debug.Log(mapUrl);
        UnityWebRequest mapRequest = UnityWebRequestTexture.GetTexture(mapUrl);
        mapRequest.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", clientId);
        mapRequest.SetRequestHeader("X-NCP-APIGW-API-KEY", clientSecret);

        yield return mapRequest.SendWebRequest();

        if (mapRequest.isNetworkError || mapRequest.isHttpError)
        {
            Debug.LogError(mapRequest.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(mapRequest);
            MapImage.texture = texture;
        }

    }
    string GenerateMapUrl(string mapx, string mapy)
    {
        string mapUrl = $"https://naveropenapi.apigw.ntruss.com/map-static/v2/raster?center={mapx},{mapy}&level=16&w=700&h=500&markers=type:d|size:mid|pos:{mapx} {mapy}";
        return mapUrl;
    }

    [Serializable]
    public class NaverSearchResponse
    {
        public NaverSearchItem[] addresses;
    }

    [Serializable]
    public class NaverSearchItem
    {
        public string x;
        public string y;
    }
}
