using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnCollision : MonoBehaviour
{
    public Material normalMaterial;
    public Material highlightMaterial;

    private Renderer objectRenderer;
    private bool isHighlighted = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = normalMaterial; // Set the default material.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CharacterHand"))
        {
            // The character's hand collided with this object.
            // Apply the highlight material.
            objectRenderer.material = highlightMaterial;
            isHighlighted = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (isHighlighted && collision.gameObject.CompareTag("CharacterHand"))
        {
            // The character's hand exited the collision.
            // Revert to the default material.
            objectRenderer.material = normalMaterial;
            isHighlighted = false;
        }
    }
}
