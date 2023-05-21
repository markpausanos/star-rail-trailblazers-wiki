import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router";

export const OrnamentCreatePage = (props) => {
    const [ornamentID, setID] = useState(-1);
    const [image, setImage] = useState("");
    const [name, setName] = useState("");
    const [effects, setEffect] = useState([{name: "",description: "",},]);
    const [ornamentList, setOrnamentList] = useState([]);

    const fetchOrnamentData = () => {
        // Replace with your own logic to fetch ornament data from the databaselightcone
        // This is a placeholder function, you should replace it with your own implementation
        // You can use axios, fetch, or any other library to make the API request
        // Return the fetched ornament data object
    
        // Placeholder data for demonstration
        const ornamentData = [
        {
            id: 0,
            image: "ornament-image-url",
            name: "ornament Name",
            effects: [
            { name: "Effect 1", description: "Effect 1" },
            ],
        },
        ];
    
        return ornamentData;
    };
    
    useEffect(() => {
        // Logic to load ornament data from the database or any other data source
        const ornamentData = fetchOrnamentData(); // Replace with your own function to fetch ornament data
    
        // Update the state with the fetched ornament data
        setOrnamentList(ornamentData);

        // Set the text displayed in the input boxes to the data for the selected ornament
        if (ornamentID >= 0 && ornamentID < ornamentData.length) {
            const selectedOrnament = ornamentData[ornamentID];
            setID(selectedOrnament.id);
            setImage(selectedOrnament.image);
            setName(selectedOrnament.name);
            setEffect(selectedOrnament.effects);
        }
    }, [ornamentID]);

    return (
        <div>
            <div>
            <label htmlFor="ornamentSelect">Select Ornament</label>
            <select
                id="ornamentSelect"
                value={ornamentID}
                onChange={(e) => {
                setID(e.target.value);
                }}
            >
                <option value={-1}>Select a ornament</option>
                {ornamentList.map((ornament) => (
                <option key={ornament.id} value={ornament.id}>
                    {ornament.name}
                </option>
                ))}
            </select>
            </div>
            <div>
                <label for="image">Ornament Image</label>
                <input type="text" placeholder="Ornament Set Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
                <img src={image} />
            </div>
            <input type="text" placeholder="Ornament Name" value={name} onChange={(e) => setName(e.target.value)} />
            <div>
                <label for="effects">Effect</label>
                <ul>
                    {effects.map((effect, index) => (
                        <li key={index}>
                            <label htmlFor={index}>Effect {index}</label>
                            <input type="text" placeholder="Name" value={effect.name} onChange={(e) => setEffect(effects.map((s) => ({...s, name: e.target.value})))} />
                            <input type="text" placeholder="Description" value={effect.description} onChange={(e) => setEffect(effects.map((s) => ({...s, description: e.target.value})))} />
                        </li>
                    ))}
                </ul>
            </div>

            <button onClick={() => {
                console.log(image, name, effects); // upload to database code here
            }}>Create Ornament</button>

            <button onClick={() => {
                setImage("")
                setName("")
                effects.forEach(effect => effect.name = "")
                effects.forEach(effect => effect.description = "")
            }}>Clear</button>
        </div>
    )
}

export default OrnamentCreatePage;