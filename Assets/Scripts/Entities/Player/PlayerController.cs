using Entities.Player.States;
using Stateforge;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerController : Entity, IController
    {
        public IStateFactory stateFactory { get; set; }
        public IStateMachine stateMachine { get; set; }
        
        protected override void Awake()
        {
            base.Awake();
            
            stateFactory = new PlayerStateFactory(this);
            stateFactory.GetFactory();
            
            stateMachine = new StateMachine(stateFactory, typeof(PlayerIdleState));
        }
        
        private void Update()
        {
            stateMachine.stateTransition.Handle(stateMachine.currentState);
            stateMachine.currentState.Update();
        }
        
        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                // Get all the active states as a tree
                UnityEditor.Handles.Label(transform.position, "Active: " + stateMachine.GetTree(stateMachine.currentState));
            }
        }
    }
}