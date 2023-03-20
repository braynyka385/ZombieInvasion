using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieInvasion
{
    public class Map
    {
        int mapSize;
        public int tileSizeOnScreen;
        Tile[,] tiles;

        public Map(int _mapSize, int tSOS)
        {
            this.mapSize = _mapSize;
            tiles = new Tile[mapSize, mapSize];
            tileSizeOnScreen = tSOS;
        }
    }

    class Tile
    {
        public bool hasBuilding;
        Building building;
        public int x, y;
        public Tile(int _x, int _y)
        {
            x = _x;
            y = _y;
            hasBuilding = false;
        }

        public bool BuildOnTile(BuildingType type, int playerMoney)
        {
            if (playerMoney >= (int)type && !hasBuilding)
            {
                hasBuilding = true;
                building = new Building();
                return true;
            }

            return false;
        }
    }

    class Building
    {
        BuildingType buildingType;
    }
    public enum BuildingType : int
    {   //Type, cost
        Turret = 100,
        Wall = 25
    }
}
