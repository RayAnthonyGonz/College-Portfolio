/*using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Yarn.Unity.Example {
    public class IconDetect : MonoBehaviour {

        public float interactionRadius = 2.0f;
        
        private GameObject GameObject = null;
        
        
        /// Draw the range at which we'll start talking to people.
        void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            //Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1,1,0));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
        }

        void Awake () {

            try {
            this.GameObject = GameObject.Find("Talk Icon Animated");
            }
            catch (NullReferenceException ex) {
                Debug.Log("There are no errors in ba sing se");
            }

        }

        /// Update is called once per frame
        void Update () {

            CheckForNearbyNPC ();
            
        }

        public void CheckForNearbyNPC ()
        {
            var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
            var target = allParticipants.Find (delegate (NPC p) {
                return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });
            if (target != null) {
                // When Player meets talkable NPC, shows talk icon
                
                GameObject.SetActive(true);

            }
            else {

                GameObject.SetActive(false);

            }

            
        }
    }
}*/
