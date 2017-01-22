using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Abstract_Actor_Components.States
{
    public class PlayerWave : IState
    {

        public void OnEnter(ActorComponent actor)
        {
        }

        public void OnLeave(ActorComponent actor)
        {
        }

        public void FixedUpdate(ActorComponent actor)
        {
            Vector2 movementIntent = actor.MovementIntent;
            if (Mathf.Abs(movementIntent.x) > 0)
            {
                actor.animator.SetBool("Walking", true);
            }
        }

        public void Update(ActorComponent actor)
        {
            
        }

    }
}
