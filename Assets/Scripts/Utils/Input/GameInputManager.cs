using UnityEngine;
using Utils.Singletons;

namespace Utils.Input
{
    public class GameInputManager : PersistentBehaviour<GameInputManager>
    {
        private GameInputActions _actions;
        
        protected override void Awake()
        {
            _actions = new GameInputActions();
            _actions.Enable();
            
            base.Awake();
        }
        
        public Vector2 MovementDirection => _actions.Player.Move.ReadValue<Vector2>();
        public Vector2 LookDirection => _actions.Player.Look.ReadValue<Vector2>();
        
        public bool HasPressedJump => _actions.Player.Jump.WasPressedThisFrame();
        public bool HasReleasedJump => _actions.Player.Jump.WasReleasedThisFrame();
        
        public bool HasPressedAttack => _actions.Player.Attack.WasPressedThisFrame();
        public bool HasReleasedAttack => _actions.Player.Attack.WasReleasedThisFrame();
        
        public bool HasPressedInteract => _actions.Player.Interact.WasPressedThisFrame();
        public bool HasReleasedInteract => _actions.Player.Interact.WasReleasedThisFrame();
    }
}