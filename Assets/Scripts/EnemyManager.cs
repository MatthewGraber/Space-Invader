using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        // Total distances basic enemies travel along the x and y planes
        int pathWidth;
        int pathHeight;

        // How far we move along the x and y each time we update
        int xIncrement;
        int yIncrement;

        // Current coordiantes for the group
        int x;
        int y;

        // How often the enemies move
        int period;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}