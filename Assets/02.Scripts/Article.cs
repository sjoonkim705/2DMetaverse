using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ArticleType
{
    Normal,
    Notice,
}

public class Article // Quest, Item, Achievement
{

    public ArticleType ArticleType; // 일반글? 공지사항글이냐?
    public string Name;             // 글쓴이
    public string Title;            // 글 제목
    public string Content;          // 글 내용
    public int Like;                // 좋아요 개수
    public DateTime WriteTime;      // 글 쓴 날짜/시간

}
