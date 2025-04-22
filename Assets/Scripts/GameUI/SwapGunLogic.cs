using UnityEngine;
using TMPro;

namespace GameUI
{
    public class SwapGunLogic : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textOfButton;

        private int _currentState = 0;

        public int CurrentState => _currentState;

        private void Start()
        {
            _textOfButton.text = "Переключить на тип " + (_currentState + 1);
        }

        public void ChangeCurrentState()
        {
            if (_currentState == 1) _currentState = -1;
            ++_currentState;

            _textOfButton.text = "Переключить на тип " + (_currentState + 1);
        }
    }
}