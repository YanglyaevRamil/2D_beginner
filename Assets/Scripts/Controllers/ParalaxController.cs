using UnityEngine;

public class ParalaxController : IExecute
{
    private Camera _camera;
    private Transform _backTransform;
    private Vector3 _backStartPosition;
    private Vector3 _cameraStartPosition;

    public ParalaxController(Camera camera, Transform backTransform)
    {
        _camera = camera;
        _backTransform = backTransform;
        _backStartPosition = backTransform.position;
        _cameraStartPosition = camera.transform.position;
    }

    public void Execute(float deltaTime)
    {
        _backTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * ParalaxConst.Coef;
    }

}
