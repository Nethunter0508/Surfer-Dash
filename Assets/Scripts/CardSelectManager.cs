using UnityEngine;

public class CardSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject charSprite;
    [SerializeField] GameObject gokuSprite;

    void Start()
    {
        Time.timeScale = 0;

        charSprite.SetActive(false);
        gokuSprite.SetActive(false);
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseChar()
    {
        charSprite.SetActive(true);
        gokuSprite.SetActive(false);
        BeginGame();
    }

    public void ChooseGoku()
    {
        gokuSprite.SetActive(true);
        charSprite.SetActive(false);
        BeginGame();
    }
}