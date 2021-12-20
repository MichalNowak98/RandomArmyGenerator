using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomArmyGenerator.Models
{
    public class UnitListModel
    {
        public UnitListModel()
        {
            Factions = new Dictionary<string, Faction>();
            CreateFaction("Mordor");
            AddUnitToFaction("Mordor", UnitType.warrior, "Morannon Orc", "7", UnitGear.none, "6");
            AddUnitToFaction("Mordor", UnitType.warrior, "Morannon Orc", "8", UnitGear.shield, "6");
            AddUnitToFaction("Mordor", UnitType.heroFortitude, "Gorbag", "50", UnitGear.shield, "1");
            AddUnitToFaction("Mordor", UnitType.heroLegend, "Witch King of Angmar", "150", UnitGear.none, "1");
            AddUnitToFaction("Mordor", UnitType.warrior, "Morannon Orc", "8", UnitGear.spear, "6");
            AddUnitToFaction("Mordor", UnitType.warrior, "Morannon Orc", "9", UnitGear.spearAndShield, "6");
            CreateFaction("Gondor");
            AddUnitToFaction("Gondor", UnitType.warrior, "Minas Tirith Warrior", "11", UnitGear.shield, "12");
        }
        public void CreateFaction(string Name)
        {
            Factions.Add(Name, new Faction(Name));
        }
        public void AddUnitToFaction(string Faction, UnitType Type, string Name, string PointCost, UnitGear Gear, string Quantity)
        {
            Factions[Faction].UnitList.Add(new Unit(Type, Name, PointCost, Gear, Quantity));
            Factions[Faction].UnitList.Sort((x, y) => x.TypeE.CompareTo(y.TypeE));
        }
        public Dictionary<string, Faction> Factions { get; set; }
    }

    public struct Faction
    {
        public Faction(string Name)
        {
            UnitList = new List<Unit>();
            this.Name = Name;
            this.UnitList = UnitList;
        }
        public Faction(string Name, List<Unit> UnitList)
        {
            this.Name = Name;
            this.UnitList = UnitList;
        }
        public string Name { get; set; }
        public List<Unit> UnitList { get; set; }
    }

    public struct Unit
    {
        public Unit(UnitType Type, string Name, string PointCost, UnitGear Gear, string Quantity)
        {
            this.Name=Name;
            this.PointCost = PointCost;
            this.Quantity = Quantity;
            this.TypeE = Type;
            this.Gear = "";
            switch (Gear)
            {
                case UnitGear.none:
                    this.Gear = "-";
                    break;
                case UnitGear.shield:
                    this.Gear = "Shield";
                    break;
                case UnitGear.spear:
                    this.Gear = "Spear";
                    break;
                case UnitGear.spearAndShield:
                    this.Gear = "Shield and Spear";
                    break;
                case UnitGear.bow:
                    this.Gear = "Bow";
                    break;
                case UnitGear.banner:
                    this.Gear = "Banner";
                    break;
                case UnitGear.drums:
                    this.Gear = "Drums";
                    break;
                case UnitGear.horn:
                    this.Gear = "Horn";
                    break;
            }
        }
        public string Name { get; set; }
        public string PointCost { get; set; }
        public string Gear { get; set; }
        public string Quantity { get; set; }
        public UnitType TypeE { get; set; }
        public string Type
        {
            get
            {
                string unitType = "";
                switch (TypeE)
                {
                    case UnitType.heroLegend:
                        unitType = "Hero of Legend";
                        break;
                    case UnitType.heroValour:
                        unitType = "Hero of Valour";
                        break;
                    case UnitType.heroFortitude:
                        unitType = "Hero of Fortitude";
                        break;
                    case UnitType.heroMinor:
                        unitType = "Minor Hero";
                        break;
                    case UnitType.heroIndependent:
                        unitType = "Indepentent Hero";
                        break;
                    case UnitType.warrior:
                        unitType = "Warrior";
                        break;
                }
                return unitType;
            }
        }
    }

    public enum UnitType
    {
        heroLegend,
        heroValour,
        heroFortitude,
        heroMinor,
        heroIndependent,
        warrior,
    }

    public enum UnitGear
    {
        none,
        shield,
        spear,
        spearAndShield,
        bow,
        banner,
        drums,
        horn
    }
}
