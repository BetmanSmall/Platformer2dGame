using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),
    typeof(Animator), typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour {
    [SerializeField] private float speed = 2f, timeToRevert = 3f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private enum EnemyState {
        Idle,
        Walk,
        Revert
    }
    private EnemyState currentState = EnemyState.Walk;
    private float currentTimeToRevert = 0f;

    private void Start() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (currentTimeToRevert >= timeToRevert) {
            currentTimeToRevert = 0f;
            currentState = EnemyState.Revert;
        }
        switch (currentState) {
            case EnemyState.Idle: {
                currentTimeToRevert += Time.deltaTime;
                break;
            }
            case EnemyState.Walk: {
                rigidbody2D.velocity = Vector2.right * speed;
                break;
            }
            case EnemyState.Revert: {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                speed *= -1;
                currentState = EnemyState.Walk;
                animator.SetBool("isRun", true);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.CompareTag("EnemyBorder")) {
            currentState = EnemyState.Idle;
            animator.SetBool("isRun", false);
        }
    }
}