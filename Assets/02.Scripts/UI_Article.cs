using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Article : MonoBehaviour
{
    public Text NameTextUI;        // 글쓴이
    //public Text TitleTextUI;      // 글 제목
    public Text ContentTextUI;    // 글 내용
    public Text LikeTextUI;       // 좋아요 개수
    public Text WriteTimeUI;      // 글 쓴 날짜/시간

    public void Init(Article article)
    {
        NameTextUI.text = article.Name;
        //TitleTextUI.text = article.Title;
        ContentTextUI.text = article.Content;
        LikeTextUI.text = $"좋아요 {article.Like}";
        WriteTimeUI.text = GetTimeString(article.WriteTime);
        //$"{article.WriteTime}";
    }
    private string GetTimeString(DateTime dateTime)
    {
        TimeSpan timeSpan = DateTime.Now - dateTime;
        //Debug.Log(timeSpan.ToString("mm"));
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
}
