
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
    public static void AddEventLisntener<T> (this Button button, T param, Action<T> Onclick)
    {
        button.onClick.AddListener(delegate ()
        {
            Onclick(param);
        });
    }
}
