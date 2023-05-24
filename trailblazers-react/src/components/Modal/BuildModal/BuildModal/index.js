import React, { useState, useEffect } from "react";
import cn from "classnames";
import PropTypes from "prop-types";
import "./styles.scss";
import Text from "../../../Text";
import GLOBALS from "../../../../app-globals";
import { textTypes } from "../../../constants";
import CharacterInfo from "../../../CharacterInfo";
import { BuildsService } from "../../../../services";
import { BuildUpdateModal } from "../../..";

function Modal({
  setOpenModal,
  setChosenBuild,
  id,
  name,
  userName,
  likes,
  isLiked,
  trailblazer,
  lightcone,
  relic,
  ornament,
  rarity,
  elementImage,
  pathImage,
  isOwner,
  lightcones,
  relics,
  ornaments,
  reloadBuilds,
}) {
  const [liked, setLiked] = useState(isLiked);
  const [modalOpenUpdate, setModalOpenUpdate] = useState(false);
  const [message, setMessage] = useState("");
  const [totalLikes, setTotalLikes] = useState(likes);

  const handleLike = async () => {
    try {
      if (liked) {
        await BuildsService.unlike(id);
        setTotalLikes(totalLikes - 1);
      } else {
        await BuildsService.like(id);
        setTotalLikes(totalLikes + 1);
      }
      setLiked(!liked);
      reloadBuilds();
    } catch (error) {
      setMessage("Error: " + error.message);
    }
  };

  const handleDelete = async () => {
    try {
      await BuildsService.delete(id);
      setOpenModal(false);
      reloadBuilds();
    } catch (error) {
      setMessage("Error: " + error.message);
    }
  };

  useEffect(() => {
    setLiked(isLiked);
  }, [isLiked]);

  return (
    <div className="modalBackground">
      <div className="modalContainer">
        <div className="titleCloseBtn">
          <button
            onClick={() => {
              setOpenModal(false);
              setChosenBuild(null);
            }}
          >
            X
          </button>
          <img src={elementImage} alt="Element" />
          <img src={pathImage} alt="Path" />

          <Text>Made by {userName} </Text>
          <Text>Total likes : {totalLikes ? totalLikes : 0} </Text>
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
            src={trailblazer.image}
            alt="Build"
            className={cn("modalImage", {
              rarity5: rarity && rarity === 5,
              rarity4: rarity && rarity === 4,
            })}
          />
          <Text
            colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}
            className={cn(textTypes.STRONG.MD, "modalText")}
          >
            {trailblazer.name}
          </Text>
          <hr style={{ width: "80%", marginTop: "20px" }} />
        </div>
        <div className="body">
          <div>
            <Text
              type={textTypes.HEADING.LG}
              className={"character-info-header"}
            >
              Build
            </Text>
            <br />
            <div>
              <CharacterInfo
                iconSrc={lightcone.image}
                name={lightcone.name}
                title={"Lightcone"}
              />
              <CharacterInfo
                iconSrc={relic.image}
                name={relic.name}
                title={"Relic"}
              />
              <CharacterInfo
                iconSrc={ornament.image}
                name={ornament.name}
                title={"Ornament"}
              />
            </div>
          </div>
        </div>
        <div className="footer">
          {!isOwner && (
            <>
              <button
                className={liked ? "liked-button" : "like-button"}
                onClick={handleLike}
              >
                {liked ? "Liked" : "Like"}
              </button>
            </>
          )}

          {isOwner && (
            <>
              <button onClick={() => setModalOpenUpdate(true)}>Update</button>
              <button className="delete-button" onClick={handleDelete}>
                Delete
              </button>
            </>
          )}
        </div>
        <div>
          <Text>{message}</Text>
        </div>
        {modalOpenUpdate && (
          <BuildUpdateModal
            setOpenModal={setModalOpenUpdate}
            id={id}
            buildNameDefault={name}
            lightconesDefault={lightcone}
            relicDefault={relic}
            ornamentsDefault={ornament}
            lightcones={lightcones}
            relics={relics}
            ornaments={ornaments}
          />
        )}
      </div>
    </div>
  );
}

Modal.propTypes = {
  setOpenModal: PropTypes.func.isRequired,
  setChosenBuild: PropTypes.func.isRequired,
  id: PropTypes.number.isRequired,
  name: PropTypes.string.isRequired,
  userName: PropTypes.string.isRequired,
  likes: PropTypes.number.isRequired,
  isLiked: PropTypes.bool,
  isOwner: PropTypes.bool,
  trailblazer: PropTypes.shape({
    image: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
  }).isRequired,
  lightcone: PropTypes.shape({
    image: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
    rarity: PropTypes.string.isRequired,
  }).isRequired,
  relic: PropTypes.shape({
    image: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
  }).isRequired,
  ornament: PropTypes.shape({
    image: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
  }).isRequired,
  rarity: PropTypes.number.isRequired,
  elementImage: PropTypes.string.isRequired,
  pathImage: PropTypes.string.isRequired,
  setLikes: PropTypes.func.isRequired,
  lightcones: PropTypes.arrayOf(
    PropTypes.shape({
      image: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
    })
  ).isRequired,
  relics: PropTypes.arrayOf(
    PropTypes.shape({
      image: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
    })
  ).isRequired,
  ornaments: PropTypes.arrayOf(
    PropTypes.shape({
      image: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
    })
  ).isRequired,
  reloadBuilds: PropTypes.any,
};

export default Modal;
