using System;
using Interfaces;
using Scriptable_Objects;
using UnityEditor;
using UnityEngine;

namespace Mono_Behaviours
{
    public class WaterShader : Shader, IWindPropertyUser
    {
        private const string ShaderPropertyWaveSpeed = "WaveSpeed";
        private const string ShaderPropertyWaveScale = "WaveScale";
        private const string ShaderPropertyWaveSize = "WaveSize";
        private const string ShaderPropertyWaveDirection = "WaveDirection";
        private static readonly int WaveSpeedId = UnityEngine.Shader.PropertyToID(ShaderPropertyWaveSpeed);
        private static readonly int WaveScaleId = UnityEngine.Shader.PropertyToID(ShaderPropertyWaveScale);
        private static readonly int WaveSizeId = UnityEngine.Shader.PropertyToID(ShaderPropertyWaveSize);
        private static readonly int WaveDirectionId = UnityEngine.Shader.PropertyToID(ShaderPropertyWaveDirection);

        [SerializeField] private float waveScale = 1f;
        [SerializeField] private float waveSize = 1f;
        
        public WindPropertiesObject WindProperties => ScriptableSingleton<WindPropertiesObject>.instance;
        
        private void UpdateShaderWaveSpeed(float newSpeed)
        {
            shaderMaterial.SetFloat(WaveSpeedId, newSpeed);
        }
        
        private void UpdateShaderWaveScale(float newScale)
        {
            shaderMaterial.SetFloat(WaveScaleId, newScale);
        }
        
        private void UpdateShaderWaveSize(float newSize)
        {
            shaderMaterial.SetFloat(WaveSizeId, newSize);
        }

        private void UpdateShaderWaveDirection(Vector2 newDirection)
        {
            shaderMaterial.SetVector(WaveDirectionId, new Vector4(newDirection.x, newDirection.y));
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            UpdateShaderWaveDirection(WindProperties.Direction);
            UpdateShaderWaveSpeed(WindProperties.Strength);
            
            WindProperties.ChangeDirectionEvent.AddListener(UpdateShaderWaveDirection);
            WindProperties.ChangeStrengthEvent.AddListener(UpdateShaderWaveSpeed);
        }

        private void OnValidate()
        {
            UpdateShaderWaveScale(waveScale);
            UpdateShaderWaveSize(waveSize);
        }
    }
}
