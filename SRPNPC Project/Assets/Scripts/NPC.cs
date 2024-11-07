using UnityEngine;

public class NPC : MonoBehaviour
{
    internal void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }

    void Update()
    {
        transform.position += transform.forward * 3 * Time.deltaTime;
        transform.Rotate(0f, 90 * Time.deltaTime, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}