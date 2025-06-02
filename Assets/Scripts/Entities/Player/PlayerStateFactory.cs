using Entities.Player.States;
using Stateforge;

namespace Entities.Player
{
    public class PlayerStateFactory : StateFactory
    {
        private PlayerController Controller { get; }
        
        public PlayerStateFactory(PlayerController controller)
        {
            Controller = controller;
        }
        
        protected override void SetStates()
        {
            AddState(typeof(PlayerIdleState), new PlayerIdleState(Controller));
            AddState(typeof(PlayerMoveState), new PlayerMoveState(Controller));
        }
    }
}