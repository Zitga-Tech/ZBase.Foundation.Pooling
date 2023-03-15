using System;
using UnityEngine;
using ZBase.Collections.Pooled.Generic;

namespace Sample.Environment
{
    public class Grid
    {
        private List<Slot> _slots = new List<Slot>();

        public Grid(int width, int height)
        {
            for (int x = -width; x < width; x++)
            {
                for (int y = -height; y < height; y++)
                {
                    _slots.Add(new Slot(new Vector3(x, 0, y), false));
                }
            }
        }

        public Grid(int width, int height, bool odd)
        {
            for (int x = -width; x < width; x++)
            {
                if (odd)
                {
                    if (x % 2 == 0)
                        continue;
                }
                else
                {
                    if (x % 2 != 0)
                        continue;
                }

                for (int y = -height; y < height; y++)
                {
                    if (odd)
                    {
                        if (y % 2 == 0)
                            continue;
                    }
                    else
                    {
                        if (y % 2 != 0)
                            continue;
                    }

                    _slots.Add(new Slot(new Vector3(x, 0, y), false));
                }
            }
        }
        
        public Slot GetAvailableSlot()
        {
            for (int i = 0; i < this._slots.Count; i++)
            {
                if (!this._slots[i].isOccupied)
                {
                    var newSlot = this._slots[i];
                    newSlot.isOccupied = true;
                    this._slots[i] = newSlot;
                    return this._slots[i];
                }
            }
            
            throw new Exception("No available slot");
        }

        public Slot FreeSlot(Vector3 position)
        {
            foreach (var slot in this._slots)
            {
                if (slot.position == position)
                {
                    var newSlot = slot;
                    newSlot.isOccupied = false;
                    this._slots[this._slots.IndexOf(slot)] = newSlot;
                    return slot;
                }
            }

            throw new Exception("No available slot");
        }
    }
}