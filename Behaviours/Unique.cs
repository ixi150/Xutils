using UnityEngine;
using System.Collections.Generic;

namespace IXI
{
    public class Unique : MonoBehaviour
    {
        [SerializeField] string id;

        static Dictionary<string, Unique> dictionary = new Dictionary<string, Unique>();

        public static Unique Get(string tag)
        {
            return dictionary.TryGetValue(tag, out var u) ? u : null;
        }

        void Awake()
        {
            if (dictionary.ContainsKey(id))
            {
                Destroy(gameObject);
            }
            else
            {
                dictionary.Add(id, this);
            }
        }
    }
}