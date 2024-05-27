using UnityEngine;
using UnityEngine.Serialization;

public class GrassCreator : MonoBehaviour
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

    #region Methods

    private void GenerateGrassField()
    {
        float yPosition = transform.position.y;

        for (int z = -grassPlaneSize; z < grassPlaneSize; z++)
        {
            for (int x = -grassPlaneSize; x < grassPlaneSize; x++)
            {
                var grassElementPosition = new Vector3(x * grassVastness + Random.Range(-randomOffsetX, randomOffsetX),
                    yPosition,
                    z * grassVastness + Random.Range(-randomOffsetZ, randomOffsetZ));
                var grassElement = Instantiate(grassPrefab, grassElementPosition, Quaternion.identity);
                grassElement.transform.localScale =
                    new Vector3(grassScaleFactor, grassScaleFactor + Random.Range(-grassHeightDeviation, grassHeightDeviation), grassScaleFactor);
            }
        }
    }

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        GenerateGrassField();
    }
    
    #endregion
}
