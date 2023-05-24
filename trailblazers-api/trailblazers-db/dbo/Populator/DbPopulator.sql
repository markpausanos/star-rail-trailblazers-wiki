INSERT INTO [dbo].[User] ([Name], [Password], [UserType])
VALUES ('admin', '123456', 'A');
GO

DECLARE @i INT = 2;
DECLARE @name NVARCHAR(MAX);
DECLARE @password NVARCHAR(MAX);

WHILE @i <= 20
BEGIN
    SET @name = CONCAT('User', CAST(NEWID() AS VARCHAR(36)));
    SET @password = '123456';
    
    INSERT INTO [dbo].[User] ([Name], [Password])
    VALUES (@name, @password);
    
    SET @i = @i + 1;
END
GO

INSERT INTO [dbo].[PathSR] ([Name], [Image])
VALUES 
('The Abundance', 'https://rerollcdn.com/STARRAIL/Filters/path_the_abundance.png'), /* 1 */
('The Destruction', 'https://rerollcdn.com/STARRAIL/Filters/path_the_destruction.png'), /* 2 */
('The Erudition', 'https://rerollcdn.com/STARRAIL/Filters/path_the_erudition.png'), /* 3 */
('The Harmony', 'https://rerollcdn.com/STARRAIL/Filters/path_the_harmony.png'), /* 4 */
('The Hunt', 'https://rerollcdn.com/STARRAIL/Filters/path_the_hunt.png'),  /* 5 */
('The Nihility', 'https://rerollcdn.com/STARRAIL/Filters/path_the_nihility.png'),   /* 6 */
('The Preservation', 'https://rerollcdn.com/STARRAIL/Filters/path_the_preservation.png')   /* 7 */


INSERT INTO [dbo].[Element] ([Name], [Image])
VALUES
('Fire', 'https://rerollcdn.com/STARRAIL/Filters/element_fire.png'), /* 1 */
('Ice', 'https://rerollcdn.com/STARRAIL/Filters/element_ice.png'), /* 2 */
('Imaginary', 'https://rerollcdn.com/STARRAIL/Filters/element_imaginary.png'),  /* 3 */
('Lightning', 'https://rerollcdn.com/STARRAIL/Filters/element_lightning.png'), /* 4 */
('Physical', 'https://rerollcdn.com/STARRAIL/Filters/element_physical.png'), /* 5 */
('Quantum', 'https://rerollcdn.com/STARRAIL/Filters/element_quantum.png'), /* 6 */
('Wind', 'https://rerollcdn.com/STARRAIL/Filters/element_wind.png')  /* 7 */

INSERT INTO [dbo].[Relic] ([Name], [DescriptionOne], [DescriptionTwo], [Image])
VALUES
('Band of Sizzling Thunder', 'Increases Lightning DMG by 10%.', 'When the wearer uses Skill, increases the wearer''s ATK by 25% for 1 turn(s).', 'https://rerollcdn.com/STARRAIL/Relics/band_of_sizzling_thunder.png'),
('Champion of Streetwise Boxing', 'Increases Physical DMG by 10%.', 'After the wearer attacks or is hit, their ATK increases by 5% for the rest of the battle.\nThis effect can stack up to 5 time(s).', 'https://rerollcdn.com/STARRAIL/Relics/champion_of_streetwise_boxing.png'),
('Eagle of Twilight Line', 'Increases Wind DMG by 10%.', 'After the wearer uses Ultimate, their action is Advanced Forward by 25%.', 'https://rerollcdn.com/STARRAIL/Relics/eagle_of_twilight_line.png'),
('Firesmith of Lava-Forging', 'Increases Fire DMG by 10%.', 'Increases the wearer''s Skill DMG by 12%.\nAfter unleashing Ultimate, increases the wearer''s Fire DMG by 12% for next attack.', 'https://rerollcdn.com/STARRAIL/Relics/firesmith_of_lava-forging.png'),
('Genius of Brilliant Stars', 'Increases Quantum DMG by 10%.', 'When the wearer deals DMG to the target enemy, ignores 10% DEF.\nIf the target enemy has Quantum Weakness, the wearer additionally ignores 10% DEF.', 'https://rerollcdn.com/STARRAIL/Relics/genius_of_brilliant_stars.png'),
('Guard of Wuthering Snow', 'Reduces DMG taken by 8%.', 'At the beginning of the turn, if the wearer''s HP is equal to or less than 50% of their Max HP, restores HP equal to 8% of their Max HP and regenerates 5 Energy.', 'https://rerollcdn.com/STARRAIL/Relics/guard_of_wuthering_snow.png'),
('Hunter of Glacial Forest', 'Increases Ice DMG by 10%.', 'After the wearer unleashes their Ultimate, their CRIT DMG increases by 25% for 2 turn(s).', 'https://rerollcdn.com/STARRAIL/Relics/hunter_of_glacial_forest.png'),
('Knight of Purity Palace', 'Increases DEF by 12%.', 'Increases the max DMG that can be absorbed by the shield created by the wearer by 20%.', 'https://rerollcdn.com/STARRAIL/Relics/knight_of_purity_palace.png'),
('Musketeer of Wild Wheat', 'ATK increases by 10%.', 'The wearer''s SPD increases by 6% and Basic ATK DMG increases by 10%.', 'https://rerollcdn.com/STARRAIL/Relics/musketeer_of_wild_wheat.png'),
('Passerby of Wandering Cloud', 'Increases Outgoing Healing by 10%.', 'At the beginning of the battle, immediately recovers 1 Skill Point.', 'https://rerollcdn.com/STARRAIL/Relics/passerby_of_wandering_cloud.png'),
('Thief of Shooting Meteor', 'Increases Break Effect by 20%.', 'Increases the wearer''s Break Effect by 20%. When the wearer inflicts Weakness Break or an enemy, regenerates 3 Energy.', 'https://rerollcdn.com/STARRAIL/Relics/thief_of_shooting_meteor.png'),
('Wastelander of Banditry Desert', 'Increases Imaginary DMG by 10%.', 'When attacking debuffed enemies, the wearer''s CRIT Rate increases by 10%. If the enemy is Imprisoned, then the wearer''s CRIT DMG increases by 20%.', 'https://rerollcdn.com/GENSHIN/Relics/wastelander_of_banditry_desert.png')


