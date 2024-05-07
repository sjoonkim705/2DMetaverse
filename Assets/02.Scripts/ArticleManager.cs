using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ArticleManager : MonoBehaviour
{
    private List<Article> _articles = new List<Article>();
    public List<Article> Articles => _articles;

    public static ArticleManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        // 1. Filestream 으로 텍스트 저장
        // 2. 객체직렬화 -> Binary 저장
        // 3. Playerprefs
/*
        int score = 100;
        PlayerPrefs.SetInt("score", 100);

        Article article = new Article();
        article.Name = "이성민";
        article.Content = "네에~~";

        string jsonText = JsonUtility.ToJson(article);
        Debug.Log(jsonText);

        // Json형태의 텍스트를 객체로 역직렬화한다.
        Article loadedArticle = JsonUtility.FromJson<Article>(jsonText);
        Debug.Log(loadedArticle.Name);
        Debug.Log(loadedArticle.Content);
        Debug.Log(loadedArticle.Like);*/



/*        _articles.Add(new Article()
        {
            Name = "김성준",
            Content = "누구세요",
            ArticleType = ArticleType.Normal,
            Like = 20,
            WriteTime = DateTime.Now
        });
        _articles.Add(new Article()
        {
            Name = "조희수",
            Content = "해삐:)",
            ArticleType = ArticleType.Normal,
            Like = 908,
            WriteTime = DateTime.Now

        });
        _articles.Add(new Article()
        {
            Name = "고승연",
            Content = "안녕하세~",
            ArticleType = ArticleType.Normal,
            Like = 50,
            WriteTime = DateTime.Now
        });
        _articles.Add(new Article()
        {
            Name = "민예진",
            Content = "하이",
            ArticleType = ArticleType.Normal,
            Like = 7,
            WriteTime = DateTime.Now
        });
        _articles.Add(new Article()
        {
            Name = "김홍일",
            Content = "안녕하세요.",
            ArticleType = ArticleType.Normal,
            Like = 20,
            WriteTime = DateTime.Now
        });*/


        // 1. 객체를 Json형태로 변환한 다음 'data.txt'에 저장하고 확인한다.
/*        ArticleData articleData = new ArticleData(_articles);
        string jsonData = JsonUtility.ToJson(articleData);
        Debug.Log(jsonData);*/
        // 유니티의 특별한 파일 저장 경로
        // 유니티만이 쓸 수 있는 파일 저장 경로를 가지고 있다.
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath;
/*        StreamWriter sw = File.CreateText($"{path}/data.txt");
        sw.Write(jsonData);
        sw.Close();*/

        string txt = File.ReadAllText($"{path}/data.txt");
        _articles = JsonUtility.FromJson<ArticleData>(txt).Data;




/*        string data = JsonUtility.ToJson(_articles);
        FileStream fs = new FileStream("c:\\User\\data.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(data);
        sw.Close();*/
    }





    // 2. 데이터를 하드코딩한 코드를 지운다.
    
    // 3. 'data.txt' 로부터 json을 읽어와서 객체들을 초기화한다.

    
}
