using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TouchMoveObj : MonoBehaviour
{
    void Start()
    {
        Random.InitState(GetHashCode());        // 해시코드를 시드값으로 설정. TODO : 근데 이게 제대로 되나? 해쉬코드 로그찍어서 확인
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
        if (other.CompareTag("Food"))
        {
            StopCoroutine(Rotate());
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            enabled = false;
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
