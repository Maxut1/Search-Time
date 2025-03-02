using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class ScriptableModelsLoader : MonoBehaviour
    {
        [SerializeField] protected List<ScriptableObject> _scriptableModelslist;

        public List<ScriptableObject> ScriptableModelsList => _scriptableModelslist;

        private void Start()
        {
            ScriptableModelsList.ForEach(scriptableModel =>
            {
                (scriptableModel as IStorable)?.Load();
            });
        }

        private void OnDisable()
        {
            ScriptableModelsList.ForEach(scriptableModel =>
            {
                (scriptableModel as IStorable)?.Save();
            });
        }
    }
}

