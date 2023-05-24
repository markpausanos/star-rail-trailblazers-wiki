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
  setChosenRelic,
  name,
  image,
  descriptionOne,
  descriptionTwo,
}) {
  return (
    <div className="modalBackground">
      <div className="modalContainer">
        <div className="titleCloseBtn">
          <img
            src="https://rerollcdn.com/GENSHIN/GameIcons/star-rail-game-icon.png"
            style={{ borderRadius: "50%" }}
          />
          <button
            onClick={() => {
              setOpenModal(false);
              setChosenRelic(null);
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
          <img src={image} />
          <hr style={{ width: "80%", marginTop: "20px" }} />
        </div>
        <div className="body">
          <div>
            <Text
              type={textTypes.HEADING.LG}
              className={"character-info-header"}
            >
              Effects
            </Text>
            <br />
            <div>
              <CharacterInfo
                key={0}
                iconSrc={image}
                title={"Two Bonus"}
                name={"Two Set Bonus"}
                description={descriptionOne}
              />
            </div>
            <div>
              <CharacterInfo
                key={1}
                iconSrc={image}
                title={"Four Bonus"}
                name={"Four Set Bonus"}
                description={descriptionTwo}
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
  setChosenRelic: PropTypes.func.isRequired,
  name: PropTypes.string.isRequired,
  image: PropTypes.string.isRequired,
  descriptionOne: PropTypes.string.isRequired,
  descriptionTwo: PropTypes.string.isRequired,
};

export default Modal;
