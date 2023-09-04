using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject soilPrefab;
    public GameObject stonePrefab;
    public GameObject bedrockPrefab;
    public int worldWidth = 10;
    public int worldHeight = 10;
    public float noiseScale = 0.1f;

    void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                float xCoord = (float)x / worldWidth * noiseScale;
                float yCoord = (float)y / worldHeight * noiseScale;
                float height = Mathf.PerlinNoise(xCoord, yCoord);

                GameObject layerPrefab;

                if (y < 2)
                {
                    layerPrefab = bedrockPrefab;
                }
                else if (height > 0.5f)
                {
                    layerPrefab = soilPrefab;
                }
                else
                {
                    layerPrefab = stonePrefab;
                }

                GameObject layer = Instantiate(layerPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
}
