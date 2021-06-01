using UnityEngine;
using UnityEngine.UI;

public class UIinteraction : MonoBehaviour
{
    [SerializeField] public Text m_txtDebug;

    public void DebugText(GameObject _go)
    {
        m_txtDebug.text = _go.name;
    }
}
