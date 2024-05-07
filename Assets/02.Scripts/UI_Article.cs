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
        WriteTimeUI.text = $"{article.WriteTime}";
    }

}
