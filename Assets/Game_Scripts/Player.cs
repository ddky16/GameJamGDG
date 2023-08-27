using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GravityManager
{
    public const float GRAVITY_AMOUNT = -9.81f;
    public const float GRAVITY_MULTIPLIER = -2.0f;
}

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public SoundManager soundManager;
    public InterfaceManager interfaceManager;

    public Transform cam;

    private Vector3 _direction;
    private Vector3 _gravityVector;

    public float speedAmount = 5f;
    public float jumpAmount = 10f;

    public float turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    public float maxHealth { get; private set; } = 100f;
    public float currentHealth { get; private set; }

    public int cheeseCounter = 0;

    public bool isBoostedSpeed = false;
    public bool isBoostedJump = false;

    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(horizontal, 0f, vertical);

        MovementAction();
        JumpAction();

        HungerBar();
    }

    private void HungerBar()
    {
        if (currentHealth > 100)
            currentHealth = 100;

        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > 0)
            currentHealth -= 2 * Time.deltaTime;
    }

    private void MovementAction()
    {
        if (_direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = CameraControl();

            if (isBoostedSpeed)
                characterController.Move(moveDir.normalized * 2 * speedAmount * Time.deltaTime);
            else
                characterController.Move(moveDir.normalized * 2 * speedAmount * Time.deltaTime);

            JumpAction();
        }
    }

    private void JumpAction()
    {
        if (characterController.isGrounded)
        {
            _gravityVector.y = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isBoostedJump)
                    _gravityVector.y = jumpAmount * 2;
                else
                    _gravityVector.y = jumpAmount;
            }
        }
        else
        {
            _gravityVector.y -= GravityManager.GRAVITY_AMOUNT * GravityManager.GRAVITY_MULTIPLIER * Time.deltaTime;
        }
        characterController.Move(_gravityVector * Time.deltaTime);
    }

    private Vector3 CameraControl()
    {
        float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        return moveDir;
    }

    public void IncreaseHealth()
    {
        currentHealth += 10;
    }

    public IEnumerator SpeedBoosted()
    {
        isBoostedSpeed = true;
        yield return new WaitForSeconds(5);
        isBoostedSpeed = false;
    }

    public IEnumerator JumpBoosted()
    {
        isBoostedJump = true;
        yield return new WaitForSeconds(5);
        isBoostedJump = false;
    }
}
