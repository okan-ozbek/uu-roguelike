using Entities.Player.States;

namespace Entities.Player
{
    public class PlayerController : AdvancedEntityController
    {
        protected override void OnAwake()
        {
            GetFactory(new PlayerStateFactory(this));
            GetStateMachine(typeof(PlayerIdleState));
        }

        protected override void OnUpdate()
        {
            stateMachine.stateTransition.Handle(stateMachine.currentState);
            stateMachine.currentState.Update();
        }
    }
}