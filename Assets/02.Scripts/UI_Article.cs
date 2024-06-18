using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class UI_Article : MonoBehaviour
{
    public Text NameTextUI;        // 글쓴이
    public Text ContentTextUI;    // 글 내용
    public Text LikeTextUI;       // 좋아요 개수
    public Text WriteTimeUI;      // 글 쓴 날짜/시간
    public GameObject PrefMenuUI;
    public RawImage ProfileRawImage;
    private static Dictionary<string, Texture> _cache = new Dictionary<string, Texture>();

    [HideInInspector]
    public Article MyArticle;
    private void Awake()
    {
        ProfileRawImage = GetComponentInChildren<RawImage>();
 
    }
    public void Init(in Article article)
    {
        NameTextUI.text = article.Name;
        ContentTextUI.text = article.Content;
        LikeTextUI.text = $"좋아요 {article.Like}";
        WriteTimeUI.text = GetTimeString(article.WriteTime.ToLocalTime());
        PrefMenuUI.SetActive(false);
        MyArticle = article;
  
        StartCoroutine(GetTexture(article.Profile));
        
    }
    IEnumerator GetTexture(string profileUrl)
    {
        if (_cache.ContainsKey(profileUrl)) // 캐시된게 있을때 -> 캐시 히트
        { 
            ProfileRawImage.texture = _cache[profileUrl];
            Debug.Log($"Cache Hit!");
            yield break;
        }
            // Http 주문을 위해 주문서(Request)를 만든다.
            // -> 주문서 내용: URL로부터 텍스처(image)를 다운로드하기위한 Get request 요청

            UnityWebRequest www = UnityWebRequestTexture.GetTexture(profileUrl);
        yield return www.SendWebRequest(); // 비동기

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;


            ProfileRawImage.texture = myTexture;
            Debug.Log($"Cache Miss");
            _cache[profileUrl] = myTexture;

        }
    }
    private string GetTimeString(DateTime dateTime)
    {
        TimeSpan timeSpan = DateTime.Now - dateTime;
        if (dateTime == null)
        {
            return "null";
        }
        else
        {
            if (timeSpan.TotalMinutes < 15)
            {
                return "방금전";
            }
            else if (timeSpan.TotalMinutes < 60)
            {
                return $"{timeSpan.TotalMinutes:N0}분전";
            }
            else if (timeSpan.TotalHours < 24)
            {
                return $"{timeSpan.TotalHours:N0}시간전";
            }
            else if (timeSpan.TotalDays < 7)
            {
                return $"{timeSpan.TotalDays:N0}일전";
            }
            else if (timeSpan.TotalDays < 4 * 7)
            {
                return $"{timeSpan.TotalDays/7:N0}주전";
            }
            else
            {
                return dateTime.ToString();
            }
        }
    }
    public void OnMenuButtonClicked()
    {
        if (PrefMenuUI.activeInHierarchy)
        {
            PrefMenuUI.SetActive(false);
        }
        else
        {
            PrefMenuUI.SetActive(true);
        }
    }
    public void OnLikeButtonClicked()
    {
        ArticleManager.Instance.AddLike(MyArticle);
        ArticleManager.Instance.FindAll();
        ArticleManager.Instance.UI_ArticleList.Refresh();

    }
}
