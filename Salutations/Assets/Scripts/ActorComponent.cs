using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Abstract_Actor_Components;
using Assets.Scripts.Abstract_Actor_Components.States;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class ActorComponent : MonoBehaviour {

    // define components
    public InputComponent input;
    public Rigidbody2D rigidBody;
    public Animator animator;

    // define state machine
    protected int currentState = 0;
    protected Dictionary<int, IState> states; // shortNameHash => IState

    // define stats
    protected float acceleration = 25;
    protected float moveSpeed = 5;

    public float Acceleration { get { return acceleration; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public Vector3 Position { get { return this.transform.position; } }

    // define inputs
    public Vector2 MovementIntent = new Vector2(0, 0);

	// Use this for initialization
	void Start ()
    {
        input = new PlayerInputComponent();
        rigidBody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        
        states = new Dictionary<int, IState>();
	}

    #region Update
    void FixedUpdate()
    {
        ActorFixedUpdate();
    }

    protected virtual void ActorFixedUpdate()
    {
        CheckStateTransition();
        states[currentState].FixedUpdate(this);
    }

    void Update()
    {
        ActorUpdate();
    }

    protected virtual void ActorUpdate()
    {
        ResetAnimatorParameters();
        input.ReadInputs(this);

        CheckStateTransition();
        states[currentState].Update(this);
    }
    #endregion

    #region Actions
    public void Jump()
    {
        rigidBody.AddForce(new Vector2(0, 1) * acceleration * 15 * rigidBody.gravityScale * 0.75f);
        Fall();
    }

    public void Fall()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Jumping", true);
    }

    public void Land()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > 0)
        {
            animator.SetBool("Walking", true);
        }

        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        animator.SetBool("Jumping", false);
    }
    #endregion

    #region Logic Control
    public virtual void ResetAnimatorParameters()
    {

    }

    private void CheckStateTransition()
    {
        int mecanimState = animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
        if (currentState != mecanimState)
        {
            if (currentState != 0)
            {
                states[currentState].OnLeave(this);
            }

            currentState = mecanimState;

            states[currentState].OnEnter(this);
        }
    }
    #endregion

}
