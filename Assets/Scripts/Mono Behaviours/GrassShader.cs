using Interfaces;
using Scriptable_Objects;
using UnityEditor;
using UnityEngine;

namespace Mono_Behaviours
{
    public class GrassShader : Shader, IWindPropertyUser
    {
        private const string ShaderPropertyWindDirection = "WindDirection";
        private const string ShaderPropertyWindStrength = "WindStrength";
        private static readonly int WindDirectionId = UnityEngine.Shader.PropertyToID(ShaderPropertyWindDirection);
        private static readonly int WindStrengthId = UnityEngine.Shader.PropertyToID(ShaderPropertyWindStrength);

        public WindPropertiesObject WindProperties => ScriptableSingleton<WindPropertiesObject>.instance;

        private void UpdateShaderWindDirection(Vector2 newDirection)
        {
            shaderMaterial.SetVector(WindDirectionId, new Vector4(newDirection.x, newDirection.y));
        }

        private void UpdateShaderWindStrength(float newStrength)
        {
            shaderMaterial.SetFloat(WindStrengthId, newStrength);
        }

        protected override void Awake()
        {
            base.Awake();
            
            UpdateShaderWindDirection(WindProperties.Direction);
            UpdateShaderWindStrength(WindProperties.Strength);
            
            WindProperties.ChangeDirectionEvent.AddListener(UpdateShaderWindDirection);
            WindProperties.ChangeStrengthEvent.AddListener(UpdateShaderWindStrength);
        }
    }
}
