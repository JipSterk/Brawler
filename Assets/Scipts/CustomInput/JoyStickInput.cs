using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.CustomInput
{
    public class JoyStickInput : MonoBehaviour
    {
        //[SerializeField] private float _maxTimeBetweenInput;
        //[SerializeField] private Text _outputText;

        //private char[][] _allChars =
        //{
        //    new [] {'(', ')', '^',':', ';'},
        //    new [] {'a', 'b', 'c', 'A', 'B', 'C'},
        //    new [] {'d', 'e', 'f', 'D', 'E', 'F'},
        //    new [] {'g', 'h', 'i', 'G', 'H', 'I'},
        //    new [] {'j', 'k', 'l', 'J', 'K', 'L'},
        //    new [] {'m', 'n', 'o', 'M', 'N', 'O'},
        //    new [] {'p', 'q', 'r', 's', 'P', 'Q', 'R', 'S'},
        //    new [] {'t', 'u', 'v', 'T', 'U', 'V'},
        //    new [] {'w', 'x', 'y', 'z', 'W', 'X', 'Y', 'Z'},
        //    new [] {'!', '?', '&'},
        //    new [] {'-', ',', '.','/', '~'}
        //};

        //private float _currentTime;
        //private float _nextTime;
        //private string _profileName;

        //public void EnterChar(int arrayIndex, int index)
        //{
        //    _nextTime = _currentTime + _maxTimeBetweenInput;
        //    StartCoroutine(Input(arrayIndex, index));
        //}

        //private IEnumerator Input(int x, int y)
        //{
        //    while (_currentTime > _nextTime)
        //    {
        //        yield return null;
        //        _currentTime += Time.time;
        //        _profileName += _allChars[x][y];
        //        y = 0;
        //    }

        //    y++;
        //}
    }
}
