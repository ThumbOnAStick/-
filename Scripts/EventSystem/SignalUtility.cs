//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public static class SignalUtility
//{
//    //signals emitted in current frame
//    public static List<string> emitted_signals = new();

//    public static void EmitSignal(string signal)
//    {
//        if (!emitted_signals.Contains(signal))
//        {
//            emitted_signals.Add(signal);
//        }
//    }

//    public static bool CapcturedSignal(string target)
//    {
//        if (emitted_signals.Contains(target))
//        {
//            //Debug.Log("Recieved " + target);
//            KillSignal(target);
//            return true;
//        }
//        return false;
//    }

//    public static void KillSignal(string target)
//    {
//        emitted_signals.Remove(target);
//    }

//    public static void KillAllSignals()
//    {
//        emitted_signals = new();
//    }
//}
