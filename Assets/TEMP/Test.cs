using Brawler.GameSettings;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            GameManager.Instance.UpdateMenuState(MenuState.LevelSelection);
    }
}