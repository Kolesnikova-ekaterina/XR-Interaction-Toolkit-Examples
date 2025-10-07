using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChangeColorOnThrow : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer objectRenderer;
    private AudioSource audioSource;

    public Color thrownColor = Color.red;
    public Color defaultColor = Color.white;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        objectRenderer.material = new Material(objectRenderer.material);

        grabInteractable.selectExited.AddListener(OnThrow);
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnThrow(SelectExitEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = thrownColor;
        }

        if (audioSource != null)
        {
            audioSource.Play(); // проигрываем звук броска
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = defaultColor;
        }
    }
}