INSERT INTO [dbo].[Ornament] ([Name], [Description], [Image])
VALUES
('Belobog of the Architects', 'Increases the wearer''s DEF by 15%. \nWhen the wearer''s Effect Hit Rate is 50% or higher, the wearer gains an extra 15% DEF.', 'https://rerollcdn.com/STARRAIL/Relics/belobog_of_the_architects.png'),
('Celestial Differentiator', 'Increases the wearer''s CRIT Rate by 8%. \nWhen the wearer''s current CRIT Rate reaches 80% or higher, the wearer''s Basic ATK and Skill DMG increase by 20%.', 'https://rerollcdn.com/STARRAIL/Relics/celestial_differentiator.png'),
('Fleet of the Ageless', 'Increases the wearer''s Max HP by 12%. \nWhen the wearer''s SPD reaches 120 or higher, all allies'' ATK increases by 8%.', 'https://rerollcdn.com/STARRAIL/Relics/fleet_of_the_ageless.png'),
('Inert Salsotto', 'Increases the wearer''s CRIT Rate by 8%. \nWhen the wearer''s current CRIT Rate reaches 50% or higher, the wearer''s Ultimate and follow-up attack DMG increases by 15%.', 'https://rerollcdn.com/STARRAIL/Relics/inert_salsotto.png'),
('Pan-Galactic Commercial Enterprise', 'Increases the wearer''s Effect Hit Rate by 10%. \nMeanwhile, the wearer''s ATK increases by an amount that is equal to 25% of Effect Hit Rate, up to a maximum of 25%.', 'https://rerollcdn.com/STARRAIL/Relics/pan-galactic_commercial_enterprise.png'),
('Space Sealing Station', 'Increases the wearer''s ATK by 12%. \nWhen the wearer''s SPD reaches 120 or higher, the wearer''s ATK increases by another 12%.', 'https://rerollcdn.com/STARRAIL/Relics/space_sealing_station.png'),
('Sprightly Vonwacq', 'Increases the wearer''s Energy Regeneration Rate by 5%. \nWhen the wearer''s SPD reaches 145 or higher, the wearer''s action is Advanced Forward by 50% immediately upon entering battle.', 'https://rerollcdn.com/STARRAIL/Relics/sprightly_vonwacq.png'),
('Talia: Kingdom of Banditry', 'Increases the wearer''s Break Effect by 20%. \nWhen the wearer''s SPD reached 145 or higher, the wearer''s Break effect increases by an additional extra 28%.', 'https://rerollcdn.com/STARRAIL/Relics/talia_kingdom_of_banditry.png')


