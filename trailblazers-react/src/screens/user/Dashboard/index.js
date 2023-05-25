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
  CharacterModal,
} from "../../../components";
import styles from "./styles.module.scss";
import GLOBALS from "../../../app-globals";
import useDashboard from "../../../hooks/useDashboard";
import { Rarity } from "./constants.js";
import Cookies from "universal-cookie";

const Dashboard = () => {
  const navigate = useNavigate();
  const cookies = new Cookies();
  if (cookies.get("accessToken") == null) {
    navigate("/login");
  }
  const isAdmin = cookies.get("role") === "Admin";
  const { trailblazers, elements, paths } = useDashboard();
  const [modalOpen, setModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [rarity, setRarity] = useState(null);
  const [element, setElement] = useState(null);
  const [path, setPath] = useState(null);
  const [chosenTrailblazer, setChosenTrailblazer] = useState(null);
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

  let res_trailblazers = trailblazers
    ? trailblazers.filter((item) =>
        item.name.toLowerCase().includes(searchTerm.toLowerCase())
      )
    : trailblazers;

  res_trailblazers =
    res_trailblazers && rarity
      ? res_trailblazers.filter((item) => item.rarity === rarity)
      : res_trailblazers;

  res_trailblazers =
    res_trailblazers && element
      ? res_trailblazers.filter((item) => item.element.name === element)
      : res_trailblazers;

  res_trailblazers =
    res_trailblazers && path
      ? res_trailblazers.filter((item) => item.pathSR.name === path)
      : res_trailblazers;

  return (
    <>
      <Navbar />

      <div className={styles.Dashboard}>
        <Container className={styles.Dashboard_container}>
          <Button
            className={cn(
              styles.Dashboard_button,
              styles.Dashboard_button_active
            )}
            onClick={() => navigate("/characters")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["900"]}>
              Trailblazers
            </Text>
          </Button>
          <Button
            className={styles.Dashboard_button}
            onClick={() => navigate("/lightcones")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
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
                Create a Trailblazer
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
              {res_trailblazers &&
                res_trailblazers.map((item) => {
                  return (
                    <button
                      key={item.id}
                      onClick={() => {
                        setModalOpen(true);
                        setChosenTrailblazer(item);
                      }}
                      className={cn(styles.Dashboard_CharacterPortrait, {
                        [styles.Dashboard_CharacterPortrait_rarity5]:
                          item.rarity === 5,
                        [styles.Dashboard_CharacterPortrait_rarity4]:
                          item.rarity === 4,
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
        <CharacterModal
          setOpenModal={setModalOpen}
          setChosenTrailblazer={setChosenTrailblazer}
          name={chosenTrailblazer.name}
          image={chosenTrailblazer.image}
          rarity={chosenTrailblazer.rarity}
          elementImage={chosenTrailblazer.element.image}
          pathImage={chosenTrailblazer.pathSR.image}
          skills={chosenTrailblazer.skills}
          eidolons={chosenTrailblazer.eidolons}
          traces={chosenTrailblazer.traces}
        />
      )}
    </>
  );
};

export default Dashboard;
