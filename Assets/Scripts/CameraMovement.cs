using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _zoomSpeed;

    private void Update()
    {
        _camera.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * _movingSpeed, Space.World);
        _camera.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * _movingSpeed, Space.World);
        
        //_camera.transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * Time.deltaTime * _zoomSpeed, Space.Self);

        
        var zoomTarget = _camera.transform.position + _camera.transform.forward * Input.mouseScrollDelta.y;
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, zoomTarget, _zoomSpeed * Time.deltaTime);
    }
}
