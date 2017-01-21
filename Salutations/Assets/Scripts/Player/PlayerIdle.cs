using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Abstract_Actor_Components.States
{
    public class PlayerIdle : IState
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
            if (movementIntent.magnitude > 0)
            {
                actor.animator.SetBool("Walking", true);
            }
            if (movementIntent.y > 0 && Mathf.Abs(rigidBody.velocity.y) < 0.01f)
            {
                actor.Jump();
                return;
            }
        }

        public void Update(ActorComponent actor)
        {
            
        }

    }
}