INSERT INTO [dbo].[Trailblazer] ([Name], [Image], [Rarity], [BaseHp], [BaseAtk], [BaseDef], [BaseSpeed], [ElementId], [PathSRId])
VALUES
('Arlan', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1008.png', 4, 1199, 599, 330, 102, 4, 2),  /*1*/
('Asta', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1009.png', 4, 1023, 511, 463, 106, 1, 4),  /*2*/
('Bailu', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1211.png', 5, 1319, 562, 485, 98, 4, 1), /*3*/
('Bronya', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1101.png', 5, 1241, 582, 533, 99, 7, 4), /*4*/
('Clara', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1107.png', 5, 1241, 737, 485, 90, 5, 2), /*5*/
('Dan Heng', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1002.png', 4, 882, 546, 396, 110, 7, 5), /*6*/
('Gepard', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1104.png', 5, 1397, 543, 654, 92, 2, 7), /*7*/
('Herta', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1013.png', 4, 952, 582, 396, 100, 2, 3),  /*8*/
('Himeko', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1003.png', 5, 1047, 756, 436, 96, 1, 3), /*9*/
('Hook', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1109.png', 4, 1340, 617, 352, 94, 1, 2), /*10*/
('Jin Yuan', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1204.png', 5, 1164, 698, 485, 99, 4, 3),  /*11*/
('Natasha', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1105.png', 4, 1164, 476, 507, 98, 5, 1), /*12*/
('Pela', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1106.png', 4, 987, 546, 463, 105, 2, 6),   /*13*/
('Qingque', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1201.png', 4, 1023, 652, 441, 98, 6, 3), /*14*/
('Seele', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1102.png', 5, 931, 640, 363, 115, 6, 5), /*15*/
('Trailblazer (Physical)', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/8001.png', 5, 620, 460, 100, 125, 5, 2), /*16*/
('Trailblazer (Fire)', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/8003.png', 5, 601, 606, 95, 100, 1, 7),  /*17*/
('Welt', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/1004.png', 5, 1125, 620, 509, 102, 3, 6)   /*18*/


INSERT INTO [dbo].[Lightcone] ([Name], [Title], [Description], [Image], [Rarity], [BaseHp], [BaseAtk], [BaseDef], [PathSRId])
VALUES 
('Before Dawn', 'Long Night', 'Increases the wearer''s CRIT DMG by 36/42/48/54/60%. Increases the wearer''s Skill and Ultimate DMG by 18/21/24/27/30%. After the wearer uses their Skill or Ultimate, they gain Somnus Corpus. Upon triggering a follow-up attack, Somnus Corpus will be consumed and the follow-up attack DMG increases by 48/56/64/72/80%.', 'https://rerollcdn.com/STARRAIL/LightCones/before_dawn_sm.png', 5, 1058, 582, 463, 3),
('Cruising in the Stellar Sea', 'Chase', 'Increases the wearer''s CRIT Rate by  8/10/12/14/16%, and increases their CRIT Rate against enemies with HP less than or equal to 50% by an extra 8/10/12/14/16%. When the wearer defeats an enemy, increase their ATK by  20/25/30/35/40% for 2 turn(s).', 'https://rerollcdn.com/STARRAIL/LightCones/cruising_in_the_stellar_sea_sm.png', 5, 952, 529, 463, 5),
('In the Name of the World', 'Inheritor', 'Increases the wearer''s DMG to debuffed enemies by 24/28/32/36/40%. When the wearer uses their Skill, the Effect Hit Rate for this attack increases by 18/21/24/27/30%, and ATK increases by 24/28/32/36/40%.', 'https://rerollcdn.com/STARRAIL/LightCones/in_the_name_of_the_world_sm.png', 5, 1058, 582, 463, 6),
('In the Night', 'Flowers and Butterflies', 'Increases the wearer''s CRIT Rate by 18/21/24/27/30%. While the wearer is in battle, for every 10 SPD that exceeds 100, the DMG of the wearer''s Basic ATK and Skill is increased by 6/7/8/9/10%, and the CRIT DMG of their Ultimate is increased by 12/14/16/18/20%. This effect can stack up to 8 time(s).', 'https://rerollcdn.com/STARRAIL/LightCones/in_the_night_sm.png', 5, 1058, 476, 595, 5),
('Moment of Victory', 'Verdict', 'Increases the wearer''s DEF by 24/28/32/36/40% and Effect Hit Rate by 24/28/32/36/40%. Increases the chance for the wearer to be attacked by enemies. When the wearer is attacked, increase their DEF by an additional 24/28/32/36/40% until the end of the wearer''s turn.', 'https://rerollcdn.com/STARRAIL/LightCones/moment_of_victory_sm.png', 5, 1058, 476, 595, 7),
('A Secret Vow', 'Spare No Effort', 'Increases DMG dealt by the wearer by 20/25/30/35/40%. The wearer also deals an extra 20/25/30/35/40% of DMG to enemies with a higher HP percentage than the wearer.', 'https://rerollcdn.com/STARRAIL/LightCones/a_secret_vow_sm.png', 4, 1058, 476, 264, 2),
('Dance! Dance! Dance!', 'Cannot Stop It!', 'When the wearer uses their Ultimate, all allies'' actions are Advanced Forward by 16/18/20/22/24%.', 'https://rerollcdn.com/STARRAIL/LightCones/dance!_dance!_dance!_sm.png', 4, 952, 423, 396, 4),
('Day One of My New Life', 'At This Very Moment', 'Increases the wearer''s DEF by 16/18/20/22/24%. After entering battle, increases DMG RES of all allies by 8/9/10/11/12%. Effects of the same type cannot stack.', 'https://rerollcdn.com/STARRAIL/LightCones/day_one_of_my_new_life_sm.png', 4, 952, 370, 463, 7),
('Eyes of the Prey', 'Self-Confidence', 'Increases Effect Hit Rate of its wearer by 20/25/30/35/40% and increases DoT by 24/30/36/42/48%.', 'https://rerollcdn.com/STARRAIL/LightCones/eyes_of_the_prey_sm.png', 4, 952, 476, 330, 6),
('Make the World Clamor', 'The Power of Sound', 'Increases Effect Hit Rate of its wearer by 20/25/30/35/40% and increases DoT by 24/30/36/42/48%.', 'https://rerollcdn.com/STARRAIL/LightCones/make_the_world_clamor_sm.png', 4, 846, 476, 396, 3),
('Adversarial', 'Alliance', 'When the wearer defeats an enemy, increases SPD by 10/12/14/16/18% for 2 turn(s).', 'https://rerollcdn.com/STARRAIL/LightCones/adversarial_sm.png', 3, 740, 370, 264, 5),
('Amber', 'Stasis', 'Increases the wearer''s DEF by 16/20/24/28/32%. If the wearer''s current HP is lower than 50%, increases their DEF by a further 16/20/24/28/32%.', 'https://rerollcdn.com/STARRAIL/LightCones/amber_sm.png', 3, 846, 264, 330, 7),
('Arrows', 'Crisis', 'At the start of the battle, the wearer''s CRIT Rate increases by 12/15/18/21/24% for 3 turn(s).', 'https://rerollcdn.com/STARRAIL/LightCones/arrows_sm.png', 3, 846, 317, 264, 5),
('Chorus', 'Concerted', 'After entering battle, increases the ATK of all allies by 8/9/10/11/12%. Effects of the same type cannot stack.', 'https://rerollcdn.com/STARRAIL/LightCones/chorus_sm.png', 3, 846, 317, 264, 4),
('Collapsing Sky', 'Havoc', 'Increases the wearer''s Basic ATK and Skill DMG by 20/25/30/35/40%.', 'https://rerollcdn.com/STARRAIL/LightCones/make_the_world_clamor_sm.png', 3, 846, 370, 198, 2)

INSERT INTO [dbo].[Eidolon] ([Name], [Description], [Image], [Order], [TrailblazerId])
VALUES
('To the Bitter End','When HP is lower than or equal to 50% of Max HP, increases Skill''s DMG by 10%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1008_Rank1.png',
1, 1),
('Breaking Free','Using Skill or Ultimate removes 1 debuff from oneself.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1008_Rank2.png',
2, 1),
('Star Sings Sans Verses or Vocals','When using Skill, deals DMG for 1 extra time to a random enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1009_Rank1.png',
1, 2),
('Moon Speaks in Wax and Wane','After using her Ultimate, Asta''s Charging stacks will not be reduced in the next turn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1009_Rank2.png',
2, 2),
('Ambrosial Aqua','If the target ally''s current HP is equal to their Max HP when Invigoration ends, regenerates 8 extra Energy for this target.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Rank1.png',
1, 3),
('Sylphic Slumber','After using her Ultimate, Bailu''s Outgoing Healing increases by an additional 15% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Rank2.png',
2, 3),
('Hone Your Strength','When using Skill, there is a 50% fixed chance of recovering 1 Skill Point. This effect has a 1 turn cooldown.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1101_Rank1.png',
1, 4),
('Quick March','When using Skill, the target ally''s SPD increases by 30% after taking action, lasting for 1 turn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1101_Rank2.png',
2, 4),
('A Tall Figure','Using Skill will not remove Mark of Counter on the enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1107_Rank1.png',
1, 5),
('A Tight Embrace','After using the Ultimate, ATK increases by 30% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1107_Rank2.png',
2, 5),
('The Higher You Fly, the Harder You Fall','When the target enemy''s current HP is greater than or equal to 50% of their Max HP, CRIT Rate increases by 12%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1002_Rank1.png',
1, 6),
('Quell the Venom Octet, Quence the Vice O''Flame','Reduces Talent cooldown by 1 turn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1002_Rank2.png',
2, 6),
('Due Diligence','When using Skill, increases the base chance to Freeze enemies by 35%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1104_Rank1.png',
1, 7),
('Lingering Cold','After an enemy Frozen by Skill is unfrozen, their SPD is reduced by 20% for 1 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1104_Rank2.png',
2, 7),
('Kick You When You''re Down','If the enemy''s HP percentage is at 50% or less, Herta''s Basic ATK deals additional Ice DMG equal to 40% of Herta''s ATK.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1013_Rank1.png',
1, 8),
('Keep the Ball Rolling','Every time Talent is triggered, this character''s CRIT Rate increases by 3%. This effect can stack up to 5 time(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1013_Rank2.png',
2, 8),
('Childhood','After "Victory Rush" is triggered, Himeko''s SPD increases by 20% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1003_Rank1.png',
1, 9),
('Convergence','Deals 15% more DMG to enemies whose HP percentage is 50% or less.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1003_Rank2.png',
2, 9),
('Early to Bed, Early to Rise','Enhanced Skill deals 20% increased DMG.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1109_Rank1.png',
1, 10),
('Happy Tummy, Happy Body','Extends the duration of Burn caused by Skill by 1 turn(s)..', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1109_Rank2.png',
2, 10),
('Slash, Seas Split','When Lightning-Lord attacks, the DMG multiplier on enemies adjacent to the target enemy increases by an extra amount equal to 25% of the DMG multiplier against the target enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1204_Rank1.png',
1, 11),
('Swing, Skies Squashed','After Lightning-Lord takes action, DMG caused by Jing Yuan''s Basic ATK, Skill, and Ultimate increases by 20% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1204_Rank2.png',
2, 11),
('Phamacology Expertise','After being attacked, if the current HP percentage is 30% or lower, heals self for 1 time to restore HP by an amount equal to 15% of Max HP plus 400.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1105_Rank1.png',
1, 12),
('Clinical Research','When Natasha uses her Ultimate, grant continuous healing for 1 turn(s) to allies whose HP is at 30% or lower.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1105_Rank2.png',
2, 12),
('Victory Report','When Pela defeats an enemy, Pela regenerates 5 Energy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1106_Rank1.png',
1, 13),
('Adamant Charge','Using Skill to remove buff(s) increases SPD by 10% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1106_Rank2.png',
2, 13),
('Rise Through the Tiles','Ultimate deals 10% more DMG.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1201_Rank1.png',
1, 14),
('Sleep on the Tiles','Every time Draw Tile is triggered, Qingque immediately regenerates 1 Energy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1201_Rank2.png',
2, 14),
('Exitrpating Slash','When dealing DMG to an enemy whose HP percentage is 80% or lower, CRIT Rate increases by 15%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1102_Rank1.png',
1, 15),
('Dancing Butterfly','The SPD Boost effect of Seele''s Skill can stack up to 2 time(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1102_Rank2.png',
2, 15),
('A Falling Star','When enemies are defeated due to the Trailblazer''s Ultimate, the Trailblazer regenerates 10 extra Energy. This effect can only be triggered once per attack.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Rank1.png',
1, 16),
('An Unwilling Host','Attacking enemies with Physical Weakness restores the Trailblazer''s HP equal to 5% of the Trailblazer''s ATK.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Rank2.png',
2, 16),
('Earth-Shaking Resonance','When the Trailblazer uses their Basic ATK, additionally deals Fire DMG equal to 25% of the Trailblazer''s DEF. When the Trailblazer uses their enhanced Basic ATK, additionally deals Fire DMG equal to 50% of the Trailblazer''s DEF.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8003_Rank1.png',
1, 17),
('Time-Defying Tenacity','The Shield applied to all allies from the Trailblazer''s Talent will block extra DMG equal to 2% of the Trailblazer''s DEF plus 27.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8003_Rank2.png',
2, 17),
('Legacy of Honor','After Welt uses his Ultimate, his abilities are enhanced.
The next 2 time(s) he uses his Basic ATK or Skill, deals Additional DMG to the target equal to 50% of his Basic ATK''s DMG multiplier or 80% of his Skill''s DMG multiplier respectively.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1004_Rank1.png',
1, 18),
('Conflux of Stars','When his Talent is triggered, Welt regenerates 3 Energy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1004_Rank2.png',
2, 18)




INSERT INTO [dbo].[Trace] ([Name], [Description], [Image], [Order], [TrailblazerId])
VALUES 
('Revival','If the current HP percentage is 30% or lower when defeating an enemy, immediately restores HP equal to 20% of Max HP.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1008_Rank1.png',
1, 1),
('Perseverance','The chance to resist DoT Debuffs increases by 50%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1008_Rank2.png',
2, 1),
('Sparks','Asta''s Basic ATK has a 80% base chance to Burn enemies for 3 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1009_Rank1.png',
1, 2),
('Ignite','When Asta is on the field, all allies'' Fire DMG increases by 18%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1009_Rank2.png',
2, 2),
('Vidyadhara Geo-Veins','Invigoration can trigger 1 more time(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Rank1.png',
1, 3),
('Qihuang Analects','When Bailu heals a target ally above their normal Max HP, the target''s Max HP increases by 10% for 2 turns.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Rank2.png',
2, 3),
('Command','The CRIT Rate for Basic ATK increases to 100%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1101_Rank1.png',
1, 4),
('Battlefield','At the start of the battle, all allies'' DEF increases by 20% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1101_Rank2.png',
2, 4),
('Kinship','When attacked, this character has a 35% fixed chance to remove a debuff placed on them.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1107_Rank1.png',
1, 5),
('Under Protection','The chance to resist Crowd Control Debuffs increases by 35%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1107_Rank2.png',
2, 5),
('Hidden Dragon','When current HP percentage is 50% or lower, reduces the chance of being attacked by enemies.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1002_Rank1.png',
1, 6),
('Shadow of Despair','When launching an attack, there is a 50% fixed chance to increase SPD by 20% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1002_Rank2.png',
2, 6),
('Integrity','Gepard has a higher chance to be attacked by enemies.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1104_Rank1.png',
1, 7),
('Commander','When "Unyielding Will" is triggered, Gepard''s Energy will be restored to 100%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1104_Rank2.png',
2, 7),
('Efficiency','When Skill is used, the DMG Boost on target enemies increases by an extra 25%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1013_Rank1.png',
1, 8),
('Puppet','The chance to resist Crowd Control debuffs increases by 35%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1013_Rank2.png',
2, 8),
('Starfire','After using an attack, there is a 50% base chance to inflict Burn on enemies for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1003_Rank1.png',
1, 9),
('Magma','Skill deals 20% more DMG to enemies currently afflicted with Burn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1003_Rank2.png',
2, 9),
('Innocence','Hook restores HP equal to 5% of her Max HP whenever her Talent is triggered.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1109_Rank1.png',
1, 10),
('Naivete','The chance to resist Crowd Control Debuffs increases by 35%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1109_Rank2.png',
2, 10),
('Battalia Crush','If the Lightning-Lord''s Hits Per Action is greater or equal to 6 in the next turn, its CRIT DMG increases by 25% for the next turn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1204_Rank1.png',
1, 11),
('Savant Providence','At the start of the battle, immediately regenerates 15 Energy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1204_Rank2.png',
2, 11),
('Healer','Natasha''s Outgoing Healing increases by 10%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1105_Rank1.png',
1, 12),
('Soothe','The Skill removes 1 debuff(s) from a target ally.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1105_Rank2.png',
2, 12),
('Bash','Pela deals 20% more DMG to debuffed enemies.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1106_Rank1.png',
1, 13),
('The Secret Strategy','When Pela is on the battlefield, all allies'' Effect Hit Rate increases by 10%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1106_Rank2.png',
2, 13),
('Tile Battle','Restores 1 Skill Point when using the Skill. This effect can only be triggered 1 time per battle.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1201_Rank1.png',
1, 14),
('Bide Time','Using the Skill increases DMG Boost effect of attacks by an extra 10%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1201_Rank2.png',
2, 14),
('Nightshade','When current HP percentage is 50% or lower, reduces the chance of being attacked by enemies.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1102_Rank1.png',
1, 15),
('Rippling Waves','After using a Basic ATK, Seele''s next action will be Advanced Forward by 20%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1102_Rank2.png',
2, 15),
('Ready for Battle','At the start of the battle, immediately regenerates 15 Energy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Rank1.png',
1, 16),
('Perseverance','Each Talent stack increases the Trailblazer''s DEF by 10%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Rank2.png',
2, 16),
('The Strong Defends the Weak','After using the Skill, the DMG taken by all allies reduces by 15% for 1 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8003_Rank1.png',
1, 17),
('Unwavering Gallantry','Using Enhanced Basic ATK restores the Trailblazer''s HP by 5% of their Max HP.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8003_Rank2.png',
2, 17),
('Retribution','When using Ultimate, there is a 100% base chance to increase the DMG received by the targets by 12% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1004_Rank1.png',
1, 18),
('Judgment','Using Ultimate additionally regenerates 10 Energy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1004_Rank2.png',
2, 18)





INSERT INTO [dbo].[Skill] ([Name], [Title], [Description], [Image], [Type], [TrailblazerId])
VALUES 
('Lightning Rush', 'Single Target', 'Deals Lightning DMG equal to 50% of Arlan''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1008_Normal.png', 
'Basic ATK', 1),
('Frenzied Punishment', 'Blast', 'Deals Lightning DMG equal to 192% of Arlan''s ATK to a single enemy and Lightning DMG equal to 96% of Arlan''s ATK to enemies adjacent to it.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1008_Ultra_on.png', 
'Ultimate', 1),
('Spectrum Beam', 'Single Target', 'Deals Fire DMG equal to 50% of Asta''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1009_Normal.png', 
'Basic ATK', 2),
('Astral Blessing', 'Support', 'Increases SPD of all allies by 36 for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1009_Ultra_on.png', 
'Ultimate', 2),
('Spectrum Beam', 'Single Target', 'Deals Fire DMG equal to 50% of Asta''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Normal.png', 
'Basic ATK', 2),
('Astral Blessing', 'Support', 'Increases SPD of all allies by 36 for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Ultra_on.png', 
'Ultimate', 2),
('Diagnostic Kick', 'Single Target', 'Deals Lightning DMG equal to 50% of Bailu''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Normal.png', 
'Basic ATK', 3),
('Felicitous Thunderleap', 'Restore', 'Heals all allies for 9% of Bailu''s Max HP plus 90. Bailu applies Invigoration to allies that are not already Invigorated. For those already Invigorated, Bailu extends the duration of their Invigoration by 1 turn. The effect of Invigoration can last for 2 turn(s). This effect cannot stack.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1211_Ultra_on.png', 
'Ultimate', 3),
('Windrider Bullet', 'Single Target', 'Deals Wind DMG equal to 50% of Bronya''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1101_Normal.png', 
'Basic ATK', 4),
('The Belobog March', 'Support', 'Increases the ATK of all allies by 33%, and increase their CRIT DMG equal to 12% of Bronya''s CRIT DMG plus 12% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1101_Ultra_on.png', 
'Ultimate', 4),
('I Want to Help', 'Single Target', 'Deals Physical DMG equal to 50% of Clara''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1107_Normal.png', 
'Basic ATK', 5),
('Promise, Not Command', 'Enhance', 'After Clara uses Ultimate, DMG dealt to her is reduced by an extra 15%, and she has a greatly increased chance of being attacked by enemies for 2 turn(s). In addition, Svarog''s Counter is enhanced. When an ally is attacked, Svarog immediately launches a Counter, and its DMG multiplier against the enemy increased by 96%. Enemies adjacent to it take 50% of the DMG dealt to the target enemy. Enhanced Counter can take effect 2 time(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1107_Ultra.png', 
'Ultimate', 5),
('Knight Spear Technique: Torrent', 'Single Target', 'Deals Wind DMG equal to 130% of Dan Heng''s ATK to a single enemy. On a CRIT Hit, there is a 100% base chance to reduce the target''s SPD by 12% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1002_BP.png', 
'Basic ATK', 6),
('Ethereal Dream', 'Single Target', 'Deals Wind DMG equal to 240% of Dan Heng''s ATK to a single enemy. If the enemy is Slowed, the Ultimate''s DMG multiplier increases by 72%.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1002_Ultra_on.png', 
'Ultimate', 6),
('Fist of Conviction', 'Single Target', 'Deals Ice DMG equal to 50% of Gepard''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1104_Normal.png', 
'Basic ATK', 7),
('EEnduring Bulwark', 'Defense', 'Applies a Shield to all allies, absorbing DMG equal to 30% of Gepard''s DEF plus 150 for 3 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1104_Ultra_on.png', 
'Ultimate', 7),
('What Are You Looking At?', 'Single Target', 'Deals Ice DMG equal to 50% of Herta''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1013_Normal.png', 
'Basic ATK', 8),
('It''s Magic, I Added Some Magic', 'AoE ATK', 'Deals Ice DMG equal to 120% of Herta''s ATK to all enemies.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1013_Ultra_on.png', 
'Ultimate', 8),
('Sawblade Tuning', 'Single Target', 'Deals Fire DMG equal to 50% of Himeko''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1003_Normal.png', 
'Basic ATK', 9),
('Heavenly Flare', 'AoE ATK', 'Deals Fire DMG equal to 138% of Himeko''s ATK to all enemies. Additionally, Himeko regenerates 5 Energy for each enemy defeated.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1003_Ultra_on.png', 
'Ultimate', 9),
('Hehe! Don''t Get Burned!', 'Single Target', 'Deals Fire DMG equal to 50% of Hook''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1109_Normal.png', 
'Basic ATK', 10),
('Boom! Here Comes the Fire!', 'Single Target', 'Deals Fire DMG equal to 240% of Hook''s ATK to a single enemy. After using Ultimate, the next Skill to be used is Enhanced, which deals DMG to a single enemy and enemies adjacent to it.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1109_Ultra_on.png', 
'Ultimate', 10),
('Glistening Light', 'Single Target', 'Deals Lightning DMG equal to 50% of Jing Yuan''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1204_Normal.png', 
'Basic ATK', 11),
('Lightbringer', 'AoE ATK', 'Deals Lightning DMG equal to 120% of Jing Yuan''s ATK to all enemies and increases Lightning-Lord''s Hits Per Action by 3 for the next turn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1204_Ultra_on.png', 
'Ultimate', 11),
('Behind the Kindness', 'Single Target', 'Deals Physical DMG equal to 50% of Natasha''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1105_Normal.png', 
'Basic ATK', 12),
('Gift of Rebirth', 'Restore', 'Heals all allies for 9.2% of Natasha''s Max HP plus 92.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1105_Ultra_on.png', 
'Ultimate', 12),
('Frost Shot', 'Single Target', 'Deals Ice DMG equal to 50% of Pela''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1106_Normal.png', 
'Basic ATK', 13),
('Zone Suppression', 'Impair', 'Deals Ice DMG equal to 60% of Pela''s ATK to all enemies, with a 100% base chance to inflict Exposed on all enemies. When Exposed, enemies'' DEF is reduced by 30% for 2 turn(s).', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1106_Ultra_on.png', 
'Ultimate', 13),
('Flower Pick', 'Single Target', 'Tosses 1 jade tile of the suit with the fewest tiles in hand to deal Quantum DMG equal to 50% of Qingque''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1201_Normal.png', 
'Basic ATK', 14),
('A Quartet? Woo-hoo!', 'AoE ATK', 'Deals Quantum DMG equal to 120% of Qingque''s ATK to all enemies, and obtain 4 jade tiles of the same suit.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1201_Ultra_on.png', 
'Ultimate', 14),
('Thwack', 'Single Target', 'Deals Quantum DMG equal to 50% of Seele''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1102_Normal.png', 
'Basic ATK', 15),
('Butterfly Flurry', 'Single Target', 'Seele enters the buffed state and deals Quantum DMG equal to 255% of her ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1102_Ultra_on.png', 
'Ultimate', 15),
('Farewell Hit', 'Single Target', 'Deals Physical DMG equal to 50% of the Trailblazer''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Normal.png', 
'Basic ATK', 16),
('Stardust Ace', 'Enhance', 'Choose between two attack modes to deliver a full strike. Blowout: Farewell Hit deals Physical DMG equal to 300% of the Trailblazer''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Ultra_on.png', 
'Ultimate', 16),
('Ice-Breaking Light', 'Single Target', 'Deals Fire DMG equal to 50% of the Trailblazer''s ATK to a single enemy and gains 1 stack of Magma Will.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8003_Normal.png', 
'Basic ATK', 17),
('War-Flaming Lance', 'AoE ATK', 'Deals Fire DMG equal to 50% of the Trailblazer''s ATK plus 75% of the Trailblazer''s DEF to all enemies. The next Basic ATK will be automatically enhanced and does not cost Magma Will.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8003_Ultra_on.png', 
'Ultimate', 17),
('Gravity Suppression', 'Single Target', 'Deals Imaginary DMG equal to 50% of Welt''s ATK to a single enemy.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1004_Normal.png', 
'Basic ATK', 18),
('Synthetic Black Hole', 'AoE ATK', 'Deals Imaginary DMG equal to 90% of Welt''s ATK to all enemies, with a 100% base chance for enemies hit by this ability to be Imprisoned for 1 turn.', 
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_1004_Ultra_on.png', 
'Ultimate', 18)
