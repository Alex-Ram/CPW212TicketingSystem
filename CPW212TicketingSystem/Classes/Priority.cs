﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPW212TicketingSystem
{
    public class Priority
    {
        [Key]
        public int? PriorityID { get; set; }

        /// <summary>
        /// A number representing the hierarchical order of priority.
        /// </summary>
        [Required]
        [Index(IsUnique = true)] // TODO: Add migration to make PriorityLevel unique in the database. Also, change name to Level for consistency.
        public byte PriorityLevel { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public Priority(Priority p)
        : this(p.PriorityID, p.PriorityLevel, p.Name) {}

        /// <summary>
        /// This contructor should be used when creating a priority that's not in the database yet.
        /// It sets the PriorityID to null.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="name"></param>
        public Priority(byte level, string name)
        : this(null, level, name) {}

        public Priority(int? id, byte level, string name)
        {
            PriorityID = id;
            PriorityLevel = level;
            Name = name;
        }

        /// <summary>
        /// Returns a string value that represents the priority.
        /// </summary>
        /// <returns>The name of the priority</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Allows sorting of a collection of priority objects.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Priority other)
        {
            return PriorityLevel.CompareTo(other.PriorityLevel);
        }
    }
}
