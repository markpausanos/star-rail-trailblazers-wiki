import React from "react";

import cn from "classnames";
import GLOBALS from "../../app-globals";
import PropTypes from "prop-types";

import styles from "./styles.module.scss";

const Container = ({ children, className }) => (
  <div className={cn(styles.Container, className)}>{children}</div>
);

Container.defaultProps = {
  className: null,
  children: null,
  colorClass: null,
};

Container.propTypes = {
  className: PropTypes.string,
  children: PropTypes.any,
  colorClass: PropTypes.oneOf([
    GLOBALS.COLOR_CLASSES.NEUTRAL["900"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["800"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["700"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["600"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["500"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["400"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["300"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["200"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["100"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["50"],
    GLOBALS.COLOR_CLASSES.NEUTRAL["0"],
    GLOBALS.COLOR_CLASSES.GRAY["200"],
    GLOBALS.COLOR_CLASSES.GRAY["400"],
    GLOBALS.COLOR_CLASSES.GOLD["0"],
  ]),
};

export default Container;
