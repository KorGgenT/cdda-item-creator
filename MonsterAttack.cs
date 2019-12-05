using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdda_item_creator
{
    public class MonsterAttack
    {
        public string AttackType { get; set; }
        public string Type { set;  get; } = "hardcoded";
        [DefaultValue("")]
        public string Id { get; set; } = "";
        public int Cooldown { get; set; }
    }
    public class MonEffectData
    {
        public string Id { get; set; }
        public int Duration { get; set; }
        [DefaultValue(false)]
        public bool AffectHitBp { get; set; }
        [DefaultValue("NUM_BP")]
        public string BodyPart { get; set; }
        [DefaultValue(false)]
        public bool Permanent { get; set; }
        [DefaultValue(100)]
        public int Chance { get; set; }
        public MonEffectData()
        {
            Id = "";
            Duration = 0;
            AffectHitBp = false;
            BodyPart = "NUM_BP";
            Permanent = false;
            Chance = 100;
        }
    }
    public class MonsterAttackLeap : MonsterAttack
    {
        public float MaxRange { get; set; }
        [DefaultValue(1.0f)]
        public float MinRange { get; set; }
        [DefaultValue(false)]
        public bool AllowNoTarget { get; set; }
        [DefaultValue(150)]
        public int MoveCost { get; set; }
        public float MinConsiderRange { get; set; }
        [DefaultValue(200.0f)]
        public float MaxConsiderRange { get; set; }
        public MonsterAttackLeap()
        {
            Type = "leap";
            MaxRange = 0.0f;
            MinRange = 1.0f;
            AllowNoTarget = false;
            MoveCost = 150;
            MinConsiderRange = 0.0f;
            MaxConsiderRange = 200.0f;
        }
    }
    public class MonsterAttackSpell : MonsterAttack
    {
        // mandatory member
        public string SpellId { get; set; }
        [DefaultValue(false)]
        public bool Self { get; set; }
        public int SpellLevel { get; set; }
        [DefaultValue("%1$s casts %2$s at %3$s!")]
        public string MonsterMessage { get; set; }
        public MonsterAttackSpell()
        {
            Type = "spell";
            SpellId = "";
            Self = false;
            SpellLevel = 0;
            MonsterMessage = "%1$s casts %2$s at %3$s!";
        }
    }
    public class MonsterAttackMelee : MonsterAttack
    {
        [JsonConverter(typeof(DamageInstanceConverter<DamageInstance>))]
        public DamageInstance DamageMaxInstance { get; set; }
        public float MinMul { get; set; }
        public float MaxMul { get; set; }
        public int MoveCost { get; set; }
        [DefaultValue(-2147483648)]
        public int Accuracy { get; set; }
        [DefaultValue("The %s lunges at you, but you dodge!")]
        public string MissMsgU { get; set; }
        [DefaultValue("The %1$s bites your %2$s, but fails to penetrate armor!")]
        public string NoDmgMsgU { get; set; }
        [DefaultValue("The %1$s bites your %2$s!")]
        public string HitDmgU { get; set; }
        [DefaultValue("The %s lunges at <npcname>, but they dodge!")]
        public string MissMsgNpc { get; set; }
        [DefaultValue("The %1$s bites <npcname>'s %2$s!")]
        public string NoDmgMsgNpc { get; set; }
        [DefaultValue("The %1$s bites <npcname>'s %2$s!")]
        public string HitDmgNpc { get; set; }
        [JsonConverter(typeof(IdValueArrayConverter))]
        public List<IdValueArray> BodyParts { get; set; }
        List<MonEffectData> Effects { get; set; }
        public MonsterAttackMelee()
        {
            Type = "melee";
            MinMul = 0.0f;
            MaxMul = 1.0f;
            MoveCost = 100;
            Accuracy = -2147483648;
            MissMsgU = "The %s lunges at you, but you dodge!";
            NoDmgMsgU = "The %1$s bites your %2$s, but fails to penetrate armor!";
            HitDmgU = "The %1$s bites your %2$s!";
            MissMsgNpc = "The %s lunges at <npcname>, but they dodge!";
            NoDmgMsgNpc = "The %1$s bites <npcname>'s %2$s!";
            HitDmgNpc = "The %1$s bites <npcname>'s %2$s!";
        }
    }
    public class MonsterAttackBite : MonsterAttackMelee
    {
        [DefaultValue(14)]
        public int NoInfectionChance { get; set; } = 14;
        MonsterAttackBite()
        {
            Type = "bite";
        }
    }
    public class IdValueArray
    {
        public string Id { get; set; }
        public int Value { get; set; }
    }
    public class GunRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string Type { get; set; }
    }
    public class MonsterAttackGun : MonsterAttack
    {
        public string GunType { get; set; }
        public string AmmoType { get; set; }
        [JsonConverter(typeof(IdValueArrayConverter))]
        public List<IdValueArray> FakeSkills { get; set; }
        public int FakeDex { get; set; }
        public int FakeInt { get; set; }
        public int FakeStr { get; set; }
        public int FakePer { get; set; }
        [JsonConverter(typeof(MAttackGunRangeConverter))]
        public List<GunRange> Ranges { get; set; }
        public int MaxAmmo { get; set; }
        public int MoveCost { get; set; }
        public string Description { get; set; }
        public string FailureMsg { get; set; }
        [DefaultValue("Click.")]
        public string NoAmmoSound { get; set; }
        public int TargetingCost { get; set; }
        public bool RequireTargetingPlayer { get; set; }
        public bool RequireTargetingNpc { get; set; }
        public bool RequireTargetingMonster { get; set; }
        public int TargetingTimeout { get; set; }
        [DefaultValue("Beep.")]
        public string TargetingSound { get; set; }
        public int TargetingVolume { get; set; }
        public bool LaserLock { get; set; }
        public bool RequireSunlight { get; set; }
        public MonsterAttackGun()
        {
            Type = "gun";
            NoAmmoSound = "Click.";
            TargetingSound = "Beep.";
        }
    }
}
