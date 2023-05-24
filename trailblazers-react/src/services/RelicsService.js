import axios from "axios";
import config from "./config";

const BASE_URL = `${config.API_URL}/api/Relics`;

const RelicsService = {
  create: (relic) => axios.post(BASE_URL, relic),
  list: () => axios.get(BASE_URL),
  retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
  retrieveByName: (name) =>
    axios.get(`${BASE_URL}`, {
      params: {
        name,
      },
    }),
  update: (id, updatedRelic) => axios.put(`${BASE_URL}/${id}`, updatedRelic),
  delete: (id) => axios.delete(`${BASE_URL}/${id}`),
};

export default RelicsService;
