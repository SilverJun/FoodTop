using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _moveBox;
    [SerializeField] private Transform _cameraTransform;
    public bool _isMoved;

	void Start ()
	{
        _moveBox.enabled = false;
	    _moveBox.isTrigger = true;
	    _isMoved = true;

	}

    public void CheckCameraMove()
    {
        _moveBox.enabled = true;
        StartCoroutine(disableCollider());
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Camera move End");
        _moveBox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        _cameraTransform.DOMoveY(transform.position.y + 2.0f, 0.5f);
        _moveBox.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        _cameraTransform.DOMoveY(transform.position.y + 2.0f, 0.5f);
        _moveBox.enabled = false;
    }
}
