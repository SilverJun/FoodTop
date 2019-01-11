using UnityEngine;
using System.Collections;

public class RankBtn : UI
{
    public void Callback()
    {
        UIManager.OpenUI<UI>(Resources.Load<GameObject>("Prefab/InGame"));
    }
}
