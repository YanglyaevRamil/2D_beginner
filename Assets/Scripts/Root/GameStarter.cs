using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] 
    private Data _data;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SpriteRenderer _background;

    private Controllers controllers;

    private void Start()
    {
        controllers = new Controllers();
        new GameInitialization(controllers, _data, _camera, _background);

        controllers.Initialization();
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        controllers.Execute(deltaTime);
    }

    private void LateUpdate()
    {
        var deltaTime = Time.deltaTime;
        controllers.LateExecute(deltaTime);
    }

    private void FixedUpdate()
    {
        controllers.FixedExecute();
    }

    private void OnDestroy()
    {
        controllers.Cleanup();
    }
}
