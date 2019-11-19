using System.Collections.Generic;

namespace cdda_item_creator
{
    namespace spell
    {
        static class allowed_strings
        {
            // flag, description
            public static Dictionary<string, string> spell_flags = new Dictionary<string, string> 
            {
                { "PERMANENT", "items or creatures spawned with this spell do not disappear and die as normal" },
                { "IGNORE_WALLS", "spell's aoe goes through walls" },
                { "HOSTILE_SUMMON", "summon spell always spawns a hostile monster" },
                { "HOSTILE_50", "summoned monster spawns friendly 50% of the time" },
                { "SILENT", "spell makes no noise at target" },
                { "LOUD", "spell makes extra noise at target" },
                { "VERBAL", "spell makes noise at caster location, mouth encumbrance affects fail %" },
                { "SOMATIC", "arm encumbrance affects fail % and casting time (slightly)" },
                { "NO_HANDS", "hands do not affect spell energy cost" },
                { "UNSAFE_TELEPORT", "teleport spell risks killing the caster or others" },
                { "NO_LEGS", "focus affects spell fail %" },
                { "CONCENTRATE", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_AOE", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_DAMAGE", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_DURATION", "picks random number between min+increment*level and max instead of normal behavior" },
                { "RANDOM_TARGET", "picks a random valid target within your range instead of normal behavior" },
                { "MUTATE_TRAIT", "overrides the mutate spell_effect to use a specific trait_id instead of a category" },
                { "WONDER", "instead of casting each of the extra_spells, it picks N of them and casts them (where N is std::min( damage(), number_of_spells ))" }
            };
            public static string[] energy_types = 
            {
                "NONE",
                "HP",
                "MANA",
                "STAMINA",
                "BIONIC",
                "FATGIUE"
            };
            public static HashSet<string> valid_targets = new HashSet<string>
            {
                "ally",
                "hostile",
                "self",
                "ground",
                "none",
                "item",
                "fd_fire",
                "fd_blood"
            };
            public static HashSet<string> damage_types = new HashSet<string>
            {
                "fire",
                "acid",
                "bash",
                "bio",
                "cold",
                "cut",
                "electric",
                "stab",
                "none"
            };
            // available options for recover_energy effect
            public static HashSet<string> recover_energy = new HashSet<string>
            {
                "MANA",
                "STAMINA",
                "FATIGUE",
                "PAIN",
                "BIONIC"
            };
            // available options for timed_event effect
            public static HashSet<string> timed_event = new HashSet<string>
            {
                "help",
                "wanted",
                "robot_attack",
                "spawn_wyrms",
                "amigara",
                "roots_die",
                "temple_open",
                "temple_flood",
                "temple_spawn",
                "dim",
                "artifact_light"
            };
            // effect, description
            public static Dictionary<string, string> effects = new Dictionary<string, string>
            {
                { "pain_split", "makes all of your limbs' damage even out" },
                { "target_attack", "deals damage to a target (ignores walls). If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts. Any aoe will manifest as a circular area centered on the target, and will only deal damage to valid_targets. (aoe does not ignore walls)" },
                { "projectile_attack", "similar to target_attack, except the projectile you shoot will stop short at impassable terrain. If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts." },
                { "cone_attack", "fires a cone toward the target up to your range. The arc of the cone in degrees is aoe. Stops at walls. If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts." },
                { "line_attack", "fires a line with width aoe toward the target, being blocked by walls on the way. If effect_str is included, it will add that effect (defined elsewhere in json) to the targets if able, to the body parts defined in effected_body_parts." },
                { "spawn_item", "spawns an item that disappear at the end of its duration. default duration is 0." },
                { "teleport_random", "teleports the player randomly range spaces with aoe variation" },
                { "recover_energy", "recovers an energy source (defined in the effect_str) equal to damage of the spell" },
                { "ter_transform", "transform the terrain and furniture in an area centered at the target. The chance of any one of the points in the area of effect changing is one_in( damage ). The effect_str is the id of a ter_furn_transform." },
                { "vomit", "any creature within its area of effect will instantly vomit, if it's able to do so." },
                { "timed_event", "adds a timed event to the player only. NOTE: This was added only for artifact active effects. support is limited, use at your own risk" },
                { "explosion", "an explosion is centered on the target, with power damage() and factor aoe()/10" },
                { "flashbang", "a flashbang effect is centered on the target, with poewr damage() and factor aoe()/10" },
                { "mod_moves", "adds damage() moves to the target. can be negative to freeze the target for that amount of time" },
                { "map", "maps the overmap centered on the player out to a radius of aoe()" },
                { "morale", "gives a morale effect to all npcs or avatar within aoe, with value damage(). decay_start is duration() / 10." },
                { "charm_monster", "charms a monster that has less hp than damage() for approximately duration()" },
                { "mutate", "mutates the target(s). if effect_str is defined, mutates toward that category instead of picking at random. the MUTATE_TRAIT flag allows effect_str to be a specific trait instead of a category. damage() / 100 is the percent chance the mutation will be successful (a value of 10000 represents 100.00%)" },
                { "bash", "bashes the terrain at the target. uses damage() as the strength of the bash." }
            };
        }
        struct fake_spell
        {
            string id;
            int max_level;
            int level;
            bool self;
        }

