using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    [SerializeField][Range(-1.0f, 1.0f)] private float windDirectionX = 1.0f;
    [SerializeField][Range(-1.0F, 1.0F)] private float windDirectionZ = 0.0f;
    [SerializeField][Range(0.01f, 0.5f)] private float windStrength = 0.2f;
    
    private Vector2 windDirection = Vector2.zero;
    private WindPropertiesObject windProperties = null;
    
    public Vector2 WindDirection
    {
        get => windDirection;
    }
    
    public float WindStrength
    {
        get => windStrength;
    }

    private void Awake()
    {
        windDirection = new Vector2(windDirectionX, windDirectionZ).normalized;
        windProperties = ScriptableObject.CreateInstance<WindPropertiesObject>();

        windProperties.Direction = windDirection;
        windProperties.Strength = windStrength;
    }

    private void OnValidate()
    {
        windDirection = new Vector2(windDirectionX, windDirectionZ).normalized;
        windProperties.Direction = windDirection;
        windProperties.Strength = windStrength;
        Debug.Log(windDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, new Vector3(windDirection.x * 5, transform.position.y, windDirection.y * 5));
        // Gizmos.DrawLine(transform.position, new Vector3(windDirection.x, transform.position.y, windDirection.y));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
