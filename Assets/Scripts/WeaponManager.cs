using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform projectileSpawnPoint;

    public int ammoCount = 100;

    //private void OnEnable()
    //{
    //    HUDController.instance.SetCrosshair();
    //    HUDController.instance.SetAmmo(ammoCount);
    //}

    //private void OnDisable()
    //{
    //    HUDController.instance.ClearHUD();
    //}

    public void Fire()
    {
        if (ammoCount > 0)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity))
            {
                Vector3 direction = hit.point - projectileSpawnPoint.position;
                GameObject bullet = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(direction * 20f, ForceMode.Impulse);
                ammoCount--;
                HUDController.instance.SetAmmo(ammoCount);
            }
        }
        else print("no ammo");
    }
}
