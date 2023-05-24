import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import cn from "classnames";
import {
  Text,
  Container,
  Button,
  Navbar,
  Search,
  ImageButton,
  BuildModal,
  BuildModalCreate,
} from "../../../components";
import styles from "./styles.module.scss";
import GLOBALS from "../../../app-globals";
import useDashboard from "../../../hooks/useDashboard";
import useBuilds from "../../../hooks/useBuilds";
import { Rarity } from "./constants.js";
import Cookies from "universal-cookie";

const Builds = () => {
  const navigate = useNavigate();
  const cookies = new Cookies();
  if (cookies.get("accessToken") == null) {
    navigate("/login");
  }
  const { builds, fetchBuilds } = useBuilds(); // Added fetchBuilds function
  const { trailblazers, lightcones, relics, ornaments, elements, paths } =
    useDashboard();
  const [modalOpen, setModalOpen] = useState(false);
  const [modalOpenCreate, setModalOpenCreate] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [rarity, setRarity] = useState(null);
  const [element, setElement] = useState(null);
  const [path, setPath] = useState(null);
  const [chosenBuild, setChosenBuild] = useState(null);
  const [currentBuilds, setCurrentBuilds] = useState(null);
  const [shouldReloadBuilds, setShouldReloadBuilds] = useState(false);

  useEffect(() => {
    let res_builds = builds
      ? builds.filter(
          (item) =>
            item.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
            item.trailblazer.name
              .toLowerCase()
              .includes(searchTerm.toLowerCase())
        )
      : builds;

    res_builds =
      res_builds && rarity
        ? res_builds.filter((item) => item.trailblazer.rarity === rarity)
        : res_builds;

    res_builds =
      res_builds && element
        ? res_builds.filter((item) => item.trailblazer.element.name === element)
        : res_builds;

    res_builds =
      res_builds && path
        ? res_builds.filter((item) => item.trailblazer.pathSR.name === path)
        : res_builds;

    setCurrentBuilds(res_builds);

    if (shouldReloadBuilds) {
      fetchBuilds();
      setShouldReloadBuilds(false); // Reset the reload flag
    }
  }, [builds, searchTerm, rarity, element, path, shouldReloadBuilds]);

  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };

  const rarityOnClickHandler = (selectedRarity) => {
    if (selectedRarity === rarity) {
      setRarity(null);
    } else {
      setRarity(selectedRarity);
    }
  };

  const elementOnClickHandler = (selectedElement) => {
    if (selectedElement === element) {
      setElement(null);
    } else {
      setElement(selectedElement);
    }
  };

  const pathOnClickHandler = (selectedPath) => {
    if (selectedPath === path) {
      setPath(null);
    } else {
      setPath(selectedPath);
    }
  };

  return (
    <>
      <Navbar />

      <div className={styles.Dashboard}>
        <Container className={styles.Dashboard_container}>
          <Button
            className={cn(
              styles.Dashboard_button,
              styles.Dashboard_button_create
            )}
            onClick={() => setModalOpenCreate(true)}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
              Create A Build
            </Text>
          </Button>
          <hr />
        </Container>
        <Container className={styles.Dashboard_container}>
          <Search onChange={searchOnChangeHandler} />
        </Container>
        <Container
          className={cn(
            styles.Dashboard_container,
            styles.Dashboard_display_grid
          )}
        >
          {Rarity &&
            Rarity.map((item, index) => {
              return (
                <ImageButton
                  key={index}
                  onClick={() => rarityOnClickHandler(item.name)}
                  className={{
                    [styles.Dashboard_button_active]: item.name == rarity,
                  }}
                  imageSrc={item.image}
                  altText={item.name}
                ></ImageButton>
              );
            })}
          <div className={styles.Dashboard_divider} />
          {elements &&
            elements.map((item, index) => {
              return (
                <ImageButton
                  key={index}
                  onClick={() => elementOnClickHandler(item.name)}
                  imageSrc={item.image}
                  className={{
                    [styles.Dashboard_button_active]: item.name == element,
                  }}
                  altText={item.name}
                ></ImageButton>
              );
            })}
          <div className={styles.Dashboard_divider} />
          {paths &&
            paths.map((item, index) => {
              return (
                <ImageButton
                  key={index}
                  onClick={() => pathOnClickHandler(item.name)}
                  imageSrc={item.image}
                  className={{
                    [styles.Dashboard_button_active]: item.name == path,
                  }}
                  altText={item.name}
                ></ImageButton>
              );
            })}
        </Container>
        <div>
          <Container className={cn(styles.Dashboard_container)}>
            <div className={styles.Dashboard_characters}>
              {currentBuilds &&
                currentBuilds.map((item) => {
                  return (
                    <button
                      key={item.id}
                      onClick={() => {
                        setModalOpen(true);
                        setChosenBuild(item);
                      }}
                      className={cn(styles.Dashboard_CharacterPortrait, {
                        [styles.Dashboard_CharacterPortrait_rarity5]:
                          item.trailblazer.rarity === 5,
                        [styles.Dashboard_CharacterPortrait_rarity4]:
                          item.trailblazer.rarity === 4,
                      })}
                    >
                      <img src={item.trailblazer.image} alt={item.name} />
                      <Text className={styles.Dashboard_CharacterPortrait_Text}>
                        {item.name}
                      </Text>
                    </button>
                  );
                })}
            </div>
          </Container>
        </div>
      </div>

      {modalOpen && chosenBuild && (
        <BuildModal
          setOpenModal={setModalOpen}
          setChosenBuild={setChosenBuild}
          id={chosenBuild.id}
          name={chosenBuild.name}
          userName={chosenBuild.user.name}
          likes={chosenBuild.totalLikes}
          isLiked={chosenBuild.isLike}
          trailblazer={chosenBuild.trailblazer}
          lightcone={chosenBuild.lightcone}
          relic={chosenBuild.relic}
          ornament={chosenBuild.ornament}
          rarity={chosenBuild.trailblazer.rarity}
          elementImage={chosenBuild.trailblazer.element.image}
          pathImage={chosenBuild.trailblazer.pathSR.image}
          isOwner={cookies.get("name") === chosenBuild.user.name}
          lightcones={lightcones}
          relics={relics}
          ornaments={ornaments}
          reloadBuilds={() => setShouldReloadBuilds(true)}
        />
      )}

      {modalOpenCreate && (
        <BuildModalCreate
          setOpenModal={setModalOpenCreate}
          trailblazers={trailblazers}
          lightcones={lightcones}
          relics={relics}
          ornaments={ornaments}
          reloadBuilds={() => setShouldReloadBuilds(true)}
        />
      )}
    </>
  );
};

export default Builds;
