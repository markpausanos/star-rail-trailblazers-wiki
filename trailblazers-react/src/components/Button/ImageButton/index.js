import React from "react";
import PropTypes from "prop-types";
import cn from "classnames";
import "./styles.scss";

const ImageButton = ({
  imageSrc,
  altText,
  onClick,
  backgroundColor,
  className,
}) => {
  const buttonStyle = {
    backgroundColor: backgroundColor,
  };

  const buttonClassName = cn("image-button", className);

  return (
    <button className={buttonClassName} style={buttonStyle} onClick={onClick}>
      <img src={imageSrc} alt={altText} />
    </button>
  );
};

ImageButton.propTypes = {
  imageSrc: PropTypes.string.isRequired,
  altText: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
  backgroundColor: PropTypes.string,
  className: PropTypes.string,
};

export default ImageButton;
