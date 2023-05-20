INSERT INTO [dbo].[User] ([Name], [Password])
VALUES ('admin', '123456');
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
('The Abundance', 'https://rerollcdn.com/STARRAIL/Filters/path_the_abundance.png'),
('The Destruction', 'https://rerollcdn.com/STARRAIL/Filters/path_the_destruction.png'),
('The Erudition', 'https://rerollcdn.com/STARRAIL/Filters/path_the_erudition.png'),
('The Harmony', 'https://rerollcdn.com/STARRAIL/Filters/path_the_harmony.png'),
('The Hunt', 'https://rerollcdn.com/STARRAIL/Filters/path_the_hunt.png'),
('The Nihility', 'https://rerollcdn.com/STARRAIL/Filters/path_the_nihility.png'),
('The Preservation', 'https://rerollcdn.com/STARRAIL/Filters/path_the_preservation.png')


INSERT INTO [dbo].[Element] ([Name], [Image])
VALUES
('Fire', 'https://rerollcdn.com/STARRAIL/Filters/element_fire.png'),
('Ice', 'https://rerollcdn.com/STARRAIL/Filters/element_ice.png'),
('Imaginary', 'https://rerollcdn.com/STARRAIL/Filters/element_imaginary.png'),
('Lightning', 'https://rerollcdn.com/STARRAIL/Filters/element_lightning.png'),
('Physical', 'https://rerollcdn.com/STARRAIL/Filters/element_physical.png'),
('Quantum', 'https://rerollcdn.com/STARRAIL/Filters/element_quantum.png'),
('Wind', 'https://rerollcdn.com/STARRAIL/Filters/element_wind.png')

INSERT INTO [dbo].[Relic] ([Name], [DescriptionOne], [DescriptionTwo], [Image])
VALUES
('Band of Sizzling Thunder', 'Increases Lightning DMG by 10%.', 'When the wearer uses Skill, increases the wearer''s ATK by 25% for 1 turn(s).', 'https://rerollcdn.com/STARRAIL/Relics/band_of_sizzling_thunder.png'),
('Champion of Streetwise Boxing', 'Increases Physical DMG by 10%.', 'After the wearer attacks or is hit, their ATK increases by 5% for the rest of the battle.\nThis effect can stack up to 5 time(s).', 'https://rerollcdn.com/STARRAIL/Relics/champion_of_streetwise_boxing.png'),
('Eagle of Twilight Line', 'Increases Wind DMG by 10%.', 'After the wearer uses Ultimate, their action is Advanced Forward by 25%.', 'https://rerollcdn.com/STARRAIL/Relics/eagle_of_twilight_line.png'),
('Firesmith of Lava-Forging', 'Increases Fire DMG by 10%.', 'Increases the wearer''s Skill DMG by 12%.\nAfter unleashing Ultimate, increases the wearer''s Fire DMG by 12% for next attack.', 'https://rerollcdn.com/STARRAIL/Relics/firesmith_of_lava-forging.png'),
('Genius of Brilliant Stars', 'Increases Quantum DMG by 10%.', 'When the wearer attacks enemies with Quantum Weakness, ignores 25% DEF.', 'https://rerollcdn.com/STARRAIL/Relics/genius_of_brilliant_stars.png'),
('Guard of Wuthering Snow', 'Reduces DMG taken by 8%.', 'At the beginning of the turn, if the wearer''s HP is equal to or less than 50% of their Max HP, restores HP equal to 8% of their Max HP and regenerates 5 Energy.', 'https://rerollcdn.com/STARRAIL/Relics/guard_of_wuthering_snow.png'),
('Hunter of Glacial Forest', 'Increases Ice DMG by 10%.', 'After the wearer unleashes their Ultimate, their CRIT DMG increases by 25% for 2 turn(s).', 'https://rerollcdn.com/STARRAIL/Relics/hunter_of_glacial_forest.png'),
('Knight of Purity Palace', 'Increases DEF by 12%.', 'Increases the max DMG that can be absorbed by the shield created by the wearer by 20%.', 'https://rerollcdn.com/STARRAIL/Relics/knight_of_purity_palace.png'),
('Musketeer of Wild Wheat', 'ATK increases by 10%.', 'The wearer''s SPD increases by 6% and Basic ATK DMG increases by 10%.', 'https://rerollcdn.com/STARRAIL/Relics/musketeer_of_wild_wheat.png'),
('Passerby of Wandering Cloud', 'Increases Outgoing Healing by 10%.', 'At the beginning of the battle, immediately recovers 1 Skill Point.', 'https://rerollcdn.com/STARRAIL/Relics/passerby_of_wandering_cloud.png'),
('Thief of Shooting Meteor', 'Increases Break Effect by 20%.', 'Increases the wearer''s Break Effect by 20%. When the wearer inflicts Weakness Break or an enemy, regenerates 3 Energy.', 'https://rerollcdn.com/STARRAIL/Relics/thief_of_shooting_meteor.png'),
('Wastelander of Banditry Desert', 'Increases Imaginary DMG by 10%.', 'When attacking debuffed enemies, the wearer''s CRIT Rate increases by 10%. If the enemy is Imprisoned, then the wearer''s CRIT DMG increases by 20%.', 'https://rerollcdn.com/GENSHIN/Relics/wastelander_of_banditry_desert.png')


