using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ArticleList : MonoBehaviour
{

    public List<UI_Article> UIArticles;
    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        // 1. Article매니저로부터 Article을 가져온다.
        // 2. 모든 UI_Article을 끈다.

        // 3. 가져온 article갯수만큼 UI_Article을 보여준다.
        // 4. 각 UI_Article의 내용을 Article 로 초기화(Init)한다.


    }
}