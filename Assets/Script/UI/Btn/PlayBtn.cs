using UnityEngine;
using System.Collections;

public class PlayBtn : UI
{
    [SerializeField] private MainMenu _menu;

    public void Callback()
    {
        UIManager.CloseUI(_menu);
        UIManager.OpenUI<UI>(Resources.Load<GameObject>("Prefab/InGame"));
    }
}
