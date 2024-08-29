using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryFarmManager : MonoBehaviour
{
    [SerializeField]
    private int expectedCount = 7;

    private int collectedCount = 0;

    public GameObject rewardBucket;

    public void BerryCollected()
    {
        collectedCount++;

        if (collectedCount == expectedCount)
        {
            GameObject inst = Instantiate(rewardBucket, PlayerManager.instance.gameObject.transform);
            inst.transform.localPosition = new Vector3(0,inst.transform.localPosition.y,0);
        }
    }
}
