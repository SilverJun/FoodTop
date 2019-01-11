using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIHelper
{
    public static void AddButtonListener(Button button, Action action)
    {
        button.GetComponent<Button>().onClick.AddListener(() => action());
    }

    public static void AddButtonListener(GameObject buttonObject, Action action)
    {
        AddButtonListener(buttonObject.GetComponent<Button>(), action);
    }

    public static void SetText(GameObject textObject, string text)
    {
        textObject.GetComponent<Text>().text = text;
    }
}