﻿using UnityEngine;
using System.Collections.Generic;

/* Script that controls dragging the furniture augmentations on the screen. */
public class MoveController : MonoBehaviour
{
    public Transform BasePoint;
    public float RotateSpeed = 25;
    private Transform _activeObject = null;
    private Camera ControllerCamera;

    private Vector3 _startObjectPosition;
    private Vector2 _startTouchPosition;
    private Vector2 _touchOffset;

    private bool isPhoto = false;

    private void Start() {
        ControllerCamera = GetComponent<Camera>();
    }

    public Transform ActiveObject {
        get {
            return _activeObject;
        }
    }

    public void SetMoveObject(Transform newMoveObject) {
        if (newMoveObject.gameObject.tag == "ARObject") {
            _activeObject = newMoveObject;
            _startObjectPosition = _activeObject.position;
            
            if(Input.touchCount > 0)
                _startTouchPosition = Input.GetTouch(0).position;
            else
                _startTouchPosition = Input.mousePosition;

            _touchOffset = ControllerCamera.WorldToScreenPoint(_startObjectPosition);

            isPhoto = _activeObject.GetComponent<IsPhoto>() ? true : false;
        }
    }

    void Update () {
        
        #if UNITY_EDITOR
        if(Input.GetMouseButton(0)){
            Vector2 mousePosition = Input.mousePosition;
            RaycastHit hit;

            if (_activeObject == null) {
                if(Physics.Raycast(ControllerCamera.ScreenPointToRay(mousePosition), out hit)) {
                    SetMoveObject(hit.transform);
                }
            }

            if (_activeObject != null) {
                Vector2 screenPosForRay = (mousePosition - _startTouchPosition) + _touchOffset;

                Vector3 newPos = ControllerCamera.ScreenToWorldPoint(new Vector3(screenPosForRay.x, screenPosForRay.y, BasePoint.position.z));

                _activeObject.position = Vector3.Lerp(_activeObject.position, newPos, 0.25f);

                if(isPhoto == false)
                    _activeObject.Rotate(0, RotateSpeed * Time.deltaTime, 0);
            }

        }
        #endif

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;

            /* If we're currently not dragging any augmentation, do a raycast to find one in the scene. */
            if (_activeObject == null) {
                if (Physics.Raycast(ControllerCamera.ScreenPointToRay(touch.position), out hit)) {
                    SetMoveObject(hit.transform);
                }
            }

            if (_activeObject != null) {
                Vector2 screenPosForRay = (touch.position - _startTouchPosition) + _touchOffset;

                Vector3 newPos = ControllerCamera.ScreenToWorldPoint(new Vector3(screenPosForRay.x, screenPosForRay.y, BasePoint.position.z));

                _activeObject.position = Vector3.Lerp(_activeObject.position, newPos, 0.25f);

                if(Input.touchCount == 1)
                    if(isPhoto == false)
                        _activeObject.Rotate(0, RotateSpeed * Time.deltaTime, 0);
            }

            /* If we are dragging an augmentation, raycast against the ground plane to find how the augmentation should be moved. 
            if (_activeObject != null) {
                var screenPosForRay = (touch.position - _startTouchPosition) + _touchOffset;

                
                Ray cameraRay = Camera.main.ScreenPointToRay(screenPosForRay);
                Plane p = new Plane(Vector3.up, Vector3.zero);

                float enter;
                if (p.Raycast(cameraRay, out enter)) {
                    var position = cameraRay.GetPoint(enter);

                    /* Clamp the new position within reasonable bounds and make sure the augmentation is firmly placed on the ground plane. 
                    position.x = Mathf.Clamp(position.x, -15.0f, 15.0f);
                    position.y = 0.0f;
                    position.z = Mathf.Clamp(position.z, -15.0f, 15.0f);

                    /* Lerp the position of the dragged augmentation so that the movement appears smoother 
                    _activeObject.position = Vector3.Lerp(_activeObject.position, position, 0.25f);
                }
            }*/
        }

        if(Input.touchCount == 0 && !Input.GetMouseButton(0)){
            /* If there are no touches, stop dragging the currently dragged augmentation, if there is one. */
            _activeObject = null;
        }
    }
}
