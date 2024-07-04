using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TMP_Text player1PointsOverlay;
    [SerializeField] TMP_Text player2PointsOverlay;
    [SerializeField] TMP_Text player1PointsEnd;
    [SerializeField] TMP_Text player2PointsEnd;
    [SerializeField] TMP_Text victoryText;
    [SerializeField] TMP_Text remainingTimeText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject endscreen;
    [SerializeField] int numberForFullyStackedStation = 4;
    [SerializeField] float gameTime = 240;

    public int Player1Points;
    public int Player2Points;
    float deadline = float.MaxValue;

    public GameManager()
    {
        Instance = this;
    }

    void Start()
    {
        deadline = Time.time + gameTime;
    }

    void Update()
    {
        player1PointsOverlay.text = Player1Points.ToString();
        player2PointsOverlay.text = Player2Points.ToString();
        remainingTimeText.text = Mathf.Round(deadline - Time.time).ToString();
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            Time.timeScale = pauseMenu.activeInHierarchy ? 0f : 1f;
        }
        if (deadline <= Time.time)
        {
            Time.timeScale = 0;
            endscreen.SetActive(true);
            player1PointsEnd.text = Player1Points.ToString();
            player2PointsEnd.text = Player2Points.ToString();
            if (Player1Points == Player2Points)
            {
                victoryText.text = "Its a draw!";
            }
            else
            {
                victoryText.text = (Player1Points > Player2Points ? "Player1" : "Player2") + " wins!";
            }
        }
    }

    public void AddPoints(AsssemblingStation[] stations, ArenaIndex arenaIndex)
    {
        int summedUpPoints = 0;
        foreach (AsssemblingStation station in stations)
        {
            int activeIndicators = station.TestIndicators.Where(a => a.activeInHierarchy).Count();
            int stationPoints = activeIndicators * 10;
            if (activeIndicators == numberForFullyStackedStation)
            {
                stationPoints *= 2;
            }
            summedUpPoints += stationPoints;
            foreach (GameObject indicator in station.TestIndicators)
            {
                indicator.SetActive(false);
            }
        }
        switch (arenaIndex)
        {
            case ArenaIndex.Arena1:
                Player1Points += summedUpPoints;
                break;
            case ArenaIndex.Arena2:
                Player2Points += summedUpPoints;
                break;
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

}

public enum ArenaIndex
{
    Arena1,
    Arena2
}