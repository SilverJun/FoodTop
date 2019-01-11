using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class InGameManager : MonoBehaviour
{
    [SerializeField] private CameraMove _camera;
    [SerializeField] private Transform _objGenPosition;
    //private List<GameObject> _foods;
    //private List<GameObject> _things;
    private List<GameObject> _objs = new List<GameObject>();
    private BoxCollider2D _collider;
    private bool _isEnd;
    public bool _isStart;

    void Awake()
    {
        //_foods = Resources.LoadAll<GameObject>("Prefab/Food").ToList();
        //_things = Resources.LoadAll<GameObject>("Prefab/Thing").ToList();
        _objs.AddRange(Resources.LoadAll<GameObject>("Prefab/Food").ToList());
        _objs.AddRange(Resources.LoadAll<GameObject>("Prefab/Thing").ToList());
        //_isStart = false;

        StartGame();
    }

    // 오브젝트 생성
    // 카메라 위치 설정
    void StartGame()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        // 첫 오브젝트 생성.
        NextObject();
    }

    public void NextObject()
    {
        StartCoroutine(ObjGen());
    }

    IEnumerator ObjGen()
    {
        _camera.CheckCameraMove();
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Random...");
        int i = Random.Range(0, _objs.Count);
        Instantiate(_objs[i], _objGenPosition.position, Quaternion.identity);
        Debug.Log("Obj Gen!");
    }
}
