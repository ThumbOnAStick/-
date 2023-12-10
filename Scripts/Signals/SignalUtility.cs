using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SignalUtility
{
    //signals emitted in current frame
    public static List<string> emitted_signals;

    public static bool CapcturedSignal(string target)
    {
        if (emitted_signals.Contains(target)) return true;
        return false;
    }
}
