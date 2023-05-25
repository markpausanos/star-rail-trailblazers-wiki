import React, { useState } from "react";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import * as Services from "../../../../services";

const Modal = ({ setOpenModal, reloadBuilds }) => {
  const [ornamentName, setOrnamentName] = useState("");
  const [ornamentDescription, setOrnamentDescription] = useState("");
  const [ornamentImage, setOrnamentImage] = useState("");
  const [message, setMessage] = useState("");

  const handleCreate = async () => {
    if (!ornamentName || !ornamentImage) {
      setMessage("Please fill in all the required fields");
      return;
    }

    const ornamentToCreate = {
      name: ornamentName,
      description: ornamentDescription,
      image: ornamentImage,
    };

    try {
      await Services.OrnamentsService.create(ornamentToCreate);

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
        <Text className="build-text">Enter ornament name</Text>
        <input
          className="build-input"
          value={ornamentName}
          onChange={(e) => setOrnamentName(e.target.value)}
        />
        <Text className="build-text">Enter ornament description</Text>
        <input
          className="build-input-description"
          value={ornamentDescription}
          onChange={(e) => setOrnamentDescription(e.target.value)}
        />
        <Text className="build-text">Enter ornament image url</Text>
        <input
          className="build-input"
          value={ornamentImage}
          onChange={(e) => setOrnamentImage(e.target.value)}
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
