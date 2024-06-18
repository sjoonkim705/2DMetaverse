using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_ArticleWrite : MonoBehaviour
{
    [HideInInspector]
    public InputField MyInputFieldUI;
    [HideInInspector]
    public Toggle NoticeToggleUI; //
    
    private void Awake()
    {
        MyInputFieldUI = GetComponentInChildren<InputField>();
        NoticeToggleUI = GetComponentInChildren<Toggle>();

    }
    private void Start()
    {
        this.gameObject.SetActive(false);
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

        ArticleManager.Instance.Write(articleType, content);
        ArticleManager.Instance.UI_ArticleList.Refresh();

        this.gameObject.SetActive(false);

    }
}
