using System.Collections;  // Required for IEnumerator
using UnityEngine;
using UnityEngine.UI;  // Required for working with UI elements

public class FadeOutEffect : MonoBehaviour
{
    // The Image component representing the black overlay
    private Image blackOverlay;

    // Duration of the fade-out effect
    public float fadeDuration = 8.0f;

    // Delay before starting the fade-out effect
    public float delayBeforeFade = 2.0f;

    void Start()
    {
        // Get the Image component attached to this GameObject (the Panel)
        blackOverlay = GetComponent<Image>();

        // Start the fade-out effect after the delay
        StartCoroutine(FadeOut());
    }

    // Coroutine that handles the fade-out over time
    IEnumerator FadeOut()
    {
        // Wait for the specified delay before starting the fade-out
        yield return new WaitForSeconds(delayBeforeFade);

        // Ensure the panel starts fully opaque
        Color overlayColor = blackOverlay.color;
        overlayColor.a = 1.0f;  // Start fully opaque
        blackOverlay.color = overlayColor;

        // Fade out over the duration
        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            overlayColor.a = Mathf.Lerp(1.0f, 0.0f, normalizedTime);  // Lerp from full opacity to transparent
            blackOverlay.color = overlayColor;

            yield return null;  // Wait until the next frame
        }

        // Ensure the panel is completely transparent at the end
        overlayColor.a = 0.0f;
        blackOverlay.color = overlayColor;

        // Optionally, deactivate the panel after the fade
        blackOverlay.gameObject.SetActive(false);
    }
}
