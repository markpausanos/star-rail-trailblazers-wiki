import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router";

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
            image: "relic-image-url",
            name: "relic Name",
            effects: [
            { name: "Effect 1", description: "Effect 1" },
            { name: "Effect 2", description: "Effect 2" },
            ],
        },
        ];
    
        return relicData;
    };
    
    useEffect(() => {
        // Logic to load character data from the database or any other data source
        const ligthconeData = fetchRelicData(); // Replace with your own function to fetch character data
    
        // Update the state with the fetched character data
        setRelicList(ligthconeData);

        // Set the text displayed in the input boxes to the data for the selected character
        if (relicID >= 0 && relicID < ligthconeData.length) {
            const selectedCharacter = ligthconeData[relicID];
            setID(selectedCharacter.id);
            setImage(selectedCharacter.image);
            setName(selectedCharacter.name);
            setEffect(selectedCharacter.effects);
        }
    }, [relicID]);

    return (
        <div>
            <div>
            <label htmlFor="relicSelect">Select Light Cone</label>
            <select
                id="relicSelect"
                value={relicID}
                onChange={(e) => {
                setID(e.target.value);
                }}
            >
                <option value={-1}>Select a light cone</option>
                {relicList.map((relic) => (
                <option key={relic.id} value={relic.id}>
                    {relic.name}
                </option>
                ))}
            </select>
            </div>
            <div>
                <label for="image">Relic Image</label>
                <input type="text" placeholder="Relic Set Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
                <img src={image} />
            </div>
            <input type="text" placeholder="Relic Name" value={name} onChange={(e) => setName(e.target.value)} />
            <div>
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

            <button onClick={() => {
                console.log(image, name, effects); // upload to database code here
            }}>Create Relic</button>

            <button onClick={() => {
                setImage("")
                setName("")
                effects.forEach(effect => effect.name = "")
                effects.forEach(effect => effect.description = "")
            }}>Clear</button>
        </div>
    )
}

export default RelicUpdatePage;