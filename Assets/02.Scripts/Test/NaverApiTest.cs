using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


using UnityEngine.Networking;

public class NaverApiTest : MonoBehaviour
{
    private string clientId = "PwkQvJVjCm3Gdzy2V_nQ"; // 네이버 개발자 센터에서 발급받은 클라이언트 ID
    private string clientSecret = "L4CWSdFx5L"; // 네이버 개발자 센터에서 발급받은 클라이언트 시크릿
    public RawImage ProductImage;


    void Start()
    {
        StartCoroutine(SearchNaver("기계식키보드"));
    }

    IEnumerator SearchNaver(string query)
    {
        string url = "https://openapi.naver.com/v1/search/shop.json?display=25&query=" + UnityWebRequest.EscapeURL(query);

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("X-Naver-Client-Id", clientId);
        www.SetRequestHeader("X-Naver-Client-Secret", clientSecret);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string jsonResponse = www.downloadHandler.text;
            Debug.Log(jsonResponse);
            ParseJson(jsonResponse);
        }
    }

    void ParseJson(string jsonResponse)
    {
        Debug.Log(jsonResponse);
        ShoppingItems a = JsonUtility.FromJson<ShoppingItems>(jsonResponse);
        Debug.Log(a.total);
        Debug.Log(a.items[0].title);
    }
    IEnumerator ShowTexture(List<Item> items, float duration)
    {
        foreach (Item item in items)
        {
            
            yield return new WaitForSeconds(duration);
        }
    }
}


public class ShoppingItems
{
    public DateTime lastBuildDate;//: "Tue, 14 May 2024 10:46:09 +0900",
    public long total;
    public int start;
    public int display;

    public List<Item> items;

}

[Serializable]
public class Item
{
    public string title; //: "웨이코스 씽크웨이 X VGN TV99 유무선 99배열 <b>기계식 키보드</b>",
    public string link;  // : "https://search.shopping.naver.com/gate.nhn?id=44775642618",
    public string image; // "image": "https://shopping-phinf.pstatic.net/main_4477564/44775642618.20240122155827.jpg",
    public int lprice; // : "139000",
    public int hprice; // : "",
    public string mallName; // : "네이버",
    public long productId; // : "44775642618",
    public int productType; // : "1",
    public string brand;  //  : "씽크웨이",
    public string maker; // : "웨이코스",
    public string category1; // : "디지털/가전",
    public string category2; // : "주변기기",
    public string category3; //: "키보드",
    public string category4;  // : "무선키보드"*/
}
