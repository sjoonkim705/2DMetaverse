using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_ArticleWrite : MonoBehaviour
{
    [HideInInspector]
    public InputField MyTextField;
    [HideInInspector]
    public Toggle NoticeToggle;
    
    private void Awake()
    {
        MyTextField = GetComponentInChildren<InputField>();
        NoticeToggle = GetComponentInChildren<Toggle>();
    }
    public void OnCloseButtonClicked()
    {
        this.gameObject.SetActive(false);
    }

    public void OnSubmitButtonClicked()
    {
        string name = "김성준";
        string content = MyTextField.text;

        Article newArticle = new Article(name, content);
        if (NoticeToggle.isOn)
        {
            newArticle.ArticleType = ArticleType.Notice;
        }
        ArticleManager.Instance.Articles.Add(newArticle);
        ArticleManager.Instance.UI_ArticleList.Refresh();

        this.gameObject.SetActive(false);

    }
}
