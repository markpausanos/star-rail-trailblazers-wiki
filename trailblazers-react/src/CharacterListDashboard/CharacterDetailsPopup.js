import React from 'react';
import './CharacterDetailsPopup.css';

function CharacterDetailsPopup({ character, onClose }) {
  const openEidolons = () => {
    // Logic for handling the openEidolons button click
    console.log('Open Eidolons');
  };

  const openTraces = () => {
    // Logic for handling the openTraces button click
    console.log('Open Traces');
  };

  const openSkills = () => {
    // Logic for handling the openSkills button click
    console.log('Open Skills');
  };

  return (
    <div className="character-details-popup">
      <div className="popup-overlay">
        <div className="popup-content">
          <img className="character-image" src={character.img} alt={character.name} />
          <h2 className="character-name">{character.name}</h2>
          <p className="character-info">Rarity: {character.rare}</p>
          <p className="character-info">Element: {character.elem}</p>
          <p className="character-info">Path: {character.path}</p>
          <div className="buttons-container">
            <button className="popup-button-eidolon" onClick={openEidolons}>Eidolons</button>
            <button className="popup-button-traces" onClick={openTraces}>Traces</button>
            <button className="popup-button-skills" onClick={openSkills}>Skills</button>
          </div>
          <button className="close-button" onClick={onClose}>Close</button>
        </div>
      </div>
    </div>
  );
}

export default CharacterDetailsPopup;