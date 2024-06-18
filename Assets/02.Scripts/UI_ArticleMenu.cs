using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ArticleMenu : MonoBehaviour
{
    private UI_Article _myArticle;
    public UI_ArticleModify UI_ArticleModify;

    private void Awake()
    {
        _myArticle = GetComponentInParent<UI_Article>();
        if (UI_ArticleModify.gameObject.activeSelf)
        {
            UI_ArticleModify.gameObject.SetActive(false);
        }

    }
    public void OnDeleteButtonClicked()
    {
        ArticleManager.Instance.Delete(_myArticle.MyArticle);
        ArticleManager.Instance.FindAll();
        ArticleManager.Instance.UI_ArticleList.Refresh();


        Debug.Log(_myArticle.ContentTextUI.text);
    }
    public void OnModifyButtonClicked()
    {
        UI_ArticleModify.TargetArticle = _myArticle.MyArticle;
        UI_ArticleModify.ExistingText = _myArticle.MyArticle.Content;
        bool IsNotice = false;
        if (_myArticle.MyArticle.ArticleType == ArticleType.Notice)
        {
            IsNotice = true;
        }
        UI_ArticleModify.IsNotice = IsNotice;

        UI_ArticleModify.gameObject.SetActive(true);

    }
}
