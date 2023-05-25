import React from "react";

import cn from "classnames";
import PropTypes from "prop-types";

import GLOBALS from "../../app-globals";

import { buttonTypes } from "./constants";
import styles from "./styles.module.scss";

const Button = ({ children, className, disabled, id, kind, type, onClick }) => {
  return (
    <button
      className={cn(className, styles[`Button___${type}`])}
      disabled={disabled}
      id={id}
      type={kind}
      onClick={onClick}
    >
      {children}
    </button>
  );
};

Button.defaultProps = {
  className: null,
  disabled: false,
  id: null,
  kind: GLOBALS.BUTTON_KINDS.BUTTON,
  type: buttonTypes.PRIMARY.BLACK,
  onClick: () => {},
};

Button.propTypes = {
  kind: PropTypes.oneOf([
    GLOBALS.BUTTON_KINDS.BUTTON,
    GLOBALS.BUTTON_KINDS.SUBMIT,
    GLOBALS.BUTTON_KINDS.RESET,
  ]),
  type: PropTypes.oneOf([
    buttonTypes.PRIMARY.BLACK,
    buttonTypes.PRIMARY.GRAY,
    buttonTypes.SECONDARY.NONE,
  ]),
  children: PropTypes.any.isRequired,
  className: PropTypes.string,
  onClick: PropTypes.func,
  disabled: PropTypes.bool,
  id: PropTypes.string,
};

export default Button;
