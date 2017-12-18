using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem
{
	private List <float> possibleOffset = new List<float> (new float[]{-10.0f, -5.0f, 0f, 5.0f, 10.0f});
	private float lastXOffsetUsed = float.NaN;
		
	public void SpawnPlayer (GameObject character, float xOffset = float.NaN)
	{
		if ( float.IsNaN (xOffset) )
		{
			do
			{
				xOffset = possibleOffset[Random.Range (0, possibleOffset.Count)];
			} while (xOffset == lastXOffsetUsed);
		}

		lastXOffsetUsed = xOffset;

		character.transform.position = new Vector2 (xOffset, 0f);
	}
}
