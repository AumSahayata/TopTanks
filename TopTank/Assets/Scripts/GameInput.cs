using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public event EventHandler OnShoot;
    public event EventHandler OnReload;

    [SerializeField] private GameObject pausePanel;

    private Controls playerControl;
    [HideInInspector] public bool pause = false;

    private void Awake() {
        playerControl = new Controls();
        playerControl.Player.Enable();
        playerControl.Player.Shoot.performed += Shoot_performed;
        playerControl.Player.Pause.performed += Pause_performed;
        playerControl.Player.Reload.performed += Reload_performed;

        
    }

    private void Reload_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnReload?.Invoke(this, EventArgs.Empty);
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        pause = !pause;

        Pause();

        print("pause " + Time.timeScale);
    }

    private void Start() {
        GameObject.FindAnyObjectByType<GameManager>().ToStopInput += GameInput_ToStopInput;
    }

    private void GameInput_ToStopInput(object sender, EventArgs e) {
        playerControl.Player.Disable();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerControl.Player.Movement.ReadValue<Vector2>();
        if(inputVector == null ) {
            playerControl = new Controls();
            playerControl.Player.Enable();
        }

        inputVector.Normalize();
        return inputVector;
    }
    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnShoot?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetPointerInput() {
        Vector3 mousePos = playerControl.Player.Aim.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void Pause() {
        if (pause) {
            Time.timeScale = 0;
            playerControl.Player.Shoot.performed -= Shoot_performed;

            if (pausePanel == null)
                return;

            pausePanel.SetActive(true);

        } else {
            Time.timeScale = 1;
            playerControl.Player.Shoot.performed += Shoot_performed;

            if (pausePanel == null)
                return;

            pausePanel.SetActive(false);
        }
    }

}