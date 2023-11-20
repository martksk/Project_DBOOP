using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupobject: MonoBehaviour
{
    private GameObject carriedBox;
    private bool isCarrying = false;
    private GameObject lastHighlightedObject;

    public Transform carryPosition;
    public Transform releasePosition;
    public float detectionRange = 0.5f;
    public Transform raycastOrigin;
    public Material normalMaterial;
    public Material highlightMaterial;
    public int score = 0;

    void Update()
    {
        RaycastHit hit;
        Vector3 raycastStart = raycastOrigin.position;
        if (Physics.Raycast(raycastStart, transform.forward, out hit, detectionRange))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("HighlightObject"))
            {
                hitObject.GetComponent<Renderer>().material = highlightMaterial;
                lastHighlightedObject = hitObject;
            }
            else if (lastHighlightedObject != null)
            {
                lastHighlightedObject.GetComponent<Renderer>().material = normalMaterial;
                lastHighlightedObject = null;
            }
        }
        else if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<Renderer>().material = normalMaterial;
            lastHighlightedObject = null;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isCarrying && CanDisposeOfRubbish())
            {
                DisposeOfRubbish();
                UpdateScore();
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
                return true;
            }
        }

        return false;
    }

    void DisposeOfRubbish()
    {
        Destroy(carriedBox);
        carriedBox = null;
        isCarrying = false;
    }

    void UpdateScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
