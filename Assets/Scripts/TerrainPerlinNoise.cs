using UnityEditor;
using UnityEngine;
using System.Collections;

public class TerrainPerlinNoise : ScriptableWizard
{
	public float tiling = 10.0f;

	[MenuItem("Terrain/Generate from Perlin Noise")]
	public static void CreateWizard(MenuCommand command)
	{
		ScriptableWizard.DisplayWizard("Perlin Noise Generator", typeof(TerrainPerlinNoise));
	}
	void OnWizardUpdate()
	{
		helpString = "Kura mi e pone 25 santa i se praznq kato tsisterna, ebasi";
	}

	void OnWizardCreate()
	{
		GameObject obj = Selection.activeGameObject;
		if (obj.GetComponent<Terrain>())
		{
			GenerateHeights(obj.GetComponent<Terrain>(),tiling);
		}
	}

	public void GenerateHeights(Terrain terrain, float tileSize)
	{
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		//float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapHeight; i++)
		{
			//tileSize = Random.Range(10.0f, 12.0f);
			for (int k = 0; k < terrain.terrainData.heightmapWidth; k++)
			{

				heights[i, k] = Mathf.PerlinNoise(((float)k / (float)terrain.terrainData.heightmapWidth) * tileSize, ((float)k / (float)terrain.terrainData.heightmapHeight) * tileSize) / 10.0f;
				//   heights[i, k] = Mathf.PerlinNoise(0.5f, ((float)k / (float)terrain.terrainData.heightmapHeight) * tileSize) / 10.0f;

			}
		}
		terrain.terrainData.SetHeights(0, 0, heights);
	}
}