using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile to be shot
    public Transform firePoint; // Point where the projectile will be spawned
    public float projectileForce = 20f; // Force applied to the projectile

    void Update()
    {
        // Check if the "Z" key (or any desired key) is pressed to shoot
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot(); // Call the Shoot method to fire a projectile
        }
    }

    void Shoot()
    {
        // Instantiate a new projectile at the firePoint position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the projectile
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();

        // Apply force to the projectile in the upward direction only
        projectileRigidbody.AddForce(transform.up * projectileForce, ForceMode.Impulse);
    }
}
