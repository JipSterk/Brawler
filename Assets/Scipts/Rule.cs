using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class Rule : MonoBehaviour
    {
        [SerializeField] private Button _previousOptionButton;
        [SerializeField] private Button _nextOptionButton;
        [SerializeField] private Text _optionText;
        [SerializeField] private Text _ruleText;

        public void Init<T>(T t)
        {
            
        }
    }
}