import React from "react";

import cn from "classnames";
import PropTypes from "prop-types";

import GLOBALS from "app-globals";

import { Icon } from "../..";
import iconButtonTypes from "../constants/iconButtonTypes";

import styles from "../icon.module.scss";

const IconButton = ({
  icon,
  className,
  iconClassName,
  onClick,
  disabled,
  type,
  kind,
  id,
}) => {
  return (
    <button
      className={cn(className, styles[`IconButton___${type}`])}
      disabled={disabled}
      id={id}
      type={kind}
      onClick={disabled === false ? onClick || (() => {}) : null}
    >
      <Icon className={cn(styles.IconButton_icon, iconClassName)} icon={icon} />
    </button>
  );
};

IconButton.defaultProps = {
  className: null,
  onClick: null,
  iconClassName: null,
  disabled: false,
  type: iconButtonTypes.SOLID.XL,
  kind: GLOBALS.BUTTON_KINDS.BUTTON,
  id: null,
};

IconButton.propTypes = {
  type: PropTypes.oneOf([
    iconButtonTypes.SOLID.LG,
    iconButtonTypes.SOLID.MD,
    iconButtonTypes.SOLID.SM,
    iconButtonTypes.SOLID.XS,
    iconButtonTypes.SOLID.XL,
  ]),
  className: PropTypes.string,
  icon: PropTypes.string.isRequired,
  onClick: PropTypes.func,
  iconClassName: PropTypes.string,
  disabled: PropTypes.bool,
  kind: PropTypes.oneOf([
    GLOBALS.BUTTON_KINDS.BUTTON,
    GLOBALS.BUTTON_KINDS.SUBMIT,
    GLOBALS.BUTTON_KINDS.RESET,
  ]),
  id: PropTypes.string,
};

export default IconButton;
