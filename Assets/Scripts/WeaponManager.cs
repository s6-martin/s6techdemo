using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform projectileSpawnPoint;

    public void Fire()
    {
        GameObject bullet = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 20f, ForceMode.Impulse);
    }
}
