using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class GrassShader : MonoBehaviour
{
    private const string ShaderPropertyWindDirection = "WindDirection";
    private const string ShaderPropertyWindStrength = "WindStrength";
    
    private WindPropertiesObject windProperties = null;
    private MeshRenderer renderer = null;
    private Material shaderMaterial = null;

    public WindPropertiesObject WindPropertiesObject
    {
        set
        {
            windProperties = value;
            
            UpdateShaderWindDirection(value.Direction);
            UpdateShaderWindStrength(value.Strength);
            
            value.ChangeDirectionEvent.AddListener(UpdateShaderWindDirection);
            value.ChangeStrengthEvent.AddListener(UpdateShaderWindStrength);
        }
    }

    private void UpdateShaderWindDirection(Vector2 newDirection)
    {
        shaderMaterial.SetVector(ShaderPropertyWindDirection, new Vector4(newDirection.x, newDirection.y));
    }

    private void UpdateShaderWindStrength(float newStrength)
    {
        shaderMaterial.SetFloat(ShaderPropertyWindStrength, newStrength);
    }

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        shaderMaterial = renderer.material;
    }
}
