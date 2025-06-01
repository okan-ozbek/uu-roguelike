using Stateforge;

namespace Entities.Player.States
{
    public abstract class PlayerBaseState : State
    {
        protected readonly PlayerController Controller;
        
        protected PlayerBaseState(PlayerController controller) : base(controller)
        {
            Controller = controller;
        }
    }
}