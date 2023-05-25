import React, { useState } from "react";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import * as Services from "../../../../services";

const Modal = ({ setOpenModal, reloadBuilds }) => {
  const [relicName, setRelicName] = useState("");
  const [relicDescriptionOne, setRelicDescriptionOne] = useState("");
  const [relicDescriptionTwo, setRelicDescriptionTwo] = useState("");
  const [relicImage, setRelicImage] = useState("");
  const [message, setMessage] = useState("");

  const handleCreate = async () => {
    if (!relicName || !relicImage) {
      setMessage("Please fill in all the required fields");
      return;
    }

    const relicToCreate = {
      name: relicName,
      descriptionOne: relicDescriptionOne,
      descriptionTwo: relicDescriptionTwo,
      image: relicImage,
    };

    try {
      await Services.RelicsService.create(relicToCreate);

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
        <Text className="build-text">Enter relic name</Text>
        <input
          className="build-input"
          value={relicName}
          onChange={(e) => setRelicName(e.target.value)}
        />
        <Text className="build-text">Enter two relics bonus effect</Text>
        <input
          className="build-input-description"
          value={relicDescriptionOne}
          onChange={(e) => setRelicDescriptionOne(e.target.value)}
        />
        <Text className="build-text">Enter four relics bonus effect</Text>
        <input
          className="build-input-description"
          value={relicDescriptionTwo}
          onChange={(e) => setRelicDescriptionTwo(e.target.value)}
        />
        <Text className="build-text">Enter relic image url</Text>
        <input
          className="build-input"
          value={relicImage}
          onChange={(e) => setRelicImage(e.target.value)}
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
