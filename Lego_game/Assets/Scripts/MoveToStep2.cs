using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveToStep2 : MonoBehaviour
{
    public Image fat_2x2_orange;
    public Image fat_2x1_green;
    public Image fat_2x1_dark_orange;
    public TextMeshProUGUI countFirst;
    public TextMeshProUGUI countSecond;
    public TextMeshProUGUI countThird;
    public Image CurrentImageStep;
    public Sprite NewImageStep;
    private string countForFirstButton = "2";
    private string countForSecondButton = "1";
    private string countForThirdButton = "2";
    [Header("NOT SET THIS VALUE!")]
    public static bool goToNextStep = false;
    private void Update()
    {
        if (goToNextStep)
        {
            SetAllButton();
            goToNextStep = false;
        }
    }
    public void SetAllButton()
    {
        fat_2x2_orange.gameObject.SetActive(true);
        fat_2x1_green.gameObject.SetActive(true);
        fat_2x1_dark_orange.gameObject.SetActive(true);
        countFirst.text = countForFirstButton;
        countSecond.text = countForSecondButton;
        countThird.text = countForThirdButton;
        countFirst.enabled = true;
        countSecond.enabled = true;
        countThird.gameObject.SetActive(true);
        CurrentImageStep.sprite = NewImageStep;
    }
}
