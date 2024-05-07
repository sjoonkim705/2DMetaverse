using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ArticleManager : MonoBehaviour
{
    private List<Article> _articles = new List<Article>();
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
    }
    private void Start()
    {
        _articles.Add(new Article()
        {
            Name = "김성준",
            Content = "누구세요",
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
        });
    }


    
}
