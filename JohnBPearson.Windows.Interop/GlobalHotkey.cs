using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using JohnBPearson.Windows.Interop;

public class BoundKeyActionEventArgs : EventArgs
{
    public string Key { get; set; }
    public string Value { get; set; }
    public BoundKeyActionEventArgs()
    {


    }
}



public class GlobalHotKey : IDisposable
{


 

    public static bool RegisterHotKey(string aKeyGestureString, JohnBPearson.Application.Gestures.Model.IGestureObject data, KeyBindCallBack callBack)
    {

        var c = new KeyGestureConverter();
        KeyGesture aKeyGesture = (KeyGesture)c.ConvertFrom(aKeyGestureString);
        if (callBack == null)
        {
            System.Diagnostics.Debugger.Break();
        }
        return GlobalHotKey.RegisterHotKey(aKeyGesture.Modifiers, aKeyGesture.Key, data, callBack);
    }
    private static bool RegisterHotKey(ModifierKeys modifier, System.Windows.Input.Key key, JohnBPearson.Application.Gestures.Model.IGestureObject data, KeyBindCallBack callBack)
    {
        if (modifier == ModifierKeys.None)
        {
            throw new ArgumentException("Modifier must not be ModifierKeys.None");
        }
      
            //if (action is null)
            //{
            //    throw new ArgumentException("Action or delegate must be provided.");
            //}

            //System.Windows.Forms.Keys aVirtualKeyCode = (System.Windows.Forms.Keys)KeyInterop.VirtualKeyFromKey(key);
            //currentID = currentID + 1;
            //bool aRegistered = InteropFacade.RegisterHotKey(window.Handle, currentID,
            //                            (uint)modifier | MOD_NOREPEAT,
            //                            (uint)aVirtualKeyCode);

            //if (aRegistered && action != null)
            //{
            //    ReplaceAdd(modifier, key, data, action);
            //}
            //return aRegistered;
        //}
        //else
        //{

            if (callBack is null)
            {
                throw new ArgumentNullException(nameof(callBack));
            }

            System.Windows.Forms.Keys aVirtualKeyCode = (System.Windows.Forms.Keys)KeyInterop.VirtualKeyFromKey(key);
            currentID = currentID + 1;
            bool aRegistered = InteropFacade.RegisterHotKey(window.Handle, currentID,
                                        (uint)modifier | MOD_NOREPEAT,
                                        (uint)aVirtualKeyCode);

            if (aRegistered)
            {
                ReplaceAdd(modifier, key, data, callBack);
            }
            return aRegistered;
        
    }

    private static void ReplaceAdd(ModifierKeys modifier, System.Windows.Input.Key key, JohnBPearson.Application.Gestures.Model.IGestureObject data,  KeyBindCallBack callBack)
    {
        if (registeredHotKeys.ContainsKey(data.Key.Value))
        {
            registeredHotKeys.Remove(data.Key.Value);
        }
        registeredHotKeys.Add(data.Key.Value, new HotKeyWithAction(modifier, key, data, null,callBack));
    }

    public static void removeAllRegistration()
    {
        // unregister all the registered hot keys.
        for (int i = currentID; i > 0; i--)
        {
            InteropFacade.UnregisterHotKey(window.Handle, i);
        }
    }

    public void Dispose()
    {
        // unregister all the registered hot keys.
        removeAllRegistration();
        // dispose the inner native window.
        window.Dispose();
    }

    static GlobalHotKey()
    {
        //BoundKeyAction = new EventHandler<BoundKeyActionEventArgs>()
        window.KeyPressed += (s, e) =>
        {
            if (registeredHotKeys.ContainsKey(e.Key.ToString()))
            {
                HotKeyWithAction item;
                registeredHotKeys.TryGetValue(e.Key.ToString().ToLower(), out item);
                if (item != null && item.Modifier == e.Modifier)
                {
                   if(item.Action != null)
                    {
                        item.Action();
                    } else if(item.CallBack != null)
                    {
                        item.CallBack.Invoke(item.Data);
                    }
                }

            }
            registeredHotKeys.Values.ToList().ForEach(x =>
            {
                if (e.Modifier == x.Modifier && e.Key == x.Key)
                {
                    if (x.Action != null)
                    {
                        x.Action();

                    }
                    else if (x.CallBack != null)
                    {
                        x.CallBack.Invoke(x.Data);
                    }

                }
            });
        };
    }

    private static readonly InvisibleWindowForMessages window = new InvisibleWindowForMessages();
    private static int currentID;
    private static uint MOD_NOREPEAT = 0x4000;
    private static Dictionary<string, HotKeyWithAction> registeredHotKeys = new Dictionary<string, HotKeyWithAction>();


    private class HotKeyWithAction
    {

        public HotKeyWithAction(ModifierKeys modifier, System.Windows.Input.Key key, JohnBPearson.Application.Gestures.Model.IGestureObject data, Action action = null, KeyBindCallBack callBack = null)
        {
            Modifier = modifier;
            Key = key;
            if (action != null)
            {
                Action = action;
            }
            if (callBack != null)
            {
                CallBack = callBack;
            }
            Data = data;
        }

        public ModifierKeys Modifier { get; }
        public System.Windows.Input.Key Key { get; }
        public JohnBPearson.Application.Gestures.Model.IGestureObject Data { get; }
        public Action Action { get; }
        public KeyBindCallBack CallBack { get; }

    }
    /// <summary>
    /// Action parameter is deprecated
    /// </summary>
    /// 

    //private class HotKeyWithAction    {

    //    public HotKeyWithAction(ModifierKeys modifier, InputKey key, string data, Action action = null, KeyBindCallBack callBack = null)
    //    {
    //        Modifier = modifier;
    //        InputKey = key;
    //        if (action != null)
    //        {
    //            Action = action;
    //        }
    //        if(callBack != null)
    //        {
    //            CallBack = callBack;
    //        }
    //        Data = data;
    //    }

    //    public ModifierKeys Modifier { get; }
    //    public InputKey InputKey { get; }
    //    public IKeyBoundData Data { get;  } 
    //    public Action Action { get; }
    //    public KeyBindCallBack CallBack { get; }

    //}      

    private class InvisibleWindowForMessages : System.Windows.Forms.NativeWindow, IDisposable
    {
        public InvisibleWindowForMessages()
        {
            CreateHandle(new System.Windows.Forms.CreateParams());
        }

        private static int WM_HOTKEY = 0x0312;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                var aWPFKey = KeyInterop.KeyFromVirtualKey(((int)m.LParam >> 16) & 0xFFFF);
                ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);
                if (KeyPressed != null)
                {
                    KeyPressed(this, new HotKeyPressedEventArgs(modifier, aWPFKey));
                }
            }
        }

        public class HotKeyPressedEventArgs : EventArgs
        {
            private ModifierKeys _modifier;
            private System.Windows.Input.Key _key;

            internal HotKeyPressedEventArgs(ModifierKeys modifier, System.Windows.Input.Key key)
            {
                _modifier = modifier;
                _key = key;
            }

            public ModifierKeys Modifier
            {
                get { return _modifier; }
            }

            public System.Windows.Input.Key Key
            {
                get { return _key; }
            }
        }


        public event EventHandler<HotKeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            this.DestroyHandle();
        }

        #endregion
    }
}


