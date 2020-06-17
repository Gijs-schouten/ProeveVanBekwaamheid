using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the UI with the amount of collected collectables
/// </summary>
public class CollectUI : MonoBehaviour
{

    [SerializeField]
    private Text _collected;

    [SerializeField]
    private Player _player;

    void Start()
    {
        _player.CollectedValueChanged += SetValue;
    }

    public void SetValue(int amount)
    {
        _collected.text = "" + amount;
    }
}
