using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Patroling,
    Chasing,
    Attacking
}

public class Enemy : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private EnemyState initialState;
    private EnemyState state;

    [Header("Patroling")]
    [SerializeField] private List<Transform> patrolingPoints;
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private int patrolingPointsIndex = 0;
    private bool retracePath = false;

    [Header("Chasing")]
    [SerializeField] private float detectionRange = 2f;
    [SerializeField] private GameObject playerObj;

    [Header("Attacking")]
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private GameObject weapon;

    private void Awake()
    {
        state = initialState;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case EnemyState.Patroling:
                Patrol();
                FindTarget();
                break;
            case EnemyState.Chasing:
                Chase();
                CheckAttackDistance();
                break;
            case EnemyState.Attacking:
                Attack();
                CheckAttackDistance();
                //FindTarget();
                break;
            default:
                break;
        }
    }

    private void ChangeState(EnemyState newState, bool resetVelocity)
    {
        if (newState != EnemyState.Attacking)
            weapon.SetActive(false);

        state = newState;

        if (resetVelocity == true)
            rb.velocity = Vector2.zero;
    }

    private void Patrol()
    {
        if (patrolingPoints.Count > 0)
        {
            if (patrolingPointsIndex > patrolingPoints.Count - 1)
            {
                patrolingPointsIndex = patrolingPoints.Count - 1;
                retracePath = true;
            }

            if (patrolingPointsIndex < 0)
            {
                patrolingPointsIndex = 0;
                retracePath = false;
            }

            Vector2 patrolPointPosition = (patrolingPoints[patrolingPointsIndex].position - transform.position).normalized;
            Vector2 facingDirection = (patrolingPoints[patrolingPointsIndex].position - transform.position).normalized;

            rb.velocity = patrolPointPosition * movementSpeed;

            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle);

            if (Vector2.Distance(transform.position, patrolingPoints[patrolingPointsIndex].position) < 0.5)
            {
                if (retracePath == true)
                {
                    patrolingPointsIndex--;
                }
                else
                {
                    patrolingPointsIndex++;
                }
            }
        }
    }

    private void FindTarget()
    {
        if (Vector2.Distance(gameObject.transform.position, playerObj.transform.position) < detectionRange)
            ChangeState(EnemyState.Chasing, false);
        else
            ChangeState(EnemyState.Patroling, false);
    }

    private void Chase()
    {
        Vector2 directionToPlayer = (playerObj.transform.position - transform.position).normalized;
        Vector2 facingDirection = (playerObj.transform.position - transform.position).normalized;

        rb.velocity = directionToPlayer * movementSpeed;

        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }

    private void CheckAttackDistance()
    {
        if (Vector2.Distance(gameObject.transform.position, playerObj.transform.position) < attackDistance)
            ChangeState(EnemyState.Attacking, true);
        else
            ChangeState(EnemyState.Chasing, false);
    }

    private void Attack()
    {
        if (weapon != null)
            weapon.SetActive(true);
    }
}
