using Interfaces;
using Scriptable_Objects;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Mono_Behaviours
{
    public class GrassField : MonoBehaviour, IWindPropertyUser
    {
        #region Inspector Parameters

        [SerializeField] private GameObject grassPrefab = null;
        [SerializeField] private int grassPlaneSize = 20;
        [SerializeField] private float randomOffsetX = 0.15f;
        [SerializeField] private float randomOffsetZ = 0.15f;
        [SerializeField] private float grassHeightDeviation = 0.2f;
        [SerializeField] private float grassScaleFactor = 5f;
        [FormerlySerializedAs("grassDensity")] [SerializeField] private float grassVastness = 0.7f;

        #endregion

        #region Properties

        public WindPropertiesObject WindProperties => ScriptableSingleton<WindPropertiesObject>.instance;

        #endregion

        #region Methods

        private void GenerateGrassField()
        {
            // use Y coordinate of this object for all grass elements
            float yPosition = transform.position.y;

            // place grass elements in a square-like arrangement
            for (int z = -grassPlaneSize; z < grassPlaneSize; z++)
            {
                for (int x = -grassPlaneSize; x < grassPlaneSize; x++)
                {
                    var grassElementPosition = new Vector3(transform.position.x + x * grassVastness + Random.Range(-randomOffsetX, randomOffsetX),
                        yPosition,
                        transform.position.z + z * grassVastness + Random.Range(-randomOffsetZ, randomOffsetZ));
                
                    // instantiate grass element as child object of this object
                    var grassElement = Instantiate(grassPrefab, grassElementPosition, Quaternion.identity, transform);
                
                    // set local scale x and z of grass element so the resulting global scale becomes 1 before multiplying with grass scale factor
                    grassElement.transform.localScale =
                        new Vector3((1 / transform.localScale.x) * grassScaleFactor, grassScaleFactor + Random.Range(-grassHeightDeviation, grassHeightDeviation), (1 / transform.localScale.z) * grassScaleFactor);
                }
            }
        }

        #endregion

        #region Unity Lifecycle
        
        private void Start()
        {
            GenerateGrassField();
        }
    
        #endregion
    }
}
