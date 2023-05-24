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

const Login = () => {
  const userContext = useContext(UserContext);
  const cookies = new Cookies();
  cookies.remove("accessToken");
  const navigate = useNavigate();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = async () => {
    try {
      setError("");
      const body = {
        name: username,
        password: password,
      };
      const { data: loginResponse } = await UsersService.login(body);
      cookies.set("accessToken", loginResponse, {
        path: "/",
      });
      const { data: user } = await UsersService.retrieveByName(body.name);
      cookies.set("role", user.role);
      userContext.loginUpdate(user);
      navigate("/dashboard");
    } catch (e) {
      setError("Invalid credentials");
    }
  };

  return (
    <>
      <div className={styles.Login}>
        <Container className={styles.Login_container}>
          <Text
            type={textTypes.HEADING.XL}
            colorClass={GLOBALS.COLOR_CLASSES.NEUTRAL["900"]}
          >
            LOGIN
          </Text>
        </Container>
        <Container className={styles.Login_container}>
          <form
            onSubmit={(e) => {
              e.preventDefault();
              handleSubmit();
            }}
          >
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
          </form>
        </Container>
        <Container>
          <Button type={buttonTypes.PRIMARY.GRAY} onClick={handleSubmit}>
            Login
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
          className={styles.Login_container}
        >
          <Button type={buttonTypes.SECONDARY.NONE}>
            <Link to="/sign-up" className={styles.Login_no_hyper}>
              <Text type={textTypes.STRONG.MD} className={styles.Login_link}>
                Create an account
              </Text>
            </Link>
          </Button>
        </Container>
      </div>
    </>
  );
};

export default Login;
