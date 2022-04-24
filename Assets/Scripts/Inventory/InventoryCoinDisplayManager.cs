using UnityEngine;
using TMPro;
public class InventoryCoinDisplayManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinCount;
    [SerializeField]
    IntVariable playerCoinCount;
    private void Update()
    {
        coinCount.text = playerCoinCount.Value.ToString();
    }
}
