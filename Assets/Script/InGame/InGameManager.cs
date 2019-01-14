using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class InGameManager : MonoBehaviour
{
    [SerializeField] private CameraMove _camera;
    [SerializeField] private Transform _objGenPosition;
    [SerializeField] private AudioSource _audio;
    //private List<GameObject> _foods;
    //private List<GameObject> _things;
    private List<GameObject> _objs = new List<GameObject>();
    private BoxCollider2D _collider;
    private bool _isEnd;
	private InGame _ui;
	private int _score;
	private int _nextIdx;
    private int _foodCount;

    void Awake()
    {
        //_foods = Resources.LoadAll<GameObject>("Prefab/Food").ToList();
        //_things = Resources.LoadAll<GameObject>("Prefab/Thing").ToList();
        _objs.AddRange(Resources.LoadAll<GameObject>("Prefab/Food").ToList());
        _foodCount = _objs.Count;
        _objs.AddRange(Resources.LoadAll<GameObject>("Prefab/Thing").ToList());
    }

    // 오브젝트 생성
    // 카메라 위치 설정
    public void StartGame()
    {
		_ui = UIManager.OpenUI<InGame>(Resources.Load<GameObject>("Prefab/InGame"));
        Random.InitState(System.DateTime.Now.Millisecond);
		// 첫 오브젝트 생성.
		_nextIdx = -1;
        _score = 0;

        _ui.UpdateScore(_score);
        Instantiate(_objs[Random.Range(0, _foodCount)], _objGenPosition.position, Quaternion.identity);
        _nextIdx = Random.Range(0, _objs.Count);
        _ui.Vars["Image"].GetComponent<Image>().sprite = Resources.Load<Sprite>("icons/" + _objs[_nextIdx].GetComponent<SpriteRenderer>().sprite.name);

    }

    public void NextObject()
    {
        _audio.Play();
        _score++;
        _ui.UpdateScore(_score);
        StartCoroutine(ObjGen());
    }

    IEnumerator ObjGen()
    {
        _camera.CheckCameraMove();
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Random...");
        
        Instantiate(_objs[_nextIdx], _objGenPosition.position, Quaternion.identity);

        if (_score < 50)
            _nextIdx = Random.Range(0, _foodCount);
        else
            _nextIdx = Random.Range(0, _objs.Count);

        // 다음 오브젝트 알림.
        _ui.Vars["Image"].GetComponent<Image>().sprite = Resources.Load<Sprite>("icons/" + _objs[_nextIdx].GetComponent<SpriteRenderer>().sprite.name);

        Debug.Log("Obj Gen!");
    }

    public void GameOver()
    {
        StartCoroutine(_GameOver());
    }

    IEnumerator _GameOver()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/GameOver"), _objGenPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);

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
