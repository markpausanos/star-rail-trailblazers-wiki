import axios from "axios";
import config from "./config";

const BASE_URL = `${config.API_URL}/Users`;

const UsersService = {
  signup: (user) => axios.post(`${BASE_URL}/SignUp`, user),
  login: (user) => axios.post(`${BASE_URL}/Login`, user),
  retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
  retrieveByName: (name) => axios.get(`${BASE_URL}/${name}`),
  update: (user) => axios.update(`${BASE_URL}`, user),
  delete: (name) => axios.delete(`${BASE_URL}/${name}`),
};

export default UsersService;
