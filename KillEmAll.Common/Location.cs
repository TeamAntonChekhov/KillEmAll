﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public abstract class Location : GameObject, IExitable
    {
        private HashSet<Location> exits;
        private HashSet<Character> characters;
        private Collection<Item> items;
        private LocationType locationType;


        protected Location(string name, HashSet<Character> characters, Collection<Item> items)
            : base(name)
        {
            this.Exits = new Collection<Location>();
            this.Characters = characters;
            this.Items = items;
        }

        public LocationType LocationType
        {
            get
            {
                return this.locationType;
            }
            protected set
            {
                this.locationType = value;
            }
        }

        public Collection<Item> Items
        {
            get
            {
                return new Collection<Item>(items);
            }
            protected set
            {
                this.items = value;
            }
        }

        public HashSet<Character> Characters
        {
            get
            {
                return new HashSet<Character>(characters);
            }
            protected set
            {
                this.characters = value;
            }
        }

        public IEnumerable<Location> Exits
        {
            get
            {
                return new HashSet<Location>(this.exits);
            }
            protected set
            {
                this.exits = new HashSet<Location>(value);
            }
        }

        internal void RemoveDestroyedCharacters()
        {
            this.characters 
                .RemoveWhere(character => (character is IDestroyable)
                    && (character as IDestroyable).IsDestroyed);
                
        }

        public void AddExit(params Location[] locations)
        {
            foreach (var location in locations)
            {
                this.exits.Add(location);
            }
        }

        public void RemoveExit(params Location[] locations)
        {
            throw new NotImplementedException();
        }
    }
}