        class spell_value_member
        {
            public spell_value_member(string name)
            {
                name_ = name;
            }
            public void update_values( int min, float increment, int max )
            {
                min_ = min;
                increment_ = increment;
                max_ = max;
            }

            public string create_json()
            {
                const string spacing = "    ";
                string ret = "";

                if( max_ == 0 )
                {
                    return ret;
                }

                ret += "\n" + spacing + "\"min_" + name_ + "\": " + min_.ToString() + ",";
                ret += "\n" + spacing + "\"max_" + name_ + "\": " + max_.ToString() + ",";

                if( increment_ != 0.0f )
                {
                    ret += "\n" + spacing + "\"" + name_ + "_increment\": " + increment_.ToString() + ",";
                }

                return ret;
            }

            string name_;
            int min_ = 0;
            float increment_ = 0.0f;
            int max_ = 0;
        }

        class spell_type
        {
            spell_type( string name )
            {
                this.name = name;
            }

            string id = "";
            string name = "";
            string description = "";
            string message = "You cast %s!";
            string sound_description = "an explosion";
            string sound_type = "combat";
            bool sound_ambient = false;
            string sound_id = "";
            string sound_variant = "default";
            string effect = "none";
            string effect_str = "";
            List<fake_spell> additional_spells;
            string field = "";
            int field_chance = 1;

            spell_value_member field_intensity = new spell_value_member("field_intensity");

            float field_intensity_variance = 0.0f;

            spell_value_member damage = new spell_value_member("damage");
            spell_value_member range = new spell_value_member("range");
            spell_value_member aoe = new spell_value_member("aoe");
            spell_value_member dot = new spell_value_member("dot");
            spell_value_member pierce = new spell_value_member("pierce");

            int min_duration = 0;
            int duration_increment = 0;
            int max_duration = 0;

            int base_energy_cost = 0;
            float energy_increment = 0.0f;
            int final_energy_cost = 0;

            string spell_class = "NONE";

            int difficulty = 0;
            int max_level = 0;

            int base_casting_time = 0;
            float casting_time_increment = 0.0f;
            int final_casting_time = 0;

            Dictionary<string, int> learn_spells;

            string energy_source = "none";
            string dmg_type = "NONE";

            HashSet<string> effect_targets;
            HashSet<string> valid_targets;
            HashSet<string> affected_bps;
            HashSet<string> spell_tags;

            public string create_json()
            {
                string ret = "  {";

                const string begin = "\n    \"";

                ret += begin + "id\": \"" + id + "\",";
                ret += begin + "type\": \"SPELL\",";
                ret += begin + "name\": \"" + name + "\",";
                ret += begin + "description\": \"" + description + "\",";
                ret += begin + "effect\": \"" + effect + "\",";
                if (effect_str != "")
                {
                    ret += begin + "effect_str\": \"" + effect_str + "\",";
                }
                ret += begin + "spell_class\": \"" + spell_class + "\",";
                if (difficulty != 0)
                {
                    ret += begin + "difficulty\": " + difficulty.ToString() + ",";
                }
                if(max_level != 0)
                {
                    ret += begin + "max_level\": " + max_level.ToString() + ",";
                }
                ret += damage.create_json();
                ret += range.create_json();
                ret += aoe.create_json();

                ret += "\n  }";
                return ret;
            }
        }
    }
}