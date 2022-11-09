using UnityEngine;

public class loadingAction2 : MonoBehaviour
{
    
    // 点滅させる対象
    [SerializeField] private Behaviour _target;

    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;

    // 明滅のデューティ比(1で完全にON、0で完全にOFF)
    [SerializeField, Range(0, 1)] private float _dutyRate = 0.5f;

    private float _time;

    private void Update()
    {
        // 内部時刻を経過させる
        _time += Time.deltaTime;

        // 周期cycleで繰り返す値の取得
        // 0～cycleの範囲の値が得られる
        var repeatValue = Mathf.Repeat(_time, _cycle);

        // 内部時刻timeにおける明滅状態を反映
        // デューティ比でON/OFFの割合を変更している
        _target.enabled = repeatValue >= _cycle * (1 - _dutyRate);
    }
}