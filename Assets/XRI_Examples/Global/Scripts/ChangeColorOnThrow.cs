using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChangeColorOnThrow : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer objectRenderer;
    private AudioSource audioSourceRoblox;
    private AudioSource audioSourceRickRoll;

    public Color thrownColor = Color.red;
    public Color defaultColor = Color.white;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectRenderer = GetComponent<Renderer>();
        audioSourceRoblox = GetComponents<AudioSource>()[0];
        audioSourceRickRoll = GetComponents<AudioSource>()[1];
       
        

        if (objectRenderer != null)
        {
            objectRenderer.material = new Material(objectRenderer.material);
        }

        grabInteractable.selectExited.AddListener(OnThrow);
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnThrow(SelectExitEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = thrownColor;
        }

        if (audioSourceRoblox != null)
        {
            audioSourceRoblox.Play(); // проигрываем звук броска
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = defaultColor;
        }

        var rand = Random.Range(0, 3);
        if (audioSourceRickRoll != null && rand == 0 && (gameObject.tag=="rickrolled"|| gameObject.tag == "Destroyer"))
        {
            Debug.Log(gameObject.name);
            audioSourceRickRoll.Play(); // проигрываем звук броска
        }
    }
}

