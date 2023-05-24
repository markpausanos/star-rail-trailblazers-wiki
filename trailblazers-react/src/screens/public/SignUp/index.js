/* eslint-disable no-unused-vars */
import React, { useState, useContext } from "react";
import Cookies from "universal-cookie";
import { Link, useNavigate } from "react-router-dom";

import { Text, Container, Input, Button } from "../../../components";
import styles from "./styles.module.scss";
import { textTypes } from "../../../components/constants";
import GLOBALS from "../../../app-globals";
import { UserContext } from "../../../contexts";
import { UsersService } from "../../../services";
import { buttonTypes } from "../../../components/Button/constants";

const SignUp = () => {
  const cookies = new Cookies();
  const navigate = useNavigate();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = async () => {
    try {
      setError("");
      if (password != confirmPassword) {
        throw 401;
      }
      const body = {
        name: username,
        password: password,
      };
      const { data: loginResponse } = await UsersService.signup(body);
      cookies.set("accessToken", loginResponse, {
        path: "/",
      });
      const { data: user } = await UsersService.retrieveByName(body.name);
      cookies.set("name", user.name);
      navigate("/dashboard");
    } catch (e) {
      setError("Invalid signup");
    }
  };

  return (
    <>
      <div className={styles.SignUp}>
        <Container className={styles.SignUp_container}>
          <Text
            type={textTypes.HEADING.XL}
            colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["900"]}
          >
            SIGN UP
          </Text>
        </Container>
        <Container className={styles.SignUp_container}>
          <form onSubmit={handleSubmit}>
            <Input
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              type="username"
              placeholder="Username"
              id="usernameid"
              name="username"
            />
            <Input
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              type="password"
              placeholder="Password"
              id="passwordid"
              name="password"
            />
            <Input
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              type="password"
              placeholder="Confirm Password"
              id="passwordidconfirm"
              name="passwordconfirm"
            />
          </form>
        </Container>
        <Container>
          <Button type={buttonTypes.PRIMARY.GRAY} onClick={handleSubmit}>
            Sign Up
          </Button>
          <Text
            type={textTypes.BODY.SM}
            colorClass={GLOBALS.COLOR_CLASSES.RED["200"]}
          >
            {error}
          </Text>
        </Container>
        <Container
          type={buttonTypes.SECONDARY.BLUE}
          className={styles.SignUp_container}
        >
          <Button type={buttonTypes.SECONDARY.NONE}>
            <Link to="/login" className={styles.SignUp_no_hyper}>
              <Text type={textTypes.STRONG.MD} className={styles.SignUp_link}>
                Back to Login
              </Text>
            </Link>
          </Button>
        </Container>
      </div>
    </>
  );
};

export default SignUp;
