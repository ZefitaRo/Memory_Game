using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace Zef.projet
{
    public class Card : MonoBehaviour
    {
        public int id;

        public Sprite sprite;

        //public bool isLocked = false;
        
        void Start()
        {
            this.GetComponent<Image>().sprite = sprite;
        }

        
    }
}
