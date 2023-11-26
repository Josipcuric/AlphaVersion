using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject objectToRespawn;
    public float respawnTime = 3f;
    
    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        Instantiate(objectToRespawn, transform.position, Quaternion.identity);
    }

    public void RespawnObject()
    {
        Invoke("SpawnObject", respawnTime);
    }
}
