using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using DG.Tweening;

namespace Zef.projet
{
    public class GenerateGrid : MonoBehaviour
    {
        public Sprite[] sprites;
        public Card firstCard;

        public List<GameObject> buttonsGameObject;
        void Start()
        {
            //Randomize tiles positions
            ShuffleArray(); // Shuffle the array
            UpdateHierarchy(); // Update the hierarchy based on the shuffled order

        }
        void ShuffleArray()
        {
            int n = buttonsGameObject.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                GameObject temp = buttonsGameObject[k];
                buttonsGameObject[k] = buttonsGameObject[n];
                buttonsGameObject[n] = temp;
                
            }
        }

        void UpdateHierarchy()
        {
            for (int i = 0; i < buttonsGameObject.Count; i++)
            {
                buttonsGameObject[i].transform.SetSiblingIndex(i);
            }
        }
    

        public void OnClickThisButton(Card clickedCard)
        {
            Debug.Log("coucou en premier");
            if (firstCard == null)
            {
                // C'est la première carte cliquée
                firstCard = clickedCard;
                Debug.Log("c'est la première carte cliquée");
                clickedCard.transform.DORotate(new Vector3(0f, 180f, 0f), 0.5f);
                // Bloque la première carte ici (si nécessaire)
            }
            else
            {
                // C'est la deuxième carte cliquée
                // Bloque toutes les cartes pendant que la deuxième carte est traitée (si nécessaire)

                // Compare les deux cartes pour vérifier si elles correspondent
                if (firstCard.id == clickedCard.id)
                {
                    Debug.Log(firstCard.id);
                    // Les cartes correspondent
                    Debug.Log("Les cartes correspondent");
                    // Traite le comportement lorsque les cartes correspondent
                    
                    // Réinitialise la première carte  
                    firstCard = null;
                }
                else
                {
                    // Les cartes ne correspondent pas
                    Debug.Log("Les cartes ne correspondent pas");
                    // Traite le comportement lorsque les cartes ne correspondent pas
                    StartCoroutine(WaitABit(firstCard,clickedCard));
                    
                    // Réinitialise la première carte
                    firstCard = null;
                }
            }
        }

        IEnumerator WaitABit(Card cardOne, Card cardTwo)
        {
            yield return new WaitForSeconds(.3f);
            
            cardOne.transform.DORotate(Vector3.zero, 0.5f);
            cardTwo.transform.DORotate(Vector3.zero, 0.5f);
        }
    }
}    
