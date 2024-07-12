using UnityEngine;

public class Customizer : MonoBehaviour
{
    public SpriteRenderer part;
    public Sprite[] options;
    public static int eyesIndex = 0; // Static variables to track indices
    public static int mouthIndex = 0;
    public static int itemIndex = 0;
    private int index;
    private static bool isInitialized = false;

    private void Start()
    {
        if (!isInitialized)
        {
            index = 0;
            isInitialized = true;
        }
    }

    private void Update()
    {
        // Set the part sprite based on the static indices
        if (gameObject.name == "eyes")
        {
            index = eyesIndex;
        }
        else if (gameObject.name == "mouth")
        {
            index = mouthIndex;
        }
        else if (gameObject.name == "item")
        {
            index = itemIndex;
        }

        part.sprite = options[index];
    }

    public void SwapRightButton()
    {
        if (gameObject.name == "eyes")
        {
            if (eyesIndex < options.Length - 1)
            {
                eyesIndex++;
            }
            else
            {
                eyesIndex = 0;
            }
        }
        else if (gameObject.name == "mouth")
        {
            if (mouthIndex < options.Length - 1)
            {
                mouthIndex++;
            }
            else
            {
                mouthIndex = 0;
            }
        }
        else if (gameObject.name == "item")
        {
            if (itemIndex < options.Length - 1)
            {
                itemIndex++;
            }
            else
            {
                itemIndex = 0;
            }
        }
    }

    public void SwapLeftButton()
    {
        if (gameObject.name == "eyes")
        {
            if (eyesIndex > 0)
            {
                eyesIndex--;
            }
            else
            {
                eyesIndex = options.Length - 1;
            }
        }
        else if (gameObject.name == "mouth")
        {
            if (mouthIndex > 0)
            {
                mouthIndex--;
            }
            else
            {
                mouthIndex = options.Length - 1;
            }
        }
        else if (gameObject.name == "item")
        {
            if (itemIndex > 0)
            {
                itemIndex--;
            }
            else
            {
                itemIndex = options.Length - 1;
            }
        }
    }
}
