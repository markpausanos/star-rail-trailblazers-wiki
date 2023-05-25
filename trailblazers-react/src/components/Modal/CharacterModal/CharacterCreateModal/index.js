import React, { useState } from "react";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import Select from "react-select";
import * as Services from "../../../../services";

const Modal = ({ setOpenModal, elements, paths, reloadBuilds }) => {
  const [trailblazerName, setTrailblazerName] = useState("");
  const [trailblazerImage, setTrailblazerImage] = useState("");
  const [trailblazerRarity, setTrailblazerRarity] = useState(null);
  const [trailblazerElement, setTrailblazerElement] = useState(null);
  const [trailblazerPath, setTrailblazerPath] = useState(null);

  const [message, setMessage] = useState("");

  const handleRarityChange = (selectedOption) =>
    setTrailblazerRarity(selectedOption);
  const handleElementChange = (selectedOption) =>
    setTrailblazerElement(selectedOption);
  const handlePathChange = (selectedOption) =>
    setTrailblazerPath(selectedOption);

  const handleCreate = async () => {
    if (
      !trailblazerName ||
      !trailblazerImage ||
      !trailblazerRarity ||
      !trailblazerElement ||
      !trailblazerPath
    ) {
      setMessage("Please fill in all the required fields");
      return;
    }

    const trailblazerToCreate = {
      name: trailblazerName,
      image: trailblazerImage,
      rarity: trailblazerRarity.value,
      baseHp: 0,
      baseAtk: 0,
      baseDef: 0,
      baseSpeed: 0,
      elementId: trailblazerElement.value,
      pathId: trailblazerPath.value,
    };

    try {
      await Services.TrailblazersService.create(trailblazerToCreate);

      setMessage("Created");
      setTimeout(() => {
        setOpenModal(false);
      }, 1000);
      reloadBuilds();
    } catch (error) {
      setMessage("Error occurred during creation.");
    }
  };

  return (
    <div className="build-modalBackground">
      <div className="build-modalContainer">
        <div className="build-titleCloseBtn">
          <button onClick={() => setOpenModal(false)}>X</button>
        </div>

        <div className="build-modal-footer"></div>
        <Text className="build-error">{message}</Text>
        <Text className="build-text">Enter trailblazer name</Text>
        <input
          className="build-input"
          value={trailblazerName}
          onChange={(e) => setTrailblazerName(e.target.value)}
        />
        <Text className="build-text">Enter trailblazer image url</Text>
        <input
          className="build-input"
          value={trailblazerImage}
          onChange={(e) => setTrailblazerImage(e.target.value)}
        />
        <Select
          className="build-select"
          value={trailblazerRarity}
          onChange={handleRarityChange}
          options={[
            {
              label: "4",
              value: 4,
            },
            {
              label: "5",
              value: 5,
            },
          ]}
        />
        <Select
          className="build-select"
          value={trailblazerElement}
          onChange={handleElementChange}
          options={elements.map((element) => ({
            label: element.name,
            value: element.id,
          }))}
        />
        <Select
          className="build-select"
          value={trailblazerPath}
          onChange={handlePathChange}
          options={paths.map((path) => ({
            label: path.name,
            value: path.id,
          }))}
        />
        <div className="build-modal-footer">
          <button className="build-create-button" onClick={handleCreate}>
            Create
          </button>
        </div>
      </div>
    </div>
  );
};

Modal.propTypes = {
  setOpenModal: PropTypes.func.isRequired,
  elements: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
    })
  ).isRequired,
  paths: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
    })
  ).isRequired,
  reloadBuilds: PropTypes.func.isRequired,
};

export default Modal;
