using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Abstract_Actor_Components;
using Assets.Scripts.Abstract_Actor_Components.States;

using Assets.Scripts;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerActor : ActorComponent {

    private float nerves = 0.0f;
    private float maxNerves = 100.0f;
    private float waveTime = 0.0f;
    
	// Use this for initialization
	void Start ()
    {
        input = new PlayerInputComponent();
        rigidBody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        
        states = new Dictionary<int, IState>();
        states.Add(Animator.StringToHash("PlayerIdle"), new PlayerIdle());
        states.Add(Animator.StringToHash("PlayerWalking"), new PlayerWalking());
        states.Add(Animator.StringToHash("PlayerJumping"), new PlayerJumping());
        states.Add(Animator.StringToHash("PlayerWave"), new PlayerWave());
	}

    #region Update
    void FixedUpdate()
    {
        base.ActorFixedUpdate();
        
        if (Mathf.Abs(rigidBody.velocity.y) > 0.01f)
        {
            Fall();
        }

        if (Mathf.Abs(rigidBody.velocity.x) > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Sign(rigidBody.velocity.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    void Update()
    {
        base.ActorUpdate();

        if (Animator.StringToHash("PlayerWave") != currentState && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Wave");
        }
    }
    #endregion

    #region Actions
    
    #endregion
}
