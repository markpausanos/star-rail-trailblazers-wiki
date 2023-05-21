import React, { useState } from "react";
import { useNavigate } from "react-router";

export const LightConeCreatePage = (props) => {
    const [image, setImage] = useState("");
    const [name, setName] = useState("");
    const [rarity, setRarity] = useState(0);
    const [path, setPath] = useState(0);
    const [baseHP, setBaseHP] = useState(0);
    const [baseAtk, setBaseAtk] = useState(0);
    const [baseDef, setBaseDef] = useState(0);
    const [effects, setEffect] = useState([{name: "",description: "",},]);

    return (
        <div>
            <div>
                <label for="image">Light Cone Image</label>
                <input type="text" placeholder="Light Cone Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
                <img src={image} />
            </div>
            <input type="text" placeholder="Light Cone Name" value={name} onChange={(e) => setName(e.target.value)} />
            <select value={rarity} onChange={(e) => setRarity(e.target.value)}>
                <option value="3">3 Star</option>
                <option value="4">4 Star</option>
                <option value="5">5 Star</option>
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
            <div>
                <label for="Base HP">Base HP</label>
                <input type="number" placeholder="Base HP" value={baseHP} onChange={(e) => setBaseHP(e.target.value)} />
                <label for="Base ATK">Base ATK</label>
                <input type="number" placeholder="Base ATK" value={baseAtk} onChange={(e) => setBaseAtk(e.target.value)} />
                <label for="Base DEF">Base DEF</label>
                <input type="number" placeholder="Base DEF" value={baseDef} onChange={(e) => setBaseDef(e.target.value)} />
            </div>
            <div>
                <label for="effects">Effect</label>
                <ul>
                    {effects.map((effect, index) => (
                        <li key={index}>
                            <input type="text" placeholder="Name" value={effect.name} onChange={(e) => setEffect(effects.map((s) => ({...s, name: e.target.value})))} />
                            <input type="text" placeholder="Description" value={effect.description} onChange={(e) => setEffect(effects.map((s) => ({...s, description: e.target.value})))} />
                        </li>
                    ))}
                </ul>
            </div>

            <button onClick={() => {
                console.log(image, name, rarity, path, baseHP, baseAtk, baseDef, effects); // upload to database code here
            }}>Create Light Cone</button>

            <button onClick={() => {
                setImage("")
                setName("")
                setRarity(0)
                setPath(0)
                setBaseHP(0)
                setBaseAtk(0)
                setBaseDef(0)
                effects.forEach(effect => effect.name = "")
                effects.forEach(effect => effect.description = "")
            }}>Clear</button>
        </div>
    )
}

export default LightConeCreatePage;