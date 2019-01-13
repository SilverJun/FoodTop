using UnityEngine;
using UnityEngine.UI;
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
	private InGame _ui;
	private int _score;
	private int _nextIdx;

    void Awake()
    {
        //_foods = Resources.LoadAll<GameObject>("Prefab/Food").ToList();
        //_things = Resources.LoadAll<GameObject>("Prefab/Thing").ToList();
        _objs.AddRange(Resources.LoadAll<GameObject>("Prefab/Food").ToList());
        _objs.AddRange(Resources.LoadAll<GameObject>("Prefab/Thing").ToList());
        //_isStart = false;
		Input.simulateMouseWithTouches = true;
        
    }

    // 오브젝트 생성
    // 카메라 위치 설정
    public void StartGame()
    {
		_ui = UIManager.OpenUI<InGame>(Resources.Load<GameObject>("Prefab/InGame"));
        Random.InitState(System.DateTime.Now.Millisecond);
		// 첫 오브젝트 생성.
		_nextIdx = -1;
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

		if (_nextIdx == -1)
			_nextIdx = Random.Range(0, _objs.Count);
        Instantiate(_objs[_nextIdx], _objGenPosition.position, Quaternion.identity);
        _nextIdx = Random.Range(0, _objs.Count);

		//_ui.Vars["Image"].GetComponent<Image>().image = Resources.Load<Sprite>("icons/" + _objs[_nextidx].name);

        Debug.Log("Obj Gen!");
    }

    public void GameOver()
	{
		//closeIngameMenu
		_ui.Close();

        //score update
		if (_score > PlayerPrefs.GetInt("TopScore"))
		{
            PlayerPrefs.SetInt("TopScore", _score);
		}
		PlayerPrefs.SetInt("Score", _score);

        //open ui
		UIManager.OpenUI<FailMenu>(Resources.Load<GameObject>("Prefab/FailMenu"));
	}

}
