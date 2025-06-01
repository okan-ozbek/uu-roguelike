using UnityEngine;
using Utils.Input;

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
            AddTransition(typeof(PlayerMoveState), () => GameInputManager.Instance.MovementDirection != Vector2.zero);
        }
    }
}