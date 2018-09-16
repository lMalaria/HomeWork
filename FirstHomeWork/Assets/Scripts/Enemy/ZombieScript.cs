using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

    enum ZombieState
    {
        Idle = 0,
        Walk,
        Attack,
        Die
    }

    ZombieState zombieState;

    private Stopwatch sw = new Stopwatch();

    private float walkSpeed;

    public float zombieHP;

    private int fieldOfView;

    private int viewDistance;

    private GameObject player;

    Animator animator;

    PlayerScript playerScript;

    void Start ()
    {
        zombieState = ZombieState.Idle;

        walkSpeed = 0.2f;
        zombieHP = 100;

        fieldOfView = 70;
        viewDistance = 18;

        player = GameObject.Find("Player");

        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();

        animator = GetComponent<Animator>();
        sw.Reset();

    }
	
	void Update ()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        direction.y = 0;

        RaycastHit hit;

        switch (zombieState)
        {
            case ZombieState.Idle:

                animator.SetBool("isIdle", true);
                animator.SetBool("isWalk", false);
                animator.SetBool("isAttack", false);
                animator.SetBool("isDead", false);

                if (Vector3.Angle(direction, transform.forward) < fieldOfView)
                {
                    if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction + new Vector3(0, 0.5f, 0), out hit, viewDistance))
                    {
                        if (hit.collider.gameObject.tag == "Player")
                            zombieState = ZombieState.Walk;
                    }
                }

                if (zombieHP != 100)
                    zombieState = ZombieState.Walk;

                if (zombieHP <= 0)
                    zombieState = ZombieState.Die;
                break;

            case ZombieState.Walk:
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalk", true);
                animator.SetBool("isAttack", false);
                animator.SetBool("isDead", false);

                direction = player.transform.position - this.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, walkSpeed * Time.deltaTime);

                if (Vector3.Distance(player.transform.position, this.transform.position) < 1.0f)
                    zombieState = ZombieState.Attack;

                if (zombieHP <= 0)
                    zombieState = ZombieState.Die;

                break;
            case ZombieState.Attack:

                animator.SetBool("isIdle", false);
                animator.SetBool("isWalk", false);
                animator.SetBool("isAttack", true);
                animator.SetBool("isDead", false);

                playerScript.hp = playerScript.hp - 10;

                if (Vector3.Distance(player.transform.position, this.transform.position) >= 1.0)
                    zombieState = ZombieState.Walk;

                if (zombieHP <= 0)
                    zombieState = ZombieState.Die;

                break;
            case ZombieState.Die:
                this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, 0.0f * Time.deltaTime);

                animator.SetBool("isIdle", false);
                animator.SetBool("isWalk", false);
                animator.SetBool("isAttack", false);
                animator.SetBool("isDead", true);

                break;
        }
    }
}
