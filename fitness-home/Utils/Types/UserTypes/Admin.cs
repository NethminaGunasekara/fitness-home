﻿namespace fitness_home.Utils.Types.UserTypes
{
    internal class Admin : User
    {
        public int ID { get; }
        public Role Role { get; }

        public Admin(int id)
        {
            ID = id;
            Role = Role.Member;
        }
    }
}