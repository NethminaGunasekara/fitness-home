﻿using System;

namespace fitness_home.Utils.Types.UserTypes
{
    /// <summary>
    /// Abstract base class for user types <see cref="Admin"/>, <see cref="Trainer"/>, and <see cref="Member"/>.
    /// </summary>
    abstract class User
    {
        // Member properties
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string NIC { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        public virtual string EmergencyContactName { get; set; }
        public virtual string EmergencyContactPhone { get; set; }
        public virtual int PlanID { get; set; }
        public virtual DateTime PlanExpiry { get; set; }
    }
}