using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractionType { ToggleLight, ChangeModel, PlayAnimation }
    public InteractionType interactionType;

    public Light targetLight; // ToggleLight
    public GameObject[] models; // ChangeModel
    private int currentModelIndex = 0;

    public Animator animator; // PlayAnimation
    public string animationTrigger = "Play";

    public void Interact()
    {
        switch (interactionType)
        {
            case InteractionType.ToggleLight:
                if (targetLight != null)
                    targetLight.enabled = !targetLight.enabled;
                break;

            case InteractionType.ChangeModel:
                if (models != null && models.Length > 0)
                {
                    models[currentModelIndex].SetActive(false);
                    currentModelIndex = (currentModelIndex + 1) % models.Length;
                    models[currentModelIndex].SetActive(true);
                }
                break;

            case InteractionType.PlayAnimation:
                if (animator != null)
                    animator.SetTrigger(animationTrigger);
                break;
        }
    }
}
