using UnityEngine;

public class BerryManager : MonoBehaviour
{
    private BerryFarmManager bfManager;

    private void Start()
    {
        bfManager = transform.parent.GetComponent<BerryFarmManager>();
    }

    // When clicked on the berry
    private void OnMouseDown()
    {
        bfManager.BerryCollected();
        Destroy(gameObject);
    }
}
