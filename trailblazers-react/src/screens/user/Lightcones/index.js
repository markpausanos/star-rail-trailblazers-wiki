/* eslint-disable no-unused-vars */
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import cn from "classnames";
import {
  Text,
  Container,
  Button,
  Navbar,
  Search,
  ImageButton,
  LightconeModal,
} from "../../../components";
import styles from "./styles.module.scss";
import GLOBALS from "../../../app-globals";
import useDashboard from "../../../hooks/useDashboard";
import { Rarity } from "./constants.js";
import Cookies from "universal-cookie";

const Lightcones = () => {
  const navigate = useNavigate();
  const cookies = new Cookies();
  if (cookies.get("accessToken") == null) {
    navigate("/login");
  }
  const isAdmin = cookies.get("role") === "Admin";
  const { lightcones, paths } = useDashboard();
  const [modalOpen, setModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [rarity, setRarity] = useState(null);
  const [path, setPath] = useState(null);
  const [chosenLightcone, setChosenLightcone] = useState(null);
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

  const pathOnClickHandler = (selectedPath) => {
    if (selectedPath === path) {
      setPath(null);
    } else {
      setPath(selectedPath);
    }
  };

  let res_lightcones = lightcones
    ? lightcones.filter((item) =>
        item.name.toLowerCase().includes(searchTerm.toLowerCase())
      )
    : lightcones;

  res_lightcones =
    res_lightcones && rarity
      ? res_lightcones.filter((item) => item.rarity === rarity)
      : res_lightcones;

  res_lightcones =
    res_lightcones && path
      ? res_lightcones.filter((item) => item.pathSR.name === path)
      : res_lightcones;

  return (
    <>
      <Navbar />

      <div className={styles.Dashboard}>
        <Container className={styles.Dashboard_container}>
          <Button
            className={styles.Dashboard_button}
            onClick={() => navigate("/characters")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
              Trailblazers
            </Text>
          </Button>
          <Button
            className={cn(
              styles.Dashboard_button,
              styles.Dashboard_button_active
            )}
            onClick={() => navigate("/lightcones")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["900"]}>
              Lightcones
            </Text>
          </Button>
          <Button
            className={styles.Dashboard_button}
            onClick={() => navigate("/relics")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>Relics</Text>
          </Button>
          <Button
            className={styles.Dashboard_button}
            onClick={() => navigate("/ornaments")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
              Ornaments
            </Text>
          </Button>
          <hr />
        </Container>
        <Container className={styles.Dashboard_container}>
          <Search onChange={searchOnChangeHandler} />
          {isAdmin && (
            <Button
              className={styles.Dashboard_button_admin}
              // onClick={() => navigate("/ornaments")}
            >
              <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
                Create a Lightcone
              </Text>
            </Button>
          )}
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
              {res_lightcones &&
                res_lightcones.map((item) => {
                  return (
                    <button
                      key={item.id}
                      onClick={() => {
                        setModalOpen(true);
                        setChosenLightcone(item);
                      }}
                      className={cn(styles.Dashboard_CharacterPortrait, {
                        [styles.Dashboard_CharacterPortrait_rarity5]:
                          item.rarity === 5,
                        [styles.Dashboard_CharacterPortrait_rarity4]:
                          item.rarity === 4,
                        [styles.Dashboard_CharacterPortrait_rarity3]:
                          item.rarity === 3,
                      })}
                    >
                      <img src={item.image} alt={item.name} />
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

      {modalOpen && (
        <LightconeModal
          setOpenModal={setModalOpen}
          setChosenLightcone={setChosenLightcone}
          name={chosenLightcone.name}
          title={chosenLightcone.title}
          description={chosenLightcone.description}
          image={chosenLightcone.image}
          rarity={chosenLightcone.rarity}
          pathImage={chosenLightcone.pathSR.image}
        />
      )}
    </>
  );
};

export default Lightcones;
