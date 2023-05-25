import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import {
  Builds,
  Lightcones,
  Login,
  Ornaments,
  Relics,
  SignUp,
  Dashboard,
} from "./screens";
import "./styles/App.scss";

function App() {
  return (
    <Routes>
      <Route path="/" exact element={<Login />} />
      <Route path="/login" element={<Login />} />
      <Route path="/sign-up" element={<SignUp />} />
      <Route path="/dashboard" element={<Dashboard />} />
      <Route path="/characters" element={<Dashboard />} />
      <Route path="/lightcones" element={<Lightcones />} />
      <Route path="/ornaments" element={<Ornaments />} />
      <Route path="/relics" element={<Relics />} />
      <Route path="/builds" element={<Builds />} />
      <Route path="*" element={<Navigate to="/" />} />
    </Routes>
  );
}

export default App;
