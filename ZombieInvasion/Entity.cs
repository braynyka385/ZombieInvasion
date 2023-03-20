using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieInvasion
{
    public abstract class Entity
    {
        protected double x, y;
        protected double health;
        protected double maxSpeed;
        protected double xSpeed, ySpeed;

        public abstract bool Attack(Entity target);
    }

    public class Player : Entity
    {
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
