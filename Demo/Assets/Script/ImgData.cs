using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgData : MonoBehaviour
{
    [SerializeField] public Image img;

    [HideInInspector]
    public Image imValue;
    public bool isMatch = false;
    private Button buttonComponent;
    public string nameSprite;


    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        img = GetComponent<Image>();
        imValue = GetComponent<Image>();
        if (buttonComponent)
        {
            buttonComponent.onClick.AddListener(() => ImgSelected());

        }
        //Check();
    }

    public void SetImg(Image ig)
    {
        img.sprite = ig.sprite;
        imValue = ig;

    }

    private void ImgSelected()
    {
        TileManager.instance.SelectedOption(this);
    }
}
