using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebImageTest : MonoBehaviour
{
    public RawImage ImageUI;

    // HTTP: 웹이서 요청(Request)과 응답(Response)을 하기 위한 약속된 형태의 주문서(Text)
    // 웹(Web): 거미줄이라는 뜻으로 현재는 "인터넷"을 의미
    // Request와 Response 

    void Start()
    {
        // 네트워크를 통해 데이터를 받아오는 것은 실시간이 아니기 때문에
        // 코루틴을 이요해서 비동기로 데이터를 받아온다.
        
        ImageUI = GetComponent<RawImage>();
        string imageURL = "https://cdn.epnews.net/news/photo/202311/33421_25614_4511.png";
        StartCoroutine(GetTexture());
    }
    IEnumerator GetTexture()
    {
        // Http 주문을 위해 주문서(Request)를 만든다.
        // -> 주문서 내용: URL로부터 텍스처(image)를 다운로드하기위한 Get request 요청


        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://cdn.epnews.net/news/photo/202311/33421_25614_4511.png");
        yield return www.SendWebRequest(); // 비동기

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            ImageUI.texture = myTexture;

        }
    }
}
