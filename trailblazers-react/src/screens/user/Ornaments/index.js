import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import cn from "classnames";
import {
  Text,
  Container,
  Button,
  Navbar,
  Search,
  OrnamentModal,
  OrnamentModalCreate,
} from "../../../components";
import styles from "./styles.module.scss";
import GLOBALS from "../../../app-globals";
import useDashboard from "../../../hooks/useDashboard";
import Cookies from "universal-cookie";

const Ornaments = () => {
  const navigate = useNavigate();
  const cookies = new Cookies();
  if (cookies.get("accessToken") == null) {
    navigate("/login");
  }
  const { ornaments, getDashboardData } = useDashboard();
  const [modalOpen, setModalOpen] = useState(false);
  const [modalOpenCreate, setModalOpenCreate] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const isAdmin = cookies.get("role") === "Admin";
  const [chosenOrnament, setChosenOrnament] = useState(null);
  const [shouldReloadBuilds, setShouldReloadBuilds] = useState(false);

  useEffect(() => {
    if (shouldReloadBuilds) {
      getDashboardData();
      setShouldReloadBuilds(false); // Reset the reload flag
    }
  }, [shouldReloadBuilds]);

  const searchOnChangeHandler = (event) => {
    setSearchTerm(event.target.value);
  };

  let res_ornaments = ornaments
    ? ornaments.filter((item) =>
        item.name.toLowerCase().includes(searchTerm.toLowerCase())
      )
    : ornaments;

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
            className={styles.Dashboard_button}
            onClick={() => navigate("/relics")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>Relics</Text>
          </Button>
          <Button
            className={cn(
              styles.Dashboard_button,
              styles.Dashboard_button_active
            )}
            onClick={() => navigate("/ornaments")}
          >
            <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["900"]}>
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
              onClick={() => setModalOpenCreate(true)}
            >
              <Text colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["0"]}>
                Create an Ornament
              </Text>
            </Button>
          )}
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
              {res_ornaments &&
                res_ornaments.map((item) => {
                  return (
                    <button
                      key={item.id}
                      onClick={() => {
                        setModalOpen(true);
                        setChosenOrnament(item);
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
        <OrnamentModal
          setOpenModal={setModalOpen}
          setChosenOrnament={setChosenOrnament}
          name={chosenOrnament.name}
          image={chosenOrnament.image}
          description={chosenOrnament.description}
        />
      )}

      {modalOpenCreate && (
        <OrnamentModalCreate
          setOpenModal={setModalOpenCreate}
          reloadBuilds={() => setShouldReloadBuilds(true)}
        />
      )}
    </>
  );
};

export default Ornaments;
