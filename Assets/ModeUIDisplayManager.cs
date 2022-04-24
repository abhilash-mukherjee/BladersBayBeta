using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUIDisplayManager : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite[] spritList;
    private void Awake()
    {
        image.enabled = false;
    }

    public void EnableModeDisplay()
    {
        image.enabled = true;
        var _mode = FindObjectOfType<BeyBladeParameters>().CurentMode;
        if(_mode == "Attack Mode")
        {
            image.sprite = spritList[0];

        }
        else if (_mode == "Defence Mode")
        {
            image.sprite = spritList[1];

        }
        else
        {
            image.sprite = spritList[2];

        }
    }
    public void DisableModeDisplay()
    {
        image.enabled = false;
    }
    public void ChangeSprite(int _spriteIndex)
    {
        image.sprite = spritList[_spriteIndex];
    }
}
