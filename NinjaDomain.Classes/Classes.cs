using NinjaDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace NinjaDomain.Classes
{
    public class NinjaTools
    {
        static public Action<string> print = message => Debug.WriteLine(message);

    }


    public class Ninja : IModificationHostory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServerInOniwaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public List<NinjaEquipment> EquipmentOwned { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public DateTime DataModified { get; set; }
        public DateTime DataCreated { get; set; }
        public bool IsDirty  { get; set; }
        }

    public class Clan : IModificationHostory
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }
        public DateTime DataModified { get; set; }
        public DateTime DataCreated { get; set; }
        public bool IsDirty { get; set; }
    }

    public class NinjaEquipment : IModificationHostory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        [Required]
        public Ninja Ninja { get; set; }
        public DateTime DataModified { get; set; }
        public DateTime DataCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
