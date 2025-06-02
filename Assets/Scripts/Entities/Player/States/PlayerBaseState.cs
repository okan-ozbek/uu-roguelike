using Stateforge;

namespace Entities.Player.States
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerController Controller { get; }

        protected PlayerBaseState(PlayerController controller) : base(controller)
        {
            Controller = controller;
        }
    }
}