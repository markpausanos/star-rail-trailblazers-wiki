import React, { useState } from "react";
import { useNavigate } from "react-router";
import "./InputPage.css";

export const RelicCreatePage = (props) => {
    const [image, setImage] = useState("");
    const [name, setName] = useState("");
    const [effects, setEffect] = useState([{name: "",description: "",},{name: "",description: "",},]);

    return (
        <div>
            <div>
                <label for="image">Relic Image</label>
                <input type="text" placeholder="Relic Set Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
                <img className="picBox" src={image} alt="+"/>
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

export default RelicCreatePage;