using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    enum PlayerState
    {
        Idle = 0,
        Walk,
        Run,
        Aiming,
        Shoot
    }

    private Stopwatch sw = new Stopwatch();

    PlayerState playerState;

    private Animator anim;

	void Start ()
    {
        playerState = PlayerState.Idle;
        anim = GetComponent<Animator>();
        sw.Reset();
	}
	
	void Update ()
    {
        if (!Input.anyKey)
        {
            playerState = PlayerState.Idle;
        }

        if (playerState == PlayerState.Idle)
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("d") || Input.GetKeyDown("w") || Input.GetKeyDown("s"))
            {
                playerState = PlayerState.Walk;
            }
        }

        switch (playerState)
        {
            case PlayerState.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
                anim.SetBool("Aiming", false);
                anim.SetBool("Shoot", false);
                break;
            case PlayerState.Walk:
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                anim.SetBool("Aiming", false);
                anim.SetBool("Shoot", false);
                break;
            case PlayerState.Run:
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
                anim.SetBool("Aiming", false);
                anim.SetBool("Shoot", false);
                break;
            case PlayerState.Aiming:
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
                anim.SetBool("Aiming", true);
                anim.SetBool("Shoot", false);
                break;
            case PlayerState.Shoot:
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
                anim.SetBool("Aiming", false);
                anim.SetBool("Shoot", true);
                break;
        }

    }
}
