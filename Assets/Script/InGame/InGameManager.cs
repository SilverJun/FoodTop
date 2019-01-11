using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class InGameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objs;
    private BoxCollider2D _collider;

    // 오브젝트 생성
    // 카메라 위치 설정
    void Start()
    {
        //Random.InitState();
        // 첫 오브젝트 생성.
        NextObject();
    }

    public void NextObject()
    {
        // 카메라 계산.
        // TODO : 여기서 충돌체크 할 수 있나?

        StartCoroutine(ObjGen());
    }

    IEnumerator ObjGen()
    {
        yield return new WaitForSeconds(0.5f);

        Random.Range(0, _objs.Count);
    }
}
