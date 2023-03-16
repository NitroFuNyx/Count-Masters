using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _mouseStartPos;
    private Vector3 _playerStartPos;

    [SerializeField] private bool moveByTouch;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float roadSpeed;
    [SerializeField] private Transform road;
    [SerializeField] private StickmenHolder stickmenHolder;

    #region Singleton

    private static PlayerMovement _instance;
    public static PlayerMovement Instance => _instance;

    private void OnEnable()
    {
        if (Instance == null)
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    #endregion


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Menu)
            GamestagesFSM.Instance.Running();
        if (GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Running ||
            GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Attacking)
        {
            MovePlayerBySides();
            if (GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.MovingForward)
                MoveForward();
        }

        if (GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.MovingForward ||
            GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Running ||
            GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Attacking)
            MoveForward();
    }

    private void MoveForward()
    {
        road.Translate(road.forward * Time.deltaTime * roadSpeed);
    }

    public void SlowRoadSpeed()
    {
        roadSpeed = 0.5f;
    }

    public void AccelerateRoadSpeed()
    {
        roadSpeed = 2f;
    }

    private void MovePlayerBySides()
    {
        if (Input.GetMouseButtonDown(0) && GamestagesFSM.Instance.CurrentState == GamestagesFSM.State.Running)
        {
            moveByTouch = true;

            var plane = new Plane(Vector3.up, 0f);

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance + 1f);
                _playerStartPos = transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;
        }

        if (moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                var mousePos = ray.GetPoint(distance + 1f);

                var move = mousePos - _mouseStartPos;

                var control = _playerStartPos + move;


                if (stickmenHolder.GetAmount() > 50)
                    control.x = Mathf.Clamp(control.x, -0.7f, 0.7f);
                else
                    control.x = Mathf.Clamp(control.x, -1.1f, 1.1f);

                transform.position = new Vector3(
                    Mathf.Lerp(transform.position.x, control.x, Time.deltaTime * playerSpeed)
                    , transform.position.y, transform.position.z);
            }
        }
    }
}