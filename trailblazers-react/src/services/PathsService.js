import axios from "axios";
import config from "./config";

const BASE_URL = `${config.API_URL}/api/Paths`;

const PathsService = {
  create: (path) => axios.post(BASE_URL, path),
  list: () => axios.get(BASE_URL),
  retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
  retrieveByName: (name) =>
    axios.get(`${BASE_URL}`, {
      params: {
        name,
      },
    }),
  update: (id, updatedPath) => axios.put(`${BASE_URL}/${id}`, updatedPath),
  delete: (id) => axios.delete(`${BASE_URL}/${id}`),
};

export default PathsService;
