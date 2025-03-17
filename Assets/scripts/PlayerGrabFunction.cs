using UnityEngine;

public class PlayerGrabFunction : MonoBehaviour
{
    public bool inRange = false;

    [Header("Range Detector")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask grabMask;

    private void Update()
    {
        //detects if grabbable objects r in range
        Collider[] hits = Physics.OverlapSphere(transform.position, range, grabMask);
        if (hits.Length > 0)
        {
            inRange = true;
            Debug.Log("I FOUND SOMEONE!!!");
        }
        else
        {
            inRange = false;
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
