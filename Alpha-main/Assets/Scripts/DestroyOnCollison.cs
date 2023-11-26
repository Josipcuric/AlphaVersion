
using System.Collections;
using UnityEngine;

public class DestroyMonsterOnCollision : MonoBehaviour
{
    public delegate void OnDestroyedAction(GameObject destroyedObject);
    public event OnDestroyedAction OnDestroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("plane"))
        {
            if (gameObject.CompareTag("Monster"))
            {
                OnDestroyed?.Invoke(gameObject); // Notify about the destruction of the monster
                Destroy(gameObject); // Destroy the object with the "Monster" tag
            }
        }
    }
}