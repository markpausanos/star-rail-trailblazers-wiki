/* eslint-disable no-unused-vars */
import React from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../Text";
import GLOBALS from "../../../app-globals";
import { textTypes } from "../../constants";
import CharacterInfo from "../../CharacterInfo";

function Modal({
  setOpenModal,
  setChosenLightcone,
  name,
  title,
  description,
  image,
  rarity,
  pathImage,
}) {
  return (
    <div className="modalBackground">
      <div className="modalContainer">
        <div className="titleCloseBtn">
          <img src={pathImage} />
          <button
            onClick={() => {
              setOpenModal(false);
              setChosenLightcone(null);
            }}
          >
            X
          </button>
          <hr />
        </div>
        <div className="title">
          <Text
            colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}
            className={cn(textTypes.HEADING.XL, "modalText")}
          >
            {name}
          </Text>
          <img
            src={image}
            className={cn("modalImage", {
              rarity5: rarity && rarity === 5,
              rarity4: rarity && rarity === 4,
              rarity3: rarity && rarity === 3,
            })}
          />
          <hr style={{ width: "80%", marginTop: "20px" }} />
        </div>
        <div className="body">
          <div>
            <Text
              type={textTypes.HEADING.LG}
              className={"character-info-header"}
            >
              Description
            </Text>
            <br></br>
            <div>
              <CharacterInfo
                key={1}
                iconSrc={image}
                title={title}
                name={name}
                description={description}
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

Modal.propTypes = {
  setOpenModal: PropTypes.func.isRequired,
  setChosenLightcone: PropTypes.func.isRequired,
  name: PropTypes.string.isRequired,
  image: PropTypes.string.isRequired,
  title: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired,
  rarity: PropTypes.number.isRequired,
  pathImage: PropTypes.string.isRequired,
};

export default Modal;
