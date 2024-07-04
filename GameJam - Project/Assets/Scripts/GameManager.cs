using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instacne { get; private set; }

    [SerializeField] int numberForFullyStackedStation = 4;

    public int Player1Points;
    public int Player2Points;

    public GameManager()
    {
        Instacne = this;
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
            foreach(GameObject indicator in station.TestIndicators)
            {
                indicator.SetActive(false);
            }
        }
        switch (arenaIndex)
        {
            case ArenaIndex.Arena1 :
                Player1Points += summedUpPoints;
                break;
            case ArenaIndex.Arena2 :
                Player2Points += summedUpPoints;
                break;
        }
    }
}

public enum ArenaIndex
{
    Arena1,
    Arena2
}