import React from 'react';

function CharacterDetailsPopup({ character, onClose }) {
  return (
    <div className="character-details-popup">
      <div className="popup-overlay">
        <div className="popup-content">
          <img src={character.img} alt={character.name} />
          <h2>{character.name}</h2>
          <p>Rarity: {character.rare}</p>
          {/* will think how to add more details here    */}
          <button onClick={onClose}>Close</button>
        </div>
      </div>
    </div>
  );
}

export default CharacterDetailsPopup;