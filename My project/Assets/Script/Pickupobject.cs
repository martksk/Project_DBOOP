using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupobject: MonoBehaviour
{
    private GameObject carriedBox;
    private bool isCarrying = false;
    private RaycastHit hit;
    private int x=0;
    private int y=0;
    private Animator animator;

    public Transform carryPosition;
    public Transform releasePosition;
    public float detectionRange = 0.5f;
    public Transform raycastOrigin;
    public static int score = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 raycastStart = raycastOrigin.position;
        if (hit.collider != null )
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
        }
        if (Physics.Raycast(raycastStart, transform.forward, out hit, detectionRange))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.DrawRay(raycastStart, transform.forward * detectionRange, Color.red, 1.0f);
            if (isCarrying && CanDisposeOfRubbish())
            {
                DisposeOfRubbish();
                // ScoreManager.instance.AddPoint();
            }
            else if(isCarrying)
            {
                ReleaseBox();
            }
        
            else
            {
                Pickup();
            
            }
        }
    }

    void Pickup()
    {
        RaycastHit hit;
        Vector3 raycastStart = raycastOrigin.position;
        if (Physics.Raycast(raycastStart, transform.forward, out hit, detectionRange))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hit.transform.CompareTag("HighlightObject"))
            {
                RubbishManager rubbishManager = hit.collider.GetComponent<RubbishManager>();
                if (rubbishManager != null)
                {
                    // Access the rubbish type
                    RubbishManager.RubbishType rubbishType = rubbishManager.rubbishType;

                    // Use the rubbish type as needed
                    switch (rubbishType)
                    {
                        case RubbishManager.RubbishType.Green:
                            x=1;
                            break;
                        case RubbishManager.RubbishType.Blue:
                            x=2;
                            break;
                        case RubbishManager.RubbishType.Yellow:
                            x=3;
                            break;
                        case RubbishManager.RubbishType.Red:
                            x=4;
                            break;
                        default:
                            break;
                    }
                }
                carriedBox = hit.transform.gameObject;
                carriedBox.GetComponent<Rigidbody>().isKinematic = true;
                carriedBox.transform.position = carryPosition.position;
                carriedBox.transform.parent = transform;
                isCarrying = true;
            }
        }
        Debug.DrawRay(raycastStart, transform.forward * detectionRange, Color.red, 1.0f);
    }


    void ReleaseBox()
    {
        if (carriedBox != null)
        {
            carriedBox.GetComponent<Rigidbody>().isKinematic = false;
            carriedBox.transform.position = releasePosition.position;
            carriedBox.transform.parent = null;
            carriedBox = null;
            isCarrying = false;
        }
    }

    bool CanDisposeOfRubbish()
    {
        RaycastHit hit;
        Vector3 raycastStart = raycastOrigin.position;
        if (Physics.Raycast(raycastStart, transform.forward, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Bin"))
            {
                BinManager binManager = hit.collider.GetComponent<BinManager>();
                if (binManager != null)
                {
                    // Access the bin type
                    BinManager.BinType binType = binManager.binType;

                    // Use the bin type as needed
                    switch (binType)
                    {
                        case BinManager.BinType.Green:
                            y=1;
                            break;
                        case BinManager.BinType.Blue:
                            y=2;
                            break;
                        case BinManager.BinType.Yellow:
                            y=3;
                            break;
                        case BinManager.BinType.Red:
                            y=4;
                            break;
                        default:
                            // Handle other cases if needed
                            break;
                    }
                }
                return true;
            }
        }

        return false;
    }

    void DisposeOfRubbish()
    {
        if(x==y)
        {
            Debug.Log("Correct!");
            ScoreManager.instance.AddPoint();
        }else
        {
            Debug.Log("Wrong!");
        }
        Destroy(carriedBox);
        carriedBox = null;
        isCarrying = false;
        x=0;
        y=0;
    }

}
