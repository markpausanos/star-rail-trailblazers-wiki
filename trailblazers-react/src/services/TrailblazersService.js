import axios from "axios";
import config from "./config";

const BASE_URL = `${config.API_URL}/api/Trailblazers`;

const TrailblazersService = {
  create: (trailblazer) =>
    axios.post("https://localhost:8000/api/Trailblazers"),
  list: () => axios.get(BASE_URL),
  retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
  update: (id, updatedTrailblazer) =>
    axios.put(`${BASE_URL}/${id}`, updatedTrailblazer),
};

export default TrailblazersService;
