using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Abstract_Actor_Components;
using Assets.Scripts.Abstract_Actor_Components.States;

using Assets.Scripts;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerActor : ActorComponent {

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
        //states.Add(Animator.StringToHash("Crouching"), new PlayerCrouching());
	}

    #region Update
    void FixedUpdate()
    {
        base.ActorFixedUpdate();
        if (Mathf.Abs(rigidBody.velocity.y) > 0.01f)
        {
            Fall();
        }
    }

    void Update()
    {
        base.ActorUpdate();
    }
    #endregion

    #region Actions
    
    #endregion
}
