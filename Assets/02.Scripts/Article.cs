using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MVC 아키텍쳐 패턴
// Model -      데이터와 그 데이터를 다루는 로직 -> Article
// View -       UI, 사용자 인터페이스 -> UI_Article, UI_ArticleList
// Controller - 관리자. Model <-> View 중재자 -> ArticleManager
// 위 요소들(데이터, 시각적, 관리)의 간섭없이 독립적으로 개발할 수 있다.

public enum ArticleType
{
    Normal,
    Notice,
}
[Serializable]
[BsonIgnoreExtraElements]
public class Article // Quest, Item, Achievement
{
    [BsonId] 
    public ObjectId Id;             // 유일한 주민번호: ID, _id, id (시간 + 기가ID + 프로세스ID + count)
    public ArticleType ArticleType; // 일반글? 공지사항글이냐?
    [BsonElement("Name")]
    public string Name;             // 글쓴이
    public string Content;          // 글 내용
    public int Like;                // 좋아요 개수
    public DateTime WriteTime;      // 글 쓴 날짜/시간
    [BsonDefaultValue("http://192.168.200.47:1043/empty.png")]
    public string Profile { get; set; }

    public Article()
    {
        Like = 0;
        WriteTime = DateTime.Now;
        ArticleType = ArticleType.Normal;
        Profile = "http://192.168.200.47:1043/empty.png";
    }
    
    public Article(string name, string content)
    {
        Name = name;
        Content = content;
        Like = 0;
        WriteTime = DateTime.Now;
        ArticleType = ArticleType.Normal;
        Profile = "http://192.168.200.47:1043/empty.png";
    }
}


[Serializable]
public class ArticleData
{
    public List<Article> Data;

    public ArticleData(List<Article> data)
    {
        Data = data;
    }
}
