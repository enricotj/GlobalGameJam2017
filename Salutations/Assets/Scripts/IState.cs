using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Abstract_Actor_Components.States
{
    public interface IState
    {
        void OnEnter(ActorComponent actor);
        void OnLeave(ActorComponent actor);
        void FixedUpdate(ActorComponent actor);
        void Update(ActorComponent actor);
    }
}
