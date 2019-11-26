using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Map
    {
        public int Width;
        public int Height;
        public int TileWidth;
        public int TileHeight;
        public List<Tile> Tiles;

        public Map(int width, int height, int tileWidth, int tileHeight)
        {
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Tiles = new List<Tile>();
        }
    }
}
