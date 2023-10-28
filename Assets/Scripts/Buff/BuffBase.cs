using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public abstract class BuffBase
    {

        [field: SerializeField]
        [field: TextArea] 
        private string m_name;

        [field: SerializeField]
        [field: TextArea] 
        private string m_description;

        protected BuffBase(string name, string description)
        {
            m_name = name;
            m_description = description;
        }
    }
}
