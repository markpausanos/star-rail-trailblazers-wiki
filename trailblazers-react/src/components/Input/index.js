import React from "react";
import PropTypes from "prop-types";
import styles from "./styles.module.scss";
import cn from "classnames";

const Input = ({
  className,
  id,
  value,
  onChange,
  type,
  placeholder,
  name,
  imageUrl,
}) => (
  <div className={styles.InputContainer}>
    {imageUrl && (
      <img src={imageUrl} alt="Input Icon" className={styles.InputIcon} />
    )}
    <input
      className={cn(styles.Input, className)}
      id={id}
      value={value}
      onChange={onChange}
      type={type}
      placeholder={placeholder}
      name={name}
    />
  </div>
);

Input.propTypes = {
  className: PropTypes.string,
  id: PropTypes.string,
  value: PropTypes.string,
  onChange: PropTypes.func,
  type: PropTypes.string,
  placeholder: PropTypes.string,
  name: PropTypes.string,
  imageUrl: PropTypes.string,
};

export default Input;
