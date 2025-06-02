using Utils.Input;
using UnityEngine;

namespace Entities.Player.States
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerController controller) : base(controller)
        {
            EnableRootState();
        }

        protected override void SetTransitions()
        {
            AddTransition(typeof(PlayerMoveState), () => GameInput.Instance.MovementDirection != Vector2.zero);
        }
    }
}