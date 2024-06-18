using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ArticleModify : MonoBehaviour
{
    public static UI_ArticleModify instance { get; private set; }
    public Article TargetArticle;
    public string ExistingText;
    public bool IsNotice;

    [HideInInspector]
    public InputField MyInputFieldUI;
    [HideInInspector]
    public Toggle NoticeToggleUI; //

    private void Awake()
    {
        MyInputFieldUI = GetComponentInChildren<InputField>();
        NoticeToggleUI = GetComponentInChildren<Toggle>();
    }
    private void OnEnable()
    {
        MyInputFieldUI.text = ExistingText;
        if (IsNotice)
        {
            NoticeToggleUI.isOn = true;
        }
        else
        {
            NoticeToggleUI.isOn = false;
        }
    }
    private void OnDisable()
    {
        MyInputFieldUI.text = string.Empty;
        IsNotice = false;
    }
    public void OnCloseButtonClicked()
    {
        FindObjectOfType<UI_ArticleWrite>().gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void OnSubmitButtonClicked()
    {
        ArticleType articleType = NoticeToggleUI.isOn ? ArticleType.Notice : ArticleType.Normal;
        string content = MyInputFieldUI.text;

        ArticleManager.Instance.Modify(TargetArticle, content, NoticeToggleUI.isOn);
        ArticleManager.Instance.FindAll();
        ArticleManager.Instance.UI_ArticleList.Refresh();

        this.gameObject.SetActive(false);

    }
}
