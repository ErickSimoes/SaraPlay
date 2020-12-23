using System;
using UnityEngine;

public static class JsonHelper {

    public static void Shuffle<T>(T[] list) {
        int rdm;
        for (int i = 0; i < list.Length; i++) {
            rdm = UnityEngine.Random.Range(0, list.Length - 1);
            T temp = list[rdm];
            list[rdm] = list[i];
            list[i] = temp;
        }
    }

    public static T[] FromJson<T>(string json) {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array, bool prettyPrint = false) {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T> {
        public T[] Items;
    }
}
