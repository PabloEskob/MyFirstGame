using UnityEngine.Events;

public class GlobalEvent
{
    public static UnityEvent CoinAmountChanged = new UnityEvent();

    public static void SendCoin()
    {
        CoinAmountChanged.Invoke();
    }
}