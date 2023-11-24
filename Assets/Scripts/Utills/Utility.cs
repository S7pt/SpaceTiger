using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
	private const float HUE_MIN = 0;
	private const float HUE_MAX = 1;
	private const float SATURATION_MIN = 0.6f;
	private const float SATURATION_MAX = 1;
	private const float VALUE_MIN = 0.9f;
	private const float VALUE_MAX = 1;

    public static int RandomExcluding(int min, int max, List<int> numbersToExclude) 
	{
		int selectedNumber = 0;
		if (numbersToExclude.Count != 0)
		{
			selectedNumber = numbersToExclude[0];
		}
		while(numbersToExclude.Contains(selectedNumber))
		{
			selectedNumber = Random.Range(min, max + 1);
		}
		return selectedNumber;
	}

	public static Color RandomColor()
	{
		return Random.ColorHSV(HUE_MIN, HUE_MAX, SATURATION_MIN, SATURATION_MAX, VALUE_MIN, VALUE_MAX);
	}
}
