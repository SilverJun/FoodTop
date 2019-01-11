using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TouchMoveObj : MonoBehaviour
{
    private InGameManager _inGame;

    void Start()
    {
        Random.InitState(GetHashCode());        // 해시코드를 시드값으로 설정. TODO : 근데 이게 제대로 되나? 해쉬코드 로그찍어서 확인
        _inGame = GameObject.FindGameObjectWithTag("InGameManager").GetComponent<InGameManager>();
        StartCoroutine(Rotate());
    }
    
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 pos = new Vector3(0.0f, transform.position.y, transform.position.z);
                pos.x = transform.position.x + Input.GetTouch(0).deltaPosition.x * Random.Range(0.0001f, 0.008f);
                transform.position = pos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled)
        {
            return;
        }

        Debug.Log(gameObject.name);
        Debug.Log("trigger enter");
        if (other.CompareTag("Food") || other.CompareTag("Thing") || other.CompareTag("Ground"))
        {
            StopCoroutine(Rotate());
            _inGame.NextObject();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            enabled = false;
        }
        else
        {
            // Game Over!
            Debug.Log("Game Over!!");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled)
        {
            return;
        }

        Debug.Log(gameObject.name);
        Debug.Log("trigger stay");
        if (other.CompareTag("Food") || other.CompareTag("Thing") || other.CompareTag("Ground"))
        {
            StopCoroutine(Rotate());
            _inGame.NextObject();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            enabled = false;
        }
        else
        {
            // Game Over!
            Debug.Log("Game Over!!");
        }
    }

    IEnumerator Rotate()
    {
        while (enabled)
        {
            transform.Rotate(0.0f, 0.0f, 3.0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
