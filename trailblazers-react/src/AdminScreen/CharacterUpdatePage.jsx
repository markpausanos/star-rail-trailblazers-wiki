import React, { useState, useEffect } from "react";
import "./InputPage.css";

export const CharacterUpdatePage = (props) => {
    const [charID, setID] = useState(-1);
    const [charImage, setCharImage] = useState("");
    const [charName, setCharName] = useState("");
    const [rarity, setRarity] = useState(0);
    const [element, setElement] = useState(0);
    const [path, setPath] = useState(0);
    const [baseHP, setBaseHP] = useState(0);
    const [baseAtk, setBaseAtk] = useState(0);
    const [baseDef, setBaseDef] = useState(0);
    const [baseSpd, setBaseSpd] = useState(0);
    const [skills, setSkills] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [eidolons, setEidolons] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [traces, setTraces] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [charList, setCharList] = useState([]);

    
    const fetchCharacterData = () => {
        // Replace with your own logic to fetch character data from the database
        // This is a placeholder function, you should replace it with your own implementation
        // You can use axios, fetch, or any other library to make the API request
        // Return the fetched character data object
    
        // Placeholder data for demonstration
        const characterData = [
        {
            id: 0,
            image: "https://rerollcdn.com/STARRAIL/Characters/Thumb/1107.png",
            name: "Illyasviel von Einzbern",
            rarityId: 5,
            elementId: 0,
            pathId: 0,
            baseHP: 1241,
            baseAtk: 737,
            baseDef: 485,
            baseSpd: 90,
            skills: [
            { name: "I Want to Help", description: "Deals Physical DMG equal to 50% of Clara's ATK to a single enemy." },
            { name: "BAHSAHKAH Watches Over You", description: "Deals Physical DMG equal to 60% of Clara's ATK to all enemies, and additionally deals Physical DMG equal to 60% of Clara's ATK to enemies marked by Svarog with a Mark of Counter. All Marks of Counter will be removed after this Skill is used." },
            { name: "Promise, Not Command", description: "After Illya uses Ultimate, DMG dealt to her is reduced by an extra 15%, and she has a greatly increased chance of being attacked by enemies for 2 turn(s). In addition, Svarog's Counter is enhanced. When an ally is attacked, Svarog immediately launches a Counter, and its DMG multiplier against the enemy increased by 96%. Enemies adjacent to it take 50% of the DMG dealt to the target enemy. Enhanced Counter can take effect 2 time(s)." },
            { name: "Because We're Family", description: "Under the protection of Heracles, DMG taken by Illya is reduced by 10%. Heracles will mark enemies who attack Illya with Mark of Counter and retaliate with a Counter, dealing Physical DMG equal to 80% of Illya's ATK." },
            { name: "Small Price for Victory", description: "Immediately attacks the enemy. Upon entering battle, the chance Illya will be attacked by enemies increases for 2 turn(s)." },
            ],
            eidolons: [
            { name: "A Tall Figure", description: "Using Skill will not remove Mark of Counter on the enemy." },
            { name: "A Tight Embrace", description: "After using the Ultimate, ATK increases by 30% for 2 turn(s)." },
            { name: "Cold Steel Armor", description: "Skill Lv. +2, up to a maximum of Lv. 15. Basic ATK Lv. +1, up to a maximum of Lv. 10." },
            { name: "Family's Warmth", description: "After Clara is hit, the DMG taken by Clara is reduced by 30%. This effect lasts until the start of her next turn." },
            { name: "A Small Promise", description: "Ultimate Lv. +2, up to a maximum of Lv. 15. Talent Lv. +2, up to a maximum of Lv. 15." },
            { name: "Long Company", description: "After other allies are hit, Svarog also has a 50% fixed chance to trigger a Counter on the attacker and mark them with a Mark of Counter. When using Clara's Ultimate, the number of Enhanced Counters increases by 1." },
            ],
            traces: [
            { name: "Kinship", description: "When attacked, this character has a 35% fixed chance to remove a debuff placed on them." },
            { name: "Under Protection", description: "The chance to resist Crowd Control Debuffs increases by 35%." },
            { name: "Revenge", description: "Increase Svarog's Counter DMG by 30%." },
            ],
        },
        ];
    
        return characterData;
    };
    
    useEffect(() => {
        // Logic to load character data from the database or any other data source
        const characterData = fetchCharacterData(); // Replace with your own function to fetch character data
    
        // Update the state with the fetched character data
        setCharList(characterData);

        // Set the text displayed in the input boxes to the data for the selected character
        if (charID >= 0 && charID < characterData.length) {
            const selectedCharacter = characterData[charID];
            setID(selectedCharacter.id);
            setCharImage(selectedCharacter.image);
            setCharName(selectedCharacter.name);
            setRarity(selectedCharacter.rarityId);
            setElement(selectedCharacter.elementId);
            setPath(selectedCharacter.pathId);
            setBaseHP(selectedCharacter.baseHP);
            setBaseAtk(selectedCharacter.baseAtk);
            setBaseDef(selectedCharacter.baseDef);
            setBaseSpd(selectedCharacter.baseSpd);
            setSkills(selectedCharacter.skills);
            setEidolons(selectedCharacter.eidolons);
            setTraces(selectedCharacter.traces);
        }
    }, [charID]);

    return (
        <div>
            <div className="pairs">
                <label htmlFor="characterSelect">Select Character</label>
                <select
                    id="characterSelect"
                    value={charID}
                    onChange={(e) => {
                    setID(e.target.value);
                    }}
                >
                    <option value={-1}>Select a character</option>
                    {charList.map((character) => (
                    <option key={character.id} value={character.id}>
                        {character.name}
                    </option>
                    ))}
                </select>
            </div>
            <div className="pairs">
                <label for="characterImage">Character Image</label>
                <input type="text" placeholder="Character Image Link" value={charImage} onChange={(e) => setCharImage(e.target.value)} />
            </div>
            <div className="the-top">
                <img className="picBox" src={charImage} alt="+"/>
                <div className="pairs">
                    <label for="charName">Name</label>
                    <input type="text" placeholder="Character Name" value={charName} onChange={(e) => setCharName(e.target.value)} />
                </div>
                <div className="pairs">
                    <label for="rarity">Rarity</label>
                    <select value={rarity} onChange={(e) => setRarity(e.target.value)}>
                        <option value="4">4 Star</option>
                        <option value="5">5 Star</option>
                    </select>
                </div>
                <div className="pairs">
                    <label for="element">Element</label>
                    <select value={element} onChange={(e) => setElement(e.target.value)}>
                        <option value="0">Physical</option>
                        <option value="1">Ice</option>
                        <option value="2">Wind</option>
                        <option value="3">Fire</option>
                        <option value="4">Lightning</option>
                        <option value="5">Quantum</option>
                        <option value="6">Imaginary</option>
                    </select>
                </div>
                <div className="pairs">
                    <label for="path">Path</label>
                    <select value={path} onChange={(e) => setPath(e.target.value)}>
                        <option value="0">Destruction</option>
                        <option value="1">Preservation</option>
                        <option value="2">Hunt</option>
                        <option value="3">Abundance</option>
                        <option value="4">Erudition</option>
                        <option value="5">Nihility</option>
                        <option value="6">Harmony</option>
                    </select>
                </div>
            </div>
            <div className="the-top">
                <div className="pairs">
                    <label for="Base HP">Base HP</label>
                    <input type="number" placeholder="Base HP" value={baseHP} onChange={(e) => setBaseHP(e.target.value)} />
                    <label for="Base ATK">Base ATK</label>
                    <input type="number" placeholder="Base ATK" value={baseAtk} onChange={(e) => setBaseAtk(e.target.value)} />
                    <label for="Base DEF">Base DEF</label>
                    <input type="number" placeholder="Base DEF" value={baseDef} onChange={(e) => setBaseDef(e.target.value)} />
                    <label for="Base SPD">Base SPD</label>
                    <input type="number" placeholder="Base SPD" value={baseSpd} onChange={(e) => setBaseSpd(e.target.value)} />
                </div>
                <div>
                    <label for="skills">Skills</label>
                    <ul>
                        {skills.map((skill, index) => (
                            <li key={index}>
                                <input type="text" placeholder="Name" value={skill.name} onChange={(e) => setSkills(skills.map((s) => ({...s, name: e.target.value})))} />
                                <input type="text" placeholder="Description" value={skill.description} onChange={(e) => setSkills(skills.map((s) => ({...s, description: e.target.value})))} />
                            </li>
                        ))}
                    </ul>
                </div>

                <div>
                    <label for="eidolons">Eidolons</label>
                    <ul>
                        {eidolons.map((eidolon, index) => (
                            <li key={index}>
                                <input type="text" placeholder="Name" value={eidolon.name} onChange={(e) => setEidolons(eidolons.map((s) => ({...s, name: e.target.value})))} />
                                <input type="text" placeholder="Description" value={eidolon.description} onChange={(e) => setEidolons(eidolons.map((s) => ({...s, description: e.target.value})))} />
                            </li>
                        ))}
                    </ul>
                </div>

                <div>
                    <label for="traces">Traces</label>
                    <ul>
                        {traces.map((trace, index) => (
                            <li key={index}>
                                <input type="text" placeholder="Name" value={trace.name} onChange={(e) => setTraces(traces.map((s) => ({...s, name: e.target.value})))} />
                                <input type="text" placeholder="Description" value={trace.description} onChange={(e) => setTraces(traces.map((s) => ({...s, description: e.target.value})))} />
                            </li>
                        ))}
                    </ul>
                </div>
            </div>
            <div className="options">
                <button className="buttons" onClick={() => {
                    console.log(charImage, charName, rarity, element, path, baseHP, baseAtk, baseDef, baseSpd, skills, eidolons, traces); // upload to database code here
                }}>Update Character</button>

                <button className="buttons" onClick={() => {
                    setCharImage("")
                    setCharName("")
                    setRarity(0)
                    setElement(0)
                    setPath(0)
                    setBaseHP(0)
                    setBaseAtk(0)
                    setBaseDef(0)
                    setBaseSpd(0)
                    skills.forEach(skill => skill.name = "")
                    skills.forEach(skill => skill.description = "")
                    eidolons.forEach(eidolon => eidolon.name = "")
                    eidolons.forEach(eidolon => eidolon.description = "")
                    traces.forEach(trace => trace.name = "")
                    traces.forEach(trace => trace.description = "")
                }}>Clear</button>
            </div>
        </div>
    )
}

export default CharacterUpdatePage;