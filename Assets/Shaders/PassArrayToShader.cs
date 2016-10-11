using UnityEngine;
using System.Collections;

public class PassArrayToShader : MonoBehaviour {

    public static void Vector3(Material material, string name, Vector3[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            material.SetVector(name + i.ToString(), array[i]);
        }
    }

    public static void Color(Material material, string name, Color[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            material.SetColor(name + i.ToString(), array[i]);
        }
    }
}
