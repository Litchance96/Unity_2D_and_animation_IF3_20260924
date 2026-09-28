using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MovePlayer : MonoBehaviour
{
    private const string ACTION_MAP = "Player";
    private const string ACTION_MOVE = "Move";

    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float speed;
    private InputAction move;

    private Animator animator;

    private SpriteRenderer spriterenderer;

    private bool isOnMove = false;
    private const string ANIMATION_SPEED = "speed";

    private void Awake()
    {
        move = inputActions.FindActionMap(ACTION_MAP).FindAction(ACTION_MOVE);
        move.started += ctx => { OnMoveStart(ctx); };
        move.canceled += ctx => { OnMoveCancel(ctx); };
        animator = GetComponent<Animator>();

        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMoveCancel(InputAction.CallbackContext ctx)
    {
        isOnMove = false;
        animator.SetFloat(ANIMATION_SPEED, 0f);
    }

    private void OnMoveStart(InputAction.CallbackContext ctx)
    {
        isOnMove = true;
    }

    private void Update()
    {
        if (isOnMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float mvtSpeed = speed * move.ReadValue<float>();
        Vector2 mvt = Time.deltaTime * mvtSpeed * Vector2.right;

        animator.SetFloat(ANIMATION_SPEED, Mathf.Abs(mvtSpeed));
        transform.Translate(mvt);

        spriterenderer.flipX = mvtSpeed < 0;
    }

    private void OnEnable()
    {
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap(ACTION_MAP).Disable();
    }


}
