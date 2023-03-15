using UnityEngine;

namespace Sample.Environment
{
    public struct Slot
    {
        public Vector3 position;
        public bool isOccupied;
        
        public Slot(Vector3 position, bool isOccupied)
        {
            this.position = position;
            this.isOccupied = isOccupied;
        }
        
        public void Occupy()
        {
            isOccupied = true;
        }
        
        public void Free()
        {
            isOccupied = false;
        }
    }
}