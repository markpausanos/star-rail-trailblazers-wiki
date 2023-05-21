import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router";

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
    const [skillIDs, setSkillIDs] = useState([]);
    const [skills, setSkills] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [eidolonIDs, setEidolonIDs] = useState([]);
    const [eidolons, setEidolons] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [traceIDs, setTraceIDs] = useState([]);
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
            image: "character-image-url",
            name: "Character Name",
            rarityId: 5,
            elementId: 1,
            pathId: 2,
            baseHP: 1000,
            baseAtk: 500,
            baseDef: 300,
            baseSpd: 200,
            skills: [
            { name: "Skill 1", description: "Description 1" },
            { name: "Skill 2", description: "Description 2" },
            { name: "Skill 3", description: "Description 3" },
            { name: "Skill 4", description: "Description 4" },
            { name: "Skill 5", description: "Description 5" },
            ],
            eidolons: [
            { name: "Eidolon 1", description: "Description 1" },
            { name: "Eidolon 2", description: "Description 2" },
            { name: "Eidolon 3", description: "Description 3" },
            { name: "Eidolon 4", description: "Description 4" },
            { name: "Eidolon 5", description: "Description 5" },
            { name: "Eidolon 6", description: "Description 6" },
            ],
            traces: [
            { name: "Trace 1", description: "Description 1" },
            { name: "Trace 2", description: "Description 2" },
            { name: "Trace 3", description: "Description 3" },
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
            <div>
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
            <div>
                <label for="characterImage">Character Image</label>
                <input type="text" placeholder="Character Image Link" value={charImage} onChange={(e) => setCharImage(e.target.value)} />
                <img src={charImage} />
            </div>
            <input type="text" placeholder="Character Name" value={charName} onChange={(e) => setCharName(e.target.value)} />
            <label for="rarity">Rarity</label>
            <select value={rarity} onChange={(e) => setRarity(e.target.value)}>
                <option value="4">4 Star</option>
                <option value="5">5 Star</option>
            </select>
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
            <div>
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

            <button onClick={() => {
                console.log(charImage, charName, rarity, element, path, baseHP, baseAtk, baseDef, baseSpd, skills, eidolons, traces); // upload to database code here
            }}>Update Character</button>

            <button onClick={() => {
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
    )
}

export default CharacterUpdatePage;