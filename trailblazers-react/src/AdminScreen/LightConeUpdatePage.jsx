import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router";
import "./InputPage.css";

export const LightConeUpdatePage = (props) => {
    const [lightconeID, setID] = useState(-1);
    const [image, setImage] = useState("");
    const [name, setName] = useState("");
    const [rarity, setRarity] = useState(0);
    const [path, setPath] = useState(0);
    const [baseHP, setBaseHP] = useState(0);
    const [baseAtk, setBaseAtk] = useState(0);
    const [baseDef, setBaseDef] = useState(0);
    const [effects, setEffect] = useState([{name: "",description: "",},]);
    const [lightconeList, setLightconeList] = useState([]);

    const fetchLightconeData = () => {
        // Replace with your own logic to fetch lightcone data from the database
        // This is a placeholder function, you should replace it with your own implementation
        // You can use axios, fetch, or any other library to make the API request
        // Return the fetched lightcone data object
    
        // Placeholder data for demonstration
        const lightconeData = [
        {
            id: 0,
            image: "https://rerollcdn.com/STARRAIL/LightCones/cruising_in_the_stellar_sea_sm.png",
            name: "Cruising in the Stellar Sea",
            rarityId: 5,
            pathId: 2,
            baseHP: 952,
            baseAtk: 529,
            baseDef: 463,
            effects: [
            { name: "Chase", description: "Increases the wearer's CRIT Rate by  8/10/12/14/16%, and increases their CRIT Rate against enemies with HP less than or equal to 50% by an extra 8/10/12/14/16%. When the wearer defeats an enemy, increase their ATK by  20/25/30/35/40% for 2 turn(s)." },
            ],
        },
        ];
    
        return lightconeData;
    };
    
    useEffect(() => {
        // Logic to load lightcone data from the database or any other data source
        const ligthconeData = fetchLightconeData(); // Replace with your own function to fetch lightcone data
    
        // Update the state with the fetched lightcone data
        setLightconeList(ligthconeData);

        // Set the text displayed in the input boxes to the data for the selected lightcone
        if (lightconeID >= 0 && lightconeID < ligthconeData.length) {
            const selectedLightcone = ligthconeData[lightconeID];
            setID(selectedLightcone.id);
            setImage(selectedLightcone.image);
            setName(selectedLightcone.name);
            setRarity(selectedLightcone.rarityId);
            setPath(selectedLightcone.pathId);
            setBaseHP(selectedLightcone.baseHP);
            setBaseAtk(selectedLightcone.baseAtk);
            setBaseDef(selectedLightcone.baseDef);
            setEffect(selectedLightcone.effects);
        }
    }, [lightconeID]);

    return (
        <div>
            <div>
            <label htmlFor="lightconeSelect">Select Light Cone</label>
            <select
                id="lightconeSelect"
                value={lightconeID}
                onChange={(e) => {
                setID(e.target.value);
                }}
            >
                <option value={-1}>Select a light cone</option>
                {lightconeList.map((lightcone) => (
                <option key={lightcone.id} value={lightcone.id}>
                    {lightcone.name}
                </option>
                ))}
            </select>
            </div>
            <div>
                <label for="image">Light Cone Image</label>
                <input type="text" placeholder="Light Cone Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
                <img className="picBox" src={image} alt="+"/>
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

export default LightConeUpdatePage;