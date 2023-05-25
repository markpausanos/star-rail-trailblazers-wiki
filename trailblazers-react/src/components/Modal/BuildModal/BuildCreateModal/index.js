/* eslint-disable no-unused-vars */
/* eslint-disable react/prop-types */
import React, { useState } from "react";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import Select from "react-select";
import * as Services from "../../../../services";

const Modal = ({
  setOpenModal,
  trailblazers,
  lightcones,
  relics,
  ornaments,
  reloadBuilds,
}) => {
  const [buildName, setBuildName] = useState(null);
  const [selectedTrailblazer, setSelectedTrailblazer] = useState(null);
  const [selectedLightcone, setSelectedLightcone] = useState(null);
  const [selectedRelic, setSelectedRelic] = useState(null);
  const [selectedOrnament, setSelectedOrnament] = useState(null);
  const [availableLightcones, setAvailableLightcones] = useState(lightcones);
  const [available, setAvailable] = useState(true);
  const [errorMessage, setErrorMessage] = useState("");

  console.log(lightcones);
  const handleTrailblazerChange = (selectedOption) => {
    setSelectedLightcone(null);
    setSelectedTrailblazer(selectedOption);
    setAvailable(true);
    if (selectedOption) {
      const selectedTrailblazer = trailblazers.find(
        (item) => item.id === selectedOption.value
      );

      if (selectedTrailblazer && selectedTrailblazer.pathSR) {
        const filteredLightcones = lightcones.filter(
          (x) => x.pathSR && x.pathSR.name === selectedTrailblazer.pathSR.name
        );

        setAvailableLightcones(filteredLightcones);
        setAvailable(false);
      } else {
        setAvailableLightcones(lightcones);
        setAvailable(true);
      }
    } else {
      setAvailableLightcones(lightcones);
      setAvailable(true);
    }
  };

  const handleLightconeChange = (selectedOption) => {
    setSelectedLightcone(selectedOption);
  };

  const handleRelicChange = (selectedOption) => {
    setSelectedRelic(selectedOption);
  };

  const handleOrnamentChange = (selectedOption) => {
    setSelectedOrnament(selectedOption);
  };

  const handleCreate = async () => {
    // Handle create button click with the selected values
    if (
      selectedTrailblazer &&
      selectedLightcone &&
      selectedRelic &&
      selectedOrnament
    ) {
      setErrorMessage("");

      const buildToCreate = {
        name: buildName,
        trailblazerId: selectedTrailblazer.value,
        lightconeId: selectedLightcone.value,
        relicId: selectedRelic.value,
        ornamentId: selectedOrnament.value,
      };
      try {
        await Services.BuildsService.create(buildToCreate);

        setErrorMessage("Created");
        setTimeout(() => {
          setOpenModal(false);
        }, 1000);
        reloadBuilds();
      } catch (error) {
        setErrorMessage("Error occurred during creation.");
      }
    } else {
      setErrorMessage("Fields are incomplete.");
      setTimeout(() => {
        setErrorMessage("");
      }, 5000);
    }
  };

  return (
    <div className="build-modalBackground">
      <div className="build-modalContainer">
        <div className="build-titleCloseBtn">
          <button onClick={() => setOpenModal(false)}>X</button>
        </div>

        <div className="build-modal-footer"></div>
        <Text className="build-error">{errorMessage}</Text>
        <Text className="build-text">Enter build name</Text>
        <input
          className="build-input"
          value={buildName}
          onChange={(e) => setBuildName(e.target.value)}
          name="username"
        />
        <Text className="build-text">Choose a Trailblazer</Text>
        <Select
          className="build-select"
          value={selectedTrailblazer}
          onChange={handleTrailblazerChange}
          options={trailblazers.map((trailblazer) => ({
            label: trailblazer.name,
            value: trailblazer.id,
          }))}
        />
        <Text className="build-text">Choose a Lightcone</Text>
        <Select
          className="build-select"
          value={selectedLightcone}
          onChange={handleLightconeChange}
          options={availableLightcones.map((lightcone) => ({
            label: lightcone.name,
            value: lightcone.id,
          }))}
          isDisabled={available}
        />

        <Text className="build-text">Choose a Relic</Text>
        <Select
          className="build-select"
          value={selectedRelic}
          onChange={handleRelicChange}
          options={relics.map((relic) => ({
            label: relic.name,
            value: relic.id,
          }))}
        />

        <Text className="build-text">Choose an Ornament</Text>
        <Select
          className="build-select"
          value={selectedOrnament}
          onChange={handleOrnamentChange}
          options={ornaments.map((ornament) => ({
            label: ornament.name,
            value: ornament.id,
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
  trailblazers: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
    })
  ).isRequired,
  lightcones: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
    })
  ).isRequired,
  relics: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
    })
  ).isRequired,
  ornaments: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
    })
  ).isRequired,
  currentBuilds: PropTypes.any,
};

export default Modal;
