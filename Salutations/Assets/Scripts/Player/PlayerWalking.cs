using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Abstract_Actor_Components.States
{
    public class PlayerWalking : IState
    {

        public void OnEnter(ActorComponent actor)
        {
        }

        public void OnLeave(ActorComponent actor)
        {
        }

        public void FixedUpdate(ActorComponent actor)
        {
            Rigidbody2D rigidBody = actor.rigidBody;
            Vector2 movementIntent = actor.MovementIntent;
            float acceleration = actor.Acceleration;
            float moveSpeed = actor.MoveSpeed;

            if (movementIntent.y > 0 && Mathf.Abs(rigidBody.velocity.y) < 0.01f)
            {
                actor.Jump();
                return;
            }

            // speed up, clamp velocity
            rigidBody.AddForce(new Vector2(movementIntent.x, 0) * acceleration);
            rigidBody.velocity = new Vector2(Mathf.Clamp(rigidBody.velocity.x, -moveSpeed, moveSpeed), rigidBody.velocity.y);

            if (movementIntent.x == 0 && rigidBody.velocity.x != 0)
            {
                // slow down
                //rigidBody.AddForce((new Vector2(rigidBody.velocity.normalized.x, 0)) * -1f * acceleration);
                //rigidBody.velocity = new Vector2(rigidBody.velocity.x * 0.95f, rigidBody.velocity.y);
                
                // stop
                if (Mathf.Abs(rigidBody.velocity.x) < 0.001f)
                {
                    rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                    actor.animator.SetBool("Walking", false);
                }
            }
            else if (rigidBody.velocity.x == 0)
            {
                actor.animator.SetBool("Walking", false);
            }
        }

        public void Update(ActorComponent actor)
        {
            
        }

    }
}
