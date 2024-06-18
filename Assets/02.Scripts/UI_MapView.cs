using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapView : MonoBehaviour
{
    public RawImage MapImage;
    public InputField MyInputField;

    private void Awake()
    {
        MapImage = GetComponentInChildren<RawImage>();
        MyInputField = GetComponentInChildren<InputField>();
        this.gameObject.SetActive(false);

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
