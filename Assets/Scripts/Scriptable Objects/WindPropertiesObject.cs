using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Scriptable_Objects
{
    public class WindPropertiesObject : ScriptableSingleton<WindPropertiesObject>
    {
        private Vector2 direction = Vector2.zero;
        private float strength = 0.2f;
        private UnityEvent<Vector2> changeDirectionEvent = null;
        private UnityEvent<float> changeStrengthEvent = null;
        
        public Vector2 Direction
        {
            get => direction;
            set
            {
                direction = value;
                changeDirectionEvent.Invoke(value);
            }
        }

        public float Strength
        {
            get => strength;
            set
            {
                strength = value;
                changeStrengthEvent.Invoke(value);
            }
        }
        
        public UnityEvent<Vector2> ChangeDirectionEvent
        {
            get => changeDirectionEvent;
        }
        
        public UnityEvent<float> ChangeStrengthEvent
        {
            get => changeStrengthEvent; 
        }

        private void Awake()
        {
            changeDirectionEvent = new UnityEvent<Vector2>();
            changeStrengthEvent = new UnityEvent<float>();
        }

        private void OnDestroy()
        {
            changeDirectionEvent.RemoveAllListeners();
            changeStrengthEvent.RemoveAllListeners();
        }
    }
}
