using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Library.Infrastructure
{

    public class ObjectState
    {
        public double Bounciness { get; private set; }
        public double Mass { get; private set; }
        public double Durability { get; private set; }
        public double MaximumDurability { get; set; }
        public TimeSpan Lifetime { get; set; }
        public bool IsAlive { get; set; }
        public Vulnerability Vulnerability { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="vulnerability"></param>
        /// <param name="lifetime">Default lifetime is infinite</param>
        /// <param name="bounciness">Bounciness</param>
        /// <param name="durability">Default is 100 points</param>
        /// <param name="maximumDurability">Default is 100 points</param>
        /// <param name="mass">Mass</param>
        public ObjectState(Vulnerability vulnerability, TimeSpan lifetime,double mass, double bounciness, double durability = 100f, double maximumDurability = 100f)
        {
            IsAlive = false;
            Vulnerability = vulnerability;
            Durability = durability;
            MaximumDurability = maximumDurability;
            Lifetime = lifetime;
            Mass = mass;
            Bounciness = bounciness;
            if (vulnerability == Vulnerability.Invulnerable || durability > 0)
            {
                IsAlive = true;
            }
        }
        public ObjectState(double durability, TimeSpan lifetime, double mass, double bounciness)
        {
            Durability = durability;
            Lifetime = lifetime;
            MaximumDurability = durability;
            IsAlive = durability > 0;
            Mass = mass;
            Bounciness = bounciness;
        }

        /// <summary>
        /// Initializes by default according to vulnaraility
        /// </summary>
        /// <param name="vulnerability"></param>
        /// <param name="mass"></param>
        /// <param name="bounciness"></param>
        public ObjectState(Vulnerability vulnerability, double mass, double bounciness)
        {

            Mass = mass;
            Bounciness = bounciness;
            if (vulnerability == Vulnerability.Vulnerable)
            {
                GetDefaultValuesForVulnarableObject();
            }
            else
            {
                GetDefaultValuesForUnvulnarableObject();    
            }
            
        }


        private void GetDefaultValuesForVulnarableObject()
        {
            IsAlive = true;
            Durability = 100;
            MaximumDurability = 100;
            Lifetime = TimeSpan.MaxValue;
            Vulnerability = Vulnerability.Vulnerable;
        }


        private void GetDefaultValuesForUnvulnarableObject()
        {
            IsAlive = true;
            Durability = double.PositiveInfinity;
            MaximumDurability = double.PositiveInfinity;
            Lifetime = TimeSpan.MaxValue;
            Vulnerability = Vulnerability.Invulnerable;
        }


        public void Hit(double amount)
        {
            if (Vulnerability == Vulnerability.Invulnerable) return;
            if (amount > 0)
            {
                Durability -= amount;
                IsAlive = Durability > 0;
            }
        }

        public void Heal(double amount)
        {
            if (Vulnerability == Vulnerability.Invulnerable) return;
            if (amount > 0)
            {
                Durability += amount;
                if (Durability > MaximumDurability)
                {
                    Durability = MaximumDurability;
                }
            }
        }
    }
}
