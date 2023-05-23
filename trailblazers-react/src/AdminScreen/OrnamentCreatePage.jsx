import React, { useState } from "react";
import "./InputPage.css";

export const OrnamentCreatePage = (props) => {
    const [image, setImage] = useState("");
    const [name, setName] = useState("");
    const [effects, setEffect] = useState([{name: "",description: "",},]);

    return (
        <div>
            <div className="pairs">
                <label for="image">Ornament Image</label>
                <input type="text" placeholder="Ornament Set Image Link" value={image} onChange={(e) => setImage(e.target.value)} />
            </div>
            <div className="the-top">
                <img className="picBox" src={image} alt="+"/>
                <div className="pairs">
                    <label for="name">Ornament Name</label>
                    <input type="text" placeholder="Ornament Name" value={name} onChange={(e) => setName(e.target.value)} />
                </div>
            </div>
            <div className="the-top">
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
            <div className="options">
                <button className="buttons" onClick={() => {
                    console.log(image, name, effects); // upload to database code here
                }}>Create Ornament</button>

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

export default OrnamentCreatePage;