using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieInvasion
{
    public abstract class Entity
    {
        public double x, y;
        public double health;
        public double maxSpeed;
        public double xSpeed, ySpeed;

        public abstract bool Attack(Entity target);
        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }
        public double Distance(double x2, double y2)
        {
            return ((x2 - x) * (x2 - x)) + ((y2 - y) * (y2 - y));
        }
    }

    public class Player : Entity
    {
        public int viewRange = 20;
        private int ammoCount;
        double money;
        
        public Player(double _x, double _y, double _health, double _maxSpeed, double _money, int _ammoCount)
        {
            x = _x;
            y= _y;
            health= _health;
            maxSpeed= _maxSpeed;
            money= _money;
            ammoCount = _ammoCount;
            
        }
        public override bool Attack(Entity target)
        {
            throw new NotImplementedException();
        }
    }
}
