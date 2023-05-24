import React from "react";
import PropTypes from "prop-types";
import "./styles.scss";

const Search = ({ text, onChange }) => {
  return (
    <input
      type="text"
      className="Search"
      placeholder={text}
      onChange={onChange}
    />
  );
};

Search.propTypes = {
  text: PropTypes.string,
  onChange: PropTypes.func,
};

Search.defaultProps = {
  text: "Enter text",
  onChange: () => {},
};

export default Search;
