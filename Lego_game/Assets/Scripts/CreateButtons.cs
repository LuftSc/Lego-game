using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Direct
{
    Right,
    Left,
}
public class ButtonWithDetail
{
    public int Row;
    public Direct Direct;
    public GameObject Prefab;
    public int Count;
    public string Color;
    public string Size;

    private int countAddedDetails = CreateButtons.NewButtons.Count;
   
    public ButtonWithDetail(GameObject prefab, int count, int row, Direct direction)
    {
        Row = row;
        Direct = direction;
        Prefab = prefab;
        Count = count;
    }
    public ButtonWithDetail(GameObject prefab, int count)
    {
        Prefab = prefab;
        Count = count;
        Row = countAddedDetails / 2;
        Direct = countAddedDetails % 2 == 1 ? Direct.Right : Direct.Left;
        var splittingName = Prefab.name.Split("_");
        Color = splittingName[1];
        Size = splittingName[0];
    }
}
public class CreateButtons : MonoBehaviour
{

    public GameObject orange_2x2_fat;
    public GameObject dorange_2x1_fat;
    public GameObject green_2x1_fat;
    public GameObject orange_2x1_fat;

    public Sprite jiraf_step_0;
    public Sprite jiraf_step_1;
    public Sprite jiraf_step_2;
    public Sprite jiraf_step_3;
    
    public static bool start;
    public static List<ButtonWithDetail> NewButtons;
    public List<Sprite> NewInstructions;
    public static int NumberOfInstruction;

    private void Start()
    {
        SetAllButtonsOnInstructions();
    }

    private void Update()
    {
        if (start)
        {
            start = false;
            SetAllButtonsOnInstructions();
        }
    }
    public void SetAllButtonsOnInstructions()
    {
        NewButtons = new List<ButtonWithDetail>();
        NewInstructions = new List<Sprite>() { jiraf_step_0, jiraf_step_1, jiraf_step_2, jiraf_step_3 };
        
        var instructionPanel = gameObject.transform.parent.parent.transform.Find("instruction_panel").gameObject;
        var currentStep = instructionPanel.transform.Find("CurrentStep").gameObject;
        var nextStep = instructionPanel.transform.Find("NextStep ").gameObject;

        switch (NumberOfInstruction)
        {
            case 0:
                NewButtons.Add(new ButtonWithDetail(orange_2x1_fat, 3));
                NewButtons.Add(new ButtonWithDetail(green_2x1_fat, 2));
                currentStep.GetComponent<Image>().sprite = jiraf_step_0;
                nextStep.GetComponent<Image>().sprite = jiraf_step_1;
                break;
            case 1:
                NewButtons.Add(new ButtonWithDetail(orange_2x2_fat, 2)); 
                NewButtons.Add(new ButtonWithDetail(dorange_2x1_fat, 2));
                NewButtons.Add(new ButtonWithDetail(green_2x1_fat, 1));
                currentStep.GetComponent<Image>().sprite = jiraf_step_1;
                nextStep.GetComponent<Image>().sprite = jiraf_step_2;
                break;
            case 2:
                NewButtons.Add(new ButtonWithDetail(orange_2x1_fat, 2)); 
                NewButtons.Add(new ButtonWithDetail(orange_2x2_fat, 1));
                NewButtons.Add(new ButtonWithDetail(dorange_2x1_fat, 1));
                currentStep.GetComponent<Image>().sprite = jiraf_step_2;
                nextStep.GetComponent<Image>().sprite = jiraf_step_3;
                break;
        }

        NumberOfInstruction += 1;
        CreateAllButtons();
    }
    public void CreateAllButtons()
    {
        foreach (var button in NewButtons)
        {
            // Ряд, по умолчанию(самый первый ряд) = 0
            var y = (button.Row - 1) * 300;
            // Где должна быть деталька? Слева или справа
            var x = button.Direct == Direct.Right ? 130 : 0;
            var createdButton = Instantiate(button.Prefab, gameObject.transform);
            var rect = createdButton.GetComponent<RectTransform>();
            rect.offsetMin += new Vector2(x, -y);
            rect.offsetMax -= new Vector2(-x, y);
            createdButton.transform.Find("count").gameObject.GetComponent<TextMeshProUGUI>().text = $"x{button.Count}";
        }
    }
}