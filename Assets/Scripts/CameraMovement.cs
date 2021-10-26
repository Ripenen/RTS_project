using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMouseInput _input;
    [SerializeField] private float _movingSpeed = 20;
    [SerializeField] private float _zoomSpeed = 200;
    
    private Vector3 _catchPoint;

    private void OnEnable()
    {
        _input.AddMouseHandler(MouseButton.MiddleMouse, MouseState.Down, OnMiddleDown);
        _input.AddMouseHandler(MouseButton.MiddleMouse, MouseState.Hold, OnMiddleHold);
    }
    
    private void OnDisable()
    {
        _input.RemoveHandler(OnMiddleDown);
        _input.RemoveHandler(OnMiddleHold);
    }

    private void Update()
    {
        Transform cameraTransform = _camera.transform;

        cameraTransform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * Time.deltaTime * _movingSpeed), Space.World);
        cameraTransform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * Time.deltaTime * _movingSpeed), Space.World);
        
        Vector3 cameraPosition = cameraTransform.position;
        
        var zoomTarget = cameraPosition + cameraTransform.forward * Input.mouseScrollDelta.y;
        cameraTransform.position = Vector3.MoveTowards(cameraPosition, zoomTarget, _zoomSpeed * Time.deltaTime);
    }

    private void OnMiddleDown()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            _catchPoint = hitInfo.point;
        }
    }

    private void OnMiddleHold()
    {
        if (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") == 0)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Vector3 second = Vector3.zero;
        if (Physics.Raycast(ray, out var hitInfo))
        {
            second = hitInfo.point - _catchPoint;
            second.y = 0;
        }

        _camera.transform.position -= second;
    }
}
