using UnityEngine;
using System.Collections;

public class CreditBtn : UI
{
    public void Callback()
    {
        UIManager.OpenUI<UI>(Resources.Load<GameObject>("Prefab/InGame"));
    }
}
