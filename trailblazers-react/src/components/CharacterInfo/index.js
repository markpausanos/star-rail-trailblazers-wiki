import React from "react";
import PropTypes from "prop-types";
import "./styles.scss";

const CharacterInfo = ({ iconSrc, title, name, type, description }) => {
  return (
    <div className="character-info-skill">
      <div className="character-info-skill-header">
        <img className="character-info-skill-icon" src={iconSrc} alt={title} />
        <h3 className="character-info-skill-title">{title}</h3>
      </div>
      <div className="character-info-skill-body">
        <h4 className="character-info-skill-name">{name}</h4>
        <h5 className="character-info-skill-type">{type}</h5>
        <p className="character-info-skill-description">{description}</p>
      </div>
    </div>
  );
};

CharacterInfo.propTypes = {
  iconSrc: PropTypes.string.isRequired,
  title: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  type: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired,
};

export default CharacterInfo;
