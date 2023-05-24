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
  RelicModal,
} from "../../../components";
import styles from "./styles.module.scss";
import GLOBALS from "../../../app-globals";
import useDashboard from "../../../hooks/useDashboard";
import Cookies from "universal-cookie";

const Relics = () => {
  const navigate = useNavigate();
  const cookies = new Cookies();
  if (cookies.get("accessToken") == null) {
    navigate("/login");
  }
  const { relics } = useDashboard();
  const [modalOpen, setModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");

  const [chosenRelic, setChosenRelic] = useState(null);
  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };

  let res_relics = relics
    ? relics.filter((item) =>
        item.name.toLowerCase().includes(searchTerm.toLowerCase())
      )
    : relics;

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
            className={styles.Dashboard_button}
            onClick={() => navigate("/lightcones")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
              Lightcones
            </Text>
          </Button>
          <Button
            className={cn(
              styles.Dashboard_button,
              styles.Dashboard_button_active
            )}
            onClick={() => navigate("/relics")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["900"]}>
              Relics
            </Text>
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
        </Container>
        <Container
          className={cn(
            styles.Dashboard_container,
            styles.Dashboard_display_grid
          )}
        ></Container>
        <div>
          <Container className={cn(styles.Dashboard_container)}>
            <div className={styles.Dashboard_characters}>
              {res_relics &&
                res_relics.map((item) => {
                  return (
                    <button
                      key={item.id}
                      onClick={() => {
                        setModalOpen(true);
                        setChosenRelic(item);
                      }}
                      className={cn(styles.Dashboard_CharacterPortrait)}
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
        <RelicModal
          setOpenModal={setModalOpen}
          setChosenRelic={setChosenRelic}
          name={chosenRelic.name}
          image={chosenRelic.image}
          descriptionOne={chosenRelic.descriptionOne}
          descriptionTwo={chosenRelic.descriptionTwo}
        />
      )}
    </>
  );
};

export default Relics;
