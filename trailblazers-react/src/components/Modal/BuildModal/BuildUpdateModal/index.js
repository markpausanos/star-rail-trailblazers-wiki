import React, { useState } from "react";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import Select from "react-select";
import * as Services from "../../../../services";

const Modal = ({
  setOpenModal,
  setOpenModalModal,
  id,
  trailblazer,
  buildNameDefault,
  lightconesDefault,
  relicDefault,
  ornamentsDefault,
  lightcones,
  relics,
  ornaments,
  reloadBuilds,
  reloadBuildsModal,
}) => {
  const [buildName, setSelectedBuildName] = useState(buildNameDefault);
  const [selectedLightcone, setSelectedLightcone] = useState(lightconesDefault);
  const [selectedRelic, setSelectedRelic] = useState(relicDefault);
  const [selectedOrnament, setSelectedOrnament] = useState(ornamentsDefault);
  const [errorMessage, setErrorMessage] = useState("");

  lightcones = lightcones.filter(
    (x) => x.pathSR && x.pathSR.name === trailblazer.pathSR.name
  );

  const handleLightconeChange = (selectedOption) => {
    setSelectedLightcone(selectedOption);
  };

  const handleRelicChange = (selectedOption) => {
    setSelectedRelic(selectedOption);
  };

  const handleOrnamentChange = (selectedOption) => {
    setSelectedOrnament(selectedOption);
  };

  const handleUpdate = async () => {
    // Handle create button click with the selected values
    if (selectedLightcone && selectedRelic && selectedOrnament) {
      setErrorMessage("");

      if (buildName === "") {
        setErrorMessage("Name cannot be empty.");
        throw "";
      }
      try {
        await Services.BuildsService.update(id, {
          name: buildName,
          lightconeId: selectedLightcone.value,
          relicId: selectedRelic.value,
          ornamentId: selectedOrnament.value,
        });

        setErrorMessage("Updated");
        setTimeout(() => {
          setOpenModal(false);
          setOpenModalModal(false);
        }, 1000);
        reloadBuilds();
        reloadBuildsModal();
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
          onChange={(e) => setSelectedBuildName(e.target.value)}
          name="username"
        />
        <Text className="build-text">Choose a Lightcone</Text>
        <Select
          className="build-select"
          value={selectedLightcone}
          onChange={handleLightconeChange}
          options={lightcones.map((lightcone) => ({
            label: lightcone.name,
            value: lightcone.id,
          }))}
          defaultInputValue={lightconesDefault.name}
          defaultValue={lightconesDefault.id}
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
          defaultInputValue={relicDefault.name}
          defaultValue={relicDefault.id}
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
          defaultInputValue={ornamentsDefault.name}
          defaultValue={ornamentsDefault.id}
        />

        <div className="build-modal-footer">
          <button className="build-create-button" onClick={handleUpdate}>
            Update
          </button>
        </div>
      </div>
    </div>
  );
};

Modal.propTypes = {
  setOpenModal: PropTypes.func.isRequired,
  id: PropTypes.string.isRequired,
  trailblazer: PropTypes.shape({
    pathSR: PropTypes.shape({
      name: PropTypes.string.isRequired,
    }),
  }),
  buildNameDefault: PropTypes.string.isRequired,
  lightconesDefault: PropTypes.object,
  relicDefault: PropTypes.object,
  ornamentsDefault: PropTypes.object,
  lightcones: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string.isRequired,
      id: PropTypes.number.isRequired,
      pathSR: PropTypes.shape({
        name: PropTypes.string.isRequired,
      }),
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
  reloadBuilds: PropTypes.func.isRequired,
  reloadBuildsModal: PropTypes.func.isRequired,
  setOpenModalModal: PropTypes.func.isRequired,
};

export default Modal;
