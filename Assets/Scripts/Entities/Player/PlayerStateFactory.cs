using Entities.Player.States;
using Stateforge;

namespace Entities.Player
{
    public class PlayerStateFactory : StateFactory
    {
        private readonly PlayerController _controller;

        public PlayerStateFactory(PlayerController controller)
        {
            _controller = controller;
        }

        protected override void SetStates()
        {
            AddState(typeof(PlayerIdleState), new PlayerIdleState(_controller));
            AddState(typeof(PlayerMoveState), new PlayerMoveState(_controller));
        }
    }
}