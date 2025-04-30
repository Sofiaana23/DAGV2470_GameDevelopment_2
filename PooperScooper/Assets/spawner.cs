using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
   [System.Serializable]
    public struct GameObjectFloatPair
    {
        public GameObject gameObject;
        public float value;
    }

    public GameObjectFloatPair[] spawnableObjects;

    // Start is called before the first frame update
    // This should initialize our first spawn for the environment.
    // Future spawns can be handled in later TODO
    void Start()
    {
        foreach (GameObjectFloatPair obj in spawnableObjects)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue > obj.value)
            {
                continue; // Skip this object if the random value is greater than the specified value
            }
            // Instantiate the object at the spawner's position and rotation
            Instantiate(obj.gameObject, transform.position + GenerateRandomOffset(), GenerateRandomYRotation());
        }
    }

    public static Vector3 GenerateRandomOffset()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        float y = 0f;

        return new Vector3(randomX, y, randomZ);
    }

    public static Quaternion GenerateRandomYRotation()
    {
        return Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }

}
