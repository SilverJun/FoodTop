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
        StartCoroutine(disableCollider());
    }

    IEnumerator disableCollider()
    {
		yield return new WaitForSeconds(0.5f);
        _moveBox.enabled = true;
		_cameraTransform.Translate(0.0f, 0.00001f, 0.0f);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Camera move End");
        _moveBox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        _cameraTransform.DOMoveY(transform.position.y + 2.0f, 0.2f);
        _moveBox.enabled = false;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        _cameraTransform.DOMoveY(transform.position.y + 2.0f, 0.2f);
        _moveBox.enabled = false;
    }
}
