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
            Debug.Log($"Movement Direction: {GameInput.Instance.MovementDirection}");
            Debug.Log($"Movement Speed: {Controller.Stats.movementSpeed.Value}");
            
            Controller.transform.Translate(GameInput.Instance.MovementDirection * Controller.Stats.movementSpeed.Value * Time.deltaTime);
        }

        protected override void SetTransitions()
        {
            AddTransition(typeof(PlayerIdleState), () => GameInput.Instance.MovementDirection == Vector2.zero);
        }
    }
}