using UnityEngine;
using TMPro;

public class PlayerNameDisplayManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private BeyBladeData beyBladeData;
    void Start()
    {
        text.text = beyBladeData.PlayerName;
    }
}
