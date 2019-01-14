using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

#if UNITY_EDITOR
public class PrefabApplier : MonoBehaviour
{

    [MenuItem("PrefabApplier/Prefab Apply #a")]
    static void PrefabApply()
    {
        Selection.gameObjects.ToList().ForEach(x =>
        {
            PrefabUtility.ReplacePrefab(x, PrefabUtility.GetPrefabParent(x), ReplacePrefabOptions.ConnectToPrefab);
        });

    }
}
#endif
