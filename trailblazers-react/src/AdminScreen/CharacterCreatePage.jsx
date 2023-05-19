import React, { useState } from "react";
import { useNavigate } from "react-router";

export const CharacterCreatePage = (props) => {
    const [charImage, setCharImage] = useState("");
    const [charName, setCharName] = useState("");
    const [rarity, setRarity] = useState(0);
    const [element, setElement] = useState(0);
    const [path, setPath] = useState(0);
    const [baseHP, setBaseHP] = useState(0);
    const [baseAtk, setBaseAtk] = useState(0);
    const [baseDef, setBaseDef] = useState(0);
    const [baseSpd, setBaseSpd] = useState(0);
    const [skills, setSkills] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [eidolons, setEidolons] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);
    const [traces, setTraces] = useState([{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},{name: "",description: "",},]);

    return (
        <div>
            <input type="text" placeholder="Character Image Link" value={charImage} onChange={(e) => setCharImage(e.target.value)} />
            <input type="text" placeholder="Character Name" value={charName} onChange={(e) => setCharName(e.target.value)} />
            <select value={rarity} onChange={(e) => setRarity(e.target.value)}>
                <option value="4">4 Star</option>
                <option value="5">5 Star</option>
            </select>
            <select value={element} onChange={(e) => setElement(e.target.value)}>
                <option value="0">Physical</option>
                <option value="1">Ice</option>
                <option value="2">Wind</option>
                <option value="3">Fire</option>
                <option value="4">Lightning</option>
                <option value="5">Quantum</option>
                <option value="6">Imaginary</option>
            </select>
            <select value={path} onChange={(e) => setPath(e.target.value)}>
                <option value="0">Destruction</option>
                <option value="1">Preservation</option>
                <option value="2">Hunt</option>
                <option value="3">Abundance</option>
                <option value="4">Erudition</option>
                <option value="5">Nihility</option>
                <option value="6">Harmony</option>
            </select>
            <input type="number" placeholder="Base HP" value={baseHP} onChange={(e) => setBaseHP(e.target.value)} />
            <input type="number" placeholder="Base ATK" value={baseAtk} onChange={(e) => setBaseAtk(e.target.value)} />
            <input type="number" placeholder="Base DEF" value={baseDef} onChange={(e) => setBaseDef(e.target.value)} />
            <input type="number" placeholder="Base SPD" value={baseSpd} onChange={(e) => setBaseSpd(e.target.value)} />
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
                console.log(charImage, charName, rarity, element, path, baseHP, baseAtk, baseDef, baseSpd, skills, eidolons, traces);
            }}>Create Character</button>
        </div>
    )
}

export default CharacterCreatePage;