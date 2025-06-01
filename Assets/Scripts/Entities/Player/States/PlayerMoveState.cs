using Enums;
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
            Controller.Rigidbody.linearVelocity = GameInputManager.Instance.MovementDirection * Controller.Data.Stats[StatType.MovementSpeed].Value;
        }
        
        protected override void SetTransitions()
        {
            AddTransition(typeof(PlayerIdleState), () =>
            {
                bool stoppedMoving = GameInputManager.Instance.MovementDirection == Vector2.zero;
                bool rigidbodyStopped = Controller.Rigidbody.linearVelocity == Vector2.zero;
                
                return stoppedMoving && rigidbodyStopped;                
            });
        }
    }
}