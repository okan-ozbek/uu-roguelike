using UnityEngine;

namespace Utils.Singletons
{
    public class PersistentBehaviour<TComponent> : MonoBehaviour where TComponent : Component
    {
        public static TComponent Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as TComponent;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}