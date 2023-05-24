import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import styles from "./styles.scss";
import { textTypes } from "../constants";
import Text from "./index.js";

const CharacterPortrait = ({ image, name, element, elementImage, rarity }) => (
  <button
    className={cn(styles.CharacterPortrait, {
      [styles.rarity5]: rarity === 5,
      [styles.rarity4]: rarity === 4,
    })}
  >
    <img src={image} alt={name} />
    <img src={elementImage} alt={element} />
    <Text className={textTypes.HEADING.LG}>{name}</Text>
  </button>
);

CharacterPortrait.propTypes = {
  image: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  element: PropTypes.string.isRequired,
  elementImage: PropTypes.string.isRequired,
  rarity: PropTypes.number.isRequired,
};

CharacterPortrait.defaultProps = {
  image: "",
  name: "",
  element: "",
  elementImage: "",
  rarity: 0,
};

export default CharacterPortrait;
