using UnityEngine;
using System;
namespace Assets.Core.Ext
{
	public static class UnityExtensions
	{

		public static void DeleteAllChildren(this Transform transform)
		{
			GameObject[] children = new GameObject[transform.childCount];
			int i = 0;
			foreach (Transform child in transform)
			{
				children[i] = child.gameObject;
				i++;
			}

			foreach (GameObject child in children)
			{
				GameObject.DestroyImmediate(child);
			}
		}

	}
}
