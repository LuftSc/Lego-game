using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveToStep3 : MonoBehaviour
{
   public static bool goToNextStep = false;
   public Image fat_2x1_orange;
   public Image fat_2x2_orange;
   public Image fat_2x1_dark_orange;
   public TextMeshProUGUI countFirst;
   public TextMeshProUGUI countSecond;
   public TextMeshProUGUI countThird;
   private string countForFirstButton = "2";
   private string countForSecondButton = "1";
   private string countForThirdButton = "1";
   public Image CurrentImageStep;
   public static bool isCompleted = false;
   public Sprite NewImageStep;
   
   public Image NextImageStep;
   public Sprite NewNextImageStep;
   

   private void Update()
   {
      if (goToNextStep)
      {
         goToNextStep = false;
         isCompleted = true;
         SetAllButton();
      }
   }

   private void SetAllButton()
   {
      fat_2x1_orange.gameObject.SetActive(true);
      fat_2x2_orange.gameObject.SetActive(true);
      fat_2x1_dark_orange.gameObject.SetActive(true);
      countFirst.text = countForFirstButton;
      countSecond.text = countForSecondButton;
      countThird.text = countForThirdButton;
      countFirst.enabled = true;
      countSecond.enabled = true;
      countThird.enabled = true;
      CurrentImageStep.sprite = NewImageStep;
      NextImageStep.sprite = NewNextImageStep;
   }
}
