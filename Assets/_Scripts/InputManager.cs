using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;

    [SerializeField] private LineRenderer _trajectoryLine;
    [SerializeField] private Transform _playerPosition;

    public bool isPlayerTurn;
    public Vector2 moveVector = Vector2.zero;

    public float holdTime = 0.0f;

    private NewControls input = null;
   

    private void Awake()
    {
        input = new NewControls();
        Instance ??= this;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }


    void Start()
    {
        isPlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {

        ShowTrajectoryLine();

        //if (isPlayerTurn)
        //{
        //    ListenForKeyPressed();
        //}




    }

    private void ShowTrajectoryLine()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 player = _playerPosition.position;
            _trajectoryLine.enabled = true;
            _trajectoryLine.positionCount = 2;
            _trajectoryLine.SetPosition(0, new Vector3(player.x, player.y, -1));
            _trajectoryLine.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -1));


        }
    }


    public void ListenForKeyPressed()
    {

        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {

            if (Input.GetKeyDown(keyCode))
            {

                Debug.Log("Key:" + keyCode.ToString());
            }


        }

        if (Input.GetKey(KeyCode.Space))
        {
            holdTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Time elapsed:" + holdTime);
            holdTime = 0.0f;

        }

    }

}
