using System.Collections;
using UnityEngine;

public class SplitOnDeath : MonoBehaviour
{
    [SerializeField] public GameObject childNPC;
    [SerializeField] public int cloneCount;
    [SerializeField] private float cloneLaunchForce;

    private void Start()
    {
        GetComponent<IHealth>().OnDied += SpawnClones;
    }

    private void SpawnClones()
    {
        if (cloneCount < 2)
            return;

        Debug.Log("Spawning Clones");

        for (int i = 0; i < cloneCount; i++)
        {
            var cloneInstance = Instantiate(childNPC, transform.position, transform.rotation);

            LaunchChildObject(cloneInstance);

            if (cloneInstance.GetComponent<SplitOnDeath>() != null)
            {
                InitializeRecursiveSplit(cloneInstance);
            }
        }
    }

    void InitializeRecursiveSplit(GameObject target)
    {
        if (target.GetComponent<SplitOnDeath>() == null)
        {
            target.AddComponent<SplitOnDeath>();
        }

        SplitOnDeath targetSplitter = target.GetComponent<SplitOnDeath>();

        target.transform.localScale /= 2;
        --targetSplitter.cloneCount;
        targetSplitter.childNPC = target;
    }

    void LaunchChildObject(GameObject launchTarget)
    {
        Vector3 direction = new Vector3 (Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f));

        if (launchTarget.GetComponent<Rigidbody>() == null)
        {
            launchTarget.AddComponent<Rigidbody>();
        }

        Rigidbody rb = launchTarget.GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        rb.AddForce(direction * cloneLaunchForce, ForceMode.Impulse);
    }
}