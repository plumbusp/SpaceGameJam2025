using UnityEngine;

namespace SGJ25.LunarGame.Focusing
{
    public interface IFocusable
    {
        void OnFocusEnter(GameObject observer);
        void OnFocusExit(GameObject observer);
    }
}