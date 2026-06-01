using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : MonoBehaviour
{
    [Tooltip("Drag the Primary Button action here from the inspector")]
    public InputActionReference primaryButtonAction;

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();

        // Turn on the button listener
        primaryButtonAction.action.Enable();

        // When the button is pressed, run the ChangeToRandomColor function
        primaryButtonAction.action.performed += ChangeToRandomColor;
    }

    private void ChangeToRandomColor(InputAction.CallbackContext context)
    {
        // Pick a random color and apply it to the material
        objRenderer.material.color = Random.ColorHSV();
    }

    void OnDestroy()
    {
        // Clean up the listener when the object is destroyed
        primaryButtonAction.action.performed -= ChangeToRandomColor;
    }
}