INSERT INTO [dbo].[Ornament] ([Name], [Description], [Image])
VALUES
('Belobog of the Architects', 'Increases the wearer''s DEF by 15%. When the wearer''s Effect Hit Rate is 50% or higher, the wearer gains an extra 15% DEF.', 'https://rerollcdn.com/STARRAIL/Relics/belobog_of_the_architects.png'),
('Celestial Differentiator', 'Increases the wearer''s CRIT Rate by 8%. When the wearer''s current CRIT Rate reaches 80% or higher, the wearer''s Basic ATK and Skill DMG increase by 20%.', 'https://rerollcdn.com/STARRAIL/Relics/celestial_differentiator.png'),
('Fleet of the Ageless', 'Increases the wearer''s Max HP by 12%. When the wearer''s SPD reaches 120 or higher, all allies'' ATK increases by 8%.', 'https://rerollcdn.com/STARRAIL/Relics/fleet_of_the_ageless.png'),
('Inert Salsotto', 'Increases the wearer''s CRIT Rate by 8%. When the wearer''s current CRIT Rate reaches 50% or higher, the wearer''s Ultimate and follow-up attack DMG increases by 15%.', 'https://rerollcdn.com/STARRAIL/Relics/inert_salsotto.png'),
('Pan-Galactic Commercial Enterprise', 'Increases the wearer''s Effect Hit Rate by 10%. Meanwhile, the wearer''s ATK increases by an amount that is equal to 25% of Effect Hit Rate, up to a maximum of 25%.', 'https://rerollcdn.com/STARRAIL/Relics/pan-galactic_commercial_enterprise.png'),
('Space Sealing Station', 'Increases the wearer''s ATK by 12%. When the wearer''s SPD reaches 120 or higher, the wearer''s ATK increases by another 12%.', 'https://rerollcdn.com/STARRAIL/Relics/space_sealing_station.png'),
('Sprightly Vonwacq', 'Increases the wearer''s Energy Regeneration Rate by 5%. When the wearer''s SPD reaches 145 or higher, the wearer''s action is Advanced Forward by 50% immediately upon entering battle.', 'https://rerollcdn.com/STARRAIL/Relics/sprightly_vonwacq.png'),
('Talia: Kingdom of Banditry', 'Increases the wearer''s Break Effect by 20%. When the wearer''s SPD reached 145 or higher, the wearer''s Break effect increases by an additional extra 28%.', 'https://rerollcdn.com/STARRAIL/Relics/talia_kingdom_of_banditry.png')


INSERT INTO [dbo].[Trailblazer] ([Name], [Image], [Rarity], [BaseHp], [BaseAtk], [BaseDef], [BaseSpeed], [ElementId], [PathSRId])
VALUES
('Trailblazer (Physical)', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/8001.png', 5, 620, 460, 100, 125, 5, 2),
('Trailblazer (Fire)', 'https://rerollcdn.com/STARRAIL/Characters/Thumb/8003.png', 5, 601, 606, 95, 100, 1, 7)

INSERT INTO [dbo].[Lightcone] ([Name], [Title], [Description], [Image], [Rarity], [BaseHp], [BaseAtk], [BaseDef], [PathSRId])
VALUES ('Moment of Victory', 'Verdict', 'Increases the wearer''s DEF by 24/28/32/36/40% and Effect Hit Rate by 24/28/32/36/40%. Increases the chance for the wearer to be attacked by enemies. When the wearer is attacked, increase their DEF by an additional 24/28/32/36/40% until the end of the wearer''s turn.', 'https://rerollcdn.com/STARRAIL/LightCones/moment_of_victory_sm.png', 5, 1058, 476, 595, 7);

INSERT INTO [dbo].[Eidolon] ([Name], [Description], [Image], [Order], [TrailblazerId])
VALUES
('A Falling Star', 
'When enemies are defeated due to the Trailblazer''s Ultimate, the Trailblazer regenerates 10 extra Energy. This effect can only be triggered once per attack.',
'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Rank1.png',
1,
1)

INSERT INTO [dbo].[Trace] ([Name], [Description], [Image], [Order], [TrailblazerId])
VALUES ('Ready for Battle','At the start of the battle, immediately regenerates 15 Energy.', 'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Rank1.png',1, 1)

INSERT INTO [dbo].[Skill] ([Name], [Title], [Description], [Image], [Type], [TrailblazerId])
VALUES ('Farewell Hit', 'Single Target', 'Deals Physical DMG equal to 50% of the Trailblazer''s ATK to a single enemy.', 'https://rerollcdn.com/STARRAIL/Skill/SkillIcon_8001_Normal.png', 'Basic ATK', 1)