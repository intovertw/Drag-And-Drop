using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GrabbableObject : MonoBehaviour
{
    private PlayerGrabFunction grabScript;
    private GameObject player;
    private Rigidbody rb;

    private bool isGrabbing = false, drop = false;

    public TMP_Text dropTxt, pickUpTxt;

    private void Start()
    {
        dropTxt.enabled = false;
        pickUpTxt.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        grabScript = player.GetComponent<PlayerGrabFunction>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (isGrabbing)
        {
            pickUpTxt.enabled = false;
            rb.useGravity = false;
            transform.position = ray.GetPoint(1);
            dropTxt.enabled = true;

            if(Input.GetMouseButtonUp(0))
            {
                drop = true;
            }

            if (drop && Input.GetMouseButtonDown(0))
            {
                Debug.Log("drop");
                rb.useGravity = true;
                isGrabbing = false;
                dropTxt.enabled = false;
                drop = false;
            }
        }

    }

    private void OnMouseOver()
    {
        if (grabScript.inRange)
        {
            Debug.Log("an object is in range.");
            pickUpTxt.enabled = true;

            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Grab Object");
                isGrabbing = true;
            }
        }
        else
        {
            Debug.Log("hovered, but not in range");
        }
    }

    private void OnMouseExit()
    {
        pickUpTxt.enabled = false;
    }
}
