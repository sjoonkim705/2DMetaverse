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
public class Article // Quest, Item, Achievement
{

    public ArticleType ArticleType; // 일반글? 공지사항글이냐?
    public string Name;             // 글쓴이
    public string Title;            // 글 제목
    public string Content;          // 글 내용
    public int Like;                // 좋아요 개수
    public DateTime WriteTime;      // 글 쓴 날짜/시간

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
