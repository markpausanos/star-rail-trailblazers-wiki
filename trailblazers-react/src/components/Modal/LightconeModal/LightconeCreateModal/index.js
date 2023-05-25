import React, { useState } from "react";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import Select from "react-select";
import * as Services from "../../../../services";

const Modal = ({ setOpenModal, paths, reloadBuilds }) => {
  const [lightconeTitle, setLightconeTitle] = useState("");
  const [lightconeName, setLightconeName] = useState("");
  const [lightconeDescription, setLightconeDescription] = useState("");
  const [lightconeImage, setLightconeImage] = useState("");
  const [lightconeRarity, setLightconeRarity] = useState(null);
  const [lightconePath, setLightconePath] = useState(null);
  const [message, setMessage] = useState("");

  const handleRarityChange = (selectedOption) =>
    setLightconeRarity(selectedOption);
  const handlePathChange = (selectedOption) => setLightconePath(selectedOption);

  const handleCreate = async () => {
    if (
      !lightconeName ||
      !lightconeImage ||
      !lightconeRarity ||
      !lightconePath
    ) {
      setMessage("Please fill in all the required fields");
      return;
    }

    const lightconeToCreate = {
      title: lightconeTitle,
      name: lightconeName,
      description: lightconeDescription,
      image: lightconeImage,
      rarity: lightconeRarity.value,
      baseHp: 0,
      baseAtk: 0,
      baseDef: 0,
      pathId: lightconePath.value,
    };

    try {
      await Services.LightconesService.create(lightconeToCreate);

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
        <Text className="build-text">Enter lightcone title</Text>
        <input
          className="build-input"
          value={lightconeTitle}
          onChange={(e) => setLightconeTitle(e.target.value)}
        />
        <Text className="build-text">Enter lightcone name</Text>
        <input
          className="build-input"
          value={lightconeName}
          onChange={(e) => setLightconeName(e.target.value)}
        />
        <Text className="build-text">Enter lightcone description</Text>
        <input
          className="build-input-description"
          value={lightconeDescription}
          onChange={(e) => setLightconeDescription(e.target.value)}
        />
        <Text className="build-text">Enter lightcone image url</Text>
        <input
          className="build-input"
          value={lightconeImage}
          onChange={(e) => setLightconeImage(e.target.value)}
        />
        <Text className="build-text">Enter lightcone rarity</Text>
        <Select
          className="build-select"
          value={lightconeRarity}
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
        <Text className="build-text">Enter lightcone path</Text>
        <Select
          className="build-select"
          value={lightconePath}
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
