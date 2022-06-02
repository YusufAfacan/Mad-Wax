using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberOfRounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNumberOfRounds(int roundNumber)
    {
        numberOfRounds = roundNumber;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
