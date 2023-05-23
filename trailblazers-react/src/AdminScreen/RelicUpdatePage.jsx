import React, { useState, useEffect } from "react";
import "./InputPage.css";

export const RelicUpdatePage = (props) => {
    const [relicID, setID] = useState(-1);
    const [image, setImage] = useState("");
    const [name, setName] = useState("");
    const [effects, setEffect] = useState([{name: "",description: "",},{name: "",description: "",},]);
    const [relicList, setRelicList] = useState([]);

    const fetchRelicData = () => {
        // Replace with your own logic to fetch relic data from the database
        // This is a placeholder function, you should replace it with your own implementation
        // You can use axios, fetch, or any other library to make the API request
        // Return the fetched relic data object
    
        // Placeholder data for demonstration
        const relicData = [
        {
            id: 0,
            image: "https://rerollcdn.com/STARRAIL/Relics/genius_of_brilliant_stars.png",
            name: "Genius of Brilliant Stars",
            effects: [
            { name: "Effect 1", description: "Increases Quantum DMG by 10%." },
            { name: "Effect 2", description: "When the wearer deals DMG to the target enemy, ignores 10% DEF. If the target enemy has Quantum Weakness, the wearer additionally ignores 10% DEF." },
            ],
        },
        ];
    
        return relicData;
    };
    
    useEffect(() => {
        // Logic to load relic data from the database or any other data source
        const relicData = fetchRelicData(); // Replace with your own function to fetch relic data
    
        // Update the state with the fetched relic data
        setRelicList(relicData);

        // Set the text displayed in the input boxes to the data for the selected relic
        if (relicID >= 0 && relicID < relicData.length) {
            const selectedRelic = relicData[relicID];
            setID(selectedRelic.id);
            setImage(selectedRelic.image);
            setName(selectedRelic.name);
            setEffect(selectedRelic.effects);
        }
    }, [relicID]);

    return (
        <div>
            <div className="pairs">
            <label htmlFor="relicSelect">Select Relic</label>
            <select
                id="relicSelect"
                value={relicID}
                onChange={(e) => {
                setID(e.target.value);
                }}
            >
                <option value={-1}>Select a relic</option>
                {relicList.map((relic) => (
                <option key={relic.id} value={relic.id}>
                    {relic.name}
                </option>
                ))}
            </select>
            </div>
            <div className="pairs">
                <label for="image">Relic Image</label>
                <input type="text" placeholder="Relic Set Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
            </div>
            <div className="the-top">
                <img className="picBox" src={image} alt="+"/>
                <div className="pairs">
                    <label for="image">Relic Name</label>
                    <input type="text" placeholder="Relic Name" value={name} onChange={(e) => setName(e.target.value)} />
                </div>
            </div>
            <div className="the-top">
                <label for="effects">Effects</label>
                <ul>
                    {effects.map((effect, index) => (
                        <li key={index}>
                            <label htmlFor={index}>Effect {index + 1}</label>
                            <input type="text" placeholder="Name" value={effect.name} onChange={(e) => setEffect(effects.map((s) => ({...s, name: e.target.value})))} />
                            <input type="text" placeholder="Description" value={effect.description} onChange={(e) => setEffect(effects.map((s) => ({...s, description: e.target.value})))} />
                        </li>
                    ))}
                </ul>
            </div>
            
            <div className="options">
                <button className="buttons" onClick={() => {
                    console.log(image, name, effects); // upload to database code here
                }}>Create Relic</button>

                <button className="buttons" onClick={() => {
                    setImage("")
                    setName("")
                    effects.forEach(effect => effect.name = "")
                    effects.forEach(effect => effect.description = "")
                }}>Clear</button>
            </div>
        </div>
    )
}

export default RelicUpdatePage;