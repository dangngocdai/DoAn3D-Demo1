using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCauHoi : MonoBehaviour
{
    [SerializeField]
    int indexCauHoi = 0;

    Collider collider;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        collider = GetComponent<Collider>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && indexCauHoi != 0 && !CauHoiManager.Instance.TraLoiDungCau(indexCauHoi))
        {
            CauHoiManager.Instance.ShowCauHoi(indexCauHoi);
            collider.enabled = false;
        }
    }
}
