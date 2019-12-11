using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdda_item_creator
{
    class BurnDataChunk
    {
        public bool Immune { get; set; }
        // volume string, like "10 ml"
        public string VolumePerTurn { get; set; }
        public float Fuel { get; set; }
        public float Smoke { get; set; }
        public float Burn { get; set; }
    }
    class MaterialType
    {
        // mandatory
        public string Ident { get; set; } = "";
        // mandatory
        public string Name { get; set; } = "";
        public int BashResist { get; set; }
        public int CutResist { get; set; }
        public int AcidResist { get; set; }
        public int ElecResist { get; set; }
        public int FireResist { get; set; }
        public int ChipResist { get; set; }
        public int Density { get; set; }
        public float SpecificHeatLiquid { get; set; }
        public float SpecificHeatSolid { get; set; }
        public float LatentHeat { get; set; }
        public int FreezePoint { get; set; }
        public string SalvagedInto { get; set; }
        [DefaultValue("null")]
        public string RepairedInto { get; set; } = "null";
        [DefaultValue(false)]
        public bool Edible { get; set; } = false;
        [DefaultValue(false)]
        public bool Rotting { get; set; } = false;
        [DefaultValue(false)]
        public bool Soft { get; set; } = false;
        [DefaultValue(false)]
        public bool Reinforces { get; set; } = false;
        // dictionary-as-array
        [JsonConverter(typeof(DictionaryAsArrayConverter<double>))]
        public Dictionary<string, double> Vitamins { get; set; }
        // mandatory
        public string BashDmgVerb { get; set; } = "";
        // mandatory
        public string CutDmgVerb { get; set; } = "";
        // mandatory
        public List<string> DmgAdj { get; set; } = new List<string> { };
        public List<BurnDataChunk> BurnData { get; set; }
        // dictionary-as-array
        [JsonConverter(typeof(DictionaryAsArrayConverter<float>))]
        public Dictionary<string, float> BurnProducts { get; set; }
        public List<string> CompactAccepts { get; set; }
        public List<string> CompactsInto { get; set; }
    }
}
