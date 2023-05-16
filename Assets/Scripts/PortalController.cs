using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalController : Damag
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
            Destroy(other.gameObject);
        }
    }

    protected override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        if (currentHealth <= 0)
        {
            UIManager.Instance.GameOver();
        }
    }


}
