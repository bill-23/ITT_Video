using UnityEngine;

public class TriggerTouch : MonoBehaviour
{
  
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
    }
}