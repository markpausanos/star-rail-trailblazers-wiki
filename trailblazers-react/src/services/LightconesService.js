import axios from "axios";
import config from "./config";

const BASE_URL = `${config.API_URL}/Lightcones`;

const LightconesService = {
  create: (lightcone) => axios.post(BASE_URL, lightcone),
  list: () => axios.get(BASE_URL),
  retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
  retrieveByName: (name) =>
    axios.get(`${BASE_URL}`, {
      params: {
        name,
      },
    }),
  update: (id, updatedLightcone) =>
    axios.put(`${BASE_URL}/${id}`, updatedLightcone),
  delete: (id) => axios.delete(`${BASE_URL}/${id}`),
};

export default LightconesService;
