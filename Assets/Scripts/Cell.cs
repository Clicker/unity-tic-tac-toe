﻿using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        public GameObject spriteCross;
        public GameObject spriteNought;

        private event Action<Cell> onCellClick;

        public int Row { get; private set; }

        public int Col { get; private set; }

        public Seed Content { get; private set; }

        public bool IsEmpty { get { return Content == Seed.Empty; } }

        public void Init(int row, int col, Action<Cell> onCellClickAction)
        {
            Row = row;
            Col = col;

            name = string.Format("Cell [{0}, {1}]", row, col);

            onCellClick = onCellClickAction;

            Clear();
        }

        public void Set(Seed seed)
        {
            Content = seed;

            switch (seed)
            {
                case Seed.Empty:
                    spriteCross.SetActive(false);
                    spriteNought.SetActive(false);
                    break;
                case Seed.Cross:
                    spriteCross.SetActive(true);
                    spriteNought.SetActive(false);
                    break;
                case Seed.Nought:
                    spriteCross.SetActive(false);
                    spriteNought.SetActive(true);
                    break;
            }
        }

        public void Clear()
        {
            Set(Seed.Empty);
        }

        public bool HasSeed(Seed seed)
        {
            return Content == seed;
        }
        
        private void OnMouseDown()
        {
            if (onCellClick != null)
            {
                onCellClick(this);
            }
        }
    }
}