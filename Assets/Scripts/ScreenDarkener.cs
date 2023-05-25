using UnityEngine;
using UnityEngine.UI;

public class ScreenDarkener : MonoBehaviour
{
    // public float initialAlpha = 1f;
    // public float targetAlpha = 0f;

    public float initialAlpha = 0f;
    public float targetAlpha = 1f;
    public float startAnimationDuration = 2f;
    public float endAnimationDuration = 1f;

    private Image image;
    private float currentAlpha;
    private float timer;

    public bool makeScreenDark;
    public bool makeScreenLight;

    SwitchDimension switchDimension;
    Animator myAnimator;

    

    private void Start()
    {
        switchDimension = FindObjectOfType<SwitchDimension>();
        myAnimator = FindObjectOfType<Animator>();
        

        makeScreenDark = false;
        makeScreenLight = false;
        image = GetComponent<Image>();
        currentAlpha = initialAlpha;
        //image.color = new Color(0f, 0f, 0f, currentAlpha);
        
    }

    private void Update()
    {
        if(makeScreenDark)
        {
            timer += Time.deltaTime;

            // Calculate the current alpha value based on the timer and animation duration
            currentAlpha = Mathf.Lerp(initialAlpha, targetAlpha, timer / startAnimationDuration);

            // Set the new alpha value for the Image
            image.color = new Color(0f, 0f, 0f, currentAlpha);

            if(timer >= startAnimationDuration)
            {
                makeScreenDark = false;
                switchDimension.ChangeDimension();

                //EnableTilemapCollider();

                StartLighteningAnimation();
            }
        }

        if(makeScreenLight)
        {
            timer += Time.deltaTime;

            // Calculate the current alpha value based on the timer and animation duration
            currentAlpha = Mathf.Lerp(initialAlpha, targetAlpha, timer / endAnimationDuration);

            // Set the new alpha value for the Image
            image.color = new Color(0f, 0f, 0f, currentAlpha);

            if(timer >= endAnimationDuration)
            {
                makeScreenLight = false;
                //DisableTilemapCollider();
                switchDimension.SetInLightDimension();
            }
        }
    }

    public void StartDarkeningAnimation()
    {
        initialAlpha = 0f;
        targetAlpha = 1f;

        // Reset the timer and set the initial alpha value
        timer = 0f;
        currentAlpha = initialAlpha;

        makeScreenDark = true;
        myAnimator.SetBool("changeDimension", true);
    }

    private void StartLighteningAnimation()
    {
        initialAlpha = 1f;
        targetAlpha = 0f;
        image.color = new Color(1f, 1f, 1f, initialAlpha);

        timer = 0f;
        currentAlpha = initialAlpha;
        makeScreenLight = true;
        myAnimator.SetBool("changeDimension", false);
    }
}
