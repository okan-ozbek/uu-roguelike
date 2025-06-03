using UnityEngine;
using Utils.Input;

namespace Entities.Player.States
{
    public class PlayerMoveState : PlayerBaseState
    {
        public PlayerMoveState(PlayerController controller) : base(controller)
        {
            EnableRootState();
        }

        protected override void OnUpdate()
        {
            Controller.transform.Translate(GameInput.Instance.MovementDirection * Controller.Data.movementSpeed.Value * Time.deltaTime);
        }

        protected override void SetTransitions()
        {
            AddTransition(typeof(PlayerIdleState), () => GameInput.Instance.MovementDirection == Vector2.zero);
        }
    }
}