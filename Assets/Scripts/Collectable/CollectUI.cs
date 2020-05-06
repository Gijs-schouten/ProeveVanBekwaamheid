using UnityEngine;
using UnityEngine.UI;

public class CollectUI : MonoBehaviour
{

    [SerializeField]
    private Text _collected;

    [SerializeField]
    private Player player;

    void Start()
    {
        player.CollectedValueChanged += SetValue;
    }

    public void SetValue(int amount)
    {
        _collected.text = "Collected: " + amount;
    }
}
