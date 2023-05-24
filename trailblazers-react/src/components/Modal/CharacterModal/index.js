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
  setChosenTrailblazer,
  name,
  image,
  rarity,
  elementImage,
  pathImage,
  skills,
  eidolons,
  traces,
}) {
  return (
    <div className="modalBackground">
      <div className="modalContainer">
        <div className="titleCloseBtn">
          <img src={elementImage} />
          <img src={pathImage} />
          <button
            onClick={() => {
              setOpenModal(false);
              setChosenTrailblazer(null);
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
        </div>
        <div className="title">
          <img
            src={image}
            className={cn("modalImage", {
              rarity5: rarity && rarity === 5,
              rarity4: rarity && rarity === 4,
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
              Skills
            </Text>
            <br></br>
            {skills &&
              skills.map((item) => (
                <>
                  <div>
                    <CharacterInfo
                      key={item.id}
                      iconSrc={item.image}
                      title={item.name}
                      name={item.title}
                      description={item.description}
                    />
                  </div>
                </>
              ))}
          </div>
        </div>
        <div className="body">
          <div>
            <Text
              type={textTypes.HEADING.LG}
              className={"character-info-header"}
            >
              Eidolons
            </Text>
            <br></br>
            {eidolons &&
              eidolons.map((item) => (
                <>
                  <div>
                    <CharacterInfo
                      key={item.id}
                      iconSrc={item.image}
                      name={item.name}
                      title={`Eidolon ${item.order}`}
                      description={item.description}
                    />
                  </div>
                </>
              ))}
          </div>
        </div>
        <div className="body">
          <div>
            <Text
              type={textTypes.HEADING.LG}
              className={"character-info-header"}
            >
              Traces
            </Text>
            <br></br>
            {traces &&
              traces.map((item) => (
                <>
                  <div>
                    <CharacterInfo
                      key={item.id}
                      iconSrc={item.image}
                      name={item.name}
                      title={`Ascension ${item.order * 2}`}
                      description={item.description}
                    />
                  </div>
                </>
              ))}
          </div>
        </div>
      </div>
    </div>
  );
}

Modal.propTypes = {
  setOpenModal: PropTypes.func.isRequired,
  setChosenTrailblazer: PropTypes.func.isRequired,
  name: PropTypes.string.isRequired,
  image: PropTypes.string.isRequired,
  rarity: PropTypes.number.isRequired,
  elementImage: PropTypes.string.isRequired,
  pathImage: PropTypes.string.isRequired,
  skills: PropTypes.arrayOf(PropTypes.object),
  eidolons: PropTypes.arrayOf(PropTypes.object),
  traces: PropTypes.arrayOf(PropTypes.object),
};

export default Modal;